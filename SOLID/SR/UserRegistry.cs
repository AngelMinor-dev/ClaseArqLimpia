
namespace SOLID.SR
{
    public class User
    { 
        public string Email { get; set; }
        public string Password { get; set; }

    }
    
    public class UserRegistry
    {
        private List<User> Users = new List<User> ();


    }
}
