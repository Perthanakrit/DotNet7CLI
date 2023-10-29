using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Database;
using Core.Interfaces.Services;
using Domain.Entities;

namespace Core.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _repository;

        public ProvinceService(IProvinceRepository repository)
        {
            _repository = repository;
        }

        private ProvinceServiceResponse ConvertToResponseModel(Provice entity)
        {
            return new ProvinceServiceResponse()
            {
                Id = entity.Id,
                Name = entity.Name!,
                Description = entity.Description!,
                CreatedUTC = entity.CreatedUTC,
                UpdatedUTC = entity.UpdatedUTC,
                IsActive = entity.IsActive
            };
        }

        public async Task<ProvinceServiceResponse> CreateNewProvinceAsync(ProvinceServiceInput input)
        {
            // Return duplication error if the name is used already.
            bool isTheNameAlreadyUsed = await (_repository.DoesExist(c => c.Name == input.Name));
            if (isTheNameAlreadyUsed)
                throw new ArgumentException("Province name is used already. Please choose another name");

            Provice entity = new Provice()
            {
                Name = input.Name,
                Description = input.Description
            };

            Provice insertedEntity = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return ConvertToResponseModel(insertedEntity);
        }
    }
}