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
        public int marked;
        public string chat, topic1, topic2, chosenTopic;
        
        public bool start = false;
        public int Room = 0;
        public int NumberOfRoom1 = 0;
        public int NumberOfRoom2 = 0;

        public byte[] image;
        public string[] players = new string[10];
        public int[] marks = new int[10];
        public SocketData() {
            for (int i = 0; i < 10; i++)
            {
                players[i] = "";
            }
        }

        public SocketData(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
