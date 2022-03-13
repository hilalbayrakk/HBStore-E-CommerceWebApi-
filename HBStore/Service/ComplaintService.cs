using HBStore.Context;
using HBStore.Interface.InterfaceRepository;
using HBStore.Interface.InterfaceService;
using HBStore.Model;

namespace HBStore.Service
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public async Task<Complaint> AddComplaint(Complaint complaint)
        {
            var result = await _complaintRepository.GetComplaintByName(complaint.Name);
            if (result == null)
            {
                return await _complaintRepository.AddComplaint(complaint);
            }
            throw new InvalidOperationException("Aynı isimde baska bir sikayet bulunuyor!");
        }

        public async Task<Complaint> UpdateComplaint(Complaint complaint, int id)
        {
            var result = await _complaintRepository.GetComplaintById(id);
            if (result != null)
            {
                result = complaint;
                await _complaintRepository.UpdateComplaint(complaint);
                return complaint;
            }
            throw new InvalidOperationException("Guncellenecek sikayet bulunamadi!");
        }


        public async Task DeleteComplaint(Complaint complaint)
        {
            var result = _complaintRepository.GetComplaintById(complaint.Id);
            if (result != null)
            {
                await _complaintRepository.DeleteComplaint(complaint);
            }
            throw new Exception("Silinecek sikayet bulunamadi!");
        }

        public async Task<List<Complaint>> GetAllComplaint()
        {
            return await _complaintRepository.GetAllComplaint();
        }

        public async Task<Complaint> GetComplaintById(int complaintId)
        {
            return await _complaintRepository.GetComplaintById(complaintId);
        }

        public async Task<Complaint> GetComplaintByName(string complaintName)
        {
            var result = _complaintRepository.GetComplaintByName(complaintName);
            if (result != null)
            {
                return await result;
            }
            throw new InvalidOperationException("Boyle bir sikayet bulunamadi!");
        }

        public async Task<List<Complaint>> GetAllComplaintByCustomerId(int customerId)
        {
            return await _complaintRepository.GetAllComplaintByCustomerId(customerId);
        }



    }
}