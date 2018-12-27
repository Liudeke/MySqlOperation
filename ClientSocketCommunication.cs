using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;

namespace ZHGW
{
    class ClientSocketCommunication:IDisposable
    {
        public string IPString { get; set; }
        public string PortString { get; set; }
        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Action<byte[]> OnReceiveMsg;
        private Thread th;
        public ClientSocketCommunication() { }
        public ClientSocketCommunication(string ip, string port, Action<byte[]> OnReMsg)
        {
            IPString = ip; PortString = port;
            OnReceiveMsg = OnReMsg;
            Connication(IPString, PortString);
        }

        private void Connication(string ipStr, string portStr)
        {
            IPAddress ip = IPAddress.Parse(ipStr);

            //IPAddress ip = IPAddress.Any;

            //连接到目标IP的哪个应用(端口号！)

            IPEndPoint point = new IPEndPoint(ip, int.Parse(portStr));

            try
            {
                //连接到服务器

                client.Connect(point);

                ShowMsg("连接成功");

                ShowMsg("服务器" + client.RemoteEndPoint.ToString());

                ShowMsg("客户端:" + client.LocalEndPoint.ToString());

                //连接成功后，就可以接收服务器发送的信息了

                th = new Thread(ReceiveMsg);

                th.IsBackground = true;

                th.Start();
            }

            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }
        void ShowMsg(string msg)
        {
            Console.WriteLine(msg);            //txtInfo.text+=(msg + "\r\n");
        }
        private void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];

                    int n = client.Receive(buffer);
                    if (OnReceiveMsg != null)
                    {
                        OnReceiveMsg(buffer);
                    }
                }

                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }
        public void SendMsg(byte[] buffer)
        {
            //客户端给服务器发消息
            if (client != null)
            {
                try
                {
                    client.Send(buffer);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                }
            }
        }
        public void Dispose()
        {
            StopThread(th);
        }
        private void StopThread(Thread tr)
        {
            if (th != null)
            {
                while (!th.IsAlive) ;
            }
            Thread.Sleep(1000);
            if (th != null)
            {
                th.Join();
            }
        }

    }
}
