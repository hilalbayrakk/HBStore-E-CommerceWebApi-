namespace HBStore.Model
{
    public class City
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<District>? Districts { get; set; }
     public virtual ICollection<Address>? Addresses { get; set; }
    }
}