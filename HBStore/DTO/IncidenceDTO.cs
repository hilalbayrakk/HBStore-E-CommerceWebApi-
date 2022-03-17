using HBStore.Model;

namespace HBStore.DTO
{
    public class IncidenceDTO
    {
        public string? Name { get; set; }
        public District? District { get; set; }
        public DateTime? Date { get; set; }
        public bool Visibility { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public User? User { get; set; }


        public IncidenceDTO(Incidence incidence)
        {
            Name = incidence.Name;
            District = incidence.District;
            Date = incidence.Date;
            Visibility = incidence.Visibility;
            Image = incidence.Image;
            Description = incidence.Description;
            User = incidence.User;
        }
        public IncidenceDTO() { }
    }
}