using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectMySQL.Model
{
    [Table("Book")]
    public class Book
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
        }
    }

