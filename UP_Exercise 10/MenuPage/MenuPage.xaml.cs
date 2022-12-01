using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace UP_Exercise_10.MenuPage
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void GeometricClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GeometricPage.GeometricPage());
        }
        private void AlgebraicClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AlgebraicPage.AlgebraicPage());
        }
        private void AggregateClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AggregatePage.AggregatePage());
        }
    }
}
