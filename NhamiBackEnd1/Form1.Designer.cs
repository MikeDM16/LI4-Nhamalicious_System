namespace NhamiBackEnd1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_start = new System.Windows.Forms.Button();
            this.l_myIP = new System.Windows.Forms.Label();
            this.l_myPort = new System.Windows.Forms.Label();
            this.l_displayIP = new System.Windows.Forms.Label();
            this.tf_portChoice = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tb_activity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(185, 110);
            this.b_start.Name = "b_start";
            this.b_start.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.b_start.Size = new System.Drawing.Size(75, 23);
            this.b_start.TabIndex = 7;
            this.b_start.Text = "Start";
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // l_myIP
            // 
            this.l_myIP.AutoSize = true;
            this.l_myIP.Location = new System.Drawing.Point(66, 36);
            this.l_myIP.Name = "l_myIP";
            this.l_myIP.Size = new System.Drawing.Size(37, 13);
            this.l_myIP.TabIndex = 1;
            this.l_myIP.Text = "My IP:";
            // 
            // l_myPort
            // 
            this.l_myPort.AutoSize = true;
            this.l_myPort.Location = new System.Drawing.Point(294, 36);
            this.l_myPort.Name = "l_myPort";
            this.l_myPort.Size = new System.Drawing.Size(29, 13);
            this.l_myPort.TabIndex = 2;
            this.l_myPort.Text = "Port:";
            // 
            // l_displayIP
            // 
            this.l_displayIP.AutoSize = true;
            this.l_displayIP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.l_displayIP.Location = new System.Drawing.Point(109, 36);
            this.l_displayIP.Name = "l_displayIP";
            this.l_displayIP.Size = new System.Drawing.Size(0, 13);
            this.l_displayIP.TabIndex = 5;
            // 
            // tf_portChoice
            // 
            this.tf_portChoice.BackColor = System.Drawing.SystemColors.Window;
            this.tf_portChoice.Location = new System.Drawing.Point(329, 33);
            this.tf_portChoice.Name = "tf_portChoice";
            this.tf_portChoice.Size = new System.Drawing.Size(100, 20);
            this.tf_portChoice.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            // 
            // tb_activity
            // 
            this.tb_activity.Location = new System.Drawing.Point(12, 156);
            this.tb_activity.Multiline = true;
            this.tb_activity.Name = "tb_activity";
            this.tb_activity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_activity.Size = new System.Drawing.Size(434, 68);
            this.tb_activity.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 236);
            this.Controls.Add(this.tb_activity);
            this.Controls.Add(this.tf_portChoice);
            this.Controls.Add(this.l_displayIP);
            this.Controls.Add(this.l_myPort);
            this.Controls.Add(this.l_myIP);
            this.Controls.Add(this.b_start);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Label l_myIP;
        private System.Windows.Forms.Label l_myPort;
        private System.Windows.Forms.Label l_displayIP;
        private System.Windows.Forms.TextBox tf_portChoice;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox tb_activity;
    }
}

