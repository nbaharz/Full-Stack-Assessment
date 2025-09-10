namespace StudentAutomationAPI.Entities
{
    public class Course: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public string? Status { get; set; } 

        // Navigation
        public Teacher Teacher { get; set; } = null!;
    }
}
