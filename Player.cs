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
        private static int Room;

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
    }
}
