namespace CodeBuilder
{
    partial class ChooseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_2 = new System.Windows.Forms.TextBox();
            this.tbx_1 = new System.Windows.Forms.TextBox();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQ = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_4 = new System.Windows.Forms.TextBox();
            this.btn_B = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_2);
            this.groupBox1.Controls.Add(this.tbx_1);
            this.groupBox1.Controls.Add(this.lbl_2);
            this.groupBox1.Controls.Add(this.lbl_1);
            this.groupBox1.Controls.Add(this.btn_OK);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 225);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "随机条形码批量生成器";
            // 
            // tbx_2
            // 
            this.tbx_2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_2.Location = new System.Drawing.Point(270, 99);
            this.tbx_2.Name = "tbx_2";
            this.tbx_2.Size = new System.Drawing.Size(181, 29);
            this.tbx_2.TabIndex = 6;
            // 
            // tbx_1
            // 
            this.tbx_1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_1.Location = new System.Drawing.Point(270, 49);
            this.tbx_1.Name = "tbx_1";
            this.tbx_1.Size = new System.Drawing.Size(181, 29);
            this.tbx_1.TabIndex = 7;
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_2.Location = new System.Drawing.Point(19, 109);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(220, 19);
            this.lbl_2.TabIndex = 5;
            this.lbl_2.Text = "请输入条形码的位数: ";
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_1.Location = new System.Drawing.Point(19, 52);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(230, 19);
            this.lbl_1.TabIndex = 4;
            this.lbl_1.Text = "请输入条形码的个数： ";
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(172, 165);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(101, 34);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "生成";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnQ);
            this.groupBox2.Location = new System.Drawing.Point(12, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 218);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "二维码生成器";
            // 
            // tbx_3
            // 
            this.tbx_3.Location = new System.Drawing.Point(23, 74);
            this.tbx_3.Multiline = true;
            this.tbx_3.Name = "tbx_3";
            this.tbx_3.Size = new System.Drawing.Size(143, 98);
            this.tbx_3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入二维码的内容";
            // 
            // btnQ
            // 
            this.btnQ.Location = new System.Drawing.Point(174, 97);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(75, 40);
            this.btnQ.TabIndex = 0;
            this.btnQ.Text = "生成";
            this.btnQ.UseVisualStyleBackColor = true;
            this.btnQ.Click += new System.EventHandler(this.btnQ_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbx_4);
            this.groupBox3.Controls.Add(this.btn_B);
            this.groupBox3.Location = new System.Drawing.Point(335, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 218);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "条形码生成器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "请输入条形码内的数字";
            // 
            // tbx_4
            // 
            this.tbx_4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_4.Location = new System.Drawing.Point(36, 97);
            this.tbx_4.Name = "tbx_4";
            this.tbx_4.Size = new System.Drawing.Size(188, 29);
            this.tbx_4.TabIndex = 1;
            // 
            // btn_B
            // 
            this.btn_B.Location = new System.Drawing.Point(95, 148);
            this.btn_B.Name = "btn_B";
            this.btn_B.Size = new System.Drawing.Size(75, 40);
            this.btn_B.TabIndex = 0;
            this.btn_B.Text = "生成";
            this.btn_B.UseVisualStyleBackColor = true;
            this.btn_B.Click += new System.EventHandler(this.btn_B_Click);
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChooseForm";
            this.Text = "条形码二维码生成器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_2;
        private System.Windows.Forms.TextBox tbx_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_4;
    }
}

