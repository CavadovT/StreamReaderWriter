using System;
using System.Collections.Generic;
using System.Text;

namespace StreamReaderWriter.Models
{
    internal class Employe
    {
        #region COMMITS AND CONTITIONS

        /*
          Employee class
            - Id
            - Name
            - Salary
            - ShowInfo()
         */
        #endregion

        #region FIELDS
        private static int _idemploye;
        private string _name;
        private double _salary;
        #endregion

        #region PROPERTIES
        public int Idemploye { get; set; }
        
        public string Name 
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        public double Salary 
        {
            get
            {
                return (double)this._salary;
            }
            set
            {
                _salary = (double)value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// bura nebde ancaq remov edende isleyir ve yeni bir instas olmur id de artmir!!!
        /// </summary>
        public Employe()
        { 
            //Console.WriteLine("BU konstructor remov islediyinde isleyir bos id artmasin");
            
            
        }
        /// <summary>
        /// burada ise menemenim Id im artir yeni bir employe yaradir instas edirem onuncunde removda bura islemir ve id heleki sabit qalir!!!!
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        public Employe(string name, double salary)
        {
            //Console.WriteLine("BU konstructor yeni bir employe yaradanda add edende islesin ve id burda static artsin");
            Name = name;
            Salary = salary;
            _idemploye++;
            Idemploye = _idemploye;
        }

        #endregion

        #region METHODS
        public void ShowInfo() 
        {
            Console.Write($"\nID: {Idemploye}\nEmploye's Name: {Name}\nEmploye's Salary={Salary}\n");
        }
        public override string ToString()
        {
            return $"\nEmploye'sID: {Idemploye}\nEmploye's Name: {Name}\nEmploye's Salary={Salary}\n";
        }
        #endregion
    }
}
