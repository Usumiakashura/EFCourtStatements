using EFCourtStatements.EFContext;
using EFCourtStatements.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class EditJudge : Window
    {
        StatementsContext statementsContext;
        Judge judge = new Judge();
        public EditJudge(StatementsContext sc)
        {
            InitializeComponent();
            statementsContext = sc;
            statementsContext.Judges.Load();
            statementsContext.StatementsInfo.Load();
            
            listBox.ItemsSource = statementsContext.Judges.Local.ToBindingList();

            editJudge.DataContext = listBox.SelectedItem;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (lastName.Text.Length > 0 &&
                firstName.Text.Length > 0 &&
                sName.Text.Length > 0)
            {
                judge.LastName = lastName.Text;
                judge.FirstName = firstName.Text;
                judge.SName = sName.Text;
                statementsContext.Judges.Add(judge);
            }
            else MessageBox.Show(
                "Заполните все поля",
                "Ошибка!",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены?",
                "Удалить выбранного судью",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                judge = listBox.SelectedItem as Judge;
                bool t = true;
                foreach (StatInfo p in statementsContext.StatementsInfo.Local)
                {
                    if (judge.JudgeId == p.JudgeId)
                    {
                        MessageBox.Show(
                            "Имеются заявления, рассматриваемые данным судьей",
                            "Ошибка!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        t = false;
                        break;
                    }

                }
                if (t)
                {
                    statementsContext.Judges.Remove(judge);
                    statementsContext.SaveChanges();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
