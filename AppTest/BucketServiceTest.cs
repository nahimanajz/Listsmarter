
using AutoFixture;
using CSharp_intro_1.Common.Business.ResponseMessages;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using FluentAssertions;
using Moq;

namespace App.Tests
{
    public class BucketServiceTest
    {
        private readonly BucketService _bucketService;
        private readonly Mock<IBucketRepository> _bucketRepositoryMock = new Mock<IBucketRepository>();
       
        private  Fixture _fixture ;
        private readonly BucketDto bucketDto;

        public BucketServiceTest()
        {
            _bucketService = new BucketService(_bucketRepositoryMock.Object);

            _fixture = new Fixture();
          
            bucketDto = _fixture.Create<BucketDto>();
           

        }

        [Fact]
        public void Create_VerifyIfBucketTitleDoesnotExist_ReturnCreatedBucket()
        {
            //Arrange

            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Create(It.IsAny<BucketDto>())).Returns(bucketDto);

            //Act
            var createdBucket = _bucketService.Create(bucketDto);
            //Assert
            createdBucket.Title.Should().Be(bucketDto.Title);
        }

        [Fact]
        public void Create_VerifyIfBucketTitleExist_ThrowException()
        {
            //ARRANGE
           
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Create(It.IsAny<BucketDto>())).Returns(bucketDto);

            //ASSERT&Act
            Action action = () => _bucketService.Create(bucketDto);
            action.Should().Throw<Exception>().WithMessage(ResponseMessages.BucketAlreadyExist);
        }

        [Fact]
        public void Update_VerifyIfBucketTitleExist_ThrowException()
        {
            //ARRANGE
           
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(bucketDto);

            //ASSERT&Act
             Action action = () => _bucketService.Update(bucketDto);
            action.Should().Throw<Exception>();
          
        }

        [Fact]
        public void Update_VerifyIfBucketIdDoesnotExist_ThrowException()
        {
            //ARRANGE
           
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto)null);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(bucketDto);
            
            //ASSERT&Act
            Action action = () => _bucketService.Update(bucketDto);
            action.Should().Throw<Exception>().WithMessage(ResponseMessages.BucketNotFound);;
           
        }

        [Fact]
        public void Update_VerifyIfBucketIdExistAndTitleIsNotTaken_ReturnUpdatedBucket()
        {
            //ARRANGE
            
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(bucketDto);
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(bucketDto);

            // Act
            var updatedBucket = _bucketService.Update(bucketDto);
            //ASSERT
           
            updatedBucket.Title.Should().Be(bucketDto.Title);
            updatedBucket.Should().BeSameAs(bucketDto);
            

        }

        [Fact]
        public void Delete_GivenInvalidBucketId_ThrowException()
        {
            //Arrange
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto)null);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            
             
            Action action = () => _bucketService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>().WithMessage(ResponseMessages.BucketNotFound);;
        }

        [Fact]
        public void Delete_GivenInvalidBucketIdWhichHasTask_ThrowException()
        {
            //Arrange
       

            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(bucketDto);
            _bucketRepositoryMock.Setup(service => service.HasBucketTasks(It.IsAny<Guid>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Action action = () => _bucketService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>();
            
        }
        [Fact]
        public void Delete_GivenValidBucketIdWhichHasNoTask_BucketShouldBeRemovedFromList()
        {
            //Arrange
         
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(bucketDto);
            _bucketRepositoryMock.Setup(service => service.HasBucketTasks(It.IsAny<Guid>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
            _bucketService.Delete(Guid.NewGuid());

            //Assert
            _bucketRepositoryMock.Verify(person => person.Delete(It.IsAny<Guid>()), Times.Once());
        }

    }


}
