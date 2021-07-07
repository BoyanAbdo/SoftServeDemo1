using System;

namespace SoftServeDemo1._1
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Employee serenaWilliams = new Employee("Serena", "Williams", 49, 'f', "CEO");
            Employee andreAgassi = new Employee("Andre", "Agassi", 39, 'm', "CTO");

            Employee rogerFederer = new Employee("Roger", "Federer", 38, 'm', "Head of Marketing");
            Employee cvetanaPironkova = new Employee("Cvetana", "Pironkova", 34, 'f', "Marketing");
            Employee novakDjokovic = new Employee("Novak", "Djokovic", 30, 'm', "Marketing");

            Employee rafaelNadal = new Employee("Rafael", "Nadal", 41, 'm', "Senior Manager");
            Employee monicaSeles = new Employee("Monica", "Seles", 32, 'f', "Software Quality Assurance");
            Employee peteSampras = new Employee("Pete", "Sampras", 40, 'm', "Project Manager");

            Employee borisBecker = new Employee("Boris", "Graff", 37, 'm', "Senior Developer");
            Employee sofiaKenin = new Employee("Sofia", "Kenin", 35, 'f', "Developer");
            Employee grigorDimitrov = new Employee("Grigor", "Dimitrov", 30, 'm', "Developer");
            Employee elinaSvitolina = new Employee("Elina", "Svitolina", 30, 'f', "Developer");
            Employee alexandrDolgopolov = new Employee("Alexandr", "Dolgopolov", 25, 'm', "Junior Developer");
            Employee andyMurray = new Employee("Andy", "Murray", 25, 'm', "Intern");
            Employee dominicThiem = new Employee("Dominic", "Thiem", 22, 'm', "Intern");

            Employee mariaSharapova = new Employee("Maria", "Sharapova", 32, 'f', "Head of Design");
            Employee steffiGraf = new Employee("Steffi", "Graf", 27, 'f', "Senior Designer");
            Employee andyRoddick = new Employee("Andy", "Roddick", 25, 'm', "Designer");
            Employee martinaHingis = new Employee("Martina", "Hingis", 20, 'f', "Junior Designer");



            Tree<Employee> companyTree =
                new Tree<Employee>(serenaWilliams,
                    new Tree<Employee>(andreAgassi),
                    new Tree<Employee>(rogerFederer,
                        new Tree<Employee>(cvetanaPironkova),
                        new Tree<Employee>(novakDjokovic)),
                    new Tree<Employee>(rafaelNadal,
                        new Tree<Employee>(monicaSeles),
                        new Tree<Employee>(peteSampras,
                            new Tree<Employee>(borisBecker,
                                new Tree<Employee>(sofiaKenin,
                                    new Tree<Employee>(alexandrDolgopolov)),
                                new Tree<Employee>(grigorDimitrov),
                                new Tree<Employee>(elinaSvitolina,
                                    new Tree<Employee>(andyMurray),
                                    new Tree<Employee>(dominicThiem)))),
                        new Tree<Employee>(mariaSharapova,
                            new Tree<Employee>(steffiGraf,
                                new Tree<Employee>(andyRoddick),
                                new Tree<Employee>(martinaHingis)))
                ));

            companyTree.PrintDFS();
            Console.WriteLine();


            // Reading two employees to find their Lowest Common Ancestor (LCA)
            Console.WriteLine("Enter two employees' first and last names to find their Lowest Common Ancestor (LCA):");

            Console.Write("Employee A first name: ");
            string employeeAFirstName = Console.ReadLine();
            Console.Write("Employee A last name:  ");
            string employeeALastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Employee B first name: ");
            string employeeBFirstName = Console.ReadLine();
            Console.Write("Employee B last name:  ");
            string employeeBLastName = Console.ReadLine();
            Console.WriteLine();


            // Validate the input and finding the nodes
            Employee employeeA = new Employee();
            Employee employeeB = new Employee();

            foreach (Employee employee in companyTree.listOfEmployees)
            {
                if (employee.FirstName == employeeAFirstName && employee.LastName == employeeALastName)
                {
                    employeeA = employee;
                }
                else if (employee.FirstName == employeeBFirstName && employee.LastName == employeeBLastName)
                {
                    employeeB = employee;
                }
            }

            if (employeeA.FirstName != null && employeeB.FirstName != null)
            {
                // Printing the paths and LCA of the two given employees 
                companyTree.PrintLCA(employeeA, employeeB);
            }
            else
            {
                Console.WriteLine("Names not found!");
                Console.WriteLine("Please enter valid names from the tree structure above.");
            }



        }
    }
}
