using System;
using System.Collections.Generic;
using System.Text;

namespace StreamReaderWriter.Models
{
    internal class Department
    {
        #region COMMIT AND CONTITION
        /*
              Department
     - Id
     - Name
     - Employees list

     - AddEmployee() - employee obyekti qebul edecek
     - GetEmployeeById() - id qebul edecek
     - RemoveEmployee() - id qebul edecek
      */
        #endregion

        #region FIELDS
        private static int _id;
        private string _name;
        private List<Employe> _employes;

        #endregion

        #region PROPERTIES
        public int IDdepartament { get;  }
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; 
            }
        }
        public  List<Employe> Employes
        {
            get
            {
                return _employes;
            }
            set 
            {
                _employes = value; 
            }
        }
        #endregion
 
        #region CONSTRUCTORS

        public Department(string name)
        {
            _id++;
           IDdepartament = _id;
            Name = name;    
            _employes=new List<Employe>();
        }

        #endregion

        #region METHODS
        public void AddEmploye(Employe employe) 
        {
          Employes.Add(employe);
          
        }
       
        public void GetEmployeById(int? id) 
        {
            int countfind=0;
            if (id == null) 
            {
                Console.WriteLine("Id is NUll");
                return;
            }

            List<Employe> findemloyes = Employes.FindAll(emp1 => emp1.Idemploye == id);
            foreach (Employe item in findemloyes)
            {
                item.ShowInfo();
                countfind++;

            }
            if (countfind == 0) 
            {
                Console.WriteLine("Not Found ");
            }
           
        }
        public void RemoveEmploye(int? id) 
        {
            int counfind = 0;
            if (id == null) 
            {
                Console.WriteLine("Id is NULL");
                return;
            }
            List<Employe> emp = Employes.FindAll(m => m.Idemploye == id);
            foreach (var item in emp)
            {
            Employes.Remove(item);
                counfind++;
            Console.WriteLine("Successfully Removed");
             return;
            }
            if (counfind == 0) 
            {
                Console.WriteLine("Not Found this ID employe");
            }

        }
        #endregion

    }
}
