using EFCourtStatements.EFContext;
using EFCourtStatements.Models;
using System;
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
using System.Windows.Shapes;

namespace EFCourtStatements
{
    public partial class EditType : Window
    {
        StatementsContext statementsContext;
        TypeST typeST = new TypeST();

        public EditType(StatementsContext sc)
        {
            InitializeComponent();
            statementsContext = sc;
            statementsContext.TypesSt.Load();
            statementsContext.StatementsInfo.Load();

            listBox.ItemsSource = statementsContext.TypesSt.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (typeName.Text.Length > 0)
            {
                typeST.NameType = typeName.Text;
                statementsContext.TypesSt.Add(typeST);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > 0)
            {
                var result = MessageBox.Show(
                "Вы уверены?",
                "Удалить тип",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    typeST = listBox.SelectedItem as TypeST;
                    bool t = true;
                    foreach (StatInfo p in statementsContext.StatementsInfo.Local)
                    {
                        if (typeST.TypeSTId == p.TypeSTId)
                        {
                            MessageBox.Show(
                                "Имеются заявления с таким типом",
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                            t = false;
                            break;
                        }

                    }
                    if (t)
                    {
                        statementsContext.TypesSt.Remove(typeST);
                        statementsContext.SaveChanges();
                    }
                }
            }
                
        }

        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listBox.SelectedIndex > 0)
        //    {
        //        typeST = listBox.SelectedItem as TypeST;
                
        //        var result = MessageBox.Show(
        //        "Вы уверены?",
        //        "Изменить тип",
        //        MessageBoxButton.YesNo,
        //        MessageBoxImage.Question);
        //        if (result == MessageBoxResult.Yes)
        //        {
        //            //typeST.NameType = typeName.Text;
        //            //statementsContext.TypesSt.Find(TypeST.TypeSTId).NameType = typeName.Text;
        //            //((TypeST)listBox.SelectedItem).NameType = typeName.Text;
        //            statementsContext.SaveChanges();
                    
        //        }
        //        //listBox.ItemsSource = statementsContext.TypesSt.Local.ToBindingList();
        //    }
            
        //    listBox.ItemsSource = statementsContext.TypesSt.Local.ToBindingList();
        //}

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
