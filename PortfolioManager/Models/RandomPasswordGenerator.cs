using System.Security.Cryptography;
using System.Text;

namespace PortfolioManager.Models
{
    /// <summary>
    /// Class generate random passwords, use RandomNumberGenerator for realy random numbers
    /// </summary>
    public class RandomPasswordGenerator
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string numbers = "123456789";
        string symbols = ".,!?/#-+";


        /// <summary>
        /// Generate random string (random generated password)
        /// </summary>
        /// <returns>random string (random generated password)</returns>
        public string Generate()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                int randomNumber = RandomNumberGenerator.GetInt32(alphabet.Length);
                sb.Append(alphabet[randomNumber]);
            }
            for (int i = 0; i < 2; i++)
            {
                int randomNumber = RandomNumberGenerator.GetInt32(numbers.Length);
                sb.Append(numbers[randomNumber]);
            }
            for (int i = 0; i < 1; i++)
            {
                int randomNumber = RandomNumberGenerator.GetInt32(symbols.Length);
                sb.Append(symbols[randomNumber]);
            }


            return sb.ToString();

        }

    }
}
