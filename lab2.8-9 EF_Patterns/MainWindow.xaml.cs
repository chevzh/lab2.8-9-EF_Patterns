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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2._8_9_EF_Patterns
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new BankContext();
            LoadData(db);
            this.Closing += MainWindow_Closing;
        }

        void LoadData(BankContext db)
        {            
            db.Investors.Load();           
            InvestorsDataGrid.ItemsSource = db.Investors.Local.ToBindingList(); // устанавливаем привязку к кэшу

            db.Investments.Load();// загружаем данные
            InvestmentsDataGrid.ItemsSource = db.Investments.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void DeleteInvestorsButton_Click(object sender, RoutedEventArgs e)
        {
            if (InvestorsDataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < InvestorsDataGrid.SelectedItems.Count; i++)
                {
                    Investor investor = InvestorsDataGrid.SelectedItems[i] as Investor;
                    if (investor != null)
                    {
                        db.Investors.Remove(investor);
                    }
                }
            }
            db.SaveChanges();
        }

        private void DeleteInvestmentsButton_Click(object sender, RoutedEventArgs e)
        {
            if (InvestmentsDataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < InvestmentsDataGrid.SelectedItems.Count; i++)
                {
                    Investment investment = InvestmentsDataGrid.SelectedItems[i] as Investment;
                    if (investment != null)
                    {
                        db.Investments.Remove(investment);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
