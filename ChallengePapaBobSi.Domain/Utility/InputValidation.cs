using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengePapaBobsSi.Domain
{
    public class RegularExpression
    {
        public static readonly string Url = @"^(http|ftp|https|www)://([\w+?" + 
            @"\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$"; 
        public static readonly string Date = "(0[1-9]|[12][0-9]|3[01])[-]" +
               "(0[1-9]|1[012])[-]((175[7-9])|(17[6-9][0-9])|(1[8-9][0-9][0-9])|" +
               "([2-9][0-9][0-9][0-9]))";
        // supports dates from 1-1-1757 to 31-12-9999 for SQL Server 2000 Date Range 
        public static readonly string Time = "(0[1-9]|[1][0-2])[:]" +
               "(0[0-9]|[1-5][0-9])[:](0[0-9]|[1-5][0-9])[ ][A|a|P|p][M|m]";
        public static readonly string Number = "[-+]?[0-9]*\\.?[0-9]*";
        public static readonly string Digit = "[0-9]*";
        public static readonly string NonNegative = "[+]?[0-9]*\\.?[0-9]*";
        public static readonly string PhoneNumber = @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?" + 
                @"[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))" +
                @"(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$";

        public static string MaxLength(int len)
        {
            return "[\\s\\S]{0," + len.ToString() + "}";
        }
    }
    public class ValidationMessages
    {

        public static readonly string Url = "Please enter a valid URL.<br>Valid " +
               "characters are all alphanumeric characters and .?" +
               "&_=-$<br> example: home.aspx?id=5&name=$my_name";
        public static readonly string Required = "* Required";
        public static readonly string Date =
           "Please enter a valid date in dd-MM-yyyy format.";
        public static readonly string Time =
           "Please enter a valid time in hh:mm:ss am format.";
        public static readonly string Number = "* Must be a valid number.";
        public static readonly string Digit = "* Must be a valid whole number.";
        public static readonly string NonNegative = "* Must be a non-negative number.";
        public static readonly string PhoneNumber = "Please enter a valid phone number.";
        public static string MaxLength(int len)
        {
            return "Maximum " + len.ToString() +
                   " characters are allowed.";
        }
    }
}
