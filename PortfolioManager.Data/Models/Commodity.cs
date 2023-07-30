using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Models
{
    /// <summary>
    /// Class representes commodity e.g. Bitcoin, Ethereum, Gold etc.
    /// </summary>
    public class Commodity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key]
        public int Id { get; set; }   
        public string Name { get; set; } = "";

        public double Amount { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal InvestedMoney { get; set; }  


    }
}
