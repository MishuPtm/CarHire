using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CarHire.Business;



namespace CarHire

{
    public partial class frmLogIn : Form
    {
       
        public static Account currAccount = null;
        bool blnAccountNumberHasFocus;
        public static Account receiver = null;
        double ammount;
        String details;
        Form1 MainMenu;
        

        public frmLogIn(Form1 main, double ammount, string details)
        {
            MainMenu = main;
            this.details = details;
            this.ammount = ammount;
            string path = Directory.GetCurrentDirectory();
            Console.Write(path);
            string test = Directory.GetCurrentDirectory();
            test.IndexOf("CarHire");
            test = test.Replace("CarHire", "AtmMachine");
            Account.readFile(test+@"\accounts.txt");
            InitializeComponent();
            blnAccountNumberHasFocus = true;
            txtAccountNb.Focus();
            receiver = Account.searchAccount("000000");
        }

        private void updateDisplay(String btnText)
        {
            if (blnAccountNumberHasFocus == true)
                txtAccountNb.Text = txtAccountNb.Text + btnText;

            else
                txtPin.Text = txtPin.Text + btnText;

        }
        private void btn0_Click(object sender, EventArgs e)
        {
            updateDisplay(btn0.Text);
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            currAccount = Account.searchAccount(txtAccountNb.Text);
           
           if (currAccount != null)
            {
                switch (currAccount.logIn(txtPin.Text)) {
                    case -1:
                        MessageBox.Show("Your account is inactive");
                        break;
                    case 0:
                        MessageBox.Show("Wrong pin, "+currAccount.getAttempts()+" left.");
                        break;
                    case 1:
                        if (currAccount.makePayment(ammount, receiver, details))
                        {
                            this.Visible = false;
                            MainMenu.success = true;
                            MainMenu.checkTransaction();
                            MainMenu.Visible = true;
                            MessageBox.Show("Paymens succesfull of " + ammount + " to " + receiver.getName() + " for " + details);
                        }else
                        {
                            this.Visible = false;
                            MainMenu.success = false;
                            MainMenu.checkTransaction();
                            MainMenu.Visible = true;
                        }
                        break;


                }

            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            updateDisplay(btn1.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountNb.Text = "";
            txtPin.Text="";

        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccountNb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtAccountNb.Focus();
        }

        private void txtPin_Enter(object sender, EventArgs e)
        {
            blnAccountNumberHasFocus = false;
        }

        private void txtAccountNb_Enter(object sender, EventArgs e)
        {
            blnAccountNumberHasFocus = true;
        }
        //=======Back Spase code========
        private void btnBackSp_Click(object sender, EventArgs e)
        {
            if (blnAccountNumberHasFocus)
            {
                if (txtAccountNb.Text.Length >= 1)
                    txtAccountNb.Text = txtAccountNb.Text.Remove(txtAccountNb.Text.Length - 1, 1);
            }
            else
            {
                if (txtPin.Text.Length >= 1)
                    txtPin.Text = txtPin.Text.Remove(txtPin.Text.Length - 1, 1);
            }


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            updateDisplay(btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            updateDisplay(btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            updateDisplay(btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            updateDisplay(btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            updateDisplay(btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            updateDisplay(btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            updateDisplay(btn8.Text);
           
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            updateDisplay(btn9.Text);
           
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.Visible = true;
            this.Visible = false;
            MainMenu.checkTransaction();
        }
    }
}
