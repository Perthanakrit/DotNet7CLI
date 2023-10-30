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

        private ProvinceServiceResponse ConvertToResponseModel(Province entity)
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

            Province entity = new Province()
            {
                Name = input.Name,
                Description = input.Description
            };

            Province insertedEntity = await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return ConvertToResponseModel(insertedEntity);
        }

        public async Task<ProvinceServiceResponse> UpdateProvinceAsync(Guid id, ProvinceServiceInput input)
        {
            Province existingEntity = await _repository.GetByIdAsync(id);

            bool isTheEntityNotExist = existingEntity == null;

            if (isTheEntityNotExist)
                throw new ArgumentException("Cannot update the province. It does not exist.");

            existingEntity!.Name = input.Name;
            existingEntity!.Description = input.Description;
            existingEntity = _repository.Update(existingEntity);
            await _repository.SaveChangesAsync();

            return ConvertToResponseModel(existingEntity);
        }

        public async Task<ProvinceServiceResponse> DeleteProvinceAsync(Guid id)
        {
            Province existingProvince = await _repository.GetByIdAsync(id);

            bool isTheEntityNotExist = existingProvince == null;

            if (isTheEntityNotExist)
                throw new ArgumentException("Cannot update the province. It does not exist.");

            existingProvince = _repository.Remove(existingProvince!);
            await _repository.SaveChangesAsync();
            return ConvertToResponseModel(existingProvince);
        }

        public async Task<ProvinceServiceResponse> GetProvinceAsync(Guid id)
        {
            Province existingProvince = await _repository.GetByIdAsync(id);

            bool isTheEntityNotExist = existingProvince == null;
            if (isTheEntityNotExist)
                throw new ArgumentException("Cannot get the province. It does not exist.");

            return ConvertToResponseModel(existingProvince!);
        }

        public async Task<List<ProvinceServiceResponse>> GetAllProvinceAsync()
        {
            List<Province> provinces = await _repository.GetAllAsync();
            return provinces.Select(ConvertToResponseModel).ToList();
        }

        public Task<ProvinceServiceResponse> GetProvinceAsyncWithPointOfInterestsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}