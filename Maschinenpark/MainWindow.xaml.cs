using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Globalization;

namespace Maschinenpark
{
    public partial class MainWindow : Window
    {
        public static Login_Sreen pLSO = new Login_Sreen();
        public int calenderWeek = 0;

        public MainWindow()
        {
            InitializeComponent();
            Login_Sreen showLoginScreen = new Login_Sreen();
            MyFrame.NavigationService.Navigate(pLSO);
            //Admin goAdmin = new Admin();
            //MyFrame.NavigationService.Navigate(goAdmin);
            deleteOldFiles();
        }

        private void deleteOldFiles() //anpassen Jahresübergreifend
        {
            int kw = getKW();
            String cut = "";
            String year = "";
            DirectoryInfo directory = new DirectoryInfo("Reservierungen\\");

            foreach (var name in directory.GetFiles())
            {
                cut = name.ToString();
                cut = cut.Remove(0, 2); //Maschinennummer entfernen
                year = cut;
                

                if (cut.Length == 10)
                {
                    year = year.Remove(0, 2);
                    year = year.Remove(4, 4);
                    cut = cut.Remove(2, 8);
                }
                else if (cut.Length == 9)
                {
                    year = year.Remove(0, 1);
                    year = year.Remove(4, 4);
                    cut = cut.Remove(1, 8);

                }

                if (Int32.Parse(year) < DateTime.Now.Year)
                {
                    if (Int32.Parse(cut) < (53 + kw - 11))
                    {
                        File.Delete("Reservierungen\\" + name);
                    }
                }
                else if (Int32.Parse(cut) < (kw - 11)) //Delete older than 12 weeks
                    File.Delete("Reservierungen\\" + name);
            }
        }

        private int getKW()
        {
            int kW = 0;

            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            System.Globalization.Calendar calendar = currentCulture.Calendar;

            calenderWeek = calendar.GetWeekOfYear(DateTime.Today,
                 currentCulture.DateTimeFormat.CalendarWeekRule,
                 currentCulture.DateTimeFormat.FirstDayOfWeek);
            calenderWeek.ToString();
            kW = calenderWeek;

            return kW;
        }

        public partial class EncrDecr
        {
            private const string AesIV256 = @"!QAZ2WSX#EDC4RFV"; //private const string AesIV256 = @"!QAZ2WSX#EDC4RFV"; private const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";
            private const string AesKey256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<";


            public static string Encrypt256(string text)
            {
                // AesCryptoServiceProvider
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = Encoding.UTF8.GetBytes(AesIV256);
                aes.Key = Encoding.UTF8.GetBytes(AesKey256);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert string to byte array
                byte[] src = Encoding.Unicode.GetBytes(text);

                // encryption
                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                    // Convert byte array to Base64 strings
                    return Convert.ToBase64String(dest);
                }
            }

            public static string Decrypt256(string text)
            {
                // AesCryptoServiceProvider
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.IV = Encoding.UTF8.GetBytes(AesIV256);
                aes.Key = Encoding.UTF8.GetBytes(AesKey256);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert Base64 strings to byte array
                byte[] src = System.Convert.FromBase64String(text);

                // decryption
                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return Encoding.Unicode.GetString(dest);
                }
            }
        }
    }
}
