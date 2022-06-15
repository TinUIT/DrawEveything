using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DrawEveything
{
    public class SQLmanager
    {
        //Khai báo các biến toàn cục
        SqlConnection con;//Khai báo đối tượng thực hiện kết nối đến cơ sở dữ liệu
        SqlCommand cmd;//Khai báo đối tượng thực hiện các câu lệnh truy vấn
        SqlDataAdapter dap;//Khai báo đối tượng gắn kết DataSource với DataSet
        DataSet ds;//Đối tượng chứa dữ liệu tại local
        

        //Hàm kiểm tra xem thông tin client đăng nhập đúng hay không
        public bool CheckLogin(string UserName, string Password)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=WINDOWS-10;Initial Catalog=ACCOUNT;Integrated Security=True");

            string name = UserName;  //login.getUsername();
            string pass = Password; //login.getPassword();

            string sql = "Select * from Account where Name = '" + name + "' and Password = '" + pass + "'";
            connect.Open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        // Hàm kiểm tra việc đăng ký tài khoản được hay không
        public bool CheckRegister(string UserName, string Password)
        {
            //Nếu đăng ký thành công thì sẽ return true
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=WINDOWS-10;Initial Catalog=ACCOUNT;Integrated Security=True");


                string name = UserName;
                string pass = Password;

                string sql = "Insert into Account(Name,Password) values ('" + name + "','" + pass + "')";


                SqlCommand cmd = new SqlCommand(sql, connect);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                cmd.Dispose();
                return true;
            }
            //Có lỗi xãy ra thì return false
            catch (Exception)
            {
                return false;
            }

        }


    }
}
