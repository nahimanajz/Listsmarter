﻿
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;
using Moq;

namespace App.Tests
{
    public class BucketServiceTest
    {
        private readonly BucketService _bucketService;
        private readonly Mock<IBucketRepository> _bucketRepositoryMock = new Mock<IBucketRepository>();
        private readonly Mock<ITaskPersonBucketService> _taskPersonAndBucketServiceMock = new Mock<ITaskPersonBucketService>();
        public BucketServiceTest()
        {
          
            _bucketService = new BucketService(_bucketRepositoryMock.Object, _taskPersonAndBucketServiceMock.Object);

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


    }
}