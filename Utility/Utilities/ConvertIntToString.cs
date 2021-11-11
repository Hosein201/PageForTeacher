using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utility.Utilities
{
    public static class ConvertIntToString
    {

        public static string Return_String_Number(double value)
        {
            var number = Convert.ToInt64(value);
            string strnumber = Convert.ToString(number);
            List<string> countnumber = convert3number(strnumber);
            int le = countnumber.Count;
            string makestringnum = null;
            int nowlength = 0;

            for (int i = 0; i < le; i++)
            {

                int numis = Convert.ToInt32(countnumber[i]);
                int coun = countnumber[i].Length;
                nowlength = i == 0 ? coun : nowlength + coun;
                string makethisnum;
                makethisnum = numis / 100 > 0 ? Getfirstin(numis / 100) + And(number, nowlength - 2) : " ";
                int value1 = numis / 100;
                value1 = numis - value1 * 100;
                if (value1 >= 20)
                {
                    int valnum = numis / 10;

                    valnum = valnum % 10;

                    makethisnum += Getsecound(valnum) + And(number, nowlength - 1);
                    makethisnum += numis % 10 > 0 ? GetThird(numis % 10) : " ";
                }

                else
                {

                    makethisnum += GetThird(value1);

                }

                if (numis != 0)
                    makethisnum += GetBoss(le - i - 1);

                makethisnum += And(number, nowlength);

                makestringnum += makethisnum;

            }
            return makestringnum;
        }


        private static List<string> convert3number(string number)
        {
            List<string> return3num = new List<string>();
            int number3count = number.Length > 3 ? number.Length / 3 : 1;
            if (number.Length > 3 && number.Length % 3 != 0)
                number3count += 1;
            if (number.Length <= 3)
            {
                return3num.Add(number);
                return return3num;
            }
            int cuf = number.Length;
            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0)
                {
                    int lengper = number.Length % 3;
                    lengper = lengper == 0 ? 3 : lengper;
                    cuf = lengper;
                    return3num.Add(number.Substring(i, lengper));

                }

                else
                {


                    return3num.Add(number.Substring(cuf, 3));
                    cuf = cuf + 3;
                    if (cuf == number.Length)
                        break;
                }

            }
            return return3num;
        }

        private static string GetBoss(int bossid)
        {
            if (bossid == 0)
                return " ";
            if (bossid == 1)
                return "هزار ";
            if (bossid == 2)
                return " میلیون ";
            if (bossid == 3)
                return "میلیارد ";
            if (bossid == 4)
                return "تیلیارد ";
            if (bossid == 5)
                return "بیلیارد ";
            else return null;

        }

        private static string Getfirstin(int numberid)
        {
            switch (numberid)
            {
                case 0:
                    return " ";
                case 1:
                    return "صد ";
                case 2:
                    return "دویست ";
                case 3:
                    return "سیصد ";
                case 4:
                    return "چهارصد ";
                case 5:
                    return "پانصد ";
                case 6:
                    return "ششصد ";
                case 7:
                    return "هفتصد ";
                case 8:
                    return "هشتصد ";
                case 9:
                    return "نهصد ";

                default:
                    return null;
            }
        }

        private static string Getsecound(int numberid)
        {
            switch (numberid)
            {

                case 1:
                    return "ده ";
                case 2:
                    return "بیست ";
                case 3:
                    return "سی ";
                case 4:
                    return "چهل ";
                case 5:
                    return "پنجاه ";
                case 6:
                    return "شصت ";
                case 7:
                    return "هفتاد ";
                case 8:
                    return "هشتاد ";
                case 9:
                    return "نود ";

                default:
                    return null;
            }
        }

        private static string GetThird(int numberid)
        {
            switch (numberid)
            {

                case 1:
                    return "یک ";
                case 2:
                    return "دو ";
                case 3:
                    return "سه ";
                case 4:
                    return "چهار ";
                case 5:
                    return "پنج ";
                case 6:
                    return "شش ";
                case 7:
                    return "هفت ";
                case 8:
                    return "هشت ";
                case 9:
                    return "نه ";
                case 11:
                    return "یازده ";
                case 12:
                    return "دوازده ";
                case 13:
                    return "سیزده ";
                case 14:
                    return "چهارده ";
                case 15:
                    return "پانزده ";
                case 16:
                    return "شانزده ";
                case 17:
                    return "هفده ";
                case 18:
                    return "هیجده ";
                case 19:
                    return "نوزده ";
                default:
                    return null;
            }
        }

        private static string And(long number, int le)
        {
            string subis = Convert.ToString(number);
            if (subis.Length < le)
            {
                return " ";
            }
            subis = subis.Substring(le);
            if (subis.Contains("1") || subis.Contains("2") || subis.Contains("3") || subis.Contains("4") || subis.Contains("5") || subis.Contains("6")
                || subis.Contains("7") || subis.Contains("8") || subis.Contains("9"))
            {
                return " و ";
            }
            else
            {
                return " ";
            }
        }

    }

    public static class PayCost
    {
        public static string Paymentcost(long rprice)
        {
            try
            {
                string price = Convert.ToString(rprice);
                string retprice = null;
                if (price == null || Convert.ToInt32(price) == 0)
                    return "0";
                if (price.Count() <= 3)
                    return price;
                int prcount = price.Count() / 3;
                if (price.Count() % 3 > 0)
                {
                    retprice = price.Substring(0, price.Count() % 3) + ",";
                    price = price.Substring(price.Count() % 3);
                }


                for (int i = 0; i < price.Count(); i = i + 3)
                {


                    string thispr = price.Substring(i, 3);
                    retprice += thispr;
                    if (price.Count() != i + 3)
                        retprice += ",";

                }
                return retprice;
            }
            catch (Exception)
            {

                return "0";
            }

        }
    }
}
