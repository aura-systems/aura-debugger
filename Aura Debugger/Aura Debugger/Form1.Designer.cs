namespace Aura_Debugger
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LabelStatus = new System.Windows.Forms.Label();
            this.WorkerWait = new System.ComponentModel.BackgroundWorker();
            this.ChkAutoScroll = new System.Windows.Forms.CheckBox();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.LabelReceived = new System.Windows.Forms.Label();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.BtnWait = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WorkerConnect = new System.ComponentModel.BackgroundWorker();
            this.LabelIP = new System.Windows.Forms.Label();
            this.ChkWordWrap = new System.Windows.Forms.CheckBox();
            this.TxtOutput = new System.Windows.Forms.RichTextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelStatus
            // 
            this.LabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.ForeColor = System.Drawing.Color.White;
            this.LabelStatus.Location = new System.Drawing.Point(12, 522);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(38, 13);
            this.LabelStatus.TabIndex = 1;
            this.LabelStatus.Text = "Ready";
            this.LabelStatus.Visible = false;
            // 
            // WorkerWait
            // 
            this.WorkerWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerWait_DoWork);
            // 
            // ChkAutoScroll
            // 
            this.ChkAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkAutoScroll.AutoSize = true;
            this.ChkAutoScroll.Checked = true;
            this.ChkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAutoScroll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAutoScroll.ForeColor = System.Drawing.Color.White;
            this.ChkAutoScroll.Location = new System.Drawing.Point(687, 521);
            this.ChkAutoScroll.Name = "ChkAutoScroll";
            this.ChkAutoScroll.Size = new System.Drawing.Size(73, 17);
            this.ChkAutoScroll.TabIndex = 2;
            this.ChkAutoScroll.Text = "Autoscroll";
            this.ChkAutoScroll.UseVisualStyleBackColor = true;
            this.ChkAutoScroll.CheckedChanged += new System.EventHandler(this.ChkAutoScroll_CheckedChanged);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(233)))));
            this.BtnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(12, 14);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 3;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.BtnCopy.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(233)))));
            this.BtnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Location = new System.Drawing.Point(93, 14);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 23);
            this.BtnCopy.TabIndex = 4;
            this.BtnCopy.Text = "Copy";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // LabelReceived
            // 
            this.LabelReceived.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LabelReceived.AutoSize = true;
            this.LabelReceived.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelReceived.ForeColor = System.Drawing.Color.White;
            this.LabelReceived.Location = new System.Drawing.Point(343, 522);
            this.LabelReceived.Name = "LabelReceived";
            this.LabelReceived.Size = new System.Drawing.Size(86, 13);
            this.LabelReceived.TabIndex = 5;
            this.LabelReceived.Text = "Received logs: 0";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.BtnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(233)))));
            this.BtnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.BtnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConnect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnect.ForeColor = System.Drawing.Color.Lime;
            this.BtnConnect.Location = new System.Drawing.Point(542, 14);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(78, 23);
            this.BtnConnect.TabIndex = 6;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = false;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtIP
            // 
            this.TxtIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.TxtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIP.ForeColor = System.Drawing.Color.White;
            this.TxtIP.Location = new System.Drawing.Point(353, 14);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(183, 23);
            this.TxtIP.TabIndex = 7;
            // 
            // BtnWait
            // 
            this.BtnWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.BtnWait.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnWait.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(233)))));
            this.BtnWait.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.BtnWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnWait.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnWait.ForeColor = System.Drawing.Color.White;
            this.BtnWait.Location = new System.Drawing.Point(643, 14);
            this.BtnWait.Name = "BtnWait";
            this.BtnWait.Size = new System.Drawing.Size(117, 23);
            this.BtnWait.TabIndex = 8;
            this.BtnWait.Text = "Wait for connection";
            this.BtnWait.UseVisualStyleBackColor = false;
            this.BtnWait.Click += new System.EventHandler(this.BtnWait_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(624, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "or";
            // 
            // WorkerConnect
            // 
            this.WorkerConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerConnect_DoWork);
            // 
            // LabelIP
            // 
            this.LabelIP.AutoSize = true;
            this.LabelIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIP.ForeColor = System.Drawing.Color.White;
            this.LabelIP.Location = new System.Drawing.Point(302, 19);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.Size = new System.Drawing.Size(45, 13);
            this.LabelIP.TabIndex = 10;
            this.LabelIP.Text = "IP/Port:";
            // 
            // ChkWordWrap
            // 
            this.ChkWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkWordWrap.AutoSize = true;
            this.ChkWordWrap.Checked = true;
            this.ChkWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkWordWrap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkWordWrap.ForeColor = System.Drawing.Color.White;
            this.ChkWordWrap.Location = new System.Drawing.Point(593, 521);
            this.ChkWordWrap.Name = "ChkWordWrap";
            this.ChkWordWrap.Size = new System.Drawing.Size(81, 17);
            this.ChkWordWrap.TabIndex = 11;
            this.ChkWordWrap.Text = "Word Wrap";
            this.ChkWordWrap.UseVisualStyleBackColor = true;
            this.ChkWordWrap.CheckedChanged += new System.EventHandler(this.ChkWordWrap_CheckedChanged);
            // 
            // TxtOutput
            // 
            this.TxtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutput.BackColor = System.Drawing.Color.Black;
            this.TxtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutput.ForeColor = System.Drawing.Color.White;
            this.TxtOutput.Location = new System.Drawing.Point(12, 50);
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(748, 465);
            this.TxtOutput.TabIndex = 12;
            this.TxtOutput.Text = "";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(233)))));
            this.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(255)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(174, 14);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "Save...";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(772, 545);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.ChkWordWrap);
            this.Controls.Add(this.LabelIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnWait);
            this.Controls.Add(this.TxtIP);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.LabelReceived);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.ChkAutoScroll);
            this.Controls.Add(this.LabelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cosmos Network Debugger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelStatus;
        private System.ComponentModel.BackgroundWorker WorkerWait;
        private System.Windows.Forms.CheckBox ChkAutoScroll;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Label LabelReceived;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Button BtnWait;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker WorkerConnect;
        private System.Windows.Forms.Label LabelIP;
        private System.Windows.Forms.CheckBox ChkWordWrap;
        private System.Windows.Forms.RichTextBox TxtOutput;
        private System.Windows.Forms.Button BtnSave;
    }
}

