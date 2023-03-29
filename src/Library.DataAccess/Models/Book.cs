namespace Library.DataAccess.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string BookImage { get; set; }
        public string Author { get; set; }
        public int EditionHouseId { get; set; }
        public EditionHouse EditionHouse { get; set; } 
        public int EditionYear { get; set; }
        public double Price { get; set; }
        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
    }
}
