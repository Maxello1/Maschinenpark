using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Security.Cryptography;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Maschinenpark
{

    public partial class Login_Sreen : Page
    {

        //Deklaration
        public static bool auth = false;
        public static String LoggedUserName = "";
        public static List<String> UserPWList = new List<String>();

        public AccountAdder accountAdderO = new AccountAdder();
        public Kalender kalenderO = new Kalender();


        public Login_Sreen()
        {
            InitializeComponent();
        }

        private void FokusPW(object sender, RoutedEventArgs e)
        {
            if (auth == false && passwordBoxlogin.Password == "Password...")
                passwordBoxlogin.Password = "";
        }

        public void setPWback()
        {
            passwordBoxlogin.Password = "Password...";
        }

        private void Fokus(object sender, RoutedEventArgs e)
        {
            if (auth == false && textBox_UserName.Text == "Benutzername...")
                textBox_UserName.Text = "";
        }

        private void EnterPresses(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Login_Click(this, new RoutedEventArgs());
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            textBox_UserName.Text = "Benutzername...";
            passwordBoxlogin.Password = "Password...";
            accountAdderO.resetPW();
            this.NavigationService.Navigate(accountAdderO);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            UserPWList.Clear();

            auth = false;
            string content;
            int i = 0, z = 0;

            StreamReader r = new StreamReader(@"LoginData.txt");

            if(UserPWList.Count == 0)
                while ((content = r.ReadLine()) != null)
                    UserPWList.Add(content);
            r.Close();

            foreach (String datas in UserPWList)
            {
                if(z == 1)
                    if (textBox_UserName.Text.Equals(MainWindow.EncrDecr.Decrypt256(UserPWList[i])))
                        if (passwordBoxlogin.Password.Equals(MainWindow.EncrDecr.Decrypt256(UserPWList[i + 1])))
                        {


                            auth = true;
                            LoggedUserName = UserPWList[i -1];

                            textBox_Tip.Content = "";

                            if (textBox_UserName.Text == "Admin" && auth)
                            {
                                textBox_UserName.Text = "Benutzername...";
                                passwordBoxlogin.Password = "Password...";
                            }
                            else
                            {
                                textBox_UserName.Text = "Benutzername...";
                                passwordBoxlogin.Password = "Password...";
                                kalenderO.initKalender();
                                kalenderO.datePickerField.Text = "";
                                this.NavigationService.Navigate(kalenderO);
                            }
                            break;
                        }
                if (z == 2)
                    z = 0;
                else
                    z++;
                i++;

            }
            if(!auth)
                textBox_Tip.Content = "Falscher Benutzer oder Passwort";
        }

        private void lostFusername(object sender, RoutedEventArgs e)
        {
            if (textBox_UserName.Text == "")
                textBox_UserName.Text = "Benutzername...";
        }

        private void lostFpw(object sender, RoutedEventArgs e)
        {
            if (passwordBoxlogin.Password == "")
                passwordBoxlogin.Password = "Password...";
        }

        private void infoBtnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                oMailItem.To = "maximillian.schoch@volkswagen.de";
                oMailItem.Subject = "Fehler-Report Maschinenpark";
                oMailItem.Body = "Bitte den Fehler und den Weg zum aufgetretenen Problem so genau wie möglich beschreiben!";
                oMailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                oMailItem.Display(true);
            }
            catch { }
        }
    }
}