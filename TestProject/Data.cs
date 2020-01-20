using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestProject
{
    class Data : INotifyPropertyChanged
    {
        private string _firstname;
        private string _surname;
        private string _secondname;
        private DateTime _date = DateTime.Now.Date;
        private string _gender;
        private string _adress;

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Secondname
        {
            get { return _secondname; }
            set
            {
                _secondname = value;
                OnPropertyChanged("Secondname");
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                OnPropertyChanged("Adress");
            }
        }

        public bool Check()
        {
            return (Adress != null && Gender != null && Date != null && Secondname != null && Firstname != null && Surname != null);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
