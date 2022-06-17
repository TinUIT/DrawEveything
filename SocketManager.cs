using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace DrawEveything
{
    public class SocketManager
    {
        #region Client
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<string> List_user = new List<string>();
        public void setIP(string IP)
        {
            sIP = IP;
        }

        public string getIP()
        {
            return sIP;
        }
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(sIP), PORT);
            
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region server

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientList1;
        List<Socket> clientList2;

        List<Player> room1;
        List<Player> room2;
        int Answered1 = 0;
        int Answered2 = 0;
        public void CreateServer()
        {
            clientList1 = new List<Socket>();
            clientList2 = new List<Socket>();

            room1 = new List<Player>();
            room2 = new List<Player>();

            IPEndPoint IP = new IPEndPoint(IPAddress.Any, 9999);
            
            server.Bind(IP);
            server.Listen(100);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Socket client = server.Accept();  

                        Thread receive = new Thread(ServerReceive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            })
            {
                IsBackground = true
            };
            Listen.Start();
        }

        void ServerReceive(Object obj)
        {
            Socket client = (Socket)obj;
            int room = 0;
            Player player = new Player();
            
            while (true)
            {
                try
                {
                    byte[] data = new byte[1024*5000];
                    client.Receive(data);

                    SocketData receive = (SocketData)DeserializeData(data);
                    SQLmanager checklogin = new SQLmanager();
                    SocketData respone = new SocketData();

                    switch (receive.Status)
                    {
                        case "login":
                            if (checklogin.CheckLogin(receive.Username, receive.Password))
                            {
                                respone.Status = "Success";
                                if (!List_user.Contains(receive.Username))
                                {
                                    List_user.Add(receive.Username);
                                }
                                else 
                                    respone.Status = "Exist";
                                client.Send(SerializeData(respone));
                            }
                            else
                            {
                                respone.Status = "Fail";
                                client.Send(SerializeData(respone));
                            }
                            break;
                        case "register":
                            if (checklogin.CheckRegister(receive.Username, receive.Password))
                            {
                                respone.Status = "Success";
                                client.Send(SerializeData(respone));
                            }
                            else
                            {
                                respone.Status = "Fail";
                                client.Send(SerializeData(respone));
                            }
                            break;
                        case "paint":
                        case "chat":
                            if (room == 1)
                            {
                                foreach (Socket socket in clientList1)
                                {
                                    if (socket != client && socket != null)
                                    {
                                        socket.Send(SerializeData(receive));
                                    }
                                }
                            }
                            else if (room == 2)
                            {
                                foreach (Socket socket in clientList2)
                                {
                                    if (socket != client && socket != null)
                                    {
                                        socket.Send(SerializeData(receive));
                                    }
                                }
                            }
                            break;
                        case "answer":
                            if (room == 1)
                            {
                                if (receive.chat == answer)
                                {
                                    Answered1++;
                                    for (int i = 0; i < clientList1.Count; i++)
                                    {
                                        if (client == clientList1[i])
                                        {
                                            room1[i].setMark(15);
                                            room1[Numrd].setMark(5);
                                            if(room1[i].getMark() >= 50)
                                            {
                                                receive.Status = "end";
                                            }
                                           
                                            int y = 0;
                                            foreach (Player p in room1)
                                            {
                                                receive.players[y] = p.Uname;
                                                receive.marks[y] = room1[y].getMark();
                                                y++;
                                            }

                                            break;
                                        }
                                    }

                                    foreach (Socket socket in clientList1)
                                    {
                                        receive.chat = "ĐÃ TRẢ LỜI ĐÚNG";
                                        socket.Send(SerializeData(receive));
                                    }
                                    if (Answered1 == room1.Count - 1)
                                    {
                                        Answered1 = 0;
                                        respone.Status = "stop";
                                        respone.done = true;
                                        clientList1[Numrd].Send(SerializeData(respone));
                                        Numrd = start(receive, respone, Numrd);
                                    }
                                }
                                else
                                {
                                    foreach (Socket socket in clientList1)
                                    {
                                        if (socket != client && socket != null)
                                        {
                                            socket.Send(SerializeData(receive));
                                        }
                                    }
                                }
                            }
                            else if (room == 2)
                            {
                                if (receive.chat == answer)
                                {
                                    Answered2++;
                                    for (int i = 0; i < clientList2.Count; i++)
                                    {
                                        if (client == clientList2[i])
                                        {
                                            room2[i].setMark(15);
                                            room1[Numrd].setMark(5);
                                            if (room2[i].getMark() >= 200)
                                            {

                                            }

                                            int y = 0;
                                            foreach (Player p in room2)
                                            {
                                                receive.players[y] = p.Uname;
                                                receive.marks[y] = room1[y].getMark();
                                                y++;
                                            }

                                            break;
                                        }
                                    }

                                    foreach (Socket socket in clientList2)
                                    {
                                        receive.chat = "ĐÃ TRẢ LỜI ĐÚNG";
                                        socket.Send(SerializeData(receive));
                                    }
                                    if (Answered2 == room2.Count - 1)
                                    {
                                        respone.Status = "stop";
                                        respone.done = true;
                                        clientList2[Numrd].Send(SerializeData(respone));
                                        start(receive, respone, Numrd);
                                    }
                                }
                                else
                                {
                                    foreach (Socket socket in clientList2)
                                    {
                                        if (socket != client && socket != null)
                                        {
                                            socket.Send(SerializeData(receive));
                                        }
                                    }
                                }
                            }
                            break;
                        case "getRoomPlayer":
                            respone.Status = "RoomPlayer";
                            respone.NumberOfRoom1 = clientList1.Count;
                            respone.NumberOfRoom2 = clientList2.Count;
                            client.Send(SerializeData(respone));
                            break;
                        case "start":
                            Numrd = start(receive,respone,Numrd);
                            break;
                        case "topic":
                            answer = receive.chosenTopic;
                            respone.Status = "topic";
                            client.Send(SerializeData(respone));
                            break;
                            case "out":
                            List_user.Remove(receive.Username);
                            break;
                        default:
                            room = receive.Room;
                            if (room == 1)
                            {
                                if (clientList1.Count <= 10)
                                {
                                    clientList1.Add(client);
                                    player = new Player();
                                    player.Uname = receive.Username;
                                    room1.Add(player);
                                    int i = 0;
                                    foreach (Player p in room1)
                                    {
                                        respone.marks[i] = room1[i].getMark();
                                        respone.players[i] = p.Uname;
                                        i++;
                                    }

                                    foreach (Socket socket in clientList1)
                                    {
                                        socket.Send(SerializeData(respone));
                                    }
                                }
                            }
                            else if (room == 2)
                            {
                                if (clientList2.Count <= 10)
                                {
                                    clientList2.Add(client);
                                    player = new Player();
                                    player.Uname = receive.Username;
                                    room2.Add(player);

                                    int i = 0;
                                    foreach (Player p in room2)
                                    {
                                        respone.marks[i] = room1[i].getMark();
                                        respone.players[i] = receive.Username;
                                        i++;
                                    }

                                    foreach (Socket socket in clientList2)
                                    {
                                        socket.Send(SerializeData(respone));
                                    }
                                }
                            }
                            break;
                    }

                }
                catch (Exception ex)
                {
                    if (room == 1)
                    {
                        clientList1.Remove(client);    
                        room1.Remove(player);
                        if (room1.Count == 0)
                            Answered1 = 0;
                    }
                    else if (room == 2)
                    {
                        clientList2.Remove(client);
                        room2.Remove(player);
                        if (room1.Count == 0)
                            Answered1 = 0;
                    }
                }
            }
        }

        public int start(SocketData receive, SocketData respone, int num)
        {
            Play play = new Play();
            Random rd = new Random();
            int Numrd = num;
            int Numrd1 = rd.Next(0, play.topic.Length);
            int Numrd2;
            do
            {
                Numrd2 = rd.Next(0, play.topic.Length);
            }
            while (Numrd1 == Numrd2);

            respone.Status = "start";
            if (clientList1.Count > 1)
            {
                Numrd++;
                if(Numrd >= clientList1.Count)
                    Numrd %= clientList1.Count;
            }
            if (clientList2.Count > 1)
            {
                Numrd++;
                if (Numrd >= clientList2.Count)
                    Numrd %= clientList2.Count;
            }
            if (receive.Room == 1)
            {
                foreach (Socket socket in clientList1)
                {
                    if (socket == clientList1[Numrd])
                    {
                        respone.start = true;
                        respone.topic1 = play.topic[Numrd1];
                        respone.topic2 = play.topic[Numrd2];
                        clientList1[Numrd].Send(SerializeData(respone));
                    }
                    else
                    {
                        respone.start = false;
                        socket.Send(SerializeData(respone));
                    }
                }
            }
            else if (receive.Room == 2)
            {
                foreach (Socket socket in clientList2)
                {
                    if (socket == clientList2[Numrd])
                    {
                        respone.start = true;
                        clientList2[Numrd].Send(SerializeData(respone));
                    }
                    else
                    {
                        respone.start = false;
                        socket.Send(SerializeData(respone));
                    }
                }
            }
            return Numrd;
        }
        #endregion

        #region Both
        public static string sIP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024*5000;
        string answer = "";
        int Numrd = 0;
        //public bool isRecieve = false;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);

            return SendData(client, sendData);
        }

        public object Receive()
        {
            byte[] receiveData = new byte[BUFFER];
            bool isOk = ReceiveData(client,receiveData);

            return DeserializeData(receiveData);
        }

        private bool SendData(Socket target, byte[] data)
        {
            try
            {
                return target.Send(data) == 1 ? true : false;
            }
            catch
            {
                return false;
            }
        }


        public bool ReceiveData(Socket target, byte[] data)
        {
            try
            {
                return target.Receive(data) == 1 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Nén đối tượng thành mảng byte[]
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        /// <summary>
        /// Giải nén mảng byte[] thành đối tượng object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            try
            {
                return bf1.Deserialize(ms);
            }
            catch
            {
                return theByteArray;
            }
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        public void Close()
        {
            server.Close();
            client.Close();
        }
        #endregion
    }
}
