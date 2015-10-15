using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pumpa
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Login = "Olololo";
            IsSignIn = true;
            IsSignOut = IsRegister = false;
            SignInCommand = new SignInCommand(this);
            SignOutCommand = new SignOutCommand(this);
            RegisterCommand = new RegisterCommand(this);
            ToSignInCommand = new ToSignInCommand(this);
            ToRegisterCommand = new ToRegisterCommand(this);
        }

        #region Binding Properties

        private bool _isSignIn;

        public bool IsSignIn
        {
            get
            {
                return _isSignIn;
            }
            set
            {
                if (_isSignIn != value)
                {
                    _isSignIn = value;
                    RaisePropertyChanged("IsSignIn");
                }
            }
        }

        private bool _isSignOut;

        public bool IsSignOut
        {
            get
            {
                return _isSignOut;
            }
            set
            {
                if (_isSignOut != value)
                {
                    _isSignOut = value;
                    RaisePropertyChanged("IsSignOut");
                }
            }
        }

        private bool _isRegister;

        public bool IsRegister
        {
            get
            {
                return _isRegister;
            }
            set
            {
                if (_isRegister != value)
                {
                    _isRegister = value;
                    RaisePropertyChanged("IsRegister");
                }
            }
        }

        private string _login;

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    RaisePropertyChanged("Login");
                }
            }
        }

        #endregion



        #region Binding Commands

        public SignInCommand SignInCommand { get; set; }

        public SignOutCommand SignOutCommand { get; set; }

        public RegisterCommand RegisterCommand { get; set; }

        public ToSignInCommand ToSignInCommand { get; set; }

        public ToRegisterCommand ToRegisterCommand { get; set; }

        #endregion



        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SignInCommand : System.Windows.Input.ICommand
    {
        private readonly MainViewModel _vm;

        public SignInCommand(MainViewModel vm)
        {
            _vm = vm;
        }
        public void Execute(object arg)
        {
            var password = (arg as PasswordBox).Password;
            var login = _vm.Login;

            _vm.IsSignOut = true;
            _vm.IsSignIn = _vm.IsRegister = false;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class RegisterCommand : System.Windows.Input.ICommand
    {
        private readonly MainViewModel _vm;

        public RegisterCommand(MainViewModel vm)
        {
            _vm = vm;
        }
        public void Execute(object arg)
        {
            var password = (arg as PasswordBox).Password;
            var login = _vm.Login;


            _vm.IsSignOut = true;
            _vm.IsSignIn = _vm.IsRegister = false;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }


    public class ToSignInCommand : System.Windows.Input.ICommand
    {
        private readonly MainViewModel _vm;

        public ToSignInCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public void Execute(object arg)
        {
            _vm.IsSignIn = true;
            _vm.IsSignOut = _vm.IsRegister = false;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }


    public class ToRegisterCommand : System.Windows.Input.ICommand
    {
        private readonly MainViewModel _vm;

        public ToRegisterCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public void Execute(object arg)
        {
            _vm.IsRegister = true;
            _vm.IsSignOut = _vm.IsSignIn = false;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }


    public class SignOutCommand : System.Windows.Input.ICommand
    {
        private readonly MainViewModel _vm;

        public SignOutCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public void Execute(object arg)
        {
            _vm.IsSignIn = true;
            _vm.IsSignOut = _vm.IsRegister = false;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
