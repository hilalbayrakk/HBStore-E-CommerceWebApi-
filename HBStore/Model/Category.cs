namespace HBStore.Model
{
    public class Category
    {
       
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Category>? SubCategories { get; set; } 
    public virtual ICollection<Product>? Products { get; set; } 
    }
}