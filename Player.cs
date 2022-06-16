using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawEveything
{
    [Serializable]
    internal class Player
    {
        private static string Username, Password;
        public string Uname;
        private static int Room = 0;
        public int Marked = 0;

        public Player() { }
        
        public Player(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Player (int room)
        {
            Room = room;
        }

        public string getUsername ()
        {
            return Username;
        }

        public int getRoom()
        {
            return Room;   
        }

        public int getMark()
        {
            return Marked;
        }

        public void setMark(int mark)
        {
            Marked += mark;
        }
    }
}
