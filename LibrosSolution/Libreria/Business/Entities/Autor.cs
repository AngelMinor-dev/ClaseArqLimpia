using System.Text.Json.Serialization;

namespace Libreria.Business.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        [JsonIgnoreAttribute]
        public ICollection<Book> Books { get; set; }


        public Autor()
        {
            
        }

        public Autor(int Id, string Name, string Description, string Nationality)
        {
            this.Id = Id;
            this.Name = Name;
            this.Nationality = Nationality; 
        }
    }
}
