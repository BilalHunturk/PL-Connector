using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PortFinder();
        }

        private void PortFinder()
        {
            int port = 0;
            Process[] ps = Process.GetProcessesByName("NostaleClientX");
            foreach (Process p in ps) {
                if (p.MainWindowTitle.Contains("BladeTiger12")) {
                    string[] pl = p.MainWindowTitle.Split(':');
                    port = Convert.ToInt32(pl[2]);
                    Console.WriteLine("PL found!");
                    break;
                }
            }
            if (port == 0)
            {
                MessageBox.Show("No port found");
            }
            MessageBox.Show($"{port} port found!");
            aptallık.Port = port;
        }

        List<CancellationTokenSource> cancellationTokenSources = new List<CancellationTokenSource>();
        PacketManagement packetManagement = new PacketManagement();
        List<Task> tasks = new List<Task>();
        Aptallık aptallık = new Aptallık();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void stplistn_btn_Click(object sender, EventArgs e)
        {
              
        }

        private void snd_btn_Click(object sender, EventArgs e)
        {
            aptallık.send = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            if (aptallık.Bekle)
                aptallık.Bekle = false;
            else if (!aptallık.Bekle)
                aptallık.Bekle = true;
        }

        private void btnRightClick_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PortFinder();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  Put button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            Packet packet = new Packet()
            {
                ATime = Convert.ToInt16(atime_text.Text == "" ? "0": atime_text.Text),
                Period = Convert.ToInt16(period_text.Text == "" ? "0": period_text.Text),
                Name = packet_name_text.Text,
            };
            packetManagement.AddPacketToList(packet);
            packetShower.Items.Add(packet.Name);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            foreach (var packet in packetManagement.Packets)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                tasks.Add(Task.Run(() => aptallık.SendPacketsToPL(packet,cancellationTokenSource.Token)));
                cancellationTokenSources.Add(cancellationTokenSource);
            }

        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            foreach(var token in cancellationTokenSources) {
                token.Cancel();
            }
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            
            var selectedPacket = packetShower.SelectedItem;
            if (selectedPacket == null) return;
            packetManagement.RemovePacketFromList(packetManagement.GetPacket(selectedPacket.ToString()));
            packetShower.Items.Remove(selectedPacket);
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            var selectedPacket = packetShower.SelectedItem;
            if (selectedPacket == null) return;
            Packet newPacket = new Packet()
            {
                ATime = Convert.ToInt16(atime_text.Text),
                Period = Convert.ToInt16(period_text.Text),
                Name = packet_name_text.Text,
            };
            packetManagement.UpdatePacketFromList(packetManagement.GetPacket(selectedPacket.ToString()),newPacket);
        }

        private void packetShower_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = packetShower.SelectedItem;
            if(selectedItem == null) return;
            var packet = packetManagement.GetPacket(selectedItem.ToString());
            atime_text.Text = packet.ATime.ToString();
            period_text.Text = packet.Period.ToString();
            packet_name_text.Text = packet.Name;
        }

        private void extract_menu_Click(object sender, EventArgs e)
        {
            var path = folder_browser.ShowDialog();
            if (path == DialogResult.OK)
            {
                aptallık.ExtractFileJson(packetManagement.Packets, folder_browser.SelectedPath);
            }
        }

        private void import_menu_Click(object sender, EventArgs e)
        {
            var path = open_file.ShowDialog();
            if (path == DialogResult.OK)
            {
                var packets = aptallık.ImportFileJson(packetManagement.Packets,open_file.FileName);
                packetManagement.Packets = packets;
                addPacketsToShower(packetManagement.Packets);
            }

        }
         private void addPacketsToShower(List<Packet> packets)
        {
            foreach (var packet in packets) packetShower.Items.Add(packet.Name);
        }
    }
}


