using Libreria.Business.Entities;

namespace Libreria.Data.Repositories
{
    public class BookRepository
    {
        private readonly AppDBContext _dbContext;

        public BookRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbContext.Database.EnsureCreated();
        }


        public int Insert(Book book)
        {
            _dbContext.Books.Add(book);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public Book FinById(int id)
        {
            var book = _dbContext.Books.Find(id);
            return book != null ? book : throw new Exception($"no existe {book}");
        }

        public int Update(Book book)
        {
            var rSearch = _dbContext.Books.Find(book.Id);
            if (rSearch != null)
            {
                _dbContext.Update(rSearch);
                return _dbContext.SaveChanges();
            }
            throw new Exception($"no existe {book.Id}");
        }

        public List<Book> GetAll() 
        { 
            return _dbContext.Books.ToList();
        }

        public List<Book> GetByBookName(string bookName)
        {
            return _dbContext.Books.Where(b => b.Name.Equals(bookName)).ToList();
        }
        public List<Book> GetByAutor(string autorName)
        {
            var autor = _dbContext.Autors.FirstOrDefault(n=>n.Name.Equals(autorName));

            List<Book> listaLibros = null;

            if (autor != null) {
                listaLibros = _dbContext.Books.Where(t => t.AutorId == autor.Id).ToList();
            }
            return listaLibros;
        }


    }
}
