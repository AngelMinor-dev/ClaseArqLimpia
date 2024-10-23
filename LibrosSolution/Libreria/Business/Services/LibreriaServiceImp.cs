using Libreria.Business.Entities;
using Libreria.Data.DTOs;
using Libreria.Data.Repositories;

namespace Libreria.Business.Services
{
    public class LibreriaServiceImp : ILibreriaService
    {
        private readonly BookRepository _bookRepository;

        public LibreriaServiceImp(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public List<Book> GetByAutor(string autorName)
        {
            return _bookRepository.GetByAutor(autorName);
        }

        public List<Book> GetByName(string bookName)
        {
           return _bookRepository.GetByBookName(bookName);
        }

        public int Insert(LibrosDTO dto)
        {
            var book = new Book();
            try
            {
                book = _bookRepository.GetByBookName(dto.Name).FirstOrDefault();
            }
            catch (Exception ex) { Console.WriteLine($"No existe el libro {ex.Message}"); throw; }

           
            if (book == null)
            {
                Book bookNew = new Book()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    AutorId = dto.AutorId
                };

                return _bookRepository.Insert(bookNew); ;
            }

            throw new Exception($"No existe libro {book.Id}");

        }
    }
}
