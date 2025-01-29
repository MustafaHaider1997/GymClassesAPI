using GymClassesAPI.Controllers;
using GymClassesAPI.Models;
using GymClassesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymClassesAPI.Tests.Controllers
{
    public class BookingControllerTests
    {
        private readonly BookingController _controller;
        private readonly BookingRepository _bookingRepository;
        private readonly ClassRepository _classRepository;
        private readonly ClassModel _testClass;

        public BookingControllerTests()
        {
            _classRepository = new ClassRepository();
            _bookingRepository = new BookingRepository();
            _controller = new BookingController(_bookingRepository, _classRepository);

            // Create a valid class for testing
            _testClass = new ClassModel
            {
                Name = "Yoga",
                StartDate = DateTime.UtcNow.AddDays(1), // Tomorrow
                EndDate = DateTime.UtcNow.AddDays(5), // 5-day class
                StartTime = TimeSpan.FromHours(10),
                Duration = 60,
                Capacity = 5 // Enough slots for bookings
            };

            // Generate class instances (one per day)
            for (DateTime date = _testClass.StartDate; date <= _testClass.EndDate; date = date.AddDays(1))
            {
                _testClass.ClassInstances.Add(new ClassInstance { Date = date, Capacity = _testClass.Capacity });
            }

            _classRepository.AddClass(_testClass); // Add class to repository
        }

        [Fact]
        public void CreateBooking_ValidRequest_ReturnsCreatedResult()
        {
            // Arrange: Create a valid booking request
            var bookingRequest = new BookingModel
            {
                MemberName = "Alice",
                ClassId = _testClass.Id, // Use valid class ID
                ParticipationDate = _testClass.StartDate // Choose a valid date
            };

            // Act: Call the API method
            var result = _controller.CreateBooking(bookingRequest);

            // Assert: Expect a successful booking
            var createdResult = Assert.IsType<CreatedAtActionResult>(result); // Ensure correct response type
            Assert.NotNull(createdResult.Value); // Ensure booking data exists in response
        }
    }
}
