using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string DigitSum(string value)
        {
            int total = 0;
            int current = 0;
            foreach (char c in value)
            {
                if (int.TryParse(c.ToString(), out current))
                {
                    total += current;
                }
            }
            return total.ToString();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string HTMLBuild(string tag, string value)
        {
            string output = "";

            output += $"<{tag}>{value}</{tag}>";

            return output;
        }

        public string IsPrime(int value)
        {
            string message = "prime number";

            for (int i = 2; i <= value/2; i++)
            {
                if (value % i == 0)
                {
                    message = "not a " + message;
                    break;
                }
            }
            if (value<=1)
            {
                message = "not a " + message;
            }

            return message;
        }

        public string ReverseString(string value)
        {
            string output = "";
            foreach (char c in value)
            {
                output = c + output;
            }
            return output;
        }

        public string SortNumbers(string type, int[] values)
        {
            string output = "";
            Array.Sort(values);
            if (type.Equals("Ascending"))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    output += values[i].ToString()+",";
                }
                output = output.Substring(0, output.Length - 1);
            }
            else if (type.Equals("Descending"))
            {
                for (int i = values.Length - 1; i >= 0; i--)
                {
                    output += values[i].ToString() + ",";
                }
                output = output.Substring(0, output.Length - 1);
            }
            else output = "No Valid Sort";

            return output;
        }
    }
}
