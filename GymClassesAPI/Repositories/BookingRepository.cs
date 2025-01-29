using GymClassesAPI.Models;

namespace GymClassesAPI.Repositories
{
    public class BookingRepository
    {
        private readonly List<BookingModel> _bookings = new();

        public IEnumerable<BookingModel> GetAllBookings() => _bookings;

        public IEnumerable<BookingModel> GetBookingsByClassId(Guid classId) =>
            _bookings.Where(b => b.ClassId == classId);

        public void AddBooking(BookingModel booking) => _bookings.Add(booking);

        public IEnumerable<BookingModel> SearchBookings(string? memberName, DateTime? startDate, DateTime? endDate)
        {
            return _bookings
                .Where(b =>
                    (string.IsNullOrEmpty(memberName) || b.MemberName.Equals(memberName, StringComparison.OrdinalIgnoreCase)) &&
                    (!startDate.HasValue || b.ParticipationDate >= startDate) &&
                    (!endDate.HasValue || b.ParticipationDate <= endDate)
                );
        }
    }
}