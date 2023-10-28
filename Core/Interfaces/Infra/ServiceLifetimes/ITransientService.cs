using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Infra.ServiceLifetimes
{
    public interface ITransientService
    {
        public int GetRequestedCount();
        public int GetScopedRequestedCount();
        public int GetSingletonRequestedCount();

    }
}