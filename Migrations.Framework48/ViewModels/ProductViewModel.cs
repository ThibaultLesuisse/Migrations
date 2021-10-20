using System;
using System.ComponentModel.DataAnnotations;

namespace Migrations.Framework48.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string description, string name, decimal price)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
        public ProductViewModel()
        {

        }

        public int Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}