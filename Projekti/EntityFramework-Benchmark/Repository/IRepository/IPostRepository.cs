﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Repository.IRepository
{
    public interface IPostRepository
    {
        void UpdateUserPosts(int userId, string text);
    }
}
