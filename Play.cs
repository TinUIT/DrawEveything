using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawEveything
{
    internal class Play
    {
        private int currentPlayer;
        bool start = false;

        string[] topic = new string[] {"học sing","giáo viên","bác sĩ","mặt trời",
                                       "chạy",""                                   };

        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
    }
}
