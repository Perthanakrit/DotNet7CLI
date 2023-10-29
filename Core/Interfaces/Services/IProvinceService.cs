using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Domain.Entities;

namespace Core.Interfaces.Services
{
    public interface IProvinceService
    {
        Task<ProvinceServiceResponse> CreateNewProvinceAsync(ProvinceServiceInput input);
    }

    public class ProvinceServiceInput
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class ProvinceServiceResponse : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}