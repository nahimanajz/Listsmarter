
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;

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
        public void CreateBucket_VerifyIfBucketTitleDoesnotExist_ThenReturnCreatedBucket()
        {
            //Arrange
           
            var newBucket = new BucketDto { Title = "test bucket" };

            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo=> repo.Create(It.IsAny<BucketDto>())).Returns(newBucket);

            //Act
            var createdBucket = _bucketService.Create(newBucket);
            //Assert
            Assert.Equal(createdBucket.Title, newBucket.Title);
        }

        [Fact]
        public void CreateBucket_VerifyIfBucketTitleExist_ThenThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Create(It.IsAny<BucketDto>())).Returns(newBucket);

            //ASSERT&Act
            Assert.Throws<Exception>(() => _bucketService.Create(newBucket));
        }

        [Fact]
        public void UpdateBucket_VerifyIfBucketTitleExist_ThenThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(newBucket);

            //ASSERT&Act
            Assert.Throws<Exception>(() => _bucketService.Update(newBucket));
        }

        [Fact]
        public void UpdateBucket_VerifyIfBucketIdDoesnotExist_ThenThrowException()
        {
            //ARRANGE
            var newBucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto) null);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(newBucket);
            //ASSERT&Act
            Assert.Throws<Exception>(() => _bucketService.Update(newBucket));
        }

        [Fact]
        public void UpdateBucket_VerifyIfBucketIdExistAndTitleIsNotTaken_ThenReturnUpdatedBucket()
        {
            //ARRANGE
            var bucket = new BucketDto { Title = "test bucket" };
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((bucket));
            _bucketRepositoryMock.Setup(repo => repo.CheckTitleExistence(It.IsAny<string>())).Returns(false);
            _bucketRepositoryMock.Setup(repo => repo.Update(It.IsAny<BucketDto>())).Returns(bucket);
            
            // Act
            var updatedBucket = _bucketService.Update(bucket);
            //ASSERT
            Assert.Equal(updatedBucket.Title, bucket.Title);
            Assert.Same(updatedBucket, bucket);
           
        }

        [Fact]
        public void DeleteBucket_GivenInvalidBucketId_ThenThrowException(){
            //Arrange
            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((BucketDto)null);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));

            //Act&Assert
            Assert.Throws<Exception>(() => _bucketService.Delete(Guid.NewGuid()));
        }

        [Fact]
        public void DeleteBucket_GivenInvalidBucketIdWhichHasTask_ThenThrowException(){
            //Arrange
             var newBucket = new BucketDto { Id= Guid.NewGuid(), Title = "test bucket" };

            _bucketRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(newBucket);
            _taskServiceMock.Setup(service=>service.HasBucketTasks(It.IsAny<Guid>())).Returns(true);
            _bucketRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
            
            //Act&Assert
            Assert.Throws<Exception>(() => _bucketService.Delete(Guid.NewGuid()));
        }
    }
}
