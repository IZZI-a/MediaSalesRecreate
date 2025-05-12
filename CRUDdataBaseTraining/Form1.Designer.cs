namespace CRUDdataBaseTraining
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.Location = new System.Drawing.Point(22, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(316, 44);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrice.Location = new System.Drawing.Point(22, 94);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(316, 44);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtQuant
            // 
            this.txtQuant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQuant.Location = new System.Drawing.Point(22, 169);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(316, 44);
            this.txtQuant.TabIndex = 3;
            this.txtQuant.TextChanged += new System.EventHandler(this.txtQuant_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.IndianRed;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnAdd.FlatAppearance.BorderSize = 12;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(80, 502);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(208, 63);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.IndianRed;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnRefresh.FlatAppearance.BorderSize = 12;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(80, 596);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(208, 63);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(431, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(666, 580);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.Enabled = false;
            this.dtpCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreatedDate.Location = new System.Drawing.Point(80, 419);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(208, 20);
            this.dtpCreatedDate.TabIndex = 9;
            this.dtpCreatedDate.ValueChanged += new System.EventHandler(this.dtpCreatedDate_ValueChanged);
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpireDate.Location = new System.Drawing.Point(80, 455);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.ShowCheckBox = true;
            this.dtpExpireDate.Size = new System.Drawing.Size(208, 20);
            this.dtpExpireDate.TabIndex = 10;
            this.dtpExpireDate.ValueChanged += new System.EventHandler(this.dtpExpireDate_ValueChanged);
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryId.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCategoryId.Location = new System.Drawing.Point(22, 240);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(316, 44);
            this.txtCategoryId.TabIndex = 11;
            this.txtCategoryId.TextChanged += new System.EventHandler(this.txtCategoryId_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1103, 21);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(385, 580);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.BorderSize = 12;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(344, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSupplier
            // 
            this.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSupplier.Location = new System.Drawing.Point(22, 318);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(316, 44);
            this.txtSupplier.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1502, 719);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.dtpExpireDate);
            this.Controls.Add(this.dtpCreatedDate);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQuant);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "DataBaseCRADoperation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpCreatedDate;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSupplier;
    }
}

