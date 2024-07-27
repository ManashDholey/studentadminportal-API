namespace studentadminportal_API.DomainModels
{
    public class AddressDTO:BaseTableDTO
    {
        //public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        public Guid? StudentId { get; set; }
        public Guid? TeacherId { get; set; }
    }
}
