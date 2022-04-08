using Newtonsoft.Json;
using StreamReaderWriter.Models;
using System;
using System.Collections.Generic;
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
           string pathfile= @"C:\Users\DELL\OneDrive - Bureau on ICT for Education, Ministry of Education\Desktop\StreamReaderWriter\StreamReaderWriter\Files\database.json";
            if (!File.Exists(pathfile))
            {
            File.Create(pathfile);
            }
            

            try
            {
                do
                {
                    Console.Write($"\n1-Add Employe\n2-Get employe by Id\n3-Remove employe\n0-Quit\n");
                    int input = int.Parse(Console.ReadLine());
                    Department department = new Department("test");
                    
                    switch (input)
                    {
                        case (int)MenuBar.Add_Employe:
                            {
                                
                                Console.Write("Please enter the Employe Name: ");
                                string name=Console.ReadLine();
                                Console.Write("Please enter the Employe Salary: ");
                                double salary=double.Parse(Console.ReadLine());
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
                                Console.WriteLine("2 isledi");
                                break;
                            }
                        case (int)MenuBar.Remove_Employe:
                            {
                                Console.WriteLine("3 isledi");
                                break;
                            }
                        case (int)MenuBar.Quit:
                            {
                                Console.WriteLine("0-isledi");
                                return;
                            }
                        default:
                            break;
                    }


                } while (true);

            }
            catch (Exception )
            {

                
            }
        }
    }
}
