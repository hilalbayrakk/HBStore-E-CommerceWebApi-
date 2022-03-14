using HBStore.Model;

namespace HBStore.Interface
{
    public interface IComplaintService
    {
        Task<Complaint> AddComplaint(Complaint complaint);
        Task<Complaint> UpdateComplaint(Complaint complaint, int id);
        Task DeleteComplaint(Complaint complaint);
        Task<List<Complaint>> GetAllComplaint();
        Task<Complaint> GetComplaintById(int complaintId);
        Task<Complaint> GetComplaintByName(string complaintName);
        Task<List<Complaint>> GetAllComplaintByCustomerId(int customerId);

    }
}