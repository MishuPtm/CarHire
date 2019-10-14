namespace CarHire
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
            this.radCar = new System.Windows.Forms.RadioButton();
            this.radVan = new System.Windows.Forms.RadioButton();
            this.listVehicles = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnHire = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDoors = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.cmbDoors = new System.Windows.Forms.ComboBox();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.groupDates = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateReturn = new System.Windows.Forms.DateTimePicker();
            this.dateCollection = new System.Windows.Forms.DateTimePicker();
            this.lblPicture = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // radCar
            // 
            this.radCar.AutoSize = true;
            this.radCar.Location = new System.Drawing.Point(8, 23);
            this.radCar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radCar.Name = "radCar";
            this.radCar.Size = new System.Drawing.Size(58, 21);
            this.radCar.TabIndex = 0;
            this.radCar.TabStop = true;
            this.radCar.Text = "Cars";
            this.radCar.UseVisualStyleBackColor = true;
            this.radCar.CheckedChanged += new System.EventHandler(this.radCar_CheckedChanged);
            // 
            // radVan
            // 
            this.radVan.AutoSize = true;
            this.radVan.Location = new System.Drawing.Point(8, 68);
            this.radVan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radVan.Name = "radVan";
            this.radVan.Size = new System.Drawing.Size(61, 21);
            this.radVan.TabIndex = 1;
            this.radVan.TabStop = true;
            this.radVan.Text = "Vans";
            this.radVan.UseVisualStyleBackColor = true;
            // 
            // listVehicles
            // 
            this.listVehicles.FormattingEnabled = true;
            this.listVehicles.ItemHeight = 16;
            this.listVehicles.Location = new System.Drawing.Point(159, 15);
            this.listVehicles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listVehicles.Name = "listVehicles";
            this.listVehicles.Size = new System.Drawing.Size(265, 100);
            this.listVehicles.TabIndex = 2;
            this.listVehicles.SelectedIndexChanged += new System.EventHandler(this.listVehicles_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radCar);
            this.groupBox1.Controls.Add(this.radVan);
            this.groupBox1.Location = new System.Drawing.Point(16, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(135, 98);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle type";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(112, 33);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(84, 22);
            this.txtPrice.TabIndex = 4;
            // 
            // txtDays
            // 
            this.txtDays.Enabled = false;
            this.txtDays.Location = new System.Drawing.Point(112, 65);
            this.txtDays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(84, 22);
            this.txtDays.TabIndex = 5;
            this.txtDays.TextChanged += new System.EventHandler(this.txtDays_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(112, 97);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(84, 22);
            this.txtTotal.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Price per day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Days";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total cost";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetails);
            this.groupBox2.Location = new System.Drawing.Point(453, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(192, 207);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Car details";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(15, 31);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(46, 17);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "label4";
            // 
            // btnHire
            // 
            this.btnHire.Location = new System.Drawing.Point(740, 182);
            this.btnHire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHire.Name = "btnHire";
            this.btnHire.Size = new System.Drawing.Size(120, 42);
            this.btnHire.TabIndex = 11;
            this.btnHire.Text = "Hire";
            this.btnHire.UseVisualStyleBackColor = true;
            this.btnHire.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtTotal);
            this.groupBox3.Controls.Add(this.txtDays);
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Location = new System.Drawing.Point(655, 17);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(205, 149);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cost";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDoors);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblFuelType);
            this.groupBox4.Controls.Add(this.cmbDoors);
            this.groupBox4.Controls.Add(this.cmbTransmission);
            this.groupBox4.Controls.Add(this.cmbFuelType);
            this.groupBox4.Location = new System.Drawing.Point(453, 231);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(407, 202);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filters";
            // 
            // lblDoors
            // 
            this.lblDoors.Location = new System.Drawing.Point(11, 86);
            this.lblDoors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoors.Name = "lblDoors";
            this.lblDoors.Size = new System.Drawing.Size(97, 28);
            this.lblDoors.TabIndex = 8;
            this.lblDoors.Text = "Nb of doors";
            this.lblDoors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Transmission";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFuelType
            // 
            this.lblFuelType.Location = new System.Drawing.Point(7, 22);
            this.lblFuelType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(103, 28);
            this.lblFuelType.TabIndex = 6;
            this.lblFuelType.Text = "Fuel type";
            this.lblFuelType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDoors
            // 
            this.cmbDoors.FormattingEnabled = true;
            this.cmbDoors.Location = new System.Drawing.Point(116, 89);
            this.cmbDoors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDoors.Name = "cmbDoors";
            this.cmbDoors.Size = new System.Drawing.Size(139, 24);
            this.cmbDoors.TabIndex = 5;
            this.cmbDoors.SelectedIndexChanged += new System.EventHandler(this.cmbDoors_SelectedIndexChanged);
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.FormattingEnabled = true;
            this.cmbTransmission.Location = new System.Drawing.Point(116, 55);
            this.cmbTransmission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(139, 24);
            this.cmbTransmission.TabIndex = 4;
            this.cmbTransmission.SelectedIndexChanged += new System.EventHandler(this.cmbTransmission_SelectedIndexChanged);
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.FormattingEnabled = true;
            this.cmbFuelType.Location = new System.Drawing.Point(117, 22);
            this.cmbFuelType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(139, 24);
            this.cmbFuelType.TabIndex = 3;
            this.cmbFuelType.SelectedIndexChanged += new System.EventHandler(this.cmbFuelType_SelectedIndexChanged);
            // 
            // groupDates
            // 
            this.groupDates.Controls.Add(this.label5);
            this.groupDates.Controls.Add(this.label4);
            this.groupDates.Controls.Add(this.dateReturn);
            this.groupDates.Controls.Add(this.dateCollection);
            this.groupDates.Location = new System.Drawing.Point(19, 123);
            this.groupDates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDates.Name = "groupDates";
            this.groupDates.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDates.Size = new System.Drawing.Size(405, 101);
            this.groupDates.TabIndex = 14;
            this.groupDates.TabStop = false;
            this.groupDates.Text = "Choose Dates";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Return date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Collection date";
            // 
            // dateReturn
            // 
            this.dateReturn.Location = new System.Drawing.Point(141, 55);
            this.dateReturn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateReturn.Name = "dateReturn";
            this.dateReturn.Size = new System.Drawing.Size(229, 22);
            this.dateReturn.TabIndex = 1;
            this.dateReturn.ValueChanged += new System.EventHandler(this.dateReturn_ValueChanged);
            // 
            // dateCollection
            // 
            this.dateCollection.Location = new System.Drawing.Point(141, 23);
            this.dateCollection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateCollection.Name = "dateCollection";
            this.dateCollection.Size = new System.Drawing.Size(229, 22);
            this.dateCollection.TabIndex = 0;
            this.dateCollection.ValueChanged += new System.EventHandler(this.dateCollection_ValueChanged);
            // 
            // lblPicture
            // 
            this.lblPicture.Location = new System.Drawing.Point(24, 231);
            this.lblPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(400, 204);
            this.lblPicture.TabIndex = 15;
            this.lblPicture.Text = " ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.groupDates);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnHire);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listVehicles);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupDates.ResumeLayout(false);
            this.groupDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radCar;
        private System.Windows.Forms.RadioButton radVan;
        private System.Windows.Forms.ListBox listVehicles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnHire;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupDates;
        private System.Windows.Forms.DateTimePicker dateCollection;
        private System.Windows.Forms.DateTimePicker dateReturn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.ComboBox cmbDoors;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Label lblDoors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.Button button1;
    }
}

