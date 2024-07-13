using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace damnoshApi.Models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        public string AppuserId{get;set;}=string.Empty;
        public int StockId { get; set; }
        public AddUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}