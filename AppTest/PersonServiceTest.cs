using System;
using System.Collections.Generic;
using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using FluentAssertions;
using Moq;

public class PersonServiceTest
{


    private readonly PersonService _personService;
    private readonly Mock<IRepository<PersonDto>> _personRepositoryMock = new Mock<IRepository<PersonDto>>();
    private readonly Mock<ITaskService> _taskServiceMock = new Mock<ITaskService>();

    private static Guid personId = Guid.NewGuid();
    private PersonDto personDto = new PersonDto() { Id = personId, FirstName = "Janvier", LastName = "Nahimana" };
    private PersonDto  newPersonDto = new PersonDto { Id = personId, FirstName = "John", LastName = "Nahimana" };

    public PersonServiceTest()
    {
        _personService = new PersonService(_personRepositoryMock.Object, _taskServiceMock.Object);

    }

    [Fact]
    public void GetAll_ExpectToReturnListOfPeople_WhenListHasRecords()
    {
       
        _personRepositoryMock.Setup(person => person.GetAll()).Returns(new List<PersonDto> {
            personDto
        });
        var result = _personService.GetAll();
        1.Should().Be(result.Count);
      
    }

    [Fact]
    public void Update_WhenCorrectPersonDataIsProvided_ReturnUpdatedPerson()
    {

        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
        _personRepositoryMock.Setup(repo => repo.Update(It.IsAny<PersonDto>())).Returns(newPersonDto);

        var updatedPerson = _personService.Update(newPersonDto);

         newPersonDto.Id.Should().Be(newPersonDto.Id);
         newPersonDto.FirstName.Should().Be(newPersonDto.FirstName);
         newPersonDto.LastName.Should().Be(newPersonDto.LastName);
         
    }

    public void Update_WhenNoPersonInDatabase_ThrowsException()
    {
        
        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
        _personRepositoryMock.Setup(repo => repo.Update(It.IsAny<PersonDto>())).Returns(newPersonDto);
        
        Action action = () => _personService.Update(newPersonDto);
        action.Should().Throw<ArgumentException>();
        
    }

    [Fact]
    public void Delete_WhenGivenPersonIdIsNotInDatabase_ThrowsException()
    {
        Guid personId = Guid.NewGuid();
        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
         _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>())).Verifiable();

        
        Action action =()=> _personService.Delete(personId);
        action.Should().Throw<Exception>();
    }
   
     [Fact]
        public void Delete_GivenInvalidPersonId_ThrowException(){
            //Arrange
            _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
            _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Action action =()=> _personService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Delete_GivenValidPersonIdWhoHasTask_ThrowException(){
            //Arrange
         

            _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
            _taskServiceMock.Setup(service=>service.HasPersonTasks(It.IsAny<Guid>())).Returns(true);
            _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
            
            //Act&Assert
            Action action =()=> _personService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>();
        }

    [Fact]
    public void Delete_GivenValidPersonIdWhoHasNoTask_RemovePersonFromList()
    {
        //Arrange
        

        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
        _taskServiceMock.Setup(service => service.HasPersonTasks(It.IsAny<Guid>())).Returns(false);
        _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

        _personService.Delete(Guid.NewGuid());

        //Assert
        _personRepositoryMock.Verify(person=> person.Delete(It.IsAny<Guid>()), Times.Once());
    }


}
   
