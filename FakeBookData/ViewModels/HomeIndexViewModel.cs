using FakeBookData.Models;

namespace FakeBookData.ViewModels
{
    public class HomeIndexViewModel
    {
        public int StartIndex { get; set; }
        public List<Book> Books { get; set; }

    }
}
