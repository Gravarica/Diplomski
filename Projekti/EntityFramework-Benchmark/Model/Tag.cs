using System;
using System.Collections.Generic;

namespace EntityFramework_Benchmark.Model;

public class Tag
{
    public int TagId { get; set; }

    public string? TagName { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
