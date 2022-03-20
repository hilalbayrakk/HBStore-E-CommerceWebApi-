namespace HBStore.Interface
{
    public interface IIncidenceService
    {
        Task<IEnumerable<IncidenceDTO>> GetAllIncidences();
        Task<IEnumerable<IncidenceDTO>> GetIncidencesByDistrictName(string districtName);
        Task<IEnumerable<IncidenceDTO>> GetAllIncidencesByUserName(string username);
        Task<IEnumerable<IncidenceDTO>> GetIncidencesByDate(DateTime FirstDate, DateTime LastDate);
        Task<IncidenceDTO> GetIncidencesById(int Id);
        Task<IEnumerable<IncidenceDTO>> GetIncidencesByName(string name);
        //Task ChangeIncidenceVisibility(Incidence incidence);
        Task ChangeIncidenceVisibilityById(int Id);
        Task<IncidenceDTO> CreateIncidence(Incidence incidence);
        Task<IncidenceDTO> ChangeIncidence(int Id, Incidence incidence);
    }
}