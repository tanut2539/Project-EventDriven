namespace Project_1570700839
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_edit = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_buy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(162, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "โปรแกรมจัดการร้านมินิมาร์ท";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_1570700839.Properties.Resources.header;
            this.pictureBox1.Location = new System.Drawing.Point(203, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // bt_edit
            // 
            this.bt_edit.Image = global::Project_1570700839.Properties.Resources.edit;
            this.bt_edit.Location = new System.Drawing.Point(365, 220);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(94, 94);
            this.bt_edit.TabIndex = 3;
            this.bt_edit.Text = "แก้ไขสินค้า";
            this.bt_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_edit.UseVisualStyleBackColor = true;
            this.bt_edit.Click += new System.EventHandler(this.bt_edit_Click);
            // 
            // bt_add
            // 
            this.bt_add.Image = global::Project_1570700839.Properties.Resources.add;
            this.bt_add.Location = new System.Drawing.Point(226, 220);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(94, 94);
            this.bt_add.TabIndex = 2;
            this.bt_add.Text = "เพิ่มสินค้า";
            this.bt_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_buy
            // 
            this.bt_buy.Image = global::Project_1570700839.Properties.Resources.buy;
            this.bt_buy.Location = new System.Drawing.Point(84, 220);
            this.bt_buy.Name = "bt_buy";
            this.bt_buy.Size = new System.Drawing.Size(94, 94);
            this.bt_buy.TabIndex = 1;
            this.bt_buy.Text = "ขาย";
            this.bt_buy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_buy.UseVisualStyleBackColor = true;
            this.bt_buy.Click += new System.EventHandler(this.bt_buy_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 346);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_edit);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.bt_buy);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leel Minimart Co.Ltd.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_buy;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}