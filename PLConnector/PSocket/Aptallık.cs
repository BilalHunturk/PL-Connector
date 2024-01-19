using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSocket
{
    public class Aptallık
    {
        // remove, Change, export, import.

        public static string IpAdress = "127.0.0.1";
        public int Port;
        static byte[] adress = new byte[4];
        public IPAddress iPAdress = new IPAddress(Ata(IpAdress, adress));
        public bool listen = true;
        public bool send = true;
        public bool Bekle = true;
        public int PerSec = 1000;
        public int icinde = 15;
        static byte[] Ata(string ipAdress, byte[] adress)
        {
            string[] a = ipAdress.Split('.');
            for (int i = 0; i < adress.Length; i++)
            {
                adress[i] = Convert.ToByte(a[i]);
            }
            return adress;
        }

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
                        sender.Send(buffer);
                        Thread.Sleep(PerSec);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($" WARNING ! \n: {e}");
            }
        }

        public void ExtractFileJson(List<Packet> packets,string path)
        {
            try
            {
                var serializedPackets = JsonConvert.SerializeObject(packets);
                using (StreamWriter file = File.CreateText(path+"\\packets.json"))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        JObject json = new JObject();
                        json["packets"] = JToken.FromObject(packets);
                        json.WriteTo(writer);
                    }
                }
                //JObject json = new JObject();
                //   json["packets"] = JToken.FromObject(packets);
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}");
            }
        }

        public List<Packet> ImportFileJson(List<Packet> packets, string path)
        {
            try
            {
                JObject o = JObject.Parse(File.ReadAllText(path));
                using (StreamReader file = File.OpenText(path))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o2 = (JObject)JToken.ReadFrom(reader);
                        o2 = JObject.Parse(o2.ToString());
                        packets = o2["packets"].ToObject<List<Packet>>();
                    }
                }
               // var serielizedInput = JsonConvert.DeserializeObject<Packet>(readText);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return packets;
        }
        /// <summary>
        /// this function does send packets to PL with proper properties that Packet class has.
        /// </summary>
        /// <param name="packet"></param>
        public void SendPacketsToPL(Packet packet, CancellationToken token)
        {
            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(iPAdress, Port);
                    sender.Connect(ipoint);
                    MessageBox.Show("Connect Successfuly!");
                    byte[] buffer = Encoding.ASCII.GetBytes("1 " + packet.Name);
                    Thread.Sleep(packet.ATime*100);
                    while (true)
                    {
                        if (token.IsCancellationRequested) { 
                            //MessageBox.Show("Requested for Cancellation"); 
                            break;
                        }
                        sender.Send(buffer);
                        Thread.Sleep(packet.Period*100);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($" WARNING ! \n: {e}");
            }
        }

        public int SendAPer(string packet)
        {
            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(iPAdress, Port);
                    sender.Connect(ipoint);

                    byte[] buffer = Encoding.ASCII.GetBytes("1 " + packet);
                    //int a = sender.Send(buffer);
                    int ge = 0;
                    int da = 0;
                    while (ge < 121)
                    {

                        byte[] bok = Encoding.ASCII.GetBytes("1 " + $"eqinfo 1 {da}");
                        Thread.Sleep(2000);
                        ge++;
                        da++;
                        if (!Bekle)
                        {
                            byte[] bok1 = Encoding.ASCII.GetBytes("1 " + $"mvi 0 {da - 1} 1 0");
                            sender.Send(bok1);
                            MessageBox.Show("Durdurdugun item 0. slotta");
                        }
                        if (!send)
                        {
                            send = true;
                            break;
                        }
                    }
                    return sender.Send(buffer);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        // gelen mesajı okuyacak bunu bir diziye atıyacak daha sonra bu diziyi gezicek içerisinde yukarıdaki listede
        // belirtilen seyler varmı yoksa 2 defa daha tekrarlıyacak
        public bool RecievePacketsFromServer1(byte[] eqinfo, Dictionary<int, Dictionary<int, Dictionary<int, string>>> sptr)
        {

            bool varmı = false, first = false;
            try
            {
                using (Socket sender = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    IPEndPoint ipoint = new IPEndPoint(iPAdress, Port);
                    sender.Connect(ipoint);
                    while (!first)
                    {
                        List<string[]> package = new List<string[]>();
                        List<bool> varmıs = new List<bool>();
                        sender.Send(eqinfo);
                        Thread.Sleep(300);
                        int g = 0;
                        int l = 20;
                        int index = -1;

                        if (!listen)
                            break;

                        package = ListenPackets(sender);

                        for (int i = 0; i < package.Count; i++)
                        {
                            if (package[i].Length <= 1)
                            {
                                continue;
                            }
                            if (package[i][1] == "e_info") // e_info geliyor fakat daha öncesinden paketler geldiği için e_infoyu bulamıyoryani 2. index dolu oldugu için bunun için burda e infoyu gezicez
                            {
                                index = i;
                                Console.WriteLine("Geldi ve Index degeri : " + index);
                                break;
                            }
                        }
                        if (index == -1)
                        {
                            continue;
                        }

                        bool ShouldItFinish = false;
                        foreach (var list in sptr)
                        {
                            for (int i = icinde; i < package[index].Length; i++)
                            {
                                foreach (var inList in list.Value)
                                {
                                    foreach (var twoInList in inList.Value)
                                    {
                                        var result = package[index][i].IndexOf(twoInList.Value);
                                        if (result != -1)
                                        {
                                            var parse = package[index][i].Split('.');
                                            if (Convert.ToInt32(parse[2]) >= twoInList.Key)
                                            {
                                                varmıs.Add(true);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (varmıs.Count != list.Value.Count) // istenilen midye gelmezse demek(istenilen deger result'un içinde varsa true deger eklenir yoksa eklenmez dolayısıyla bütün seyler gözden geçirildiğinde iki dizinin countları birbirine eşit olmazsa istenen durum yok demektir bu durumda recieve pakedinin false dönmesi gerekir)
                            {
                                Console.WriteLine("istenilen degerlerden ancak bu kadarı çıktı : " + varmıs.Count);
                                varmıs.Clear();
                                varmı = false;
                            }
                            else
                            {
                                
                                varmı = true;
                                ShouldItFinish = true;
                                break;
                            }
                        }
                        
                        first = true;
                    }
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    if (varmı)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($" Can not connect the server! : {e}");
            }
            return false;

        }

        private static List<string[]> ListenPackets(Socket sender)
        {
            //
            byte[] buffer = new byte[4096];
            int recieved = sender.Receive(buffer);
            string packages = Encoding.ASCII.GetString(buffer, 0, recieved);
            string[] package = packages.Split('\r');
            List<string[]> packagelist = new List<string[]>(package.Length);
            for (int i = 0; i < package.Length; i++)
            {
                string[] array = package[i].Split(' ');
                packagelist.Add(array);
            }
            return packagelist;
        }
    }

}

/*
 *                          int a = 0;
                            while (a < package.Length)
                            {
                                for (int b = 0; b < elements.Count; b++)
                                {
                                    if (package[a] == elements[b])
                                    {
                                        varmıs[g] = true;
                                        g++;
                                        break;
                                    }
                                }
                                if (!varmıs.Any(p => p == false))
                                {
                                    varmı = true;
                                    break;
                                }

                            }
 
 */

/*
                        for (int a = 0; a < package.Length; a++)
                        {
                            for (int b = 0; b < elements.Count; b++)
                            {
                                if (package[a] == elements[b])
                                {
                                    varmıs[g] = true;
                                    g++;
                                    break;
                                }
                            }
                            if (!varmıs.Any(p => p == false))
                            {
                                varmı = true;
                                break;
                            }
                        }
 */

/*
 //int a = 0;
                        //while (a < package.Count)
                        //{
                        //    for (int b = 0; b < elements.Count; b++)
                        //    {
                        //        //var result = string.Compare(elements[b], package[a]);
                        //        var result = package[a].IndexOf(elements[b]);
                        //        if (result != -1)
                        //        {
                        //            varmıs[g] = true;
                        //            g++;
                        //            break;
                        //        }
                        //    }
                        //    if (varmıs.Any(p => p == null || p == false))
                        //    {
                        //        a++;
                        //        continue;
                        //    }
                        //    else if (true)
                        //    {
                        //        varmı = true;
                        //        break;
                        //    }

                        //}
 */
