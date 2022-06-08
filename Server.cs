using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace DrawEveything
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            socket.CreateServer();
            tbIP.Text = socket.getIP();
            
        }    
        public SocketManager socket = new SocketManager();

        SqlDataAdapter dap;//Khai báo đối tượng gắn kết DataSource với DataSet
        DataSet ds;//Đối tượng chứa dữ liệu tại local
        SqlConnection con;//Khai báo đối tượng thực hiện kết nối đến cơ sở dữ liệu

        public void Database()
        {
            //Tạo đối tượng Connection
            con = new SqlConnection();
            //Truyền vào chuỗi kết nối tới cơ sở dữ liệu
            //Gọi Application.StartupPath để lấy đường dẫn tới thư mục chứa file chạy chương trình 
            con.ConnectionString = @"Data Source=DESKTOP-QPN0QKO\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            //Gọi phương thức Load dự liệu
            LoadDuLieu("Select * from Account");
        }
        private void LoadDuLieu(String sql)
        {
            //tạo đối tượng DataSet
             ds = new DataSet();
            //Khởi tạo đối tượng DataAdapter và cung cấp vào câu lệnh SQL và đối tượng Connection
             dap = new SqlDataAdapter(sql, con);
            //Dùng phương thức Fill của DataAdapter để đổ dữ liệu từ DataSource tới DataSet
             dap.Fill(ds);
            //Gắn dữ liệu từ DataSet lên DataGridView
             dgvServer.DataSource = ds.Tables[0];
        }
        private void Server_Load(object sender, EventArgs e)
        {
            Database();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Database();
        }
    }
}
