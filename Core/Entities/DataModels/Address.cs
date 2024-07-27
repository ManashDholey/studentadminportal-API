namespace Core.Entities.DataModels
{
    public class Address:BaseTable
    {
        //public Guid Id { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }

        // Navigation Property
        public Guid? StudentId { get; set; }
        public Guid? TeacherId { get; set; }
    }
}
