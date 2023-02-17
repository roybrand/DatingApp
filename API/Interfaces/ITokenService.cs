using API.Entities;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string  CreateToken(AppUser user);
    }
}
