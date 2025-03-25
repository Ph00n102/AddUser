using System;

namespace HosxpUi.Dtos;

public class UserRegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string LoginName { get; set; }
    public string? Cid { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
