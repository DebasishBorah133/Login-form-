using System;
using System.Collections.Generic;

namespace prac1.Entities.DataModels;

public partial class Login
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
