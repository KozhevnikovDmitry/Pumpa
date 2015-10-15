using Pumpa.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumpa.Domain
{

    public class AuthService
    {
        private readonly AuthRepository _authRepository;
        private const string Salt = "Pinch of salt";

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public bool SignIn(string login, string password)
        {
            return _authRepository.IsThereUser(login, password + Salt);
        }

        public bool Register(string login, string password)
        {
            if (_authRepository.IsThereUser(login))
            {
                return false;
            }

            _authRepository.Register(login, password + Salt);
            return true;
        }
    }
}
