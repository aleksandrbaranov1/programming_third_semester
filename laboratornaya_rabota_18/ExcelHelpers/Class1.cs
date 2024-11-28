using System;

namespace ExcelHelpers
{
    public static class ExcelHelpers
    {
        public static string ExcelCellTranslator(int i, int j)
        {
            string cell = "";
            int x;
            int lose;

            x = j;
            if (x < 16384)
            {
                lose = (x - 1) / 676;

                if (lose > 0)
                {
                    cell += Alphabet(lose);
                    x = x - (676 * lose);
                }

                lose = (x - 1) / 26;

                if (lose > 0)
                {
                    cell += Alphabet(lose);
                    x = x - (26 * lose);
                }

                cell += Alphabet(x);
            }
            else
            {
                cell += "XFD";
            }

            cell += i.ToString();

            return cell;
        }

        public static string Alphabet(int Num)
        {
            return ((char)('A' + Num - 1)).ToString();
        }
    }
}