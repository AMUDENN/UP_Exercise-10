using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UP_Exercise_10.ApplicationLogic;

namespace UP_Exercise_10.AlgebraicPage
{
    public partial class AlgebraicPage : Page
    {
        public AlgebraicPage()
        {
            InitializeComponent();
        }
        private void NumberPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!"0123456789.".Contains(e.Text) || Number.Text.Length >= 5 || Number.Text.Count(x => x == '.') == 1 && e.Text == ".") e.Handled = true;
        }
        private void NumberTextChanged(object sender, TextChangedEventArgs e) => GetResult();

        private void FunctionSelectionChanged(object sender, SelectionChangedEventArgs e) => GetResult();

        private void GetResult()
        {
            if (FunctionBox.SelectedItem == null || Number.Text == "" || Number.Text.Last() == '.')
            {
                Result.Text = "";
                return;
            }
            string function = ((TextBlock)FunctionBox.SelectedItem).Text.ToString();
            double num = Convert.ToDouble(Number.Text.Replace('.', ','));
            try 
            {
                Result.Text = (new string[] { "Fact" }.Contains(function) && (num > 100 || num < 0)) ? "" : $"{ExcelFunctions.GetResult(function, new object[] { num }):f2}";
            }
            catch
            {
                MainWindow.ShowErrorMessageBox(function);
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.BackClick(this);
        }
    }
}
