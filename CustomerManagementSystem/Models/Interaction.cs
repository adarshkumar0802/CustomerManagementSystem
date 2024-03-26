using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CustomerManagementSystem.Models;

public partial class Interaction
{
    public int InteractionId { get; set; }

    public int? TicketId { get; set; }

    public string? InteractionType { get; set; }

    public DateTime? InteractionDate { get; set; }

    public string? InteractionDetails { get; set; }

    [JsonIgnore]
    public virtual Ticket? Ticket { get; set; }

   
}
