using EFCourtStatements.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCourtStatements.Models
{
    public class StatInfo
    {
        public int StatInfoId { get; set; }             //айди
        public int Number { get; set; }                 //номер заявления (устанавливается пользователем)
        public int? TypeSTId { get; set; }               //айди типа заявления
        public TypeST typeST { get; set; }
        public int? JudgeId { get; set; }                //айди судьи
        public Judge judge { get; set; }
        public string PersName { get; set; }            //имя (название организации) заявителя
        public string Kategory { get; set; }            //категория
        public DateTime? InDate { get; set; }            //дата поступления
        public DateTime? DataCorrect { get; set; }       //срок устранения 
        public DateTime? Notice { get; set; }            //дата извещения
        public DateTime? DataCorrectIn { get; set; }     //дата устранения недостатков
        public DateTime? DataOut { get; set; }           //дата возврата заявления

        

        
    }
}
