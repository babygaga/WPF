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

namespace wpfMinta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int CountOfDevisers(int number)
        {
            int DevisorCount = 1;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    DevisorCount++;
                }
            }
            return DevisorCount;
        }

        private void Randomgenerator_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int number = random.Next(1, 1000000000);
            NumberTextbox.Text = number.ToString();
        }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(NumberTextbox.Text);
                await Task.Run(() =>
                { 
                int divisors = CountOfDevisers(number);
                MessageBox.Show(string.Format($"{number}has {divisors} devisors"));
            });
        }
            catch (FormatException formatexception)
            {
                MessageBox.Show(formatexception.Message, "A szám nem megfelelő formátumú!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Nem várt hiba történt!");
            }
        }

        private void FirtsRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            var radioButton = (sender as RadioButton);
            System.Diagnostics.Debug.WriteLine($"{radioButton.Name} is checked: {radioButton.IsChecked}");
        }

        private void On_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void textinput_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(textinput.Text);
        }
    }
}
