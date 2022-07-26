using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DemoLibrary;

namespace WPFMiniProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISaveAddresss
    {   BindingList<AddressModel> addressModels = new BindingList<AddressModel>(); 
        public MainWindow()
        {
            InitializeComponent();
            // Automatically looks to see whats been added to the address model and adjusts the box
            addressesList.ItemsSource = addressModels;
            addressModels.Add(new AddressModel { StreetAddress = "11 Boundary Lane", City = "Thorold", 
                PostalCode = "L2V 1X8", Province = "Ontario" });
            addressesList.MouseDoubleClick += AddressesList_MouseDoubleClick; ;
        }

        private void AddressesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var address = addressesList.SelectedItem as AddressModel;
            Details details = new Details(address);
            details.Show();
        }

      
        public void SaveAddress(AddressModel addressModel)
        {

            addressModels.Add(addressModel);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddressEntry entry = new AddressEntry(this);
            entry.Show();
        }

        private void savePerson_Click(object sender, RoutedEventArgs e)
        {
            PersonModel personModel = new PersonModel()
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                IsActive = (activeCheckBox.IsChecked ?? false),
                Address = addressModels.ToList()
            };    

        }
    }
}
