using Libreria.Business.Entities;
using Libreria.Data.DTOs;

namespace Libreria.Business.Services
{
    public interface ILibreriaService
    {
        List<Book> GetAll();
        int Insert(LibrosDTO dto);
        List<Book> GetByName(string bookName);
        List<Book> GetByAutor(string autorName);

    }
}
