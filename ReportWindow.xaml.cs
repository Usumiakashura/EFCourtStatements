using EFCourtStatements.EFContext;
using EFCourtStatements.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    public partial class ReportWindow : Window
    {
        StatementsContext statementsContext; 
        List<JudgeForStatistics> judge_collection = new List<JudgeForStatistics>();
        JudgeForStatistics judgeForStatistics = new JudgeForStatistics();
        string text;

        public ReportWindow(StatementsContext sc)
        {
            InitializeComponent();
            statementsContext = sc;
            statementsContext.TypesSt.Load();
            statementsContext.Judges.Load();
            statementsContext.StatementsInfo.Load();

            FillCollection();

            //MessageBox.Show($"{judge_collection[4]} {judge_collection[4].Types[0].TypeSt} {judge_collection[4].Types[0].NumberStatements}");

            listBox.ItemsSource = judge_collection;
            //for (int i = 0; i < listBox.Items.Count; i++)
            //{
            //    listBox.Items[i].Types
            //}
            //foreach (JudgeForStatistics jfs in listBox.Items)
            //{
            //    jfs.Types
            //}
            
            //typesList

        }

        private void FillCollection()
        {
            //заполняем коллекцию всеми возможными судьями
            foreach (Judge j in statementsContext.Judges)
                judge_collection.Add(new JudgeForStatistics() { JudgeSt = j });

            //создаем табличный запрос
            var typesSt = from st in statementsContext.StatementsInfo
                          join jdg in statementsContext.Judges on st.JudgeId equals jdg.JudgeId
                          join tp in statementsContext.TypesSt on st.TypeSTId equals tp.TypeSTId
                          select new
                          {
                              judgeName = jdg.LastName,
                              typeName = tp.NameType,
                              idSt = st.TypeSTId
                          };

            foreach (var ts in typesSt)
            {//цикл по таблице полученной выше джойнами
                for (int i = 0; i < judge_collection.Count; i++)
                {//цикл по коллекции судей для отчета
                    if (judge_collection[i].JudgeSt.LastName == ts.judgeName)
                    {//если судья из таблицы совпал с судьей из коллекции
                        if (judge_collection[i].Types == null)
                        {
                            judge_collection[i].Types = new List<TypeForStatistics>();
                            judge_collection[i].Types.Add(new TypeForStatistics()
                            {
                                TypeSt = ts.typeName,
                                NumberStatements = 1
                            });
                        }
                        else
                        {
                            bool tf = false;
                            foreach (TypeForStatistics tfs in judge_collection[i].Types)
                            {//цикл, который проверяет нет ли совпадений типов
                                if (tfs.TypeSt == ts.typeName)
                                {
                                    tfs.NumberStatements++;
                                    tf = true;
                                }
                                    
                                //else
                                //{
                                //    judge_collection[i].Types.Add(new TypeForStatistics()
                                //    {
                                //        TypeSt = ts.typeName,
                                //        NumberStatements = 1
                                //    });
                                //    break;
                                //}
                            }
                            if (tf == false)
                            {
                                judge_collection[i].Types.Add(new TypeForStatistics()
                                {
                                    TypeSt = ts.typeName,
                                    NumberStatements = 1
                                });
                            }

                        }
                    }
                }
            }



        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Сохранить отчет",
                "Сохранить отчет",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                foreach (JudgeForStatistics jfs in judge_collection)
                {
                    text += $"--------------------\n{jfs}\n{jfs.TypeString}\n";
                }
                string writePath = @"D:\123.txt";
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(text);
                    }

                    //using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    //{
                    //    sw.WriteLine("Дозапись");
                    //    sw.Write(4.5);
                    //}
                    MessageBox.Show("Запись выполнена");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
