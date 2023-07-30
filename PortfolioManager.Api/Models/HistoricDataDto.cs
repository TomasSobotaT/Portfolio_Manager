using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Models
{
    public class HistoricDataDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public decimal PriceCZK { get; set; }
        public decimal PriceUSD { get; set; }

    }
}
