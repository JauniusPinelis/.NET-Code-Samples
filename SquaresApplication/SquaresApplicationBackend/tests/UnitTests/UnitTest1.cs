using NUnit.Framework;
using SquaresApplicationBackend.Api.Models;
using SquaresApplicationBackend.Api.Repositories;
using SquaresApplicationBackend.Api.Services;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Equals_GivenTheSamePoints_ShouldReturnTrue()
        {
            // Arrange
            var point1 = new PointEntity()
            {
                X = 2,
                Y = 3
            };

            var point2 = new PointEntity()
            {
                X = 2,
                Y = 3
            };
            // Act
            var areEqual = point1.Equals(point2);

            //Assert 

            Assert.AreEqual(true, areEqual);
        }

        [Test]
        public void Delete_GivenInvalidId_ExceptionGetsThrown()
        {
            // Interfaces and Mocking
            var dataContext = new DataContext();
            // Arrange
            var repository = new PointRepository();
            var pointService = new PointService();
        }
    }
}