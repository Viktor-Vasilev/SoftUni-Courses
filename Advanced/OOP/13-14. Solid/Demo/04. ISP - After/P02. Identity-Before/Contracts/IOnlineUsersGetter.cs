﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Identity_Before.Contracts
{
    public interface IOnlineUsersGetter
    {
        IEnumerable<IUser> GetAllUsersOnline();


    }
}
