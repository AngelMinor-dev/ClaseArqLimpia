using System.Globalization;

namespace MicroservicioPerros.Business.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxLife { get; set; }
        public string UrlImage { get; set; }
    }
}
