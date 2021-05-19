using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestProject
{
    internal class Data : INotifyPropertyChanged
    {
        private string _firstname;
        private string _surname;
        private string _secondname;
        private DateTime _date = DateTime.Now.Date;
        private string _gender;
        private string _adress;

        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Secondname
        {
            get => _secondname;
            set
            {
                _secondname = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public string Adress
        {
            get => _adress;
            set
            {
                _adress = value;
                OnPropertyChanged();
            }
        }

        public bool Check => Adress != null && Gender != null && Secondname != null && Firstname != null && Surname != null;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
