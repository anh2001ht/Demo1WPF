using System;
using System.Collections.Generic;
using System.IO;
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

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String[] args = App.Args;
            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    String line = sr.ReadToEnd();
                    textBox.AppendText(line.ToString());
                    textBox.AppendText("\n");
                }
            }
            catch (Exception ex)
            {
                textBox.AppendText("Can not read");
                textBox.AppendText(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTbx.Text;
                int age = Convert.ToInt32(AgeTbx.Text);
                string genderSelected = ((ComboBoxItem)GenderCbBox.SelectedItem).Content.ToString();
                MessageBox.Show($"{name} - {age} - {genderSelected}");
                InfoFrm infoFrm = new InfoFrm();
                infoFrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Re-Input\n"+ex.Message);
            }
            
        }
    }
}
