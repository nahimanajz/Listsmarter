
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
        private readonly Mock<ITaskService> _taskServiceMock = new Mock<ITaskService>();

        public BucketServiceTest()
        {
            _bucketService = new BucketService(_bucketRepositoryMock.Object, _taskServiceMock.Object);
        }

        [Fact]
        public void Create_VerifyIfBucketTitleDoesnotExist_ReturnCreatedBucket()
        {
            //Arrange

            var newBucket = new BucketDto { Title = "test bucket" };

            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Create(It.IsAny<BucketDto>())).Returns(newBucket);

            //Act
            var createdBucket = _bucketService.Create(newBucket);
            //Assert
            createdBucket.Title.Should().Be(newBucket.Title);
        }

        [Fact]
        public void Create_VerifyIfBucketTitleExist_ThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Create(It.IsAny<BucketDto>())).Returns(newBucket);

            //ASSERT&Act
            Action action = () => _bucketService.Create(newBucket);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Update_VerifyIfBucketTitleExist_ThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(newBucket);

            //ASSERT&Act
             Action action = () => _bucketService.Update(newBucket);
            action.Should().Throw<Exception>();
          
        }

        [Fact]
        public void Update_VerifyIfBucketIdDoesnotExist_ThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto)null);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(newBucket);
            
            //ASSERT&Act
            Action action = () => _bucketService.Update(newBucket);
            action.Should().Throw<Exception>();
           
        }

        [Fact]
        public void Update_VerifyIfBucketIdExistAndTitleIsNotTaken_ReturnUpdatedBucket()
        {
            //ARRANGE
            var bucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((bucket));
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(bucket);

            // Act
            var updatedBucket = _bucketService.Update(bucket);
            //ASSERT
           
            updatedBucket.Title.Should().Be(bucket.Title);
            updatedBucket.Should().BeSameAs(bucket);
            

        }

        [Fact]
        public void Delete_GivenInvalidBucketId_ThrowException()
        {
            //Arrange
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto)null);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Assert.Throws<Exception>(() => _bucketService.Delete(Guid.NewGuid()));
             
            Action action = () => _bucketService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void Delete_GivenInvalidBucketIdWhichHasTask_ThrowException()
        {
            //Arrange
            var newBucket = new BucketDto { Id = Guid.NewGuid(), Title = "test bucket" };

            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(newBucket);
            _taskServiceMock.Setup(service => service.HasBucketTasks(It.IsAny<Guid>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Action action = () => _bucketService.Delete(Guid.NewGuid());
            action.Should().Throw<Exception>();
            
        }
        [Fact]
        public void Delete_GivenValidBucketIdWhichHasNoTask_BucketShouldBeRemovedFromList()
        {
            //Arrange
            var bucketDto = new BucketDto { Id = Guid.NewGuid(), Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(bucketDto);
            _taskServiceMock.Setup(service => service.HasBucketTasks(It.IsAny<Guid>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
            _bucketService.Delete(Guid.NewGuid());

            //Assert
            _bucketRepositoryMock.Verify(person => person.Delete(It.IsAny<Guid>()), Times.Once());
        }

    }


}
