using jwt_implement.Models;

namespace jwt_implement.Repositories;

public interface IRepository
{
    User GetBy(string userName);
}
