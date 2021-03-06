using EFCourtStatements.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EFCourtStatements
{
    public partial class EditStatement : Window
    {
        StatInfo statement = new StatInfo();
        ObservableCollection<Judge> judge_collection = new ObservableCollection<Judge>();
        ObservableCollection<TypeST> type_collection = new ObservableCollection<TypeST>();

        public StatInfo Statement
        {
            get { return statement; }
        }

        public EditStatement(StatInfo statInfo, ObservableCollection<Judge> jc, ObservableCollection<TypeST> tc)
        {
            InitializeComponent();
            statement = statInfo;
            grid_stat.DataContext = statement;
            judge_collection = jc;
            type_collection = tc;

            foreach (var p in type_collection)
                comboBoxType.Items.Add(p);  //заполняет комбобокс из коллекции
            foreach (var p in judge_collection)
                comboBoxJudge.Items.Add(p);//заполняет комбобокс из коллекции

            if (statement.TypeSTId != 0)    //делает выбранным по умолчанию текущее значение объекта ТИПА при редактировании
            {
                foreach (var item in comboBoxType.Items)
                {
                    var comboItem = (TypeST)item;
                    if (comboItem.TypeSTId.Equals(statement.TypeSTId))
                        comboBoxType.SelectedItem = comboItem;
                }
            }
            if (statement.JudgeId != 0)   //делает выбранным по умолчанию текущее значение объекта СУДЬИ при редактировании
            {
                foreach (var item in comboBoxJudge.Items)
                {
                    var comboItem = (Judge)item;
                    if (comboItem.JudgeId.Equals(statement.JudgeId))
                        comboBoxJudge.SelectedItem = comboItem;
                }
            }

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (number.Text.Length == 0 ||
                Convert.ToInt32(number.Text) <= 0 ||
                comboBoxType.SelectedIndex < 0 ||
                comboBoxJudge.SelectedIndex < 0 ||
                in_date.SelectedDate == null ||
                pers_name.Text.Length == 0)
                MessageBox.Show("Остались не заполненные поля!\nОбязательные для заполнения:\n" +
                    "Номер, Тип, Дата поступления, Судья, ФИО/название организации",
                    "Ошибка!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else 
            {
                statement.TypeSTId = type_collection[comboBoxType.SelectedIndex].TypeSTId;
                statement.JudgeId = judge_collection[comboBoxJudge.SelectedIndex].JudgeId; 
                this.DialogResult = true;   //диалоговое окно завершено положительно и закроется
            }
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
