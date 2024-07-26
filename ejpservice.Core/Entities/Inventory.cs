using ejpservice.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace ejpservice.Domain.Entities
{
    public class Inventory : BasePAD
    {
        [Key] 
        public int InventoryId { get; set; }
    }
}
