using EFCourtStatements.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EFCourtStatements
{
    public partial class BigFind : Window
    {
        StatInfo statement = new StatInfo();
        ObservableCollection<Judge> judge_collection = new ObservableCollection<Judge>();
        ObservableCollection<TypeST> type_collection = new ObservableCollection<TypeST>();
        public StatInfo Statement { get { return statement; } }

        public BigFind(ObservableCollection<Judge> jc, ObservableCollection<TypeST> tc)
        {
            InitializeComponent();
            grid_find.DataContext = statement;
            judge_collection = jc;
            type_collection = tc;

            foreach (var p in type_collection)
                comboBoxType.Items.Add(p);  //заполняет комбобокс из коллекции
            foreach (var p in judge_collection)
                comboBoxJudge.Items.Add(p);//заполняет комбобокс из коллекции


        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxType.SelectedIndex >= 0)
                statement.TypeSTId = type_collection[comboBoxType.SelectedIndex].TypeSTId;
            if (comboBoxJudge.SelectedIndex >= 0)            
                statement.JudgeId = judge_collection[comboBoxJudge.SelectedIndex].JudgeId;


            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "0" && number.Text == "0")    //запрещает ввод 0 если в текстбоксе уже стоит 0
                e.Handled = true;
            if (e.Text != "0" && number.Text == "0")    //убирает 0 в начале ввода номера заявления
                number.Text = "";
            if (IsNumber(e.Text) == false) e.Handled = true;    //запрет на ввод букв в поле номера заявления
        }

        private bool IsNumber(string text)  //метод для проверки является ли вводимый текст числом
        {
            int output;
            return int.TryParse(text, out output);
        }
    }
}
