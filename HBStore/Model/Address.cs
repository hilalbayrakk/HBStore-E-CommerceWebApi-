namespace HBStore.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OpenAddress { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }

        public Company Company { get; set; }

    }
}