using System.ComponentModel.DataAnnotations;

namespace Movie.DAL.Entity
{
    public class Geners
    { 
        [Key]
        public byte Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }
        public IEnumerable<Movies> Movies { get; set; }
    }
}
