using System.ComponentModel.DataAnnotations;

namespace React_To_VS2022.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
