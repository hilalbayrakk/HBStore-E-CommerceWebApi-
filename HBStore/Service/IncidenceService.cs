namespace HBStore.Service
{
    public class IncidenceService : ControllerBase, IIncidenceService
{
    private readonly IIncidenceRepository _IncidenceRepository;
    public IncidenceService(IIncidenceRepository incidenceRepository)
    {
         _IncidenceRepository = incidenceRepository;
    }

    public IncidenceService(){}

    public async Task<IEnumerable<IncidenceDTO>> GetAllIncidences()
    {
        IEnumerable<IncidenceDTO> incidenceDTOs = await _IncidenceRepository.GetAllIncidences();
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        //todo
        return new List<IncidenceDTO> { new IncidenceDTO(null) };

    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDistrictName(string districtName)
    {
        IEnumerable<IncidenceDTO> incidenceDTOs = await _IncidenceRepository.GetIncidencesByDistrictName(districtName);
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        return new List<IncidenceDTO> { new IncidenceDTO(null) };
    }

    public async Task<IEnumerable<IncidenceDTO>> GetAllIncidencesByUserName(string username)
    {
        IEnumerable<IncidenceDTO> incidenceDTOs = await _IncidenceRepository.GetAllIncidencesByUserName(username);
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        return new List<IncidenceDTO> { new IncidenceDTO(null) };
    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDate(DateTime FirstDate, DateTime LastDate)
    {
        IEnumerable<IncidenceDTO> incidenceDTOs = await _IncidenceRepository.GetIncidencesByDate(FirstDate, LastDate);
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        return new List<IncidenceDTO> { new IncidenceDTO(null) };
    }

    public async Task<IncidenceDTO> GetIncidencesById(int Id)
    {
       IncidenceDTO incidenceDTOs = await _IncidenceRepository.GetIncidencesById(Id);
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        return new IncidenceDTO(null) ;
    }

    public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByName(string name)
    {
        IEnumerable<IncidenceDTO> incidenceDTOs = await _IncidenceRepository.GetIncidencesByName(name);
        if(incidenceDTOs != null)
        {
            return incidenceDTOs;
        }
        return new List<IncidenceDTO> { new IncidenceDTO(null) };
    }

    //todo
    public async Task ChangeIncidenceVisibilityById(int Id)
    {
        var incidence = await _IncidenceRepository.GetIncidencesById(Id); 
        if(incidence != null)
        {
            await ChangeIncidenceVisibilityById(Id);
        }
    }

    //todo
    public async Task<IncidenceDTO> CreateIncidence(Incidence incidence)
    {
        IncidenceDTO incidenceDTO = await _IncidenceRepository.GetIncidencesById(incidence.Id);
        if(incidenceDTO == null)
        {
            return await _IncidenceRepository.CreateIncidence(incidence);
        }
        return new IncidenceDTO(null) ;
    }

    //todo
    public async Task<IncidenceDTO> ChangeIncidence(int Id, Incidence incidence)
    {
        IncidenceDTO incidenceDTO = await _IncidenceRepository.GetIncidencesById(Id);
        if(incidenceDTO != null)
        {
            return await _IncidenceRepository.ChangeIncidence(Id, incidence);
        }
        return new IncidenceDTO(null) ;
    }
}
}