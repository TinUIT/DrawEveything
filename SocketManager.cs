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
        List<Socket> clientList;
        
        public void CreateServer()
        {
            clientList = new List<Socket>();

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
                        clientList.Add(client);

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
                                foreach (Socket socket in clientList)
                                {
                                    if (socket != client && socket != null)
                                    {
                                        socket.Send(SerializeData(receive));
                                    }
                                }
                                //MessageBox.Show(receive.Status);
                                break;
                            case "answer":
                                break;
                        }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    clientList.Remove(client);
                    client.Close();
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
            return target.Send(data) == 1 ? true : false;
        }


        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
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
            return bf1.Deserialize(ms);
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
