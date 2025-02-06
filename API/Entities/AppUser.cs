using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get;set; } //nullable flag enabled in project file

    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}
