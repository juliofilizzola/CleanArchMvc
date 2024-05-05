using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}