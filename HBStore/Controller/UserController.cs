using HBStore.Model;
using HBStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HBStore.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<User> Add(User user)
        {
            await _userService.AddUser(user);
            return user;
        }

        [HttpPut("delete")]
        public async Task Delete(User user)
        {
            await _userService.DeleteUser(user);
        }

        [HttpPut("update")]
        public async Task<User> Update(User user, int id)
        {
            var result = await _userService.UpdateUser(user, id);
            return user;
        }

        [HttpGet("getall")]
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAllUser();
        }

        [HttpGet("getbyid")]
        async Task<User> GetUserById(int userId)
        {
            return await _userService.GetUserById(userId);
        }

        [HttpGet("getbyname")]
        async Task<User> GetUserByUserName(string userName)
        {
            return await _userService.GetUserByUserName(userName);
        }

        [HttpGet("getbyaccountid")]
        async Task<User> GetUserByAccountId(int accountId)
        {
            return await _userService.GetUserByAccountId(accountId);

        }

        [HttpGet("getbygenderid")]
        async Task<List<User>> GetAllUserByGenderId(int genderId)
        {
            return await _userService.GetAllUserByGenderId(genderId);
        }

    }

}