namespace Bookstore.common.data.entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }   

        public Post(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
