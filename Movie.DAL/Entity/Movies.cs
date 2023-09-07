using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.DAL.Entity
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Title { get; set; }
        [Range(1,10)]
        public double Rate { get; set; }
        public int Year { get; set; }
        [MaxLength(50)]
        public string StoryLine { get; set; }
        public string Poster { get; set; }
        [ForeignKey("Geners")]
        public byte GenersId { get; set; }
        public Geners Geners { get; set; }
    }
}
