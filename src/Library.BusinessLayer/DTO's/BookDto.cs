using Library.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLayer.DTO_s
{
    public class BookDto
    {
        public int Id { get; set; }
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string BookImage { get; set; }
        public string Author { get; set; }
        public int EditionHouseId { get; set; }
        public EditionHouseDto EditionHouse { get; set; }
        public int EditionYear { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public double Price { get; set; }
    }
}
