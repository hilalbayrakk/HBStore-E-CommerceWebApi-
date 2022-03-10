namespace HBStore.Model
{
    public class Country
    {
         public int Id { get; set; }
    public string? Name { get; set; }
    public int? Code { get; set; }
    public bool HasState { get; set; }
    public virtual ICollection<City>? city { get; set; }
    public virtual ICollection<State>? state { get; set; }
    public virtual ICollection<Address>? Addresses {get;set;}
    }
}