namespace DemoApi.Core.Models;

public class FormViewModel
{
    public DateTime IssuedDate { get; set; }
    
    public DateTime ReturnDate { get; set; }

    public ReaderViewModel? Reader { get; set; }
}
