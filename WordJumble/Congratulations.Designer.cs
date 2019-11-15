namespace WordJumble
{
    partial class Congratulations
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
            this.subtitle = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.callToAction = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // subtitle
            // 
            this.subtitle.AutoSize = true;
            this.subtitle.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.Gold;
            this.subtitle.Location = new System.Drawing.Point(36, 126);
            this.subtitle.MinimumSize = new System.Drawing.Size(734, 0);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(734, 35);
            this.subtitle.TabIndex = 69;
            this.subtitle.Text = "November 2019";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Jokerman", 44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Gold;
            this.title.Location = new System.Drawing.Point(101, 39);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(605, 87);
            this.title.TabIndex = 68;
            this.title.Text = "Bank Word Jumble";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jokerman", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(712, 312);
            this.label1.TabIndex = 70;
            this.label1.Text = "CONGRATS\r\nROCKSTAR!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(28, 368);
            this.label2.MinimumSize = new System.Drawing.Size(734, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(734, 90);
            this.label2.TabIndex = 71;
            this.label2.Text = "You successfully\r\ncompleted";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.title);
            this.panel1.Controls.Add(this.subtitle);
            this.panel1.Location = new System.Drawing.Point(-8, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 199);
            this.panel1.TabIndex = 72;
            // 
            // callToAction
            // 
            this.callToAction.AutoSize = true;
            this.callToAction.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callToAction.ForeColor = System.Drawing.Color.DarkRed;
            this.callToAction.Location = new System.Drawing.Point(28, 751);
            this.callToAction.MaximumSize = new System.Drawing.Size(734, 135);
            this.callToAction.MinimumSize = new System.Drawing.Size(734, 135);
            this.callToAction.Name = "callToAction";
            this.callToAction.Size = new System.Drawing.Size(734, 135);
            this.callToAction.TabIndex = 73;
            this.callToAction.Text = "Email a screenshot of this screen to JC Davis to be entered to win a fabulous pri" +
    "ze at the end of the month!";
            this.callToAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(647, 918);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 47);
            this.button1.TabIndex = 74;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Congratulations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(790, 977);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.callToAction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Congratulations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Congratulations";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label callToAction;
        private System.Windows.Forms.Button button1;
    }
}