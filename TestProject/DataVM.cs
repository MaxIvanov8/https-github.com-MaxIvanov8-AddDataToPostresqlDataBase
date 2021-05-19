using Npgsql;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestProject
{
    class DataVM : INotifyPropertyChanged
    {
        private Data _selected = new Data();
        
        private readonly NpgsqlConnection _con;

        public DataVM(string adr)
        {
            _con = new NpgsqlConnection(adr);
            _con.Open();
        }

        public Data Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public bool Add(string name)
        {
            if (CheckDate())
            {
                var cmd = new NpgsqlCommand("INSERT INTO " + name + "(surname, firstname, secondname, date, gender, adress) VALUES(" + ToAddValues() + ");", _con);
                cmd.ExecuteNonQuery();
                Selected = new Data();
                return true;
            }
            return false;
        }

        public void Delete(string name)
        {
            var cmd = new NpgsqlCommand("DELETE FROM " + name + " WHERE " + ToDelValues() + ";", _con);
            cmd.ExecuteNonQuery();
            Selected = new Data();
        }

        private string ToDelValues()
        {
            return
                $"surname='{_selected.Surname}' and firstname='{_selected.Firstname}' and secondname='{_selected.Secondname}' and date='{_selected.Date.ToShortDateString()}' and gender='{_selected.Gender}' and adress='{_selected.Adress}'";
        }

        private string ToAddValues()
        {
            return
                $"'{_selected.Surname}','{_selected.Firstname}','{_selected.Secondname}','{_selected.Date.ToShortDateString()}','{_selected.Gender}','{_selected.Adress}'";
        }

        private bool CheckDate()
        {
            return Selected.Check;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
