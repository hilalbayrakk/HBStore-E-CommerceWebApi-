
namespace HBStore.DTO
{
      public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Visibility { get; set; }

        public AccountDTO()
        {

        }
        public AccountDTO(Account account)
        {
            this.Email = account.Email;
            this.Visibility = account.Visibility;
        }
        public AccountDTO(string email, bool visibility)
        {
            this.Email = email;
            this.Visibility = visibility;
        }

    }
}