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
        public Employe(string name, double salary)
        {
            _idemploye++;
            Idemploye = _idemploye;
            Name = name;
            Salary = salary;
            
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
