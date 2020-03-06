using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Class2
    {
        public List<int> logic_1(string myStr)
        {
            int i, len, vowela_count, vowele_count, voweli_count, vowelo_count, vowelu_count;
            vowela_count = 0;
            vowele_count = 0;
            voweli_count = 0;
            vowelo_count = 0;
            vowelu_count = 0;
            len = myStr.Length;
            for (i = 0; i < len; i++)
            {
                if (myStr[i] == 'a' || myStr[i] == 'A')
                {
                    vowela_count++;
                }
                else if (myStr[i] == 'e' || myStr[i] == 'E')
                {
                    vowele_count++;
                }
                else if (myStr[i] == 'i' || myStr[i] == 'I')
                {
                    voweli_count++;
                }
                else if (myStr[i] == 'o' || myStr[i] == 'O')
                {
                    vowelo_count++;
                }
                else if (myStr[i] == 'u' || myStr[i] == 'U')
                {
                    vowelu_count++;
                }

            }
            var _list = new List<int>();
            _list.Add(vowela_count);
            _list.Add(vowele_count);
            _list.Add(voweli_count);
            _list.Add(vowelo_count);
            _list.Add(vowelu_count);
            return _list;
        }
    }
}
