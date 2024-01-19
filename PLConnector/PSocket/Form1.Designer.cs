
namespace PSocket
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.port_refresher_button = new System.Windows.Forms.Button();
            this.packet_name_text = new System.Windows.Forms.TextBox();
            this.put_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.atime_text = new System.Windows.Forms.TextBox();
            this.period_text = new System.Windows.Forms.TextBox();
            this.packetShower = new System.Windows.Forms.ListBox();
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extract_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.import_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.folder_browser = new System.Windows.Forms.FolderBrowserDialog();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_refresher_button
            // 
            this.port_refresher_button.Location = new System.Drawing.Point(247, 307);
            this.port_refresher_button.Name = "port_refresher_button";
            this.port_refresher_button.Size = new System.Drawing.Size(101, 53);
            this.port_refresher_button.TabIndex = 10;
            this.port_refresher_button.Text = "Refresh Port";
            this.port_refresher_button.UseVisualStyleBackColor = true;
            this.port_refresher_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // packet_name_text
            // 
            this.packet_name_text.Location = new System.Drawing.Point(157, 239);
            this.packet_name_text.Name = "packet_name_text";
            this.packet_name_text.Size = new System.Drawing.Size(191, 20);
            this.packet_name_text.TabIndex = 11;
            this.packet_name_text.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // put_button
            // 
            this.put_button.Location = new System.Drawing.Point(21, 266);
            this.put_button.Name = "put_button";
            this.put_button.Size = new System.Drawing.Size(101, 26);
            this.put_button.TabIndex = 12;
            this.put_button.Text = "Put";
            this.put_button.UseVisualStyleBackColor = true;
            this.put_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(27, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Packet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(27, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Time After Packet ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(27, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Period";
            // 
            // atime_text
            // 
            this.atime_text.Location = new System.Drawing.Point(157, 187);
            this.atime_text.Name = "atime_text";
            this.atime_text.Size = new System.Drawing.Size(191, 20);
            this.atime_text.TabIndex = 16;
            // 
            // period_text
            // 
            this.period_text.Location = new System.Drawing.Point(157, 213);
            this.period_text.Multiline = true;
            this.period_text.Name = "period_text";
            this.period_text.Size = new System.Drawing.Size(191, 20);
            this.period_text.TabIndex = 17;
            // 
            // packetShower
            // 
            this.packetShower.ColumnWidth = 1;
            this.packetShower.FormattingEnabled = true;
            this.packetShower.Location = new System.Drawing.Point(21, 27);
            this.packetShower.Name = "packetShower";
            this.packetShower.Size = new System.Drawing.Size(327, 147);
            this.packetShower.TabIndex = 18;
            this.packetShower.SelectedIndexChanged += new System.EventHandler(this.packetShower_SelectedIndexChanged);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(21, 307);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(99, 53);
            this.start_button.TabIndex = 19;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(136, 307);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(101, 53);
            this.stop_button.TabIndex = 20;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // remove_button
            // 
            this.remove_button.Location = new System.Drawing.Point(136, 266);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(101, 26);
            this.remove_button.TabIndex = 21;
            this.remove_button.Text = "Remove";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(247, 266);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(101, 26);
            this.update_button.TabIndex = 22;
            this.update_button.Text = "Update";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extract_menu,
            this.import_menu});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // extract_menu
            // 
            this.extract_menu.Name = "extract_menu";
            this.extract_menu.Size = new System.Drawing.Size(180, 22);
            this.extract_menu.Text = "Extract file";
            this.extract_menu.Click += new System.EventHandler(this.extract_menu_Click);
            // 
            // import_menu
            // 
            this.import_menu.Name = "import_menu";
            this.import_menu.Size = new System.Drawing.Size(180, 22);
            this.import_menu.Text = "Import file";
            this.import_menu.Click += new System.EventHandler(this.import_menu_Click);
            // 
            // folder_browser
            // 
            this.folder_browser.SelectedPath = "C:\\Users\\Bilal\\Desktop";
            // 
            // open_file
            // 
            this.open_file.FileName = "open_file_dialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(374, 376);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.packetShower);
            this.Controls.Add(this.period_text);
            this.Controls.Add(this.atime_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.put_button);
            this.Controls.Add(this.packet_name_text);
            this.Controls.Add(this.port_refresher_button);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button port_refresher_button;
        private System.Windows.Forms.Button put_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox atime_text;
        private System.Windows.Forms.TextBox period_text;
        private System.Windows.Forms.ListBox packetShower;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.Button update_button;
        public System.Windows.Forms.TextBox packet_name_text;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem extract_menu;
        private System.Windows.Forms.ToolStripMenuItem import_menu;
        private System.Windows.Forms.FolderBrowserDialog folder_browser;
        private System.Windows.Forms.OpenFileDialog open_file;
    }
}

