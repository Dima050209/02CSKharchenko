using _02Kharchenko.ViewModels;
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

namespace _02Kharchenko.Views
{
    /// <summary>
    /// Interaction logic for PersonDetailsView.xaml
    /// </summary>
    public partial class PersonDetailsView : UserControl
    {
        ViewModel _viewModel;
        public PersonDetailsView()
        {
            InitializeComponent();
            DataContext = _viewModel = new ViewModel();
        }

        private void BProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.Proceed();
                if(_viewModel.IsBirthday)
                {
                    MessageBox.Show("З днем народження!");
                }
            } 
            catch(ArgumentNullException)
            {
                MessageBox.Show("Потрібно заповнити всі поля.");
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
