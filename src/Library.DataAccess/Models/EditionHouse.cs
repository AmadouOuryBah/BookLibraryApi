
namespace Library.DataAccess.Models
{
    public class EditionHouse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
