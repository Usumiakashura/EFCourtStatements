using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.Models
{
    public class JudgeForStatistics
    {
        public Judge JudgeSt { get; set; }
        public List<TypeForStatistics> Types { get; set; }
        public string TypeString    //возвращает строкой коллекцию типов для статистики
        {
            get
            {
                if (Types == null) Types = new List<TypeForStatistics>();
                string s = ""; 
                for (int i = 0; i < Types.Count; i++)
                {
                    s += $"{Types[i]}"; 
                    if (i < Types.Count - 1)
                        s += "\n";
                }
                return s;
            }
        }

        public override string ToString()   //вызывает ToString от класса Judge
        {
            return JudgeSt.ToString();
        }
    }
}
