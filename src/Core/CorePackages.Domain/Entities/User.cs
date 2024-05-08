﻿using Microsoft.AspNetCore.Identity;

namespace CorePackages.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpTime { get; set; }
}
