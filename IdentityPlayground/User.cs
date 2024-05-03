using Microsoft.AspNetCore.Identity;

namespace IdentityPlayground;

public class User : IdentityUser
{
    public string? Nickname { get; set; }
}
