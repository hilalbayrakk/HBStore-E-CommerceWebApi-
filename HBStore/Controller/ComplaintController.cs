using HBStore.Model;
using HBStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;


        public ComplaintController (IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost("add")]
        public async Task<Complaint> Add (Complaint complaint)
        {
            await _complaintService.AddComplaint(complaint);
            return complaint;
        }

        [HttpPut("update")]
        public async Task<Complaint> Update([FromQuery]Complaint complaint, int id)
        {
            return await _complaintService.UpdateComplaint(complaint, id);
        }

        [HttpDelete]
        public async Task Delete (Complaint complaint)
        {
            await _complaintService.DeleteComplaint(complaint);
        }

        [HttpGet("getall")]
        public async Task<List<Complaint>>GetComplaintAsync(Complaint complaint)
        {
            return await _complaintService.GetAllComplaint();
        }

        [HttpGet("getbyid")]
        public async Task<Complaint> GetComplaintById([FromQuery]int complaintId)
        {
            return await _complaintService.GetComplaintById(complaintId);
        }

        [HttpGet("getbyname")]
        public async Task<Complaint> GetComplaintByName([FromQuery]string complaintName)
        {
            return await _complaintService.GetComplaintByName(complaintName);
        }

        [HttpGet("getallbycustomerid")]
        public async Task<List<Complaint>>GetAllComplaintByCustomerId(int customerId)
        {
            return await _complaintService.GetAllComplaintByCustomerId(customerId);
        }
    }
}