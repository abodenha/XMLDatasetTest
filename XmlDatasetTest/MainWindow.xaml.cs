using System;
using System.Collections.Generic;
using System.Data;
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

namespace XmlDatasetTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlDatasetTest.journal_data journal_data;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            journal_data = ((XmlDatasetTest.journal_data)(this.FindResource("journal_data")));
        }

        // I love you too!
        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "journal", // Default file name
                DefaultExt = ".xml", // Default file extension
                Filter = "Text documents (.xml)|*.xml" // Filter files by extension
            };

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                journal_data.WriteXml(dlg.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void load_button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xml", // Default file extension
                Filter = "Text documents (.xml)|*.xml" // Filter files by extension
            };

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                journal_data.ReadXml(dlg.FileName);
            }
        }
    }
}
