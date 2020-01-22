using System.Windows;
using Npgsql;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pass = "Server=localhost;Port=5432;User Id=postgres;Password=admin;";
        private string _dataBaseName = "testdb";
        private string _tableName = "peoples";
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new DataVM(_pass + "Database=" + _dataBaseName);
            ConnectionToBase();
        }

        private void ConnectionToBase()
        {
            var con = new NpgsqlConnection(_pass);
            var createdb = new NpgsqlCommand(@"CREATE DATABASE"+ _dataBaseName + "WITH OWNER = postgres ENCODING = 'UTF8' CONNECTION LIMIT = -1;", con);
            con.Open();
            try
            {
                createdb.ExecuteNonQuery();
            }
            catch { }
            con.Close();
            con = new NpgsqlConnection(_pass + "Database=" + _dataBaseName);
            var createtbl = new NpgsqlCommand(@"CREATE TABLE " + _tableName + "(id SERIAL PRIMARY KEY, surname VARCHAR(20), firstname VARCHAR(20), secondname VARCHAR(20), date TIMESTAMP, gender VARCHAR(1), adress VARCHAR(50));", con);
            con.Open();
            try
            {
                createtbl.ExecuteNonQuery();
            }
            catch { }
            con.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!((DataVM)DataContext).Add(_tableName)) MessageBox.Show("Заполните все поля", "Программное сообщение");
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
