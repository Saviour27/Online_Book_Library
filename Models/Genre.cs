using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }  
    }
}
