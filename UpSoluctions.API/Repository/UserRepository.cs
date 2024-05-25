using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password, string repassword)
        {
            var users = new List<User>();
            users.Add( new User { Id = 1, UserName = "batman",  Password = "123456", RePassword = "123456", Role = "manager" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == password && x.RePassword == repassword).FirstOrDefault();
        }
    }
}
