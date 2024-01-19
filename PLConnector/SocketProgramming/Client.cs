// A C# program for Client 
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{

    public class Client
    {
        public int Port = 0;
        public string IpAdress = "127.0.0.1";
        public bool listen = true;
        public bool send = false;
        public int PerSec = 1000;

        // Main Method 
        //static void Main(string[] args)
        //{
        //    ExecuteClient();
        //}

        // ExecuteClient() Method 
        // this is just example and i did to this way   

        
        //public void ExecuteClient()
        //{

        //    try
        //    {

        //        // Establish the remote endpoint  
        //        // for the socket. This example  
        //        // uses port 11111 on the local  
        //        // computer. 
        //        //IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
        //        //IPAddress ipAddr = ipHost.AddressList[0];
        //        IPEndPoint localEndPoint = new IPEndPoint(Convert.ToInt64(IpAdress), Port);

        //        // Creation TCP/IP Socket using  
        //        // Socket Class Constructor 
        //        Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp);

        //        try
        //        {
        //            /*
        //             Hi Roman
        //            Sorry for bother you 
        //            first of all sorry my eng 
        //            idk anything about socket programing but im learning
        //             anyway, i wanna ask some question about Blade tigers packet logger 
        //            now (i think ) i can connect but, Does it send packets encrypted ?
        //             */
        //            // Connect Socket to the remote  
        //            // endpoint using method Connect() 
        //            sender.Connect(localEndPoint);

        //            // We print EndPoint information  
        //            // that we are connected 
        //            Console.WriteLine("Socket connected to -> {0} ",
        //                          sender.RemoteEndPoint.ToString());

        //            // Creation of messagge that 
        //            // we will send to Server 
        //            byte[] messageSent = Encoding.ASCII.GetBytes("Test Client<EOF>");
        //            int byteSent = sender.Send(messageSent);

        //            // Data buffer 
        //            byte[] messageReceived = new byte[1024];

        //            // We receive the messagge using  
        //            // the method Receive(). This  
        //            // method returns number of bytes 
        //            // received, that we'll use to  
        //            // convert them to string 

        //            int byteRecv = sender.Receive(messageReceived);
        //            //Console.WriteLine("Message from Server -> {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));

        //            // Close Socket using  
        //            // the method Close() 

        //            sender.Shutdown(SocketShutdown.Both);
        //            sender.Close();
        //        }

        //        // Manage of Socket's Exceptions 
        //        catch (ArgumentNullException ane)
        //        {

        //            Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //        }

        //        catch (SocketException se)
        //        {

        //            Console.WriteLine("SocketException : {0}", se.ToString());
        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Unexpected exception : {0}", e.ToString());
        //        }
        //    }

        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e.ToString());
        //    }
        //}
        // i'm not sure about fork about this method
        public void RecievePacketsFromServer()
        {

            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(Convert.ToInt64(IpAdress), Port);
                    sender.Connect(ipoint);
                        MessageBox.Show("Connect Successfuly!");
                    while (true)
                    {
                        if (!listen)
                        {
                            sender.Shutdown(SocketShutdown.Both);
                            sender.Close();
                            break;
                        }
                        byte[] buffer = new byte[2048];
                        int recieved = sender.Receive(buffer);
                        string packages = Encoding.ASCII.GetString(buffer, 0, recieved);
                        string[] package = packages.Split(' ');
                        string first = package[0];
                        if (first == "1")
                            package[0] = "Send";
                        else
                            package[0] = "Recieve";
                        string packet = package.ToString();
                        // yazdırma işlemi burada olacak ya da , return ile 


                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(" Can not connect the server! : {0}", e.ToString());
            }

        }

        public void SendPacketsToServer(string packet)
        {
            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(Convert.ToInt64(IpAdress), Port);
                    sender.Connect(ipoint);
                    MessageBox.Show("Connect Successfuly!");
                    byte[] buffer = Encoding.ASCII.GetBytes("1 " + packet);
                    while (true)
                    {
                        if (!listen)
                        {
                            sender.Shutdown(SocketShutdown.Both);
                            sender.Close();
                            break;
                        }
                        int a = sender.Send(buffer);
                        Thread.Sleep(PerSec);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($" WARNING ! \n: {e}");
            }
        }
        /*
hello Elendan
sometimes i want to connect someone's packler logger and send some packets
but i dont know anything about socket programing,
today i tried myself and learned some socket code and i want to share with you my little codes.
Because you know a lot of things and maybe you can comment my codes 
or if you are available you can give me some advice and I would be very thankful. 
So if you are available give me some advice please. Thank you for your helps.
         */

        // send once (idk hovv much  anybody need )
        public int SendAPer(string packet)
        {
            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(Convert.ToInt64(IpAdress), Port);
                    sender.Connect(ipoint);
                    byte[] buffer = Encoding.ASCII.GetBytes("1 " + packet);
                    int a = sender.Send(buffer);
                    return sender.Send(buffer);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}