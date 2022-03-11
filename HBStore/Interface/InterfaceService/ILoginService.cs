using HBStore.DTO;
using HBStore.Model;

namespace HBStore.Interface.InterfaceService
{
    public interface ILoginService
    {
        LoginResponseDTO Authenticate(LoginDTO model);
        Account findAccountById(int id);
    }
}