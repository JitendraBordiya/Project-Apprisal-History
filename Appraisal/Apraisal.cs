using System;
using System.Data.SqlClient;

namespace Appraisal
{
    public class Apraisal
    {
        public string cons;
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static void CreateConnection()
        {
            string cons = "Data Source=LAPTOP-FS8H47HQ\\DBSERVER;Initial catalog=Appraisal;User Id=sa;password=@123";
            con = new SqlConnection();
            con.ConnectionString = cons;
        }
        public static void InsertData(string EmpId,string Name, string DeptNo, string CurrRole,string DeptName,string NewRole,int AppNo )
        {
            con.Open();
            string query = "Insert Into Employee(EmpId,EmpName,DeptNo,DeptName,CurrentRole,NewRole,AppNo) values('" + EmpId + "','" + Name + "','" + DeptNo + "','" + DeptName + "','" + CurrRole+ "','" + NewRole + "','" + AppNo + "')";

            cmd = new SqlCommand(query, con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} Record Insert Suceesfully", r);
            con.Close();
        }
        public static void DisplayData()
        {
            con.Open();
            string query = "Select * From Employee";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}  |  {6} | {7} ",dr["EmpId"],dr["EmpName"], dr["DeptNo"],dr["DeptName"],dr["CurrentRole"], dr["NewRole"], dr["AppDate"], dr["AppNo"]);
                
            }
            dr.Close();
            string cmdCount = "Select Count(*) from Employee";
            cmd = new SqlCommand(cmdCount, con);
            int Count = (int)cmd.ExecuteScalar();
            Console.WriteLine("{0} Records ", Count);
            con.Close();
        }
        public static void HighAppData()
        {
            con.Open();
            string query = "Select EmpId,EmpName,DeptName,CurrentRole From Employee Where AppNo=5";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("EmpID || Name   ||   DeptName  || CurrRole  ");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t   {1}   \t   {2}   \t   {3} ", dr["EmpId"],dr["EmpName"],dr["DeptName"],dr["CurrentRole"]);

            }
            dr.Close();
            con.Close();
        }


        public static void UpdateData(string NewRole,string id ,int AppNo)      
        {
            con.Open();
            string query = "update Employee Set CurrentRole='"+NewRole+"',NewRole='"+NewRole+ "', AppNo='" + AppNo + "'Where EmpId='" + id+"'";

            cmd = new SqlCommand(query, con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} Record Updates", r);
            con.Close();
        }
        public static void DeleteData(string id)
        {
            con.Open();
            string query = "Delete From Employee Where EmpId='" + id + "' ";

            cmd = new SqlCommand(query, con);
            int r = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} row Deleted", r);
            con.Close();
        }
    }
}
