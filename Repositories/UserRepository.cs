using jwt_implement.Models;

namespace jwt_implement.Repositories;
public class Repository : IRepository
{
    private readonly IList<User> _users = new List<User>()
    {
        new User()
        {
            Email = "Reynaldo",
            Password = "Reynaldo",
            Role = "Admin"
        },
        new User()
        {
            Email = "Jose",
            Password = "Jose",
            Role = "User"
        },
        new User()
        {
            Email = "Rodriguez",
            Password = "Rodriguez",
            Role = "Manager"
        }
    };

    User IRepository.GetBy(string userName) => _users.FirstOrDefault(x => x.Email.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
}
