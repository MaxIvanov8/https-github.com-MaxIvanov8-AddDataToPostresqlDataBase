using Npgsql;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestProject
{
    class DataVM : INotifyPropertyChanged
    {
        private Data _selected = new Data();
        
        public NpgsqlConnection _con;

        public DataVM(string adr)
        {
            _con = new NpgsqlConnection(adr);
            _con.Open();
        }

        public Data Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public bool Add(string name)
        {
            if (CheckDate())
            {
                var cmd = new NpgsqlCommand(@"INSERT INTO " + name + "(surname, firstname, secondname, date, gender, adress) VALUES(" + ToValues() + ");", _con);
                cmd.ExecuteNonQuery();
                Selected = new Data();
                return true;
            }
            return false;
        }

        private string ToValues()
        {
            return string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'",_selected.Surname, _selected.Firstname, _selected.Secondname, _selected.Date.ToShortDateString(), _selected.Gender, _selected.Adress);
        }

        private bool CheckDate()
        {
            return (Selected.Check());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
