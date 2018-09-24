using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.MyProject0.Model
{

    /// <summary>
    ///     Classe de données qui représente une personne
    /// </summary>
    class Person // tout classe hérite de la classe "Object" (object == mot clé de la classe: minuscule pour mot clé)
    {
        #region Fields
        /// <summary>
        ///     prénom de la personne
        /// </summary>
        private string firstName;
        private string lastName;
        private DateTime birthDdate;

        #endregion

        #region Properties
        /// <summary>
        ///     Obtien ou définit le prénom de la personne
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDdate { get => birthDdate; set => birthDdate = value; }

        #endregion


        #region Constructors
        public Person()
        {

        }
        
        #endregion


        #region Methods

        #endregion
    }
}
