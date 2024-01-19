using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSocket
{
    public class PacketManagement
    {
        public List<Packet> Packets { get; set; }

        public PacketManagement() { Packets = new List<Packet>(); }
        
        public void AddPacketToList(Packet packet)
        {
            Packets.Add(packet);
        }
        
        public void RemovePacketFromList(Packet packet) {  Packets.Remove(packet); }

        public Packet GetPacket(string packetName) {  
            return Packets.Find(p=>p.Name.Contains(packetName)); 
        }

        public void UpdatePacketFromList(Packet packet,Packet newPacket)
        {
            int index = Packets.IndexOf(packet);
            Packets[index] = newPacket;
        }
    }
}
