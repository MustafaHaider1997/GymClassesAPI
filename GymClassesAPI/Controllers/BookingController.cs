using GymClassesAPI.Models;
using GymClassesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GymClassesAPI.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingRepository _bookingRepository;
        private readonly ClassRepository _classRepository;

        public BookingController(BookingRepository bookingRepository, ClassRepository classRepository)
        {
            _bookingRepository = bookingRepository;
            _classRepository = classRepository;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingModel bookingRequest)
        {
            var gymClass = _classRepository.GetClassById(bookingRequest.ClassId);
            if (gymClass == null)
                return NotFound("Class not found.");

            if (bookingRequest.ParticipationDate < DateTime.UtcNow.Date)
                return BadRequest("Participation date must be in the future.");

            var classInstance = gymClass.ClassInstances.FirstOrDefault(ci => ci.Date == bookingRequest.ParticipationDate);
            if (classInstance == null)
                return BadRequest("Class does not occur on the selected date.");

            var existingBookings = _bookingRepository.GetBookingsByClassId(gymClass.Id)
                                    .Count(b => b.ParticipationDate == bookingRequest.ParticipationDate);

            if (existingBookings >= classInstance.Capacity)
                return BadRequest("Class is fully booked.");

            _bookingRepository.AddBooking(bookingRequest);
            return CreatedAtAction(nameof(GetBookingById), new { id = bookingRequest.Id }, bookingRequest);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(Guid id)
        {
            var booking = _bookingRepository.GetAllBookings().FirstOrDefault(b => b.Id == id);
            return booking is not null ? Ok(booking) : NotFound("Booking not found.");
        }

        [HttpGet]
        public IActionResult SearchBookings([FromQuery] string? memberName, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var bookings = _bookingRepository.SearchBookings(memberName, startDate, endDate)
                .Select(b => new
                {
                    BookingId = b.Id,
                    MemberName = b.MemberName,
                    ClassName = _classRepository.GetClassById(b.ClassId)?.Name ?? "Unknown",
                    ClassStartTime = _classRepository.GetClassById(b.ClassId)?.StartTime,
                    BookingDate = b.ParticipationDate
                });

            return Ok(bookings);
        }
    }
}
