namespace HBStore.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public bool Visibility { get; set; }
        public virtual ICollection<Role>? Role { get; set; }


    }
}