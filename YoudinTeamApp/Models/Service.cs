using System.ComponentModel.DataAnnotations;
namespace YoudinTeamApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Short_Description { get; set; }
        public int Display_Order { get; set; }
        public int Price { get; set; }
        public string? Href { get; set; }
    }
}
