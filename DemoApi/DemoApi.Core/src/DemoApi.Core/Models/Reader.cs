namespace DemoApi.Core.Models;

public class Reader
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
    
    public ICollection<Form> Forms { get; } = new List<Form>();
}