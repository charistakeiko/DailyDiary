using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DailyDiary.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(Write.NewDiary));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = (e.AddedItems[0] as ListViewItem).Name;

            switch(x)
            {
                case "Write":
                    MainFrame.Navigate(typeof(Write.NewDiary));
                    break;
                case "View":
                    MainFrame.Navigate(typeof(ViewDiary));
                    break;
                //case "Greet":
                ////    MainFrame.Navigate(typeof(Write.NewDiary));
                ////    break;
            }
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
                MainFrame.Navigate(typeof(Write.NewDiary));

        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainFrame.Navigate(typeof(Diaries.ViewDiary))))
            {
                MainFrame.Navigate(typeof(Write.NewDiary));
            }
            else
            {

            }
               
        }

        private void InnerFlyoutButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Write.NewDiary));
        }
        
    }

    public class ViewDiary
    {
    }
}
