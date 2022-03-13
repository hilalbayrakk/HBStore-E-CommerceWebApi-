using HBStore.Model;

namespace HBStore.Interface.InterfaceRepository
{
    public interface IComplaintRepository
    {

        Task<Complaint> AddComplaint(Complaint complaint);
        Task<Complaint> UpdateComplaint(Complaint complaint);
        Task DeleteComplaint(Complaint complaint);
        Task<List<Complaint>> GetAllComplaint();
        Task<Complaint> GetComplaintById(int complaintId);
        Task<Complaint> GetComplaintByName(string complaintName);
        Task<List<Complaint>> GetAllComplaintByCustomerId(int customerId);
    }
}