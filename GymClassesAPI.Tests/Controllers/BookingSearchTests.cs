using GymClassesAPI.Controllers;
using GymClassesAPI.Models;
using GymClassesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymClassesAPI.Tests.Controllers
{
    public class BookingSearchTests
    {
        private readonly BookingController _controller;
        private readonly BookingRepository _bookingRepository;
        private readonly ClassRepository _classRepository;

        public BookingSearchTests()
        {
            _classRepository = new ClassRepository();
            _bookingRepository = new BookingRepository();
            _controller = new BookingController(_bookingRepository, _classRepository);

            // Create a class for testing
            var testClass = new ClassModel
            {
                Name = "Yoga",
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow.AddDays(5),
                StartTime = TimeSpan.FromHours(10),
                Duration = 60,
                Capacity = 5
            };
            _classRepository.AddClass(testClass);

            // Create test bookings
            _bookingRepository.AddBooking(new BookingModel
            {
                MemberName = "Alice",
                ClassId = testClass.Id,
                ParticipationDate = DateTime.UtcNow.AddDays(2)
            });
        }

        [Fact]
        public void SearchBookings_ByMemberName_ReturnsResults()
        {
            var result = _controller.SearchBookings("Alice", null, null) as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotEmpty(result.Value as dynamic);
        }
    }
}
