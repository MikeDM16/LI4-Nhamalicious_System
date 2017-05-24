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
            this.tb_activity = new System.Windows.Forms.TextBox();
            this.b_Stop = new System.Windows.Forms.Button();
            this.l_displayPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(139, 127);
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
            // tb_activity
            // 
            this.tb_activity.Location = new System.Drawing.Point(12, 156);
            this.tb_activity.Multiline = true;
            this.tb_activity.Name = "tb_activity";
            this.tb_activity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_activity.Size = new System.Drawing.Size(434, 68);
            this.tb_activity.TabIndex = 8;
            this.tb_activity.TextChanged += new System.EventHandler(this.tb_activity_TextChanged);
            // 
            // b_Stop
            // 
            this.b_Stop.Location = new System.Drawing.Point(242, 127);
            this.b_Stop.Name = "b_Stop";
            this.b_Stop.Size = new System.Drawing.Size(75, 23);
            this.b_Stop.TabIndex = 9;
            this.b_Stop.Text = "Stop";
            this.b_Stop.UseVisualStyleBackColor = true;
            this.b_Stop.Click += new System.EventHandler(this.b_Stop_Click);
            // 
            // l_displayPort
            // 
            this.l_displayPort.AutoSize = true;
            this.l_displayPort.Location = new System.Drawing.Point(330, 36);
            this.l_displayPort.Name = "l_displayPort";
            this.l_displayPort.Size = new System.Drawing.Size(0, 13);
            this.l_displayPort.TabIndex = 10;
            // 
            // TurnOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 236);
            this.Controls.Add(this.l_displayPort);
            this.Controls.Add(this.b_Stop);
            this.Controls.Add(this.tb_activity);
            this.Controls.Add(this.l_displayIP);
            this.Controls.Add(this.l_myPort);
            this.Controls.Add(this.l_myIP);
            this.Controls.Add(this.b_start);
            this.Name = "TurnOn";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Label l_myIP;
        private System.Windows.Forms.Label l_myPort;
        private System.Windows.Forms.Label l_displayIP;
        private System.Windows.Forms.TextBox tb_activity;
        private System.Windows.Forms.Button b_Stop;
        private System.Windows.Forms.Label l_displayPort;
    }
}

