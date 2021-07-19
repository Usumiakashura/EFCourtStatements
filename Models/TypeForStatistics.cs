using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.Models
{
    public class TypeForStatistics
    {
        public string TypeSt { get; set; }
        //public int WidthRect { get; set; }
        public int NumberStatements { get; set; } = 0;

        public override string ToString()
        {
            return $"{TypeSt}\t\t{NumberStatements}";
        }
    }
}
