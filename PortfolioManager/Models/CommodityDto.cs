using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManager.Models
{
    public class CommodityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";

        public string CoingeckoId { get; set; } = "";

        public double Amount { get; set; }

        public decimal InvestedMoney { get; set; }
    }
}
