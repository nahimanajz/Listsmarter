using System;
using System.Collections.Generic;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using Moq;

public class PersonServiceTest
{


    private readonly PersonService _personService;
    private readonly Mock<IRepository<PersonDto>> _personRepositoryMock = new Mock<IRepository<PersonDto>>();
    private readonly Mock<ITaskService> _taskServiceMock = new Mock<ITaskService>();

    

    public PersonServiceTest()
    {
        _personService = new PersonService(_personRepositoryMock.Object, _taskServiceMock.Object);

    }

    [Fact]
    public void GetPeople_ExpectToReturnListOfPeople_WhenListHasRecords()
    {
        //SET UP MOCK AND TELL HO IT BEHAVE

        _personRepositoryMock.Setup(person => person.GetAll()).Returns(new List<PersonDto> {

            new PersonDto(){Id= Guid.NewGuid(), FirstName="Janvier", LastName="Nahimana"}
        });
        var result = _personService.GetAll();
        Assert.Equal(1, result.Count);
    }

    [Fact]
    public void UpdatePerson_WhenCorrectPersonDataIsProvided_ReturnUpdatedPerson()
    {
        //scenario one:test one person is not found then exception is thrown
        var personDto = new PersonDto() { Id = Guid.NewGuid(), FirstName = "Janvier", LastName = "Nahimana" };

        var newPersonDto = new PersonDto { Id = personDto.Id, FirstName = "John", LastName = "Nahimana" };

        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
        _personRepositoryMock.Setup(repo => repo.Update(It.IsAny<PersonDto>())).Returns(newPersonDto);

        var updatedPerson = _personService.Update(newPersonDto);

        Assert.Equal(newPersonDto.Id, updatedPerson.Id);
        Assert.Equal(newPersonDto.FirstName, updatedPerson.FirstName);
        Assert.Equal(newPersonDto.LastName, updatedPerson.LastName);
    }

    public void UpdatePerson_WhenNoPersonInDatabase_ThrowsException()
    {
        var personDto = new PersonDto() { Id = Guid.NewGuid(), FirstName = "Janvier", LastName = "Nahimana" };

        var newPersonDto = new PersonDto { Id = personDto.Id, FirstName = "John", LastName = "Nahimana" };

        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
        _personRepositoryMock.Setup(repo => repo.Update(It.IsAny<PersonDto>())).Returns(newPersonDto);

        Assert.Throws<ArgumentException>(() => _personService.Update(newPersonDto));
    }

    [Fact]
    public void DeletePerson_WhenGivenPersonIdIsNotInDatabase_ThrowsException()
    {
        Guid personId = Guid.NewGuid();
        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
         _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>())).Verifiable();

        Assert.Throws<Exception>(() => _personService.Delete(personId));
    }

    [Fact]
    public void DeletePerson_WhenPersonInDatabase_ReturnNothing()
    {
        Guid personId = Guid.NewGuid();
        var personDto = new PersonDto() { Id = Guid.NewGuid(), FirstName = "Janvier", LastName = "Nahimana" };

        _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
         _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>())).Verifiable();
        _personRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Guid>()), Times.Once());

        Assert.Throws<Exception>( ()=> _personService.Delete(personId));

    }
     [Fact]
        public void DeletePerson_GivenInvalidPersonId_ThenThrowException(){
            //Arrange
            _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((PersonDto)null);
            _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Assert.Throws<Exception>(() => _personService.Delete(Guid.NewGuid()));
        }

        [Fact]
        public void DeletePerson_GivenValidPersonIdWhoHasTask_ThenThrowException(){
            //Arrange
            var personDto = new PersonDto() { Id = Guid.NewGuid(), FirstName = "Janvier", LastName = "Nahimana" };

            _personRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(personDto);
            _taskServiceMock.Setup(service=>service.HasPersonTasks(It.IsAny<Guid>())).Returns(true);
            _personRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
            
            //Act&Assert
            Assert.Throws<Exception>(() => _personService.Delete(Guid.NewGuid()));
        }


}
   
