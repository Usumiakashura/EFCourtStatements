using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.Models
{
    public class Judge
    {
        public int JudgeId { get; set; }       //айди
        public string LastName { get; set; }   //фамилия
        public string FirstName { get; set; }  //имя
        public string SName { get; set; }      //отчество

        public  List<StatInfo> StatInfos { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}.{SName}.";
        }
    }
}
