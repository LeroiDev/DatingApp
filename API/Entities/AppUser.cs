using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get;set; } //nullable flag enabled in project file
}
