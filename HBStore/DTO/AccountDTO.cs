using HBStore.Model;

namespace HBStore.DTO
{
    [Serializable]
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public bool Visibility { get; set; }

        public AccountDTO()
        {

        }
        public AccountDTO(Account account)
        {
            this.Email = account.Email;
            this.IsBlocked = account.IsBlocked;
            this.Visibility = account.Visibility;
        }
        public AccountDTO(string email, bool isBlocked, bool visibility)
        {
            this.Email = email;
            this.IsBlocked = isBlocked;
            this.Visibility = visibility;
        }

    }
}