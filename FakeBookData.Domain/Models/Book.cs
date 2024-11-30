namespace FakeBookData.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public List<string> AuthorList { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Publisher { get; set; }
        public DateOnly Year { get; set; }
        public int PageCount { get; set; }
        public int LikeCount { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
