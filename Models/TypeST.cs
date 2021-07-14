using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.Models
{
    public class TypeST
    {
        public int TypeSTId { get; set; }       //айди типа
        public string NameType { get; set; }    //название типа

        public  List<StatInfo> StatInfos { get; set; }







        public override string ToString()
        {
            return $"{NameType}";
        }

    }
}
