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
        private static int _id;
        private string _name;
        private double _salary;
        #endregion

        #region PROPERTIES
        public int Idemploye 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
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
        public Employe(string name)
        {
            _id++;
            Idemploye = _id;
            Name = name;
        }
        #endregion

        #region METHODS
        public void ShowInfo() 
        {
            Console.Write($"\nEmploye's ID: {Idemploye}\nEmploye's Name: {Name}\nEmploye's Salary={Salary}\n");
        }
        public override string ToString()
        {
            return $"\nEmploye's ID: {Idemploye}\nEmploye's Name: {Name}\nEmploye's Salary={Salary}\n";
        }
        #endregion
    }
}
