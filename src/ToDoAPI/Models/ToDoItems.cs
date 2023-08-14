using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class ToDoItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}