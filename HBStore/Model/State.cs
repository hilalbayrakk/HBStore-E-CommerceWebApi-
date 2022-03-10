namespace HBStore.Model
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<City>? city { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}