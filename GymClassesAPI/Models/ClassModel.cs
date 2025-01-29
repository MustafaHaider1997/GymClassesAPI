namespace GymClassesAPI.Models
{
    public class ClassModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public int Capacity { get; set; }

        public List<ClassInstance> ClassInstances { get; set; } = new();
    }

    public class ClassInstance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
    }
}