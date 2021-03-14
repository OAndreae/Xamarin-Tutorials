using SQLite;
namespace ContactBook.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }
    }
}
