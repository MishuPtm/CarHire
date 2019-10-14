using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarHire.Business;
using System.IO;

namespace CarHire
{
    public partial class Form1 : Form
    {
        CarHireClass hireObject = new CarHireClass();
        public bool success = false;
        String[] doors = { "Any", "2 doors", "4+ doors" };
        String[] wheelbase = { "Any", "Short", "Long" };
        public Form1()
        {

            InitializeComponent();
            String[] fuel = { "Any", "Diesel", "Petrol" };
            String[] transmission = { "Any", "Automatic", "Manual" };
            String[] doors = { "Any", "2 doors", "4+ doors" };
            String[] wheelbase = { "Any", "Short", "Long" };


            cmbFuelType.Items.AddRange(fuel);
            cmbFuelType.SelectedIndex = 0;
            cmbFuelType.FormattingEnabled = false;

            cmbTransmission.Items.AddRange(transmission);
            cmbTransmission.SelectedIndex = 0;

            cmbDoors.Items.AddRange(doors);
            cmbDoors.SelectedIndex = 0;





            radCar.Select();
            dateCollection.MinDate = DateTime.Today;
            dateReturn.MinDate = dateCollection.Value.AddDays(1);

            //dateCollection.Value = DateTime.Now;
            CarHireClass.start = dateCollection.Value;
            CarHireClass.end = dateReturn.Value;
            txtDays.Text = "2";






        }

        private void listVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radCar.Checked)
            {
                if (listVehicles.SelectedIndex != -1)
                {
                    updateDetails(CarHireClass.availableCars[listVehicles.SelectedIndex].getDetails(), CarHireClass.availableCars[listVehicles.SelectedIndex].Price);
                    txtTotal.Text = (int.Parse(txtDays.Text) * double.Parse(txtPrice.Text)).ToString();
                }
            }
            else
            {
                if (listVehicles.SelectedIndex != -1)
                {
                    updateDetails(CarHireClass.availableVans[listVehicles.SelectedIndex].getDetails(), CarHireClass.availableVans[listVehicles.SelectedIndex].Price);
                    txtTotal.Text = (int.Parse(txtDays.Text) * double.Parse(txtPrice.Text)).ToString();
                }
            }
            try
            {
                lblPicture.Text = "";
                lblPicture.Image = Image.FromFile("images\\" + listVehicles.SelectedItem.ToString().ToLower() + ".jpg");
            }
            catch
            {
                lblPicture.Image = null;
                lblPicture.Text = "Picture not available";
            }


        }

        private void radCar_CheckedChanged(object sender, EventArgs e)
        {
            if (radCar.Checked)
            {
                clearBoxes();
                listVehicles.Items.Clear();
                listVehicles.Items.AddRange(CarHireClass.availableCars.ToArray());
                lblDoors.Text = "Nb of doors";
                cmbDoors.Items.Clear();
                cmbDoors.Items.AddRange(doors);
                cmbDoors.SelectedItem = CarHireClass.DoorsType;


            }
            else
            {
                clearBoxes();
                listVehicles.Items.Clear();
                listVehicles.Items.AddRange(CarHireClass.availableVans.ToArray());
                lblDoors.Text = "Wheelbase";
                cmbDoors.Items.Clear();
                cmbDoors.Items.AddRange(wheelbase);
                cmbDoors.SelectedItem = CarHireClass.Wheelbase;

            }
            lblPicture.Image = null;
            lblPicture.Text = "Picture not available";
        }
        private void updateDetails(String description, double price)
        {
            txtPrice.Text = price.ToString();
            lblDetails.Text = description;
            txtTotal.Clear();
            //txtDays.Clear();
        }
        private void clearBoxes()
        {
            lblDetails.Text = "";
            txtPrice.Clear();
            //txtDays.Clear();
            txtTotal.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "")
            {
                frmLogIn frm = new frmLogIn(this, double.Parse(txtTotal.Text), listVehicles.SelectedItem.ToString());
                frm.Visible = true;
                this.Visible = false;

            }
        }
        public void checkTransaction()
        {
            if (success)
            {

                if (radCar.Checked)
                {
                    if (listVehicles.SelectedIndex != -1)
                    {
                        CarHireClass.availableCars[listVehicles.SelectedIndex].hire(dateCollection.Value, dateReturn.Value);

                    }
                }
                else
                {
                    if (listVehicles.SelectedIndex != -1)
                    {
                        CarHireClass.availableVans[listVehicles.SelectedIndex].hire(dateCollection.Value, dateReturn.Value);
                    }
                }
                CarHireClass.updateLists();
                updateScreen();

            }
            else
            {
                MessageBox.Show("Transaction failed");
            }
        }

        private void updateScreen()
        {
            listVehicles.SelectedIndex = -1;
            if (radCar.Checked)
            {
                clearBoxes();
                listVehicles.Items.Clear();
                listVehicles.Items.AddRange(CarHireClass.availableCars.ToArray());

            }
            else
            {
                clearBoxes();
                listVehicles.Items.Clear();
                listVehicles.Items.AddRange(CarHireClass.availableVans.ToArray());

            }

        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            int days = 0;
            if (int.TryParse(txtDays.Text, out days))
            {
                try
                {
                    txtTotal.Text = (days * double.Parse(txtPrice.Text)).ToString();
                }
                catch
                {

                }
            }
            else
            {
                txtDays.Clear();
                txtTotal.Clear();
            }
        }



        bool changed = false;
        private void dateCollection_ValueChanged(object sender, EventArgs e)
        {
            dateReturn.MinDate = dateCollection.Value.AddDays(1);
            CarHireClass.start = dateCollection.Value;
            CarHireClass.updateLists();
            updateScreen();
            txtDays.Text = (dateReturn.Value.Subtract(dateCollection.Value).Days + 1).ToString();
            changed = true;


        }

        private void dateReturn_ValueChanged(object sender, EventArgs e)
        {
            CarHireClass.end = dateReturn.Value;
            CarHireClass.updateLists();
            updateScreen();
            if (changed)
            {
                txtDays.Text = (dateReturn.Value.Subtract(dateCollection.Value).Days + 1).ToString();
            }
            else
            {
                txtDays.Text = (dateReturn.Value.Subtract(dateCollection.Value).Days + 2).ToString();
            }


        }

        private void cmbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarHireClass.FuelType = cmbFuelType.SelectedItem.ToString();
            updateScreen();

        }

        private void cmbTransmission_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarHireClass.TransmissionType = cmbTransmission.SelectedItem.ToString();
            updateScreen();

        }

        private void cmbDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radCar.Checked)
            {
                CarHireClass.DoorsType = cmbDoors.SelectedItem.ToString();
                updateScreen();
            }
            else
            {
                CarHireClass.Wheelbase = cmbDoors.SelectedItem.ToString();
                updateScreen();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string test = Directory.GetCurrentDirectory();
            test.IndexOf("CarHire");
            test = test.Replace("CarHire", "AtmMachine");
            Console.WriteLine(test);
        }
    }
}
