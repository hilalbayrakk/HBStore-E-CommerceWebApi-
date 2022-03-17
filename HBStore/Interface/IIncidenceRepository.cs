using HBStore.DTO;
using HBStore.Model;

namespace HBStore.Interface
{
    public interface IIncidenceRepository
{
    Task<IEnumerable<IncidenceDTO>> GetAllIncidences();
    Task<IEnumerable<IncidenceDTO>> GetIncidencesByDistrictName(string regionName);
    Task<IEnumerable<IncidenceDTO>> GetAllIncidencesByUserName(string username);
    Task<IEnumerable<IncidenceDTO>> GetIncidencesByDate(DateTime FirstDate, DateTime LastDate);
    Task<IncidenceDTO> GetIncidencesById(int Id);
    Task<IEnumerable<IncidenceDTO>> GetIncidencesByName(string name);
    Task<bool> ChangeIncidenceVisibilityById(int Id);
    Task<IncidenceDTO> CreateIncidence(Incidence incidence);

    //TODO
    Task<IncidenceDTO> ChangeIncidence(int Id, Incidence incidence);   
}
}