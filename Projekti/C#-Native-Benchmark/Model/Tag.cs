using System;
using System.Collections.Generic;

namespace Native.Model;

public partial class Tag
{
    public int TagId { get; set; }

    public string? TagName { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
