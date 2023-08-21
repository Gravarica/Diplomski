﻿using System;
using System.Collections.Generic;

namespace Native.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public User() { }

    public User(int userId, string firstName, string lastName, string email, DateTime dob)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dob;
    }
}
