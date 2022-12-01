using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_Exercise_10.ApplicationLogic;

namespace UP_Exercise_10.GroupPage
{
    public partial class GroupPage : Page
    {
        public GroupPage()
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
            if (FunctionBox.SelectedItem == null || NumberGrid.Children.OfType<UIElement>().Any(x => ((TextBox)x).Text == "" || ((TextBox)x).Text.Last() == '.'))
            {
                Result.Text = "";
                return;
            }
            object[] nums = new object[] { NumberGrid.Children.OfType<UIElement>().Select(x => Convert.ToDouble(((TextBox)x).Text.Replace('.', ','))).ToArray() };
            Result.Text = $"{ExcelFunctions.GetResult(((TextBlock)FunctionBox.SelectedItem).Text.ToString(), nums):f2}";
        }
        private void PlusClick(object sender, RoutedEventArgs e)
        {
            if (NumberGrid.Children.Count == 15) return;
            TextBox tb = new()
            {
                Style = (Style)Application.Current.Resources["TextBoxStyle"],
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 30,
                Width = 100
            };
            tb.PreviewTextInput += NumberPreviewTextInput;
            tb.TextChanged += NumberTextChanged;
            NumberGrid.Children.Add(tb);
            Grid.SetRow(tb, (NumberGrid.Children.Count - 1) / 3);
            Grid.SetColumn(tb, (NumberGrid.Children.Count - 1) % 3);
            GetResult();
        }
        private void MinusClick(object sender, RoutedEventArgs e)
        {
            if (NumberGrid.Children.Count == 1) return;
            NumberGrid.Children.Remove(NumberGrid.Children[NumberGrid.Children.Count - 1]);
            GetResult();
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow.BackClick(this);
        }
    }
}
