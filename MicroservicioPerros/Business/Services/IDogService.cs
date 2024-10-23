using MicroservicioPerros.Business.Entities;
using MicroservicioPerros.Data;

namespace MicroservicioPerros.Business.Services
{
    public interface IDogService
    {
        int Insert(DogDTO dog);
        
        int Delete(int id);

        List<DogDTO> GetAll();
    }
}
