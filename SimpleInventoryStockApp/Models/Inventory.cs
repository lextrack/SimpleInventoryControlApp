using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryStockApp.Models
{
    [Table("inventory")]
    public class Inventory : BaseEntity
    {
        public string Item { get; set; }
        public string Qty { get; set; }

        [MaxLength(10)]
        public string Price { get; set; }
        public string? Location { get; set; }

        public string? Supplier { get; set; }


        public string? Observations { get; set; }

        public string? Date { get; set; }
    }
}
