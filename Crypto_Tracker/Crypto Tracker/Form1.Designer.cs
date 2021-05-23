
namespace Crypto_Tracker
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
            this.onBT = new System.Windows.Forms.Button();
            this.offBt = new System.Windows.Forms.Button();
            this.coinDataTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // onBT
            // 
            this.onBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.onBT.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.onBT.Location = new System.Drawing.Point(12, 12);
            this.onBT.Name = "onBT";
            this.onBT.Size = new System.Drawing.Size(167, 112);
            this.onBT.TabIndex = 0;
            this.onBT.Text = "ON";
            this.onBT.UseVisualStyleBackColor = false;
            this.onBT.Click += new System.EventHandler(this.onBT_Click);
            // 
            // offBt
            // 
            this.offBt.BackColor = System.Drawing.Color.Red;
            this.offBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.offBt.Location = new System.Drawing.Point(1126, 680);
            this.offBt.Name = "offBt";
            this.offBt.Size = new System.Drawing.Size(167, 112);
            this.offBt.TabIndex = 1;
            this.offBt.Text = "OFF";
            this.offBt.UseVisualStyleBackColor = false;
            this.offBt.Click += new System.EventHandler(this.offBt_Click);
            // 
            // coinDataTB
            // 
            this.coinDataTB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinDataTB.Location = new System.Drawing.Point(12, 130);
            this.coinDataTB.Multiline = true;
            this.coinDataTB.Name = "coinDataTB";
            this.coinDataTB.ReadOnly = true;
            this.coinDataTB.Size = new System.Drawing.Size(1281, 544);
            this.coinDataTB.TabIndex = 2;
            // 
            // Form1
            // 
            this.AcceptButton = this.onBT;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.CancelButton = this.offBt;
            this.ClientSize = new System.Drawing.Size(1305, 804);
            this.Controls.Add(this.coinDataTB);
            this.Controls.Add(this.offBt);
            this.Controls.Add(this.onBT);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypto Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onBT;
        private System.Windows.Forms.Button offBt;
        private System.Windows.Forms.TextBox coinDataTB;
    }
}

