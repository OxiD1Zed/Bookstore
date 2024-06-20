namespace Bookstore.common.data.entities
{
    public class User
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public string Login { get; set; }

        public User(int id, int idPost, string login)
        {
            Id = id;
            IdPost = idPost;
            Login = login;
        }
    }
}
