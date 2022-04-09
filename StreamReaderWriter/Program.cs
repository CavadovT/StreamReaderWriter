using Newtonsoft.Json;
using StreamReaderWriter.Models;
using System;
using System.IO;


namespace StreamReaderWriter
{
    enum MenuBar { Quit, Add_Employe, Get_Employe_By_Id, Remove_Employe }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region COMMITS AND CONDITIONS
            /*
                         Program class
            Files folder-i yaradırsız içindədə Database.json deyə bir file yaradırsız amma database.json-u
            yaratmamışdan qabaq yoxlayırsız bu adda file yoxdursa yaradır
            
            Menu
            1. Add employee
            2. Get employee by id
            3. Remove employee
            0. Quit
            
            1-ci əməliyyatda istifadəçidən employee-nin bütün məlumatları istənəcək yeni bir employee
            obyekti yaranacaq və add methodu vasitəsilə listə əlavə oluncaq daha sonra həmin listi
            json-a serialize edəcəksiniz və həmin serialize olunmuş obyekti database.json faylına əlavə
            edəcəksiniz.
            
            2-ci əməliyyatda istidaçi bir id daxil edəcək daha sonra database.json faylının oxuyacaqsız
            axıra qədər ordan gələn string-i deserialize edəcəksizin department obyektinə və GetEmployeeById
            methodu vasitəsilə həmin id-li employee obyektini tapacaqsız
            
            3-cü əməliyyatda isə yenə 2 ci əməliyyatdakı kimi database.json oxunacaq deserialize olunacaq
            department obyektinə həmin idli employee tapılacaq və listdən silinəcək daha sonra həmin depatment
            yenidən obyekti serialize olunacaq json-a və database.json file-na yazılacaq.
             */
            #endregion


            string pathfolder = @"C:\Users\DELL\OneDrive - Bureau on ICT for Education, Ministry of Education\Desktop\StreamReaderWriter\StreamReaderWriter\Files";

            if (!Directory.Exists(pathfolder))
            {
                Directory.CreateDirectory(pathfolder);
            }
            string pathfile = @"C:\Users\DELL\OneDrive - Bureau on ICT for Education, Ministry of Education\Desktop\StreamReaderWriter\StreamReaderWriter\Files\database.json";
            if (!File.Exists(pathfile))
            {
                File.Create(pathfile);
            }

            Department department = new Department("Test");

            try
            {
                do
                {
                    Console.WriteLine("=====MENUBAR=====");
                    Console.Write($"\n1-Add Employe\n2-Get employe by Id\n3-Remove employe\n0-Quit\n");
                    int input = int.Parse(Console.ReadLine());


                    switch (input)
                    {
                        case (int)MenuBar.Add_Employe:
                            {

                                Console.Write("Please enter the Employe Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the Employe Salary: ");
                                double salary = double.Parse(Console.ReadLine());
                                Employe employe = new Employe(name, salary);
                                department.AddEmploye(employe);

                                using (StreamWriter stream = new StreamWriter(pathfile))
                                {
                                    stream.WriteLine(JsonConvert.SerializeObject(department));

                                }

                                break;
                            }
                        case (int)MenuBar.Get_Employe_By_Id:
                            {
                                if (department.Employes.Count == 0)
                                {
                                    Console.WriteLine("Error: Add employe first!!!");

                                }
                                else
                                {
                                    Console.Write("Id-daxil edin: ");
                                    var inputid = Console.ReadLine();
                                    int? id;
                                    if (string.IsNullOrEmpty(inputid))
                                    {
                                        id = null;
                                        department.GetEmployeById(id);
                                    }
                                    else
                                    {
                                        id = int.Parse(inputid);
                                        string result;
                                        using (StreamReader stream = new StreamReader(pathfile))

                                        {
                                            result = stream.ReadToEnd();

                                        }
                                        Department depresult = JsonConvert.DeserializeObject<Department>(result);

                                        depresult.GetEmployeById(id);

                                    }
                                }


                                break;
                            }
                        case (int)MenuBar.Remove_Employe:
                            {
                                if (department.Employes.Count == 0)
                                {
                                    Console.WriteLine("Error: Add employe first!!!");
                                }
                                else
                                {
                                    Console.Write("Please enter the ID: ");
                                    var idinput = Console.ReadLine();
                                    int? id;
                                    string result;
                                    if (string.IsNullOrEmpty(idinput))
                                    {
                                        id = null;
                                        department.RemoveEmploye(id);
                                    }
                                    else
                                    {
                                        id = Convert.ToInt32(idinput);
                                        using (StreamReader stream = new StreamReader(pathfile))
                                        {
                                            result = stream.ReadToEnd();
                                        }
                                        department = JsonConvert.DeserializeObject<Department>(result);

                                        department.RemoveEmploye(id);

                                        string resultnew = JsonConvert.SerializeObject(department);

                                        using (StreamWriter stream = new StreamWriter(pathfile))
                                        {
                                            stream.Write(resultnew);
                                        }

                                    }
                                }
                                
                                break;
                            }
                        case (int)MenuBar.Quit:
                            {
                                return;
                            }
                    }

                } while (true);

            }
            catch (Exception)
            {

            }
        }
    }
}
