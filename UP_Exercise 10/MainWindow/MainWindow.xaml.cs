using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Linq;
using UP_Exercise_10.ApplicationLogic;

namespace UP_Exercise_10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += ShowCloseMessage;
            MainFrame.Content = new MenuPage.MenuPage();
        }
        private void ShowCloseMessage(object sender, CancelEventArgs e)
        {
            if (ActionConfirmation("Вы уверены, что хотите закрыть приложение?") == MessageBoxResult.No) e.Cancel = true;
            else ExcelFunctions.Application.Quit();
        }
        private static MessageBoxResult ActionConfirmation(string question) => MessageBox.Show(question, "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
        public static void BackClick(Page page)
        {
            page.NavigationService.Navigate(new MenuPage.MenuPage());
        }
    }
}
