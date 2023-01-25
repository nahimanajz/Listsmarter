using System;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using Moq;

public class PersonServiceTest
    {
   
    
    private readonly Mock<IRepository<PersonDto>> _repositoryMock; // m
    private readonly PersonService _personService;
    //private readonly ITaskPersonBucketService _taskPersonService;


    public PersonServiceTest()
        {
        
        _repositoryMock= new Mock<IRepository<PersonDto>>();
        //_taskPersonService = new ITaskPersonBucketService();
        _personService = new PersonService(_repositoryMock.Object, null);
    }
    [Fact]
    public void Sum_AddTwoNumbers_ReturnTrue()
    {
        var a = 1;
        var b=1;
        var c = a + b;
        Assert.Equal(c, 2);
    }
    [Fact]
    public void GetAll()
    {
        _repositoryMock.Setup(p=>p.GetAll()).Returns(new List<PersonDto>());
        var result = _personService.GetAll();
      //  Assert.Equals(1, result.Count);
    }
    }

