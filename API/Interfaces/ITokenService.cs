using API.Entities;

namespace API;

public interface ITokenService
{
  public Task<string> CreateTokenAsync(AppUser user);
}
