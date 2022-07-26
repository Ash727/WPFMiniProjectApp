using DemoLibrary;
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
using System.Windows.Shapes;

namespace WPFMiniProject
{
    /// <summary>
    /// Interaction logic for AddressEntry.xaml
    /// </summary>
    public partial class AddressEntry : Window
    {
        public ISaveAddresss Caller; 
        public AddressEntry(ISaveAddresss caller)
        {
            InitializeComponent();
            Caller = caller;
        }

        private void savePerson_Click(object sender, RoutedEventArgs e)
        {
            Caller.SaveAddress(
            new AddressModel
            {
                StreetAddress = streetAddressText.Text,
                Province = provinceText.Text,
                PostalCode = postalText.Text,
                City = cityAddressText.Text
            });

            this.Close();
        }
    }
}
