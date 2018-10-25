using Front.Models;
using Front.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Front.ViewModels
{
    class CompteViewModel : ViewModelBase
    {
        public CompteViewModel()
        {
            BtnSearch = new RelayCommand(GetCompteByEmailAsync);
        }

        private Compte user;

        public Compte User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        public async void GetCompteByEmailAsync()
        {
            var result = await WSServices.GetInstance().GetCompteByEmail(Email);
            if (result != null)
            {
                User = result;
            }
        }

        public ICommand BtnSearch { get; private set; }

    }
}
