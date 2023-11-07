using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Core.Entities
{
    public class Order : BaseEntity<int>
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsFinaly { get; set; }


        [ForeignKey("UserId")]
        public User Users { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
