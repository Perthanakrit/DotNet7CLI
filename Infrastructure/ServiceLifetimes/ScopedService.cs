using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.ServiceLifetimes;

namespace Infrastructure.ServiceLifetimes
{
    public class ScopedService : IScopedService
    {
        private int _requestedCount;
        public ScopedService() { }

        public int GetRequestedCount()
        {
            _requestedCount = _requestedCount + 1;
            return _requestedCount;
        }
    }
}