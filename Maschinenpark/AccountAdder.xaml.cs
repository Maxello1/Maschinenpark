using System;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Maschinenpark
{

    public partial class AccountAdder : Page
    {
        public AccountAdder()
        {
            InitializeComponent();
        }

        private void Fokus(object sender, RoutedEventArgs e)
        {
            if (textBox_UserName.Text == "Benutzername...")
                textBox_UserName.Text = "";

        }
        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Save_Click(this, new RoutedEventArgs());
        }
        private void Back_click(object sender, RoutedEventArgs e)
        {
            cBoxBeruf.SelectedIndex = 0;
            tbox_Name.Text = "Name...";
            tbox_Vorname.Text = "Vorname...";
            textBox_UserName.Text = "Benutzername...";
            textBox_Tip.Content = "";

            MainWindow.pLSO.setPWback();
            this.NavigationService.Navigate(MainWindow.pLSO);

        }
        public void resetPW()
        {
            pbox_Password.Password = "Password...";
            pbox_PasswordKontrolle.Password = "Password...";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            textBox_Tip.Foreground = new SolidColorBrush(Colors.Red);
            if (!pbox_Password.Password.Equals("") && !pbox_Password.Password.Equals("Password...")
                && !textBox_UserName.Text.Equals("") && !textBox_UserName.Text.Equals("Nutzername...")
                && !tbox_Name.Text.Equals("") && !tbox_Name.Text.Equals("Name...")
                && !tbox_Vorname.Text.Equals("") && !tbox_Vorname.Text.Equals("Vorname...")
                && !pbox_PasswordKontrolle.Password.Equals("") && !pbox_PasswordKontrolle.Password.Equals("Password...")
                && !cBoxBeruf.Text.Equals("Beruf wählen...")
                )
            {
                //Save Funktion
                if (pbox_PasswordKontrolle.Password.Equals(pbox_Password.Password))
                    try
                    {
                        if (textBox_UserName.Text != "Admin")
                        {
                            string berufSel = "";
                            switch (cBoxBeruf.Text)
                            {
                                case "Mechatroniker (MECH)":
                                    berufSel = " (MECH)";
                                    break;
                                case "Werkzeugmechaniker (WZM)":
                                    berufSel = " (WZM)";
                                    break;
                                case "Industriemechaniker (IM)":
                                    berufSel = " (IM)";
                                    break;
                                case "Zerspanungsmechaniker (ZM)":
                                    berufSel = " (ZM)";
                                    break;
                                default:
                                    break;
                            }
                            StreamWriter wr = new StreamWriter(@"LoginData.txt", true);

                            string encDataUser = MainWindow.EncrDecr.Encrypt256(textBox_UserName.Text);
                            string encDataPW = MainWindow.EncrDecr.Encrypt256(pbox_Password.Password);

                            wr.WriteLine(tbox_Name.Text + ", " + tbox_Vorname.Text + berufSel);
                            wr.WriteLine(encDataUser);
                            wr.WriteLine(encDataPW);

                            wr.Close();

                            Login_Sreen.UserPWList.Clear();
                            textBox_Tip.Foreground = new SolidColorBrush(Colors.Green);
                            textBox_Tip.Content = "Account hinzugefügt";

                            tbox_Name.Text = "Name...";
                            tbox_Vorname.Text = "Vorname...";
                            textBox_UserName.Text = "Benutzername...";
                            resetPW();
                        }
                        else
                            textBox_Tip.Content = "Nutzername bereits reserviert";
                    }
                    catch { textBox_Tip.Content = "Account nicht hinzugefügt"; }
                else
                    textBox_Tip.Content = "Ungleiche Passwörter";
            }
            else
                textBox_Tip.Content = "Fehlende Informationen";
        }

        private void VornameFokus(object sender, RoutedEventArgs e)
        {
            if (tbox_Vorname.Text == "Vorname...")
                tbox_Vorname.Text = "";
        }

        private void nameFokus(object sender, RoutedEventArgs e)
        {
            if (tbox_Name.Text == "Name...")
                tbox_Name.Text = "";
        }

        private void pwFokus(object sender, RoutedEventArgs e)
        {
            if (pbox_PasswordKontrolle.Password == "Password...")
                pbox_PasswordKontrolle.Password = "";
        }

        private void pwFok(object sender, RoutedEventArgs e)
        {
            if (pbox_Password.Password == "Password...")
                pbox_Password.Password = "";
        }

        private void tbox_Vorname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbox_Vorname.Text == "")
                tbox_Vorname.Text = "Vorname...";
        }

        private void tbox_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbox_Name.Text == "")
                tbox_Name.Text = "Name...";
        }

        private void textBox_UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_UserName.Text == "")
                textBox_UserName.Text = "Benutzername...";
        }

        private void pbox_Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pbox_Password.Password == "")
                pbox_Password.Password = "Password...";
        }

        private void pbox_PasswordKontrolle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pbox_PasswordKontrolle.Password == "")
                pbox_PasswordKontrolle.Password = "Password...";
        }
    }
}