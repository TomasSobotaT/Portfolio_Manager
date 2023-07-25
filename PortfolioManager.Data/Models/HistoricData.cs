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
    /// historical data for API - prices of crypto 
    /// </summary>
    public class HistoricData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal BitcoinPrice { get; set; }
        public decimal EthereumPrice { get; set; }
        public decimal PolygonPrice { get; set; }
        public decimal CosmosPrice { get; set; }
        public decimal MadleyPrice { get; set; }

    }
}
