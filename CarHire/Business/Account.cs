using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHire.Business
{
    public class Account
    {
        //=============Constructors=============
        public Account() { }
        private Account(String line)
        {

            String[] param = line.Split(line[6]);
            accNumber = param[0];
            pin = param[1];
            balance = double.Parse(param[2]);
            active = bool.Parse(param[3]);
            attempts = int.Parse(param[4]);
            accName = param[5];
        }

        //=======Static variables===============
        static string filepath, statementpath;
        static List<Account> listAccounts = new List<Account>();
        static String[] accountNumbers;
        static Account currAccount;
        //======================================


        //========Object related variables======
        String pin, accNumber, accName;
        double balance;
        int attempts;
        bool active, logedIn = false;
        List<String> transactions = new List<String>();
        //======================================



        //=========Static methods======================================
        public static String[] readFile(String accPath)
        {
            try
            {
                System.IO.File.ReadAllLines(accPath);
                filepath = accPath;
                statementpath = filepath.Substring(0, filepath.LastIndexOf('\\')) + "\\statements.txt";
            }
            catch
            {
                filepath = "accounts.txt";
                statementpath = "statements.txt";
            }
            

            String[] fileContent = System.IO.File.ReadAllLines(filepath);
            String[] statement = System.IO.File.ReadAllLines(statementpath);
            accountNumbers = new String[fileContent.Length];
            listAccounts.Clear();
            for (int i = 0; i < fileContent.Length; i++)
            {
                Account a = new Account(fileContent[i]);
                accountNumbers[i] = fileContent[i].Split(fileContent[i][6])[0];
                for (int x = 0; x < statement.Length; x++)
                {
                    if (statement[x].Contains(a.AccNumber))
                    {
                        a.transactions.Add(statement[x].Split('|')[1]);
                    }
                }
                if (a.transactions.Count == 0)
                {
                    a.transactions.Add("Initial balance: " + a.balance);
                }
                listAccounts.Add(a);
            }
            return accountNumbers;

        } // - call this method first
        public static Account searchAccount(String inputAccountNb)
        {
            //This method returns the account object if it finds the account number
            //or returns a null object if it does not find it. 
            currAccount = null;
            for (int i = 0; i < accountNumbers.Length; i++)
            {
                if (inputAccountNb == accountNumbers[i])
                {
                    currAccount = listAccounts[i];
                }
            }

            return currAccount;
        }
        //=============================================================



        //==============Account operations=============================
        public bool lodge(double ammount)
        {
            if (ammount > 0)
            {
                balance += ammount;
                transactions.Add("Lodged " + ammount);
                saveChanges();
                return true;
            }
            else return false;
        }
        public bool withdraw(double ammount)
        {

            if (logedIn && ammount > 0 && ammount <= balance)
            {
                balance -= ammount;
                transactions.Add("Withdrawn " + ammount);
                saveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool transfer(double ammount, Account receiver)
        {

            if (receiver != null && ammount <= balance && receiver.incomingTransfer(this, ammount))
            {
                balance -= ammount;
                transactions.Add("Transfer to " + receiver.getName() + ": " + ammount);
                saveChanges();
                return true;
            }

            return false;
        }
        public bool incomingTransfer(Account sender, double ammount)
        {
            if (sender.logedIn && ammount > 0)
            {
                balance += ammount;
                transactions.Add("Incoming transfer from " + sender.getName() + ": " + ammount);
                return true;
            }
            else return false;

        }
        public string getBalance()
        {

            if (logedIn) return "£" + String.Format("{0:0.00}", balance);
            else return "Access denied";
        }
        public String changePin(String pinEntry1, String pinEntry2)
        {
            String message;
            if (logedIn && validPinFormat(pinEntry1) && validPinFormat(pinEntry2))
            {
                if (pinEntry2 == pinEntry1)
                {
                    pin = pinEntry1;
                    saveChanges();
                    message = "Pin changed succesfully";
                }
                else message = "Pins don't match";
            }
            else if (!logedIn)
            {
                message = "Access denied";
            }
            else message = "Invalid pin format";
            return message;

        }
        public int logIn(String pinInput)
        {
            //Returns -1 for Blocked account, 0 for incorrect pin, 1 for success
            if (active)
            {
                if (pin == pinInput)
                {
                    this.attempts = 3;
                    logedIn = true;
                    saveChanges();
                    return 1;
                }
                else
                {
                    this.attempts--;
                    if (attempts == 0)
                    {
                        active = false;
                        saveChanges();
                        return -1;
                    }
                    saveChanges();
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        public int getAttempts()
        {
            return attempts;
        }
        public List<String> getStatement()
        {
            if (transactions.Count == 0)
            {
                transactions.Add("Initial balance: " + balance);
                saveChanges();
            }
            return transactions;
        }
        public String getName()
        {
            return accName;
        }
        public bool receivePayment(double ammount, Account sender)
        {
            if (ammount > 0 && sender.logedIn)
            {
                balance += ammount;
                transactions.Add("Payment from " + sender.getName() + " " + ammount);
                saveChanges();
                return true;
            }
            else return false;
        }
        public bool makePayment(double ammount, Account receiver, string details)
        {

            if (receiver != null && ammount <= balance && receiver.receivePayment(ammount, this))
            {
                balance -= ammount;
                transactions.Add(receiver.getName() + " " + details + ": " + ammount);
                saveChanges();
                return true;
            }

            return false;
        }
        //=============================================================



        //===========Helper methods====================================
        private bool validPinFormat(String input)
        {

            if (input.Length == 4)
            {
                try
                {
                    int.Parse(input);
                    return true;
                }
                catch
                {
                }
            }
            return false;
        }
        private void saveChanges()
        {

            String[] contents = new String[listAccounts.Count];
            List<String> statements = new List<String>();
            for (int i = 0; i < listAccounts.Count; i++)
            {
                contents[i] = listAccounts[i].toString();

                for (int x = 0; x < listAccounts[i].transactions.Count; x++)
                {
                    statements.Add(listAccounts[i].accNumber + "|" + listAccounts[i].transactions[x]);
                }
            }
            System.IO.File.WriteAllLines(filepath, contents);
            System.IO.File.WriteAllLines(statementpath, statements);
        }
        //=============================================================


        //=============Private accessors===============================
        private string Pin
        {
            get
            {
                return pin;
            }

            set
            {
                pin = value;
            }
        }
        private string AccNumber
        {
            get
            {
                return accNumber;
            }

            set
            {
                accNumber = value;
            }
        }
        private double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }
        private int Attempts
        {
            get
            {
                return attempts;
            }

            set
            {
                attempts = value;
            }
        }
        private bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }
        private string toString()
        {
            string separator = "|";
            return accNumber + separator + pin + separator + balance + separator
                + active + separator + attempts + separator + accName;
        }
        //=============================================================

    }
}
