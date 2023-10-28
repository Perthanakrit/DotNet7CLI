using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.ServiceLifetimes;

namespace Infrastructure.ServiceLifetimes
{
    public class TransientService : ITransientService
    {
        private int _requestedCount;
        private readonly IScopedService _scopeService;
        private readonly ISingletonService _singletonService;
        public TransientService(IScopedService scopeService, ISingletonService singletonService)
        {
            _scopeService = scopeService;
            _singletonService = singletonService;
        }

        public int GetRequestedCount()
        {
            _requestedCount = _requestedCount + 1;
            return _requestedCount;
        }

        public int GetScopedRequestedCount() => _scopeService.GetRequestedCount();

        public int GetSingletonRequestedCount() => _singletonService.GetRequestedCount();
    }
}