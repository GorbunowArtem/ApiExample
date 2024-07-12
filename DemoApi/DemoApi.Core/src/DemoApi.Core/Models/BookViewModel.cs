namespace DemoApi.Core.Models;

public class BookViewModel
{
    public int Isbn { get; set; }

    public string Title { get; set; } = string.Empty;

    public IEnumerable<FormViewModel> Forms { get; set; } = [];
}
