namespace DemoApi.Core.Models;

public class Form
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    
    public int ReaderId { get; set; }
    
    public DateTime IssuedDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public Reader? Reader { get; set; }
    
    public Book? Book { get; set; }
}
