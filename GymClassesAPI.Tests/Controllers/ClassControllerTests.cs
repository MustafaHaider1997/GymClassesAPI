using GymClassesAPI.Controllers;
using GymClassesAPI.Models;
using GymClassesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymClassesAPI.Tests.Controllers
{
    public class ClassControllerTests
    {
        private readonly ClassController _controller;
        private readonly ClassRepository _repository;

        public ClassControllerTests()
        {
            _repository = new ClassRepository();
            _controller = new ClassController(_repository);
        }

        [Fact]
        public void CreateClass_ValidRequest_ReturnsCreatedResult()
        {
            var classRequest = new ClassModel
            {
                Name = "Yoga",
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(10),
                StartTime = TimeSpan.FromHours(10),
                Duration = 60,
                Capacity = 15
            };

            var result = _controller.CreateClass(classRequest);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void CreateClass_InvalidCapacity_ReturnsBadRequest()
        {
            var classRequest = new ClassModel
            {
                Name = "Pilates",
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(10),
                StartTime = TimeSpan.FromHours(10),
                Duration = 60,
                Capacity = 0
            };

            var result = _controller.CreateClass(classRequest);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
