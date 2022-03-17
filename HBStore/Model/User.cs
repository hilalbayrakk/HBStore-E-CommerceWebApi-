namespace HBStore.Model
{
    public class User
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public int? AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }

    }
}