using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
        public static void ShowErrorMessageBox(string function) => MessageBox.Show($"Ошибка при вычислении {function}", "Ошибка при вычислении", MessageBoxButton.OK, MessageBoxImage.Error);
        public static void BackClick(Page page)
        {
            page.NavigationService.Navigate(new MenuPage.MenuPage());
        }
    }
}
