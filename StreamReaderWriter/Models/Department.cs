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
        public void GetEmployeById(int id) 
        {

            List<Employe> findemloyes = Employes.FindAll(emp1 => emp1.Idemploye == id);
            foreach (Employe item in findemloyes)
            {
                item.ShowInfo();
            }
        }
        public void RemoveEmploye(int id) 
        {
            Employe emp = Employes.Find(m => m.Idemploye == id);
            if (emp == null) 
            {
                throw new InvalidOperationException("Invalid Operation");

            }
            Employes.Remove(emp);
            Console.WriteLine("Successfully Removed");
        }
        #endregion

    }
}
