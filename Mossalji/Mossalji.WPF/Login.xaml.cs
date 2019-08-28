using Mossalji.Data.DataModels;
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

namespace Mossalji.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Employee emp;

            using (DataService DS = new DataService())
            {
                emp = DS.Login(UserName.Text, Password.Password);
            }

            if(emp!=null)
            {
                Properties.Settings.Default.UserName = UserName.Text;

                Properties.Settings.Default.Save();

                var mainWindow = new MainWindow(emp);

                App.Current.MainWindow = mainWindow;

                this.Hide();

                App.Current.MainWindow.Show();

                this.Close();
            }

            else
            {
                MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة، يرجى اعادة المحاولة ", "خطـ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Text = Properties.Settings.Default.UserName;
        }
    }
}
