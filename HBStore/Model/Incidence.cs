namespace HBStore.Model
{
    public class Incidence
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public District? District { get; set; }
        public int DistrictId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public bool Visibility { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

    }
}