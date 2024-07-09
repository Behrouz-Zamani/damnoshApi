using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace damnoshApi.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol can not be over 10 charecters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(15, ErrorMessage = "CompanyName can not be over 15 charecters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }


        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Indestry can not be over 15 charecters")]
        public string Indestry { get; set; } = string.Empty;

        [Range(1, 5000000000)]

        public long MarketCap { get; set; }
    }
}