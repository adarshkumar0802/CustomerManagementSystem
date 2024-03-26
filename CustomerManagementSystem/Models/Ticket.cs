using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CustomerManagementSystem.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int? AgentId { get; set; }

    public string? Status { get; set; }

    public string? ActionRemarks { get; set; }

    
    
    public virtual User? Agent { get; set; }

    public virtual Customer? Customer { get; set; }
    
    public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();


    [JsonIgnore]
    public virtual Product? Product { get; set; }
}
