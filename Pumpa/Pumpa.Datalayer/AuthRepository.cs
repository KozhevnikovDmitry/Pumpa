using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumpa.Datalayer
{
    public class AuthRepository
    {
        public bool IsThereUser(string login)
        {
            return true;
        }

        public bool IsThereUser(string login, string password)
        {
            return true;
        }

        public void Register(string login, string password)
        {

        }
    }
}
