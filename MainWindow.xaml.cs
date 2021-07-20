using EFCourtStatements.EFContext;
using EFCourtStatements.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EFCourtStatements
{
    public partial class MainWindow : Window
    {
        StatementsContext statementsContext;
        ObservableCollection<Judge> judge_collection = new ObservableCollection<Judge>();
        ObservableCollection<TypeST> type_collection = new ObservableCollection<TypeST>();
        ObservableCollection<StatInfo> searchCollection = new ObservableCollection<StatInfo>();
        
        public MainWindow()
        {
            InitializeComponent();
            statementsContext = new StatementsContext();

            statementsContext.StatementsInfo.Load();
            statementsContext.TypesSt.Load();
            statementsContext.Judges.Load();

            FillCollections();

            listBox.ItemsSource = statementsContext.StatementsInfo.Local.ToBindingList();

            statusBar.Text = $"Заявлений: {listBox.Items.Count}";
        }

        public void FillCollections()
        {
            type_collection.Clear();
            judge_collection.Clear();
            foreach (var p in statementsContext.TypesSt)
                type_collection.Add(p);
            foreach (var p in statementsContext.Judges)
                judge_collection.Add(p);

        }

        private void AddNew_Button_Click(object sender, RoutedEventArgs e)
        {
            StatInfo addStatInfo = new StatInfo();
            EditStatement dialog = new EditStatement(addStatInfo, judge_collection, type_collection);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                statementsContext.StatementsInfo.Add(addStatInfo);
                statementsContext.SaveChanges();
            }
            statusBar.Text = $"Заявлений: {listBox.Items.Count}";
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;

            StatInfo upStatInfo = listBox.SelectedItem as StatInfo;
            EditStatement dialog = new EditStatement(upStatInfo, judge_collection, type_collection);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                statementsContext.SaveChanges();
            }
        }

        private void UpdateAll_Button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = statementsContext.StatementsInfo.Local.ToBindingList();
            statusBar.Text = $"Заявлений: {listBox.Items.Count}";
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены?", 
                "Удалить заявление", 
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                StatInfo stat = listBox.SelectedItem as StatInfo;
                statementsContext.StatementsInfo.Remove(stat);
                statementsContext.SaveChanges();
            }
            statementsContext.SaveChanges();
            statusBar.Text = $"Заявлений: {listBox.Items.Count}";
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            searchCollection.Clear();
            if (textBoxName.Text.Length > 0)
            {
                for (int i = 0; i < statementsContext.StatementsInfo.Local.Count(); i++)
                {
                    if (statementsContext.StatementsInfo.Local[i].PersName.Contains(textBoxName.Text))
                        searchCollection.Add(statementsContext.StatementsInfo.Local[i]);
                }
                listBox.ItemsSource = searchCollection;
                statusBar.Text = $"Заявлений: {listBox.Items.Count}";
            }
        }

        private void MenuItem_TypeEdit_Click(object sender, RoutedEventArgs e)
        {
            EditType dialog = new EditType(statementsContext);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                statementsContext.SaveChanges();
                FillCollections();
            }
        }

        private void MenuItem_JudgeEdit_Click(object sender, RoutedEventArgs e)
        {
            EditJudge dialog = new EditJudge(statementsContext);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                statementsContext.SaveChanges();
                FillCollections();
            }
        }

        private void MenuItemBigFind_Click(object sender, RoutedEventArgs e)
        {
            BigFind dialog = new BigFind(judge_collection, type_collection);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                searchCollection.Clear();   //очистка коллекции с найденными по критериям элементами
                for (int i = 0; i < statementsContext.StatementsInfo.Local.Count(); i++)
                {//цикл, в котором в searchCollection добавляются элементы, соответствующие поиску
                    //если поле не пустое и не совпадает, то tf становится false и текущий объект не добавится в коллекцию
                    bool tf = true;
                    if (dialog.Statement.Number > 0 &&
                        dialog.Statement.Number != statementsContext.StatementsInfo.Local[i].Number)
                        tf = false;
                    if (dialog.Statement.TypeSTId != null &&
                        dialog.Statement.TypeSTId != statementsContext.StatementsInfo.Local[i].TypeSTId)
                        tf = false;
                    if (dialog.Statement.JudgeId != null &&
                        dialog.Statement.JudgeId != statementsContext.StatementsInfo.Local[i].JudgeId)
                        tf = false;
                    if ((dialog.Statement.PersName != null) && 
                        !statementsContext.StatementsInfo.Local[i].PersName.Contains(dialog.Statement.PersName))
                        tf = false;
                    
                    //проверка дат (здесь InDate - начальная дата диапазона, DataCorrect - конечная дата диапазона)
                    if (dialog.Statement.InDate != null && dialog.Statement.DataCorrect != null)
                    {
                        if (statementsContext.StatementsInfo.Local[i].InDate < dialog.Statement.InDate ||
                        statementsContext.StatementsInfo.Local[i].InDate > dialog.Statement.DataCorrect)
                            tf = false;
                    }
                    if (dialog.Statement.InDate != null && dialog.Statement.DataCorrect == null)
                    {
                        if (statementsContext.StatementsInfo.Local[i].InDate < dialog.Statement.InDate)
                            tf = false;
                    }
                    if (dialog.Statement.InDate == null && dialog.Statement.DataCorrect != null)
                    {
                        if (statementsContext.StatementsInfo.Local[i].InDate > dialog.Statement.DataCorrect)
                            tf = false;
                    }

                    if (tf) //текущий объект добавится в коллекцию поиска либо если было совпадение, либо если все графы пустые
                        searchCollection.Add(statementsContext.StatementsInfo.Local[i]);
                }

                listBox.ItemsSource = searchCollection; //listBox заполняется объектами из коллекции поиска
                statusBar.Text = $"Заявлений: {listBox.Items.Count}";   //обновление кол-ва заявлений
            }
        }

        private void MenuItemReport_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow dialog = new ReportWindow(statementsContext);
            var result = dialog.ShowDialog();
        }

        private void MenuGraph_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
