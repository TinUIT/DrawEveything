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
            string answer= "";
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
                                foreach (Socket socket in clientList1)
                                {
                                    if (receive.chat == answer)
                                    {
                                        respone.chat = "đã trả lời đúng";
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
                        case "getRoomPlayer":
                            respone.Status = "RoomPlayer";
                            respone.NumberOfRoom1 = clientList1.Count;
                            respone.NumberOfRoom2 = clientList2.Count;
                            client.Send(SerializeData(respone));
                            break;
                        case "start":
                            Play play = new Play();
                            Random rd = new Random();
                            int Numrd = 0;
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
                                Numrd = rd.Next(0, clientList1.Count - 1);                              
                            }
                            if (clientList2.Count > 1)
                            {
                                Numrd = rd.Next(0, clientList2.Count - 1);
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
                            break;
                        case "topic":
                            answer = receive.chosenTopic;
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
                                        respone.players[i] = receive.Username;
                                        i++;
                                    }

                                    client.Send(SerializeData(respone));
                                }
                            }
                            break;
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    if (room == 1)
                    {
                        clientList1.Remove(client);
                        room1.Remove(player);
                    }
                    else if (room == 2)
                    {
                        clientList2.Remove(client);
                        room2.Remove(player);
                    }
                }
            }
        }
        #endregion

        #region Both
        public static string sIP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER = 1024*5000;
        
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
