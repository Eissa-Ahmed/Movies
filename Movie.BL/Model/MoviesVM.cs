using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.BL.Model
{
    public class MoviesVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Story Line Is Required") ,MaxLength(15, ErrorMessage = "Max Length is 15 Char")]
        public string Title { get; set; }
        [Range(1, 10, ErrorMessage = "Range From 1 To 10")]
        public double Rate { get; set; }
        [Required(ErrorMessage = "Year Is Required")]
        public int Year { get; set; }
        [Required( ErrorMessage = "Story Line Is Required"), MaxLength(50, ErrorMessage = "Max Length is 50 Char")]
        public string StoryLine { get; set; }
        public string? Poster { get; set; }
        [Required(ErrorMessage = "Poster Is Required")]
        public IFormFile File { get; set; }
        [ForeignKey("Geners")]
        public byte GenersId { get; set; }
        public GenersVM? Geners { get; set; }
    }
}
