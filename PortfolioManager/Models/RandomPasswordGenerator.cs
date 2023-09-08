using System.Security.Cryptography;
using System.Text;

namespace PortfolioManager.Models
{
    /// <summary>
    /// Class generate random passwords, use RandomNumberGenerator for realy random numbers
    /// </summary>
    public class RandomPasswordGenerator
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789.,!?/#-+";
        int length = 12;


        /// <summary>
        /// Generate random string (random generated password)
        /// </summary>
        /// <returns>random string (random generated password)</returns>
        public string Generate()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int randomNumber = RandomNumberGenerator.GetInt32(alphabet.Length);
                sb.Append(alphabet[randomNumber]);
            }

            return sb.ToString();

        }

    }
}
