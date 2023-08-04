namespace AsyncClient_New
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSent = new System.Windows.Forms.Button();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.receivedMsgBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSent
            // 
            this.btnSent.Location = new System.Drawing.Point(407, 54);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(94, 29);
            this.btnSent.TabIndex = 0;
            this.btnSent.Text = "button1";
            this.btnSent.UseVisualStyleBackColor = true;
            this.btnSent.Click += new System.EventHandler(this.button1_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(259, 56);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(125, 27);
            this.msgBox.TabIndex = 1;
            // 
            // receivedMsgBox
            // 
            this.receivedMsgBox.Location = new System.Drawing.Point(259, 149);
            this.receivedMsgBox.Multiline = true;
            this.receivedMsgBox.Name = "receivedMsgBox";
            this.receivedMsgBox.Size = new System.Drawing.Size(242, 98);
            this.receivedMsgBox.TabIndex = 2;
            this.receivedMsgBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "send message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "receive message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ip address";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(22, 55);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(125, 27);
            this.ipBox.TabIndex = 6;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(22, 126);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(125, 27);
            this.portBox.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(20, 179);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 29);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "port number";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.statusLabel.Location = new System.Drawing.Point(22, 227);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(140, 20);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "server disconnected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 299);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receivedMsgBox);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.btnSent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSent;
        private TextBox msgBox;
        private TextBox receivedMsgBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox ipBox;
        private TextBox portBox;
        private Button btnConnect;
        private Label label4;
        private Label statusLabel;
    }
}