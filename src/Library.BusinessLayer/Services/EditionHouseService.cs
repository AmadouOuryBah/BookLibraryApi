
using AutoMapper;
using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Exceptions;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories.Interfaces;

namespace Library.BusinessLayer.Services
{
    public class EditionHouseService : IEditionHouseService
    {
        private readonly IEditionHouseRepository _editionHouseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EditionHouseService(IMapper mapper, IEditionHouseRepository editionHouseRepository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _editionHouseRepository = editionHouseRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<EditionHouseDto> AddAsync(EditionHouseRequest editionHouse, CancellationToken cancellation)
        {
            var editionHouseMapped = _mapper.Map<EditionHouse>(editionHouse);
            _editionHouseRepository.Add(editionHouseMapped);
            await _unitOfWork.SaveChangesAsync(cancellation);

            return _mapper.Map<EditionHouseDto>(editionHouseMapped);
        }

        public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
        {
            var editionHouse = await GetByIdAsync(id, cancellation);
            _editionHouseRepository.Delete(editionHouse);

            await _unitOfWork.SaveChangesAsync(cancellation);

            return "editionHouse has been deleted";
        }

        public async Task<List<EditionHouseDto>> GetAllAsync(CancellationToken cancellation)
        {
            var editionHouses = await _editionHouseRepository.GetAllAsync(cancellation);

            return _mapper.Map<List<EditionHouseDto>>(editionHouses);
        }

        public async Task<EditionHouseDto> UpdateAsync(int id, EditionHouseRequest editionHouse, CancellationToken cancellation)
        {
            var editionHouseFound = await GetByIdAsync(id, cancellation);

            editionHouseFound.City = editionHouse.City;
            editionHouseFound.Address = editionHouse.Address;

            _editionHouseRepository.Update(editionHouseFound);
           await _unitOfWork.SaveChangesAsync(cancellation);

            return _mapper.Map<EditionHouseDto>(editionHouseFound);
        }

        private async Task<EditionHouse> GetByIdAsync(int id, CancellationToken cancellation)
        {
            var editionHouseFound = await _editionHouseRepository.GetByIdAsync(id, cancellation);
            if (editionHouseFound is not null)
                return editionHouseFound;

            throw new NotFoundException("editionHouse with this id not doesn't exist");
        }
    }
}
