using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PortfolioManager.Models
{
    public class CommodityDto
    {
        public int Id { get; set; }

        [DisplayName("Název komodity")]
        public string Name { get; set; } = "";

		[DisplayName("Typ komodity")]

		public string Type { get; set; } = "";


		[DisplayName("ID komodity")]

		public string ApiId { get; set; } = "";

		[DisplayName("Množství")]

		public double Amount { get; set; }

		[DisplayName("Celkem investováno (CZK)")]

		public decimal InvestedMoney { get; set; }
    }
}
