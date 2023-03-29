using Library.BusinessLayer.DTO_s;
using Library.DataAccess.Models;

namespace Library.BusinessLayer.Requests
{
    public class BookRequest
    {
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string BookImage { get; set; }
        public string Author { get; set; }
        public int EditionHouseID { get; set; }
        public int EditionYear { get; set; }
        public List<GenreRequest> Genres { get; set; }
        public double Price { get; set; }
    }
}
