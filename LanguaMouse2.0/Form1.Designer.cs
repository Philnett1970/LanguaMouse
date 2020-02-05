namespace LanguaMouse2._0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrOut = new System.Windows.Forms.Timer(this.components);
            this.tmrInn = new System.Windows.Forms.Timer(this.components);
            this.lblMouseXY = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblNumScreens = new System.Windows.Forms.Label();
            this.tmrCurPosition = new System.Windows.Forms.Timer(this.components);
            this.chkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.tmrCursorOn = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblDate = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkBoxStartUp = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.picBoxBarFontColor = new System.Windows.Forms.PictureBox();
            this.txtNudgeAmount = new System.Windows.Forms.TextBox();
            this.chkBoxHFree = new System.Windows.Forms.CheckBox();
            this.chkBoxPTT = new System.Windows.Forms.CheckBox();
            this.chkBoxSpeak = new System.Windows.Forms.CheckBox();
            this.chkBoxHighLight = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picBoxFont = new System.Windows.Forms.PictureBox();
            this.picBoxLine = new System.Windows.Forms.PictureBox();
            this.picBoxHighLight = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMouseSpeed = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tmrMouseUP = new System.Windows.Forms.Timer(this.components);
            this.tmrMouseDown = new System.Windows.Forms.Timer(this.components);
            this.tmrMouseLeft = new System.Windows.Forms.Timer(this.components);
            this.tmrMouseRight = new System.Windows.Forms.Timer(this.components);
            this.tmrStopSound = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBarFontColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHighLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrOut
            // 
            this.tmrOut.Tick += new System.EventHandler(this.tmrOut_Tick);
            // 
            // tmrInn
            // 
            this.tmrInn.Tick += new System.EventHandler(this.tmrInn_Tick);
            // 
            // lblMouseXY
            // 
            this.lblMouseXY.AutoSize = true;
            this.lblMouseXY.Location = new System.Drawing.Point(118, 60);
            this.lblMouseXY.Name = "lblMouseXY";
            this.lblMouseXY.Size = new System.Drawing.Size(153, 15);
            this.lblMouseXY.TabIndex = 1;
            this.lblMouseXY.Text = "CurrentMouse Position";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(118, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 15);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Current User:";
            // 
            // lblNumScreens
            // 
            this.lblNumScreens.AutoSize = true;
            this.lblNumScreens.Location = new System.Drawing.Point(118, 36);
            this.lblNumScreens.Name = "lblNumScreens";
            this.lblNumScreens.Size = new System.Drawing.Size(130, 15);
            this.lblNumScreens.TabIndex = 3;
            this.lblNumScreens.Text = "Number of Screens";
            // 
            // tmrCurPosition
            // 
            this.tmrCurPosition.Enabled = true;
            this.tmrCurPosition.Tick += new System.EventHandler(this.tmrCurPosition_Tick);
            // 
            // chkBoxAutoHide
            // 
            this.chkBoxAutoHide.AutoSize = true;
            this.chkBoxAutoHide.Location = new System.Drawing.Point(121, 88);
            this.chkBoxAutoHide.Name = "chkBoxAutoHide";
            this.chkBoxAutoHide.Size = new System.Drawing.Size(178, 19);
            this.chkBoxAutoHide.TabIndex = 5;
            this.chkBoxAutoHide.Text = "Auto Hide Main Window";
            this.chkBoxAutoHide.UseVisualStyleBackColor = true;
            this.chkBoxAutoHide.CheckedChanged += new System.EventHandler(this.chkBoxAutoHide_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTime,
            this.toolStripButton1,
            this.lblDate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 289);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(439, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(39, 22);
            this.lblTime.Text = "Time";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(75, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(114, 22);
            this.toolStripButton1.Text = "LanguaMouse";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // lblDate
            // 
            this.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Margin = new System.Windows.Forms.Padding(25, 1, 3, 2);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 22);
            this.lblDate.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.chkBoxStartUp);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.picBoxBarFontColor);
            this.panel1.Controls.Add(this.txtNudgeAmount);
            this.panel1.Controls.Add(this.chkBoxHFree);
            this.panel1.Controls.Add(this.chkBoxPTT);
            this.panel1.Controls.Add(this.chkBoxSpeak);
            this.panel1.Controls.Add(this.chkBoxHighLight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picBoxFont);
            this.panel1.Controls.Add(this.picBoxLine);
            this.panel1.Controls.Add(this.picBoxHighLight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMouseSpeed);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.chkBoxAutoHide);
            this.panel1.Controls.Add(this.lblMouseXY);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.lblNumScreens);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 286);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 245);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 62);
            this.textBox1.TabIndex = 44;
            this.textBox1.Visible = false;
            // 
            // chkBoxStartUp
            // 
            this.chkBoxStartUp.AutoSize = true;
            this.chkBoxStartUp.Location = new System.Drawing.Point(208, 222);
            this.chkBoxStartUp.Name = "chkBoxStartUp";
            this.chkBoxStartUp.Size = new System.Drawing.Size(147, 19);
            this.chkBoxStartUp.TabIndex = 43;
            this.chkBoxStartUp.Text = "Start with Windows";
            this.chkBoxStartUp.UseVisualStyleBackColor = true;
            this.chkBoxStartUp.CheckedChanged += new System.EventHandler(this.chkBoxStartUp_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(205, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 42;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInput.Location = new System.Drawing.Point(12, 247);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(164, 21);
            this.txtInput.TabIndex = 41;
            this.txtInput.Visible = false;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged_1);
            // 
            // picBoxBarFontColor
            // 
            this.picBoxBarFontColor.Location = new System.Drawing.Point(346, 197);
            this.picBoxBarFontColor.Name = "picBoxBarFontColor";
            this.picBoxBarFontColor.Size = new System.Drawing.Size(36, 21);
            this.picBoxBarFontColor.TabIndex = 40;
            this.picBoxBarFontColor.TabStop = false;
            this.picBoxBarFontColor.Click += new System.EventHandler(this.picBoxBarFontColor_Click);
            // 
            // txtNudgeAmount
            // 
            this.txtNudgeAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNudgeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNudgeAmount.ForeColor = System.Drawing.Color.White;
            this.txtNudgeAmount.Location = new System.Drawing.Point(260, 138);
            this.txtNudgeAmount.Name = "txtNudgeAmount";
            this.txtNudgeAmount.Size = new System.Drawing.Size(41, 21);
            this.txtNudgeAmount.TabIndex = 39;
            this.txtNudgeAmount.Text = "25";
            this.txtNudgeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBoxHFree
            // 
            this.chkBoxHFree.AutoSize = true;
            this.chkBoxHFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkBoxHFree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxHFree.Location = new System.Drawing.Point(307, 115);
            this.chkBoxHFree.Name = "chkBoxHFree";
            this.chkBoxHFree.Size = new System.Drawing.Size(91, 17);
            this.chkBoxHFree.TabIndex = 38;
            this.chkBoxHFree.Text = "Hands Free";
            this.chkBoxHFree.UseVisualStyleBackColor = true;
            this.chkBoxHFree.CheckedChanged += new System.EventHandler(this.chkBoxHFree_CheckedChanged);
            // 
            // chkBoxPTT
            // 
            this.chkBoxPTT.AutoSize = true;
            this.chkBoxPTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkBoxPTT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxPTT.Location = new System.Drawing.Point(208, 115);
            this.chkBoxPTT.Name = "chkBoxPTT";
            this.chkBoxPTT.Size = new System.Drawing.Size(93, 17);
            this.chkBoxPTT.TabIndex = 37;
            this.chkBoxPTT.Text = "Enable PTT";
            this.chkBoxPTT.UseVisualStyleBackColor = true;
            this.chkBoxPTT.CheckedChanged += new System.EventHandler(this.chkBoxPTT_CheckedChanged);
            // 
            // chkBoxSpeak
            // 
            this.chkBoxSpeak.AutoSize = true;
            this.chkBoxSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkBoxSpeak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxSpeak.Location = new System.Drawing.Point(12, 224);
            this.chkBoxSpeak.Name = "chkBoxSpeak";
            this.chkBoxSpeak.Size = new System.Drawing.Size(191, 17);
            this.chkBoxSpeak.TabIndex = 36;
            this.chkBoxSpeak.Text = "Turn On/Off Audio Response";
            this.chkBoxSpeak.UseVisualStyleBackColor = true;
            // 
            // chkBoxHighLight
            // 
            this.chkBoxHighLight.AutoSize = true;
            this.chkBoxHighLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkBoxHighLight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkBoxHighLight.Location = new System.Drawing.Point(13, 115);
            this.chkBoxHighLight.Name = "chkBoxHighLight";
            this.chkBoxHighLight.Size = new System.Drawing.Size(189, 17);
            this.chkBoxHighLight.TabIndex = 36;
            this.chkBoxHighLight.Text = "Turn On/Off Cursor Highlight";
            this.chkBoxHighLight.UseVisualStyleBackColor = true;
            this.chkBoxHighLight.CheckedChanged += new System.EventHandler(this.chkBoxHighLight_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Change Line Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(205, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Change Bar Font Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(208, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Change Font Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Change Highlight Color";
            // 
            // picBoxFont
            // 
            this.picBoxFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxFont.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picBoxFont.Location = new System.Drawing.Point(346, 165);
            this.picBoxFont.Name = "picBoxFont";
            this.picBoxFont.Size = new System.Drawing.Size(36, 21);
            this.picBoxFont.TabIndex = 32;
            this.picBoxFont.TabStop = false;
            this.picBoxFont.Click += new System.EventHandler(this.picBoxFont_Click);
            // 
            // picBoxLine
            // 
            this.picBoxLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picBoxLine.Location = new System.Drawing.Point(166, 197);
            this.picBoxLine.Name = "picBoxLine";
            this.picBoxLine.Size = new System.Drawing.Size(36, 21);
            this.picBoxLine.TabIndex = 33;
            this.picBoxLine.TabStop = false;
            this.picBoxLine.Click += new System.EventHandler(this.picBoxLine_Click);
            // 
            // picBoxHighLight
            // 
            this.picBoxHighLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxHighLight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picBoxHighLight.Location = new System.Drawing.Point(166, 165);
            this.picBoxHighLight.Name = "picBoxHighLight";
            this.picBoxHighLight.Size = new System.Drawing.Size(36, 21);
            this.picBoxHighLight.TabIndex = 32;
            this.picBoxHighLight.TabStop = false;
            this.picBoxHighLight.Click += new System.EventHandler(this.picBoxHighLight_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(163, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Nudge Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Mouse Speed";
            // 
            // txtMouseSpeed
            // 
            this.txtMouseSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMouseSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMouseSpeed.ForeColor = System.Drawing.Color.White;
            this.txtMouseSpeed.Location = new System.Drawing.Point(106, 138);
            this.txtMouseSpeed.Name = "txtMouseSpeed";
            this.txtMouseSpeed.Size = new System.Drawing.Size(41, 21);
            this.txtMouseSpeed.TabIndex = 29;
            this.txtMouseSpeed.Text = "15";
            this.txtMouseSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(408, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // tmrMouseUP
            // 
            this.tmrMouseUP.Tick += new System.EventHandler(this.tmrMouseUP_Tick);
            // 
            // tmrMouseDown
            // 
            this.tmrMouseDown.Tick += new System.EventHandler(this.tmrMouseDown_Tick);
            // 
            // tmrMouseLeft
            // 
            this.tmrMouseLeft.Tick += new System.EventHandler(this.tmrMouseLeft_Tick);
            // 
            // tmrMouseRight
            // 
            this.tmrMouseRight.Tick += new System.EventHandler(this.tmrMouseRight_Tick);
            // 
            // tmrStopSound
            // 
            this.tmrStopSound.Tick += new System.EventHandler(this.tmrStopSound_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(439, 314);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBarFontColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHighLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrOut;
        private System.Windows.Forms.Timer tmrInn;
        private System.Windows.Forms.Label lblMouseXY;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblNumScreens;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrCurPosition;
        private System.Windows.Forms.CheckBox chkBoxAutoHide;
        private System.Windows.Forms.Timer tmrCursorOn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNudgeAmount;
        private System.Windows.Forms.CheckBox chkBoxHFree;
        private System.Windows.Forms.CheckBox chkBoxPTT;
        private System.Windows.Forms.CheckBox chkBoxHighLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxLine;
        private System.Windows.Forms.PictureBox picBoxHighLight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMouseSpeed;
        private System.Windows.Forms.ToolStripLabel lblTime;
        private System.Windows.Forms.ToolStripLabel lblDate;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.CheckBox chkBoxSpeak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBoxFont;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picBoxBarFontColor;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrMouseUP;
        private System.Windows.Forms.Timer tmrMouseDown;
        private System.Windows.Forms.Timer tmrMouseLeft;
        private System.Windows.Forms.Timer tmrMouseRight;
        private System.Windows.Forms.Timer tmrStopSound;
        private System.Windows.Forms.CheckBox chkBoxStartUp;
        private System.Windows.Forms.TextBox textBox1;
    }
}

