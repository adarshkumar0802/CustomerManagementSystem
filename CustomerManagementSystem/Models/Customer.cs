using System;
using System.Collections.Generic;

namespace CustomerManagementSystem.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerContactDetails { get; set; }

    public int? CustomerAssgAgentId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
