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

        public string[] topic = new string[] {"quần áo thể thao","mắt kính","thắt lưng","Ví tiền","khẩu trang","lens","khuyên tai","dây đeo đồng hồ",
                                       "bàn là","máy tính để bàn","máy đếm tiền","heo đất","tủ lạnh","bồn cầu","kem đánh răng",
                                       "ngữ văn","toán","mĩ thuật","địa lý","giáo dục công dân","tiếng nhật",
                                       "rắn","chó","heo rừng","dúi","nhím","đười ươi","chuột túi","thú mỏ vịt","rái cá"};

        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
    }
}
