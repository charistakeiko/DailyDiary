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

namespace DailyDiary.View.Write
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewDiary : Page
    {
        public NewDiary()
        {
            this.InitializeComponent();
            //string Date = Convert.ToString(DateTime.Now.Date);
            var DDate = DateTime.Now.ToString("dd/MM/yyyy"); 
            TextBox.Text = DDate;
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        private void InsertTodoBtn_Click(object sender, RoutedEventArgs e)
        {
            // Try the the View Model insertion and check externally for result
            App.TODO_VIEW_MODEL.InsertNewTodo(TextBox.Text);
        }
        
    }
}
