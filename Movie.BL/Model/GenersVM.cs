using Movie.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace Movie.BL.Model
{
    public class GenersVM
    {
        public byte Id { get; set; }
        [MaxLength(15 , ErrorMessage = "Max Length is 15 Char")]
        public string Name { get; set; }
        public IEnumerable<Movies>? Movies { get; set; }
    }
}
