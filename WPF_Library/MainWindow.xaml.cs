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
        Repository repo = new Repository();

        public MainWindow()
        {
            InitializeComponent();

            uxBookData.ItemsSource = repo.AvailableBooks();
            uxMemberList.ItemsSource = repo.Members();

            int memberID = repo.Members().Keys.ElementAt(0);
            uxMemberList.SelectedIndex = 0;
            uxItemsOut.ItemsSource = repo.ItemsOutByMember(memberID);
            // Fill the Book Grid with all the Books from the Database
            // Fill the ComboBox with all the Members
            // Views
        }

        private void UxSearch_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        { }

        private void UxCheckOut_Click(object sender, RoutedEventArgs e)
        {
            // Checkout a Book with the Selected Member and Selected Book
            // Insert Procedure
            int memberID = repo.Members().Keys.ElementAt(uxMemberList.SelectedIndex);

            int bookID = Convert.ToInt32(uxBookData.SelectedValue.ToString().Split(',').First().Substring(1));

            repo.CheckOut(bookID, memberID);
            uxBookData.ItemsSource = repo.AvailableBooks();
            uxItemsOut.ItemsSource = repo.ItemsOutByMember(memberID);

        }

        private void UxReturn_Click(object sender, RoutedEventArgs e)
        {
            // Return a book with the Selected Book from the ItemsOut List
            // Update Procedure
            int memberID = repo.Members().Keys.ElementAt(uxMemberList.SelectedIndex);
            int bookID = ((ItemsOut)uxItemsOut.SelectedValue).BookID;
            repo.ReturnBook(bookID);

            uxBookData.ItemsSource = repo.AvailableBooks();
            uxItemsOut.ItemsSource = repo.ItemsOutByMember(memberID);

        }

        private void UxMemberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Filter the ItemsOut by the selected Member
            // Select Procedure
            int memberID = repo.Members().Keys.ElementAt(uxMemberList.SelectedIndex);
            uxItemsOut.ItemsSource = repo.ItemsOutByMember(memberID);
        }

        private void UxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Filter the Book Grid by the Search Textbox
            // Select Procedure
            if(!uxSearch.Text.Equals("Search.."))
                uxBookData.ItemsSource = repo.SearchBooks(uxSearch.Text);
        }
    }
}
