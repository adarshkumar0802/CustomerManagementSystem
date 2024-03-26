using System;
using System.Collections.Generic;

namespace CustomerManagementSystem.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Rating { get; set; }

    public string? FeedbackReview { get; set; }

    public string? Category { get; set; }

    public string? Recommendation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
