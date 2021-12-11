﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.EF.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
