using MySolution.MyProject0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // utilisation de namespace (grisé si pas encor utilisé)

namespace MySolution.MyProject0
{
    class Program // class est une schéma pour un/des objet(s)
    {
        static void Main(string[] args) // méthode -- signature(ce qu'elle retourne / ses parametres)
        {
            Person maPersonne = new Person();
            maPersonne.FirstName = "James";
            maPersonne.LastName = "Bourne";

            string message;
            message = "Bonjour " + maPersonne.FirstName + " " + maPersonne.LastName;
            message = string.Format(" Bonjour {0} {1}"
                , maPersonne.FirstName
                , maPersonne.LastName);
            message = $"Bonjour {maPersonne.FirstName} {maPersonne.LastName}";
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
