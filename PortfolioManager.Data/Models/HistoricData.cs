using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Data.Models
{
    /// <summary>
    /// historical data for API - prices of crypto czk/usd
    /// </summary>
    public class HistoricData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public DateTime Date { get; set; }
        public decimal PriceCZK { get; set; }
        public decimal PriceUSD { get; set; }
  

    }
}
