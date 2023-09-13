
using SQLite;

namespace SimpleInventoryStockApp.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
