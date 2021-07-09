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
    }
}
