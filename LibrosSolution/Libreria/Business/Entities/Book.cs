using System.Text.Json.Serialization;

namespace Libreria.Business.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AutorId { get; set; }

        public Autor? Autor { get; set; }
 
        public Book(){}

        public Book(int Id, string Name, string Description, int AutorId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.AutorId = AutorId;
        }
    }
}
