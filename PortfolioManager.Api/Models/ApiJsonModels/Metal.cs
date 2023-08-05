using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api
{


    public class Metal
    {
        public GSJ? GSJ { get; set; }
    }

    public class GSJ
    {
        public string? date { get; set; }
        public string? unit { get; set; }
        public Gold? Gold { get; set; }
        public Silver? Silver { get; set; }
    }

    public class Gold
    {
        public USD? USD { get; set; }
    }

    public class USD
    {
        public decimal? Ask { get; set; }
        public decimal? Bid { get; set; }
    }

    public class Silver
    {
        public USD1? USD { get; set; }
    }

    public class USD1
    {
        public decimal? Ask { get; set; }
        public decimal? Bid { get; set; }
    }






}
