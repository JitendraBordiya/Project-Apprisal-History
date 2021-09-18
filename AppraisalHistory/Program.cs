using System;
using System.Data.SqlClient;
using Appraisal;

namespace AppraisalHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            char Choice;
            string Id;
            string Name;
            string DeptNo;
            string DeptName;
            string CurrRole;
            string NewRole;
            int AppNo;

            Console.WriteLine("Confirm Your Validation");
            //Console.Write("UserName :");
            //string UserName = Console.ReadLine();
            //Console.Write("Pass :");
            //string PassWord = Console.ReadLine();



     

            Apraisal.CreateConnection();
             Console.WriteLine("Connection SuccessFul");
            Console.WriteLine("############################################################");

            Console.WriteLine("          WelCome To T-Company    ");
            Console.WriteLine("############################################################");

            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1 to Check The Details Of Employee");
            Console.WriteLine("2 to Add New Data");
            Console.WriteLine("3 TO Update the Data");
            Console.WriteLine("4 TO HighAppraisal Employee's  Data");
            Console.WriteLine("5 Delete The Data");
            Console.WriteLine("Press Y to Continue");
            Console.WriteLine("_____________________________________________________________");

            do
            {
                Console.WriteLine("_____________________________________________________________");


                Console.WriteLine("Enter Your Choice");
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                    { 
                   case 1:
                        Apraisal.DisplayData();
                        break;
                    case 2:
                       
                        Console.WriteLine("Enter Your Details");
                        Console.Write("Enter ID : ");
                        Id = Console.ReadLine();
                        Console.Write("Enter Name : ");
                        Name = Console.ReadLine();
                        Console.Write("Enter DeptID : ");
                        DeptNo = Console.ReadLine();
                        Console.Write("Enter DeptName : ");
                        DeptName = Console.ReadLine();
                        Console.Write("Enter Your Role : ");
                        CurrRole = Console.ReadLine();
                        Console.Write("Enter Your New Role : ");
                        NewRole = Console.ReadLine();
                        Console.Write("Enter No of Appraisal : ");
                        AppNo = Convert.ToInt32(Console.ReadLine());
                        Apraisal.InsertData(Id, Name, DeptNo, DeptName, CurrRole, NewRole, AppNo);
                        break;
                    case 3:
                        Console.Write("Enter ID : ");
                        Id = Console.ReadLine();
                        Console.Write("Enter Your New Role : ");
                        NewRole = Console.ReadLine();
                        Console.Write("Enter Your AppNo : ");
                        AppNo = Convert.ToInt32( Console.ReadLine());
                        Apraisal.UpdateData( NewRole, Id,AppNo);
                        break;
                    case 4:
                        Console.WriteLine("Employees List Who Are Intern Now Managers");
                        Apraisal.HighAppData();
                        break;
                    case 5:
                        Console.Write("Enter ID : ");
                        Id = Console.ReadLine();

                        Apraisal.DeleteData(Id);
                        break;
                }
                 Console.Write("Want To revisit Data Press Y :");
                 Choice = Convert.ToChar(Console.ReadLine());
            } while(Choice == 'Y');

            Console.Read();

            
        }
    }
}
