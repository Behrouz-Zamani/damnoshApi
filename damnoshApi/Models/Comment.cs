using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace damnoshApi.Models
{
    [Table("Command")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        public int? StockId { get; set; }
        //NAVIGATION PROPERTY   
        public Stock? Stock { get; set; }

        public string AppUserId { get; set;}
        public AddUser AppUser{get; set;}
    }
}