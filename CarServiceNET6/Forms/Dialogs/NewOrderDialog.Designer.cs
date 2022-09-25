
namespace LB4
{
    partial class d_neworder
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
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_clients = new System.Windows.Forms.ComboBox();
            this.tb_carname = new System.Windows.Forms.TextBox();
            this.b_setcar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_desc = new System.Windows.Forms.RichTextBox();
            this.numud_price = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_empl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numud_price)).BeginInit();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_ok.Location = new System.Drawing.Point(535, 224);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "Добавить";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_cancel.Location = new System.Drawing.Point(454, 224);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 1;
            this.b_cancel.Text = "Отмена";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Заказчик";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Машина";
            // 
            // cb_clients
            // 
            this.cb_clients.FormattingEnabled = true;
            this.cb_clients.Location = new System.Drawing.Point(73, 16);
            this.cb_clients.Name = "cb_clients";
            this.cb_clients.Size = new System.Drawing.Size(229, 21);
            this.cb_clients.TabIndex = 4;
            // 
            // tb_carname
            // 
            this.tb_carname.Enabled = false;
            this.tb_carname.Location = new System.Drawing.Point(73, 42);
            this.tb_carname.Name = "tb_carname";
            this.tb_carname.Size = new System.Drawing.Size(229, 20);
            this.tb_carname.TabIndex = 5;
            this.tb_carname.Text = "Не выбрана";
            // 
            // b_setcar
            // 
            this.b_setcar.Location = new System.Drawing.Point(308, 40);
            this.b_setcar.Name = "b_setcar";
            this.b_setcar.Size = new System.Drawing.Size(75, 23);
            this.b_setcar.TabIndex = 6;
            this.b_setcar.Text = "Добавить";
            this.b_setcar.UseVisualStyleBackColor = true;
            this.b_setcar.Click += new System.EventHandler(this.b_setcar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Стоимость";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Опсание";
            // 
            // rtb_desc
            // 
            this.rtb_desc.Location = new System.Drawing.Point(12, 97);
            this.rtb_desc.Name = "rtb_desc";
            this.rtb_desc.Size = new System.Drawing.Size(595, 96);
            this.rtb_desc.TabIndex = 10;
            this.rtb_desc.Text = "";
            // 
            // numud_price
            // 
            this.numud_price.Location = new System.Drawing.Point(519, 17);
            this.numud_price.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numud_price.Name = "numud_price";
            this.numud_price.Size = new System.Drawing.Size(90, 20);
            this.numud_price.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ответсвенный";
            // 
            // cb_empl
            // 
            this.cb_empl.FormattingEnabled = true;
            this.cb_empl.Location = new System.Drawing.Point(99, 202);
            this.cb_empl.Name = "cb_empl";
            this.cb_empl.Size = new System.Drawing.Size(269, 21);
            this.cb_empl.TabIndex = 13;
            // 
            // d_neworder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 257);
            this.Controls.Add(this.cb_empl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numud_price);
            this.Controls.Add(this.rtb_desc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.b_setcar);
            this.Controls.Add(this.tb_carname);
            this.Controls.Add(this.cb_clients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Name = "d_neworder";
            this.Text = "Добавить заказ";
            ((System.ComponentModel.ISupportInitialize)(this.numud_price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_clients;
        private System.Windows.Forms.TextBox tb_carname;
        private System.Windows.Forms.Button b_setcar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_desc;
        private System.Windows.Forms.NumericUpDown numud_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_empl;
    }
}