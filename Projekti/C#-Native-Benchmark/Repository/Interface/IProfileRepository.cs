﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Repository.Interface
{
    public interface IProfileRepository
    {
        void DeleteProfilesWithPhoneNumber(string phoneNumber);
    }
}
