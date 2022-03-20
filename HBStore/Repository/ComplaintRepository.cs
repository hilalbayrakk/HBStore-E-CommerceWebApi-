namespace HBStore.Repository
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly HBStoreDbContext _context;

        public ComplaintRepository(HBStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Complaint> AddComplaint(Complaint complaint)
        {
            await _context.AddAsync(complaint);
            await _context.SaveChangesAsync();
            return complaint;
        }

        public async Task<Complaint> UpdateComplaint(Complaint complaint)
        {
            var result = _context.Update(complaint);
            await _context.SaveChangesAsync();
            return complaint;
        }

        public async Task DeleteComplaint(Complaint complaint)
        {
            var result = _context.Remove(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Complaint>> GetAllComplaint()
        {
            return await _context.Complaints.ToListAsync();
        }

        public async Task<Complaint> GetComplaintById(int complaintId)
        {
            return await _context.Complaints.SingleOrDefaultAsync(x => x.Id == complaintId);
        }

        public async Task<Complaint> GetComplaintByName(string complaintName)
        {
            var result = await _context.Complaints.FirstOrDefaultAsync(x => x.Name == complaintName);
            return result;
        }
        public async Task<List<Complaint>> GetAllComplaintByCustomerId(int customerId)
        {
            return await _context.Complaints.Where(x => x.CustomerId == customerId).ToListAsync();
        }




    }
}