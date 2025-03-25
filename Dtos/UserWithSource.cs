using System;
using HosxpUi.Models;

namespace HosxpUi.Dtos;

public class UserWithSource
{
    public int Id { get; set; }
    public string LoginName { get; set; }
    public string Role { get; set; }
    public string Cid { get; set; }
    public string Source { get; set; } // Indicates whether it's from User or User2

    public UserWithSource(User user, string source)
    {
        Id = user.id;
        LoginName = user.loginName;
        Role = user.role;
        Cid = user.cid;
        Source = source;
    }
}
