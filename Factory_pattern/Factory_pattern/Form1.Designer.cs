namespace Factory_pattern
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.car_butt = new System.Windows.Forms.Button();
            this.ball_butt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.presentButton = new System.Windows.Forms.Button();
            this.box_c_butt = new System.Windows.Forms.Button();
            this.ribb_c_butt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(-5, 362);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(656, 50);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // car_butt
            // 
            this.car_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.car_butt.Location = new System.Drawing.Point(13, 13);
            this.car_butt.Name = "car_butt";
            this.car_butt.Size = new System.Drawing.Size(131, 55);
            this.car_butt.TabIndex = 1;
            this.car_butt.Text = "CAR";
            this.car_butt.UseVisualStyleBackColor = true;
            this.car_butt.Click += new System.EventHandler(this.car_butt_Click);
            // 
            // ball_butt
            // 
            this.ball_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ball_butt.Location = new System.Drawing.Point(150, 13);
            this.ball_butt.Name = "ball_butt";
            this.ball_butt.Size = new System.Drawing.Size(131, 55);
            this.ball_butt.TabIndex = 2;
            this.ball_butt.Text = "BALL";
            this.ball_butt.UseVisualStyleBackColor = true;
            this.ball_butt.Click += new System.EventHandler(this.ball_butt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Olive;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(150, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 31);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // presentButton
            // 
            this.presentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentButton.Location = new System.Drawing.Point(287, 13);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(131, 55);
            this.presentButton.TabIndex = 5;
            this.presentButton.Text = "PRESENT";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.presentButton_Click);
            // 
            // box_c_butt
            // 
            this.box_c_butt.BackColor = System.Drawing.Color.Olive;
            this.box_c_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_c_butt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.box_c_butt.Location = new System.Drawing.Point(287, 74);
            this.box_c_butt.Name = "box_c_butt";
            this.box_c_butt.Size = new System.Drawing.Size(131, 31);
            this.box_c_butt.TabIndex = 6;
            this.box_c_butt.UseVisualStyleBackColor = false;
            this.box_c_butt.Click += new System.EventHandler(this.box_c_butt_Click);
            // 
            // ribb_c_butt
            // 
            this.ribb_c_butt.BackColor = System.Drawing.Color.Olive;
            this.ribb_c_butt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribb_c_butt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ribb_c_butt.Location = new System.Drawing.Point(287, 111);
            this.ribb_c_butt.Name = "ribb_c_butt";
            this.ribb_c_butt.Size = new System.Drawing.Size(131, 31);
            this.ribb_c_butt.TabIndex = 7;
            this.ribb_c_butt.UseVisualStyleBackColor = false;
            this.ribb_c_butt.Click += new System.EventHandler(this.ribb_c_butt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ribb_c_butt);
            this.Controls.Add(this.box_c_butt);
            this.Controls.Add(this.presentButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ball_butt);
            this.Controls.Add(this.car_butt);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button car_butt;
        private System.Windows.Forms.Button ball_butt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button presentButton;
        private System.Windows.Forms.Button box_c_butt;
        private System.Windows.Forms.Button ribb_c_butt;
    }
}

