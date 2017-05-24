namespace NhamiBackEnd1
{
    partial class TurnOn
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
            this.tb_activity = new System.Windows.Forms.TextBox();
            this.b_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(185, 156);
            this.b_start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_start.Name = "b_start";
            this.b_start.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.b_start.Size = new System.Drawing.Size(100, 28);
            this.b_start.TabIndex = 7;
            this.b_start.Text = "Start";
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // l_myIP
            // 
            this.l_myIP.AutoSize = true;
            this.l_myIP.Location = new System.Drawing.Point(88, 44);
            this.l_myIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_myIP.Name = "l_myIP";
            this.l_myIP.Size = new System.Drawing.Size(46, 17);
            this.l_myIP.TabIndex = 1;
            this.l_myIP.Text = "My IP:";
            // 
            // l_myPort
            // 
            this.l_myPort.AutoSize = true;
            this.l_myPort.Location = new System.Drawing.Point(392, 44);
            this.l_myPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_myPort.Name = "l_myPort";
            this.l_myPort.Size = new System.Drawing.Size(38, 17);
            this.l_myPort.TabIndex = 2;
            this.l_myPort.Text = "Port:";
            // 
            // l_displayIP
            // 
            this.l_displayIP.AutoSize = true;
            this.l_displayIP.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.l_displayIP.Location = new System.Drawing.Point(145, 44);
            this.l_displayIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_displayIP.Name = "l_displayIP";
            this.l_displayIP.Size = new System.Drawing.Size(0, 17);
            this.l_displayIP.TabIndex = 5;
            // 
            // tf_portChoice
            // 
            this.tf_portChoice.BackColor = System.Drawing.SystemColors.Window;
            this.tf_portChoice.Location = new System.Drawing.Point(439, 41);
            this.tf_portChoice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tf_portChoice.Name = "tf_portChoice";
            this.tf_portChoice.Size = new System.Drawing.Size(132, 22);
            this.tf_portChoice.TabIndex = 6;
            // 
            // tb_activity
            // 
            this.tb_activity.Location = new System.Drawing.Point(16, 192);
            this.tb_activity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_activity.Multiline = true;
            this.tb_activity.Name = "tb_activity";
            this.tb_activity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_activity.Size = new System.Drawing.Size(577, 83);
            this.tb_activity.TabIndex = 8;
            this.tb_activity.TextChanged += new System.EventHandler(this.tb_activity_TextChanged);
            // 
            // b_Stop
            // 
            this.b_Stop.Location = new System.Drawing.Point(323, 156);
            this.b_Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_Stop.Name = "b_Stop";
            this.b_Stop.Size = new System.Drawing.Size(100, 28);
            this.b_Stop.TabIndex = 9;
            this.b_Stop.Text = "Stop";
            this.b_Stop.UseVisualStyleBackColor = true;
            this.b_Stop.Click += new System.EventHandler(this.b_Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 290);
            this.Controls.Add(this.b_Stop);
            this.Controls.Add(this.tb_activity);
            this.Controls.Add(this.tf_portChoice);
            this.Controls.Add(this.l_displayIP);
            this.Controls.Add(this.l_myPort);
            this.Controls.Add(this.l_myIP);
            this.Controls.Add(this.b_start);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox tb_activity;
        private System.Windows.Forms.Button b_Stop;
    }
}

