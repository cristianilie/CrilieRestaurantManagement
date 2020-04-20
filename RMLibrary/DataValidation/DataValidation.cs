using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary
{
    public class DataValidation
    {
        /// <summary>
        /// Validates Price textboxes so that entered values are decimal numbers
        /// </summary>
        /// <param name="priceTxt"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool ValidatePrice(string priceTxt, char c)
        {
            if (char.IsDigit(c))
                return true;
            if (c.Equals('.') && !priceTxt.Contains(c))
                return true;

            return false;
        }

        /// <summary>
        /// Validates textboxes related to quantity so that entered values are integers
        /// </summary>
        /// <param name="priceTxt"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool ValidateQuantity(string priceTxt, char c)
        {
            if (char.IsDigit(c) || Char.IsControl(c))
            {
                if (c == '0')
                {
                    if (priceTxt.Length == 0)
                    {
                        return false;
                    }
                    return true;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates if an integer is parsable from string
        /// If not, return default value 1
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public  int CheckAndQuantity(string quantity)
        {
            if (quantity.StartsWith("0"))
            {
                quantity = quantity.TrimStart('0');
            }
            int qty = 0;
            bool isParsable = int.TryParse(quantity, out qty);

            return isParsable && qty > 0 ? qty : 1;
        }
    }
}
