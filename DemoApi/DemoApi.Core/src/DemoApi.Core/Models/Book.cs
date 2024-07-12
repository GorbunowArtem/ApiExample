using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApi.Core.Models;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Isbn { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public ICollection<Form> Forms { get; } = new List<Form>();
}
