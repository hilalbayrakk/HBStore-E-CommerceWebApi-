using HBStore.Context;
using HBStore.DTO;
using HBStore.Interface;
using HBStore.Model;
using Microsoft.EntityFrameworkCore;

namespace HBStore.Repository
{
    public class IncidenceRepository : IIncidenceRepository
    {
        private readonly HBStoreDbContext _context;

        public IncidenceRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public IncidenceRepository() { }

        //TODO
        public async Task<IncidenceDTO> ChangeIncidence(int Id, Incidence incidence)
        {
            if (!IncidenceExists(Id))
            {
                return null;
            }
            _context.Entry(incidence).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return new IncidenceDTO(incidence);
        }

        public async Task<bool> ChangeIncidenceVisibilityById(int Id)
        {
            var incidence = await _context.Incidences.FindAsync(Id);
            if (incidence == null)
            {
                return false;
            }

            try
            {
                incidence.Visibility = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //todo
        public async Task<IncidenceDTO> CreateIncidence(Incidence incidence)
        {
            await _context.Incidences.AddAsync(incidence);
            await _context.SaveChangesAsync();
            return new IncidenceDTO(incidence);
        }

        public async Task<IEnumerable<IncidenceDTO>> GetAllIncidences()
        {
            List<IncidenceDTO> Incidences = await
            (from incidence in _context.Incidences
             select new IncidenceDTO()
             {
                 Name = incidence.Name,
                 District = incidence.District,
                 Date = incidence.Date,
                 Visibility = incidence.Visibility,
                 Image = incidence.Image,
                 Description = incidence.Description,
                 User = incidence.User
             }).ToListAsync();
            return Incidences;
        }

        public async Task<IEnumerable<IncidenceDTO>> GetAllIncidencesByUserName(string userName)
        {
            IEnumerable<Incidence> Incidences = await _context.Incidences.Where(p => p.User.UserName == userName).Where(p => p.Visibility == true).OrderByDescending(p => p.Date).ToListAsync();
            return ConvertToIncedenceDTO(Incidences);
        }

        public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDate(DateTime firstDate, DateTime lastDate)
        {
            var IncidencesByDate = from x in _context.Incidences
                                   where x.Date >= firstDate.Date
                                   where x.Date <= lastDate.Date
                                   where x.Visibility == true
                                   select x;
            IEnumerable<Incidence> Incidences = await IncidencesByDate.ToListAsync();
            return ConvertToIncedenceDTO(Incidences);
        }

        public async Task<IncidenceDTO> GetIncidencesById(int Id)
        {
            var incidence = await _context.Incidences.Where(p => p.Id == Id).Where(p => p.Visibility == true).FirstOrDefaultAsync();
            return new IncidenceDTO(incidence);
        }

        public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByName(string name)
        {
            IEnumerable<Incidence> Incidences = await _context.Incidences.Where(p => p.Name == name).Where(p => p.Visibility == true).OrderByDescending(p => p.Date).ToListAsync();
            return ConvertToIncedenceDTO(Incidences);
        }

        public async Task<IEnumerable<IncidenceDTO>> GetIncidencesByDistrictName(string districtName)
        {
            IEnumerable<Incidence> Incidences = await _context.Incidences.Where(p => p.District.Name == districtName).Where(p => p.Visibility == true).OrderByDescending(p => p.Date).ToListAsync();
            return ConvertToIncedenceDTO(Incidences);
        }


        private bool IncidenceExists(int id)
        {
            return _context.Incidences.Any(e => e.Id == id);
        }

        private List<IncidenceDTO> ConvertToIncedenceDTO(IEnumerable<Incidence> Incidences)
        {
            List<IncidenceDTO> IncidenceDTOs = new List<IncidenceDTO>();
            foreach (Incidence incedence in Incidences)
            {
                IncidenceDTOs.Add(new IncidenceDTO(incedence));
            }
            return IncidenceDTOs;
        }
    }
}
