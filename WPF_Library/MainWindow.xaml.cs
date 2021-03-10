using System;
using System.Collections.Generic;
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

namespace WPF_Library
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Fill the Book Grid with all the Books from the Database
            // Fill the ComboBox with all the Members
            // Views
        }

        private void UxSearch_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Filter the Book Grid by the Search Textbox
            // Select Procedure
        }

        private void UxCheckOut_Click(object sender, RoutedEventArgs e)
        {
            // Checkout a Book with the Selected Member and Selected Book
            // Insert Procedure
        }

        private void UxReturn_Click(object sender, RoutedEventArgs e)
        {
            // Return a book with the Selected Book from the ItemsOut List
            // Update Procedure
        }

        private void UxMemberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Filter the ItemsOut by the selected Member
            // Select Procedure
        }
    }
}
