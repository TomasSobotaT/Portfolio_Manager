using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Api.Models.ApiJsonModels
{

    public class Currency
    {
        public string? den { get; set; }
        public string? denc { get; set; }
        public string? banka { get; set; }
        public string? url { get; set; }
        public Kurzy? kurzy { get; set; }
    }

    public class Kurzy
    {
        public AUD? AUD { get; set; }
        public GBP? GBP { get; set; }
        public CNY? CNY { get; set; }
        public DKK? DKK { get; set; }
        public EUR? EUR { get; set; }
        public JPY? JPY { get; set; }
        public CAD? CAD { get; set; }
        public HUF? HUF { get; set; }
        public NOK? NOK { get; set; }
        public PLN? PLN { get; set; }
        public RON? RON { get; set; }
        public SEK? SEK { get; set; }
        public CHF? CHF { get; set; }
        public TRY? TRY { get; set; }
        public USD? USD { get; set; }
    }

    public class AUD
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class GBP
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public float? val_stred { get; set; }
        public float? val_nakup { get; set; }
        public float? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class CNY
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class DKK
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class EUR
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public float? val_stred { get; set; }
        public float? val_nakup { get; set; }
        public float? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class JPY
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class CAD
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class HUF
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class NOK
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class PLN
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class RON
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class SEK
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class CHF
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public float? val_stred { get; set; }
        public float? val_nakup { get; set; }
        public float? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class TRY
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public object? val_stred { get; set; }
        public object? val_nakup { get; set; }
        public object? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

    public class USD
    {
        public int? jednotka { get; set; }
        public float? dev_stred { get; set; }
        public float? dev_nakup { get; set; }
        public float? dev_prodej { get; set; }
        public float? val_stred { get; set; }
        public float? val_nakup { get; set; }
        public float? val_prodej { get; set; }
        public string? nazev { get; set; }
        public string? url { get; set; }
    }

}
