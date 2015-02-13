using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FunctionsNET.Functions
{
    public class Search
    {
        public static List<string> LCS(string value, List<string> list)
        {
            try
            {
                List<dynamic> lista = new List<dynamic>();

                foreach (var item in list)
                {
                    lista.Add(new { P = LCS(value.ToLower(), item.ToLower(), 0, 0), Word = item });
                }

                return lista.Where(x => x.P > 0)
                            .OrderBy(x => x.Word)           //Ordenação por Nome.
                            .OrderByDescending(x => x.P)    //Ordenação por pontuação.
                            .Select(x => x.Word)            //Selecionar a palavra.
                            .Cast<string>()                 //Cast para List<string>
                            .ToList();                      //Immediate Execution
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static int LCS(string A, string B, int index1, int index2)
        {
            int max = 0;
            if (index1 == A.Length)
            {
                return 0;
            }
            if (index2 == B.Length)
            {
                return 0;
            }

            for (int i = index1; i < A.Length; i++)
            {
                int exist = B.IndexOf(A[i], index2);
                if (exist != -1)
                {
                    int temp = 1 + LCS(A, B, i + 1, exist + 1);
                    if (max < temp)
                    {
                        max = temp;
                    }
                }
            }
            return max;
        }
    }
}
