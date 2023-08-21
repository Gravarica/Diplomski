using System;
using System.Collections.Generic;

namespace EntityFramework_Benchmark.Model;

public partial class Post
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
