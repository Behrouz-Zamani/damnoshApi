using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Dtos.Comment;

namespace damnoshApi.Dtos.Stack
{
    public class StockDto
    {
         public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Indestry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto>? Comments{get;set;}
    }
}