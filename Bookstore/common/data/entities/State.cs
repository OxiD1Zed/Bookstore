namespace Bookstore.common.data.entities
{
    public class State
    {
        public int Id { get; set; }
        public string Title {  get; set; }

        public State(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
