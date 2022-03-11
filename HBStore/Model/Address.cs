namespace HBStore.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpenAddress1 { get; set; }
        public string OpenAddress2 { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public Company Company { get; set; }

    }
}