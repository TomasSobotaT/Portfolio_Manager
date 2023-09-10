using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PortfolioManager.Data.Models;

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

		
		//public string AmountString { get; set; } = "";
		public double Amount { get; set; }

		[DisplayName("Celkem investováno (CZK)")]

		public decimal InvestedMoney { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public string UserId { get; set; }
    }
}
