namespace HBStore.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Visibility { get; set; }
        public virtual ICollection<Role>? Role { get; set; }
        public virtual ICollection<User>Users { get; set; }

        public Account()
        {

        }

        public Account(AccountDTO incomingAccount)
        {
            this.Email = incomingAccount.Email;
            this.Password = incomingAccount.Password;
        }


        public Account(int id, string email, string password, bool visibility)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Visibility = visibility;
        }
    }


}
