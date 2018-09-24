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
        #region Fiels
        private static bool exit = false;
        private static List<Person> People = new List<Person>();
        #endregion

        static void Main(string[] args) // méthode -- signature(ce qu'elle retourne / ses parametres)
        {


            while (!exit)
            {
                DisplayMenu();
                switch (readChoice())
                {
                    case "1":
                        addPerson();
                        break;
                    case "2":
                        ShowPeople(People);
                        break;
                    case "3":
                        Recherch();
                        break;
                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Choix invalid");
                        break;
                }
                
            }
        }


        #region Methods

        
        /// <summary>
        ///     Afiche le menu
        /// </summary>
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Ajouter");
            Console.WriteLine("2 - Lister");
            Console.WriteLine("3 - Chercher");
            Console.WriteLine("0 - Quitter");
        }

        /// <summary>
        ///     Displays info of given person
        /// </summary>
        /// <param name="_person"></param>
        public static void ShowPerson(Person _person)
        {
            int diff = 0;
            try
            {
                if((_person?.BirthDdate.Month > DateTime.Now.Month) || (_person?.BirthDdate.Month == DateTime.Now.Month && _person?.BirthDdate.Day > DateTime.Now.Day))
                {
                    diff--;
                }
            }catch(Exception)
            {

            }
            // C#6.0 "?" vérifie si l'objet exist
            Console.WriteLine($"Prénom : {_person?.FirstName}");
            Console.WriteLine($"Nom : {_person?.LastName}");
            Console.WriteLine($"Prénom : {_person?.BirthDdate.ToLongDateString()}");
            Console.WriteLine($"Age : {_person?.BirthDdate.Year - DateTime.Today.Year + diff}");
        }

        /// <summary>
        ///     Retourne la touche qui à été touché
        /// </summary>
        /// <returns></returns>
        private static string readChoice()
        {
            return Console.ReadKey().KeyChar.ToString();
        }

        /// <summary>
        ///     Permet d'ajouter une personne dans une liste
        /// </summary>
        private static void addPerson()
        {
            Person p = createPerson();
            People.Add(p);
            ShowPerson(p);
        }

        /// <summary>
        ///     Permet de créer une personne
        /// </summary>
        /// <returns></returns>
        private static Person createPerson()
        {
            Person p = new Person();
            Console.Clear();
            Console.WriteLine("Entrez le prénom");
            p.FirstName = Console.ReadLine();

            Console.WriteLine("Entrez le nom");
            p.LastName = Console.ReadLine();

            bool dateIsValid = false;
            DateTime bd;
            do
            {
                Console.WriteLine("Entrez votre date de naissance");
                dateIsValid = DateTime.TryParse(Console.ReadLine(), out bd);
                if (!dateIsValid) { Console.WriteLine("Date Invalide"); }
            } while (!dateIsValid);
            p.BirthDdate = bd;
            return p;
        }

        /// <summary>
        ///     Permet d'afficher les personnes présente dans la liste Poeple
        /// </summary>
        private static void ShowPeople(List<Person> _people)
        {

            bool exitShowPeople = false;
            int i = 0;
            while (!exitShowPeople && People.Count() > 0)
            {
                Person p = _people[i];
                Console.Clear();
                ShowPerson(p);
                Console.WriteLine("\n1 - Suivant");
                Console.WriteLine("2 - Précedent");
                Console.WriteLine("3 - supprimer");
                Console.WriteLine("0 - Quitter");

                switch (readChoice())
                {
                    case "1":
                        i++;
                        break;
                    case "2":
                        i--;
                        break;
                    case "3":
                        People.Remove(p);
                        i--;
                        break;
                    case "0":
                        exitShowPeople = true;
                        break;
                    default:
                        break;

                }
                if (i >= _people.Count())
                {
                    i = 0;
                }
                else if (i < 0)
                {
                    i = _people.Count() - 1;
                }
            }
            if (_people.Count() <= 0)
            {
                Console.Clear();
                Console.WriteLine("Votre liste est vide");
                Console.ReadKey();
            }
        }

        private static void Recherch()
        {
            List<Person> searchList = new List<Person>();
            Console.Clear();
            Console.WriteLine("Que cherchez vous");
            string search = Console.ReadLine().ToLower();

            DateTime date;
            bool isDate = (DateTime.TryParse(search, out date) ? true : false);

            foreach (Person person in People)
            {
                if (person.FirstName.ToLower().Contains(search) || person.FirstName.ToLower().Contains(search))
                {
                    searchList.Add(person);
                }
                else if (isDate & person.BirthDdate == date)
                {
                    searchList.Add(person);
                }
            }
            ShowPeople(searchList);
        }

        #endregion

    }
}
