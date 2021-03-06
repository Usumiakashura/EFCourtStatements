using EFCourtStatements.EFContext;
using EFCourtStatements.Models;
using System.Data.Entity;
using System.Windows;

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
                listBox.SelectedIndex = -1;
                typeST = new TypeST() { NameType = typeName.Text };
                statementsContext.TypesSt.Add(typeST);
                statementsContext.SaveChanges();

                typeName.Text = "";
                statementsContext.TypesSt.Load();
            }
            else MessageBox.Show(
                "Невозможно добавить пустое поле",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                typeST = listBox.SelectedItem as TypeST;

                var result = MessageBox.Show(
                "Вы уверены?",
                "Изменить тип",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    statementsContext.TypesSt.Find(typeST.TypeSTId).NameType = typeName.Text;
                    statementsContext.SaveChanges();
                    listBox.Items.Refresh();
                    typeName.Text = "";
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
