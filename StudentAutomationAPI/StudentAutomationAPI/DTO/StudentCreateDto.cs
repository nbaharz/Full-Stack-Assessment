namespace StudentAutomationAPI.DTO
{
    public class StudentCreateDto
    {
        public Guid UserId { get; set; }   
        public string FullName { get; set; } = null!;
        public string? StudentNumber { get; set; } // opsiyonel
    }
}
