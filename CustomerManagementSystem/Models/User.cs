using System;
using System.Collections.Generic;

namespace CustomerManagementSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? UserRole { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
