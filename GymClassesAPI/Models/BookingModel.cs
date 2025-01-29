namespace GymClassesAPI.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MemberName { get; set; } = string.Empty;
        public Guid ClassId { get; set; }  // The ID of the class being booked
        public DateTime ParticipationDate { get; set; }
    }
}