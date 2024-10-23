using MicroservicioPerros.Business.Entities;
using MicroservicioPerros.Data;
using MicroservicioPerros.Data.Repositories;

namespace MicroservicioPerros.Business.Services
{
    public class DogServiceImp : IDogService
    {
        private readonly DogRepository _dogRepository;

        public DogServiceImp(DogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public int Delete(int id)
        {
            return _dogRepository.Delete(id);
        }

        public List<DogDTO> GetAll()
        {
           return _dogRepository.GetAll()
                .Select(t => new DogDTO() {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    MaxLife = t.MaxLife,
                    UrlImage = t.UrlImage
                }).ToList();
        }

        public int Insert(DogDTO dog)
        {
            return _dogRepository.Insert(new Dog() {
                Name = dog.Name,
                Description = dog.Description,
                MaxLife = dog.MaxLife,
                UrlImage = dog.UrlImage
            });
        }
    }
}
