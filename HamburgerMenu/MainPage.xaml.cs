using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace HamburgerMenu
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(MainWindow));
            MenuItems.SelectedIndex = 0;
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void MenuChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MainMenuItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                MainFrame.Navigate(typeof(MainWindow));
                TitleTextBlock.Text = "Main";
            }
            if (FoodMenuItem.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                MainFrame.Navigate(typeof(FoodWindow));
                TitleTextBlock.Text = "Food";
            }
        }

        private void CloseMenu(object sender, PointerRoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = false;
        }

        private void OpenMenu(object sender, PointerRoutedEventArgs e)
        {
            if(e.KeyModifiers == Windows.System.VirtualKeyModifiers.Control)
            {
                MenuSplitView.IsPaneOpen = true;
            }
        }

        private void BackEvent(object sender, RoutedEventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
                TitleTextBlock.Text = "Main";
                MainMenuItem.IsSelected = true;
            }   
        }
    }
}
