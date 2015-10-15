using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pumpa.Datalayer
{
    public class AuthRepository
    {
        private const string Path = "Repo.xml";

        public bool IsThereUser(string login)
        {
            var doc = XDocument.Load(Path);
            var result = doc.Root.Elements().Any(t => t.Attribute("login").Value == login);
            return result;
        }

        public bool IsThereUser(string login, string password)
        {
            var doc = XDocument.Load(Path);
            var result = doc.Root.Elements().Any(t => t.Attribute("login").Value == login && 
                                                    t.Attribute("password").Value == password.GetHashCode().ToString());
            return result;
        }

        public void Register(string login, string password)
        {
            var doc = XDocument.Load(Path);

            doc.Root.Add(new XElement("User", new XAttribute("login", login), new XAttribute("password", password.GetHashCode().ToString())));
            
            doc.Save(Path);
        }
    }
}
