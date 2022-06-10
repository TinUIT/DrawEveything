using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawEveything
{
    [Serializable]
    public class SocketData
    {
        public string Username, Password;
        public string Status = "";

        public string chat;

        public int index;

        public byte[] image;

        public SocketData() { }

        public SocketData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public SocketData(string c, float Width, int cX, int cY, int sX, int sY, int Index, string status) 
        {
            this.index = Index;
            this.Status = status;
        }
    }
}
