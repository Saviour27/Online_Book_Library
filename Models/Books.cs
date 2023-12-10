using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyLibrary.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Models
{
    public class Books : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        public int GenreId { get; set; }
        
        [Required(ErrorMessage = "Publisher is required")]
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public DateTime LibraryAddDate { get; set; }
        public int CopiesInLibrary { get; set; }
        public int CopiesOutLibrary { get; set; }
        public int AvailableCopies { get; set; }
        public bool EVersion { get; set; }
        public Data.Enums.Genre bookcategories { get; set; }
        public string ImageURL { get; set; }
        
        [ForeignKey("GenreId")]
        [ValidateNever]
        public Genre? Genre { get; set; }
    }
}