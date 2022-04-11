using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Globalization; //Kalenderwochen 

namespace Maschinenpark
{
    public partial class Kalender : Page
    {
        [DllImport("user32.dll")]
        public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);

        public static List<String> DataList = new List<String>();
        public static List<String> autoList = new List<String>();
        public static List<Vorschlag> DataListVoschlaege = new List<Vorschlag>();
        public static List<Monday> MondayList = new List<Monday>();
        public static List<Tuesday> TuesdayList = new List<Tuesday>();
        public static List<Wednesday> WednesdayList = new List<Wednesday>();
        public static List<Thursday> ThursdayList = new List<Thursday>();
        public static List<Friday> FridayList = new List<Friday>();
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
        private static List<String> machinelist = new List<String>();
        private static int kWNow = 0;
        private static int selectedYear = 0;
        private bool kwCountIs52;
        private static DateTime dayFirst, dayLast;
        private static String day;

        private static int calenderWeek = 0, machineIndex = 0;

        public Kalender()
        {
            InitializeComponent();
        }

        public void initKalender()
        {
            try
            {
                selectedYear = DateTime.Now.Year;
                kwCountIs52 = kwCount52();
                kWNow = getKW(DateTime.Today); //Methode KW
                labelKW.Content = "Kalenderwoche " + calenderWeek.ToString();
                getMaschines();

                StreamReader r = new StreamReader("ProjectName.txt");
                labelProject.Content = r.ReadLine();
                r.Close();

                labelUsername.Content = Login_Sreen.LoggedUserName;
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
            catch { }
        }

        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Int32 IdleTime;
            LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
            LastInput.dwTime = 0;

            if (GetLastInputInfo(ref LastInput))
            {
                IdleTime = System.Environment.TickCount - LastInput.dwTime;

                if (IdleTime >= 60000)
                    logout();

            }
        }

        public void getMaschines()
        {
            string buffer = "";
            StreamReader reader = new StreamReader("Machines.txt");
            while ((buffer = reader.ReadLine()) != null)
                machinelist.Add(buffer);
            reader.Close();
            comboBoxMN.Items.Clear();
            foreach (String mac in machinelist)
            {
                comboBoxMN.Items.Add(mac);
            }
            comboBoxMN.SelectedIndex = 0;
            labelMN.Content = "Maschinennummer " + machinelist[machineIndex];
        }

        private int getKW(DateTime selected)
        {
            int kW = 0;

            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            System.Globalization.Calendar calendar = currentCulture.Calendar;

            if (selected == DateTime.Today)
            {
                calenderWeek = calendar.GetWeekOfYear(selected,
                 currentCulture.DateTimeFormat.CalendarWeekRule,
                 currentCulture.DateTimeFormat.FirstDayOfWeek);
                calenderWeek.ToString();
                kW = calenderWeek;
            }
            else
            {
                kW = calendar.GetWeekOfYear(selected,
                 currentCulture.DateTimeFormat.CalendarWeekRule,
                 currentCulture.DateTimeFormat.FirstDayOfWeek);
                calenderWeek.ToString();
            }

            getDatumVonKW();

            return kW;
        }

        private void getDatumVonKW()
        {
            DateTime dateNow = DateTime.Now;
            String Day = dateNow.DayOfWeek.ToString();
            int selKW = kWNow, add1 = 0, add2 = 0;

            if (labelKW.Content != "")
                selKW = Int32.Parse(labelKW.Content.ToString().Remove(0, 14));

            switch (Day)
            {
                case "Monday":
                    add2 = 6;
                    break;
                case "Tuesday":
                    add1 = -1;
                    add2 = 5;
                    break;
                case "Wednesday":
                    add1 = -2;
                    add2 = 4;
                    break;
                case "Thursday":
                    add1 = -3;
                    add2 = 3;
                    break;
                case "Friday":
                    add1 = -4;
                    add2 = 2;
                    break;
                case "Saturday":
                    add1 = -5;
                    add2 = 0;
                    break;
                case "Sunday":
                    add1 = -6;
                    break;
            }

            if (DateTime.Now.Year > selectedYear)
                if (kwCountIs52)
                    kwDaysDatum.Content = dateNow.AddDays((add1 + ((selKW - 52) - kWNow) * 7)).ToString().Remove(10, 9) + " - " + dateNow.AddDays((add2 + ((selKW - 52) - kWNow) * 7)).ToString().Remove(10, 9);
                else
                    kwDaysDatum.Content = dateNow.AddDays((add1 + ((selKW - 53) - kWNow) * 7)).ToString().Remove(10, 9) + " - " + dateNow.AddDays((add2 + ((selKW - 53) - kWNow) * 7)).ToString().Remove(10, 9);
            else if (DateTime.Now.Year < selectedYear)
                if (kwCountIs52)
                    kwDaysDatum.Content = dateNow.AddDays((add1 + ((52 - kWNow) + selKW) * 7)).ToString().Remove(10, 9) + " - " + dateNow.AddDays((add2 + ((52 - kWNow) + selKW) * 7)).ToString().Remove(10, 9);
                else
                    kwDaysDatum.Content = dateNow.AddDays((add1 + ((53 - kWNow) + selKW) * 7)).ToString().Remove(10, 9) + " - " + dateNow.AddDays((add2 + ((53 - kWNow) + selKW) * 7)).ToString().Remove(10, 9);
            else
                kwDaysDatum.Content = dateNow.AddDays((add1 + (selKW - kWNow) * 7)).ToString().Remove(10, 9) + " - " + dateNow.AddDays((add2 + (selKW - kWNow) * 7)).ToString().Remove(10, 9);

        }

        private bool kwCount52()
        {
            bool countIs52 = true;
            DateTime startYear = (DateTime.Parse("01.01." + selectedYear));
            String startday = startYear.DayOfWeek.ToString();
            if (startday == "Thursday")
                countIs52 = false;
            else
            {
                startYear = (DateTime.Parse("31.12." + selectedYear));
                startday = startYear.DayOfWeek.ToString();
                if (startday == "Thursday")
                    countIs52 = false;
            }

            return countIs52;
        }

        private void ausloggenClick(object sender, RoutedEventArgs e)
        {
            logout();
        }

        private void logout()
        {
            Login_Sreen.auth = false;
            Login_Sreen.LoggedUserName = "";
            showDeleteTable();
            DataGridVorschlag.Visibility = Visibility.Hidden;
            MachineUnusedLIstBox.Items.Clear();
            machinelist.Clear();
            dispatcherTimer.Stop();
            labelTipp.Content = "";
            vonHH.Text = "07";
            vonSS.Text = "30";
            bisHH.Text = "15";
            bisSS.Text = "15";
            datePickerField.Text = "";

            try
            {
                MainWindow.pLSO.setPWback();

                if (this.NavigationService.CanGoBack)
                    this.NavigationService.GoBack();
                else
                {
                    Login_Sreen showLoginScreen = new Login_Sreen();
                    this.NavigationService.Navigate(showLoginScreen);
                }
            }
            catch { }

        }

        private void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void lockInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) || !char.IsLetter(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void addEintrag_Click(object sender, RoutedEventArgs e) // Specihern Button
        {
            try
            {
                bool isCorrect = inputIsCorrect();
                int kW = calenderWeek;
                bool avail = false;

                if (isCorrect)
                {
                    kW = getKW(DateTime.Parse(datePickerField.Text)); //Ausgewählte KW
                    avail = checkNichtBesetzt(kW);
                }

                if (labelTipp.Content == "" && avail) // wenn kein Fehler gemacht und erkannt wurde abspeichern
                {
                    try
                    {
                        String[] splitYear = datePickerField.Text.Split('.');
                        StreamWriter write = new StreamWriter("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kW + splitYear[2] + ".txt", true);

                        write.WriteLine(datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text + "_" + datePickerField.Text + " " + bisHH.Text + ":" +
                                bisSS.Text + "_" + Login_Sreen.LoggedUserName);
                        write.Close();

                        labelTipp.Foreground = new SolidColorBrush(Colors.Green);
                        labelTipp.Content = "Eintrag erfolgreich hinzugefügt.";

                        datePickerField.Text = "";
                        DataGridVorschlag.Visibility = Visibility.Hidden;
                        loadDataGrid(calenderWeek, machineIndex);


                    }
                    catch { }
                }
                else if (labelTipp.Content == "")
                {
                    labelTipp.Content = "Maschine bereits belegt";
                }
            }
            catch { }
        }

        private bool inputIsCorrect()
        {
            bool isCorrect = false;
            labelTipp.Foreground = new SolidColorBrush(Colors.Red);
            labelTipp.Content = "";

            if (datePickerField.Text != "")
            {
                try
                {
                    DateTime checkInputDate = DateTime.Parse(datePickerField.Text);
                }
                catch
                {
                    labelTipp.Content = "Ungültiges Datum.";
                }
            }
            if (vonHH.Text != "--" && bisHH.Text != "--" && vonSS.Text != "--" && bisSS.Text != "--" && datePickerField.Text != "") //Vollständigkeitsabfrage
            {

                correctinput();//Optische Verbesserung der Eingabe

                if (Int32.Parse(vonHH.Text) > 23 || Int32.Parse(bisHH.Text) > 23)
                    labelTipp.Content = "Die Stunden müssen 00 bis 23 betragen.";
                if (Int32.Parse(vonSS.Text) > 59 || Int32.Parse(bisSS.Text) > 59)
                    labelTipp.Content = "Die Minuten müssen 00 bis 59 betragen.";

                if (Int32.Parse((vonHH.Text + vonSS.Text)) > Int32.Parse((bisHH.Text + bisSS.Text)))
                    labelTipp.Content = "Späteren Endzeitpunkt wählen";
            }
            else
                labelTipp.Content = "Bitte alle Felder ausfüllen.";

            if (labelTipp.Content == "")
                isCorrect = true;

            return isCorrect;
        }

        private bool checkNichtBesetzt(int kW)
        {
            List<string> reservierungen = new List<string>();
            String content = "", buffer = "", lastDate = "";
            bool reservierbar1 = false, first = true;

            if (File.Exists("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kW + selectedYear + ".txt"))
            {
                StreamReader reader = new StreamReader("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kW + selectedYear + ".txt");
                while ((content = reader.ReadLine()) != null)
                    reservierungen.Add(content);
                reader.Close();
                reservierungen.Sort();

                String[] dateSplit;
                foreach (string data in reservierungen)
                {
                    dateSplit = data.Split('_');
                    buffer = dateSplit[0].Remove(10, 6);
                    if (datePickerField.Text == buffer)
                    {
                        reservierbar1 = false;
                        if (first && (DateTime.Parse((datePickerField.Text + " " + bisHH.Text + ":" + bisSS.Text)) <= DateTime.Parse(dateSplit[0])))
                        {
                            first = false;
                            reservierbar1 = true;
                            break;
                        }
                        else if (first)
                        {
                            lastDate = dateSplit[1];
                            first = false;
                        }


                        if (!first && (DateTime.Parse((datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text)) >= DateTime.Parse(lastDate))
                            && (DateTime.Parse((datePickerField.Text + " " + bisHH.Text + ":" + bisSS.Text)) <= DateTime.Parse(dateSplit[0])))
                        {
                            reservierbar1 = true;
                            break;
                        }
                        else
                        {
                            lastDate = dateSplit[1];
                        }
                    }
                    else if (first)
                        reservierbar1 = true;
                }
                if (reservierbar1 == false && reservierungen.Count != 0 && DateTime.Parse((datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text)) >= DateTime.Parse(lastDate))
                    reservierbar1 = true;
                if (reservierungen.Count == 0)
                    reservierbar1 = true;

            }
            else
                reservierbar1 = true;
            return reservierbar1;
     
        }

        private bool checkNichtBesetztVorschlag(int kW)
        {
            List<string> reservierungen = new List<string>();
            String content = "", buffer = "", lastDate = "";
            bool reservierbar1 = false, first = true;

           
                DataList.Sort();

                String[] dateSplit;
                if (DataList.Count == 0)
                    reservierbar1 = false;
                else
                    foreach (string data in DataList)
                    {
                        dateSplit = data.Split('_');
                        buffer = dateSplit[0].Remove(10, 6);
                        if (datePickerField.Text == buffer)
                        {
                            reservierbar1 = true;
                            if (first && (DateTime.Parse((datePickerField.Text + " " + bisHH.Text + ":" + bisSS.Text)) <= DateTime.Parse(dateSplit[0])))
                            {
                                first = false;
                                reservierbar1 = false;
                                break;
                            }
                            else if (first)
                            {
                                lastDate = dateSplit[1];
                                first = false;
                            }
                            if (!first && (DateTime.Parse((datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text)) >= DateTime.Parse(lastDate))
                                && (DateTime.Parse((datePickerField.Text + " " + bisHH.Text + ":" + bisSS.Text)) <= DateTime.Parse(dateSplit[0])))
                            {
                                reservierbar1 = false;
                                break;
                            }
                            else
                            {
                                lastDate = dateSplit[1];
                            }
                        }
                        else if (first)
                            reservierbar1 = false;
                    }
                if (reservierbar1 == true && DataList.Count != 0 && DateTime.Parse((datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text)) >= DateTime.Parse(lastDate))
                    reservierbar1 = false;
           

            return reservierbar1;
        }

        private void otherMaschine(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxMN.Items.Count != 0)
            {
                string buffer = "";
                labelMN.Content = "Maschinennummer " + comboBoxMN.SelectedValue.ToString();
                buffer = comboBoxMN.SelectedValue.ToString();
                machineIndex = machinelist.IndexOf(buffer.ToString());
                loadDataGrid(calenderWeek, machineIndex);
            }
        }

        private void correctinput()
        {
            if (vonHH.Text.Length == 1)
                vonHH.Text = "0" + vonHH.Text;
            if (bisHH.Text.Length == 1)
                bisHH.Text = "0" + bisHH.Text;
            if (vonSS.Text.Length == 1)
                vonSS.Text = "0" + vonSS.Text;
            if (bisSS.Text.Length == 1)
                bisSS.Text = "0" + bisSS.Text;
        }

        private void Fokus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox btn = (System.Windows.Controls.TextBox)sender;

            //if (btn.Text == "--")
            btn.Text = "";
        }

        private void Fokuslost(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox btn = (System.Windows.Controls.TextBox)sender;

            if (btn.Text == "")
                btn.Text = "--";
        }

        private void btnKWBackClick(object sender, RoutedEventArgs e)
        {
            calenderWeek--;
            if (calenderWeek == 0)
            {
                selectedYear--;
                kwCountIs52 = kwCount52();
                if (kwCountIs52)
                    calenderWeek = 52;
                else
                    calenderWeek = 53;
            }
            else if (calenderWeek < (kWNow - 12) && calenderWeek > 0)
            {
                calenderWeek = kWNow - 12;
            }
            else if (selectedYear < DateTime.Now.Year)
            {
                if(kwCountIs52)
                {
                    if (calenderWeek < (52 + kWNow - 12)) { 
                        calenderWeek = 52 + kWNow - 12;
                        if (kwCountIs52 && calenderWeek == 53)
                            calenderWeek = 52;
                    }
                            
                }
                else
                    if (calenderWeek < (53 + kWNow - 12))
                        calenderWeek = 53 + kWNow - 12;
            }
            labelKW.Content = "Kalenderwoche " + calenderWeek;
            getDatumVonKW();
            loadDataGrid(calenderWeek, machineIndex);
        }

        private void kWforwardClick(object sender, RoutedEventArgs e)
        {
            calenderWeek++;

            if (kwCountIs52)
            {
                if (calenderWeek == 53)
                {
                    selectedYear++;
                    kwCountIs52 = kwCount52();
                    calenderWeek = 1;
                }
            }
            else
                if (calenderWeek == 54)
                {
                    selectedYear++;
                    kwCountIs52 = kwCount52();
                    calenderWeek = 1;
                }

            labelKW.Content = "Kalenderwoche " + calenderWeek;
            getDatumVonKW();
            loadDataGrid(calenderWeek, machineIndex);
        }

        private void btnMachineBackClick(object sender, RoutedEventArgs e)
        {
            machineIndex--;
            if (machineIndex == -1)
                machineIndex++;
            comboBoxMN.SelectedIndex = machineIndex;
            labelMN.Content = "Maschinennummer " + (comboBoxMN.Items[machineIndex].ToString());

            loadDataGrid(calenderWeek, machineIndex);
        }

        private void btnMachineForwoard_Click(object sender, RoutedEventArgs e)
        {
            machineIndex++;
            if (machineIndex > (comboBoxMN.Items.Count - 1))
                machineIndex--;
            comboBoxMN.SelectedIndex = machineIndex;
            labelMN.Content = "Maschinennummer " + (comboBoxMN.Items[machineIndex].ToString());
            loadDataGrid(calenderWeek, machineIndex);
        }

        private void vonHHTextChanged(object sender, TextChangedEventArgs e)
        {
            if (vonHH.Text.Length == 2)
                Keyboard.Focus(vonSS);
        }

        private void vonSSTextChanged(object sender, TextChangedEventArgs e)
        {
            if (vonSS.Text.Length == 2)
                Keyboard.Focus(bisHH);
        }

        private void bisHHTextChanged(object sender, TextChangedEventArgs e)
        {
            if (bisHH.Text.Length == 2)
                Keyboard.Focus(bisSS);
        }

        //private void deleteClick(object sender, RoutedEventArgs e)
        //{
        //    bool isCorrect = inputIsCorrect();

        //    if (isCorrect)
        //    {
        //        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            String eintrag = datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text + "_" + datePickerField.Text + " "
        //                    + bisHH.Text + ":" + bisSS.Text + "_" + Login_Sreen.LoggedUserName;
        //            if (DataList.IndexOf(eintrag) != -1)
        //            {
        //                int kw = getKW(DateTime.Parse(datePickerField.Text));

        //                try
        //                {
        //                    File.Delete("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kw + selectedYear + ".txt");
        //                    DataList.Remove(eintrag);
        //                    StreamWriter writer = new StreamWriter("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kw + selectedYear + ".txt");
        //                    foreach (String data in DataList)
        //                        writer.WriteLine(data);
        //                    writer.Close();
        //                    loadDataGrid(kw, Int32.Parse(machinelist[machineIndex]));
        //                }
        //                catch
        //                {
        //                    labelTipp.Content = "Eintrag wurde nicht gelöscht";
        //                }
        //            }
        //            else
        //            {
        //                labelTipp.Content = "Kein übereinstimmender Eintrag vorhanden";
        //                foreach (String data in DataList)
        //                {
        //                    if (data.IndexOf(datePickerField.Text + " " + vonHH.Text + ":" + vonSS.Text + "_" + datePickerField.Text + " " + bisHH.Text + ":" + bisSS.Text + "_") != -1)
        //                    {
        //                        labelTipp.Content = "Keine Berechtigungen für diesen Eintrag";
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        else if (dialogResult == DialogResult.No)
        //        {

        //        }
        //    }
        //    datePickerField.Text = "";
        //}

        private void deleteClick(object sender, RoutedEventArgs e)
        {
            if (btnMachineBack_Copy.Visibility == System.Windows.Visibility.Visible)
            {
                deleteEintrag();
                //loadDataGrid(calenderWeek, machineIndex);
            }
            else
                showDeleteTable();
        }

        private void showDeleteTable()
        {
            labelTipp.Content = "";
            LabelLeftCenter.Content = "Eigene Einträge";
            btnMachineBack_Copy.Visibility = System.Windows.Visibility.Visible;
            KWLabel.Visibility = System.Windows.Visibility.Visible;
            btnMachineBack_Copy1.Visibility = System.Windows.Visibility.Visible;
            btnMachineBack_Copy3.Visibility = System.Windows.Visibility.Visible;
            MNLabel.Visibility = System.Windows.Visibility.Visible;
            btnMachineBack_Copy2.Visibility = System.Windows.Visibility.Visible;
            EntryDeleteListBox.Visibility = System.Windows.Visibility.Visible;
            DeleteEntry.Visibility = System.Windows.Visibility.Visible;
            MachineUnusedLIstBox.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void enterPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                addEintrag_Click(this, new RoutedEventArgs());
        }

        private void sucheClick(object sender, RoutedEventArgs e)
        {
            try { 
            if (inputIsCorrect())
            {
                btnMachineBack_Copy.Visibility = System.Windows.Visibility.Collapsed;
                KWLabel.Visibility = System.Windows.Visibility.Collapsed;
                btnMachineBack_Copy1.Visibility = System.Windows.Visibility.Collapsed;
                btnMachineBack_Copy3.Visibility = System.Windows.Visibility.Collapsed;
                MNLabel.Visibility = System.Windows.Visibility.Collapsed;
                btnMachineBack_Copy2.Visibility = System.Windows.Visibility.Collapsed;
                LabelLeftCenter.Content = "Verfügbare Maschinen";
                EntryDeleteListBox.Visibility = System.Windows.Visibility.Collapsed;
                DeleteEntry.Visibility = System.Windows.Visibility.Collapsed;
                MachineUnusedLIstBox.Visibility = System.Windows.Visibility.Visible;

                int kW = calenderWeek;
                bool avail = false;
                int indexMerken = comboBoxMN.SelectedIndex;

                MachineUnusedLIstBox.Items.Clear();
                DataListVoschlaege.Clear();

                kW = getKW(DateTime.Parse(datePickerField.Text)); //Ausgewählte KW

                foreach (String mech in machinelist)
                {
                    DataList.Clear();
                    string eintrag = "";

                    if (File.Exists("Reservierungen\\" + mech + kWNow + selectedYear + ".txt"))
                    {
                        StreamReader reader = new StreamReader("Reservierungen\\" + mech + kWNow + selectedYear + ".txt");
                        while ((eintrag = reader.ReadLine()) != null)
                        {
                            DataList.Add(eintrag);
                        }
                        reader.Close();

                        avail = checkNichtBesetztVorschlag(kW);
                    }
                    if (!avail)
                    {
                        MachineUnusedLIstBox.Items.Add(mech);
                    }
                    avail = false;
                }

                DataGridVorschlag.ItemsSource = DataListVoschlaege;
                DataGridVorschlag.Items.Refresh();
            }
                }catch
            {}
        }

        private void loadDataGrid(int kw, int mn)
        {
            try { 
            DataList.Clear();
            MondayList.Clear();
            ThursdayList.Clear();
            WednesdayList.Clear();
            TuesdayList.Clear();
            FridayList.Clear();

            String content;
            if (File.Exists("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kw + selectedYear + ".txt"))
            {
                StreamReader r = new StreamReader("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kw + selectedYear + ".txt");

                if (DataList.Count == 0)
                {
                    while ((content = r.ReadLine()) != null)
                    {
                        DataList.Add(content);
                    }
                    r.Close();
                    DataList.Sort();

                    String[] dateSplit;
                    String[] timeBuffer;
                    String timeFirst = "";
                    String timeLast;
                    DateTime Date;

                    for (int i = 0; i < DataList.Count; i++)
                    {
                        dateSplit = DataList[i].Split('_');
                        timeBuffer = dateSplit[0].Split(' ');
                        timeFirst = timeBuffer[1];
                        timeBuffer = dateSplit[1].Split(' ');
                        timeLast = timeBuffer[1];
                        Date = Convert.ToDateTime(dateSplit[0]);

                        switch (Date.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                MondayList.Add(new Monday() { Montag = dateSplit[2] });
                                MondayList.Add(new Monday() { Montag = timeFirst + " - " + timeLast + " Uhr" });
                                MondayList.Add(new Monday() { Montag = "" });
                                break;
                            case DayOfWeek.Tuesday:
                                TuesdayList.Add(new Tuesday() { Dienstag = dateSplit[2] });
                                TuesdayList.Add(new Tuesday() { Dienstag = timeFirst + " - " + timeLast + " Uhr" });
                                TuesdayList.Add(new Tuesday() { Dienstag = "" });
                                break;
                            case DayOfWeek.Wednesday:
                                WednesdayList.Add(new Wednesday() { Mittwoch = dateSplit[2] });
                                WednesdayList.Add(new Wednesday() { Mittwoch = timeFirst + " - " + timeLast + " Uhr" });
                                WednesdayList.Add(new Wednesday() { Mittwoch = "" });
                                break;
                            case DayOfWeek.Thursday:
                                ThursdayList.Add(new Thursday() { Donnerstag = dateSplit[2] });
                                ThursdayList.Add(new Thursday() { Donnerstag = timeFirst + " - " + timeLast + " Uhr" });
                                ThursdayList.Add(new Thursday() { Donnerstag = "" });
                                break;
                            case DayOfWeek.Friday:
                                FridayList.Add(new Friday() { Freitag = dateSplit[2] });
                                FridayList.Add(new Friday() { Freitag = timeFirst + " - " + timeLast + " Uhr" });
                                FridayList.Add(new Friday() { Freitag = "" });

                                break;
                        }

                        timeFirst = "";
                        timeLast = "";
                        dateSplit[2] = "";
                    }

                    if (MondayList.Count != 0)
                        MondayList.RemoveAt(MondayList.Count - 1);
                    if (TuesdayList.Count != 0)
                        TuesdayList.RemoveAt(TuesdayList.Count - 1);
                    if (WednesdayList.Count != 0)
                        WednesdayList.RemoveAt(WednesdayList.Count - 1);
                    if (ThursdayList.Count != 0)
                        ThursdayList.RemoveAt(ThursdayList.Count - 1);
                    if (FridayList.Count != 0)
                        FridayList.RemoveAt(FridayList.Count - 1);
                }

            }

            DataGridMonday.ItemsSource = MondayList;
            DataGridMonday.Items.Refresh();
            DataGridTuesday.ItemsSource = TuesdayList;
            DataGridTuesday.Items.Refresh();
            DataGridWednesday.ItemsSource = WednesdayList;
            DataGridWednesday.Items.Refresh();
            DataGridThursday.ItemsSource = ThursdayList;
            DataGridThursday.Items.Refresh();
            DataGridFriday.ItemsSource = FridayList;
            DataGridFriday.Items.Refresh();

            addEntryDeleteList();
            }
            catch
            { }
        }

        private void addEntryDeleteList()
        {
            string typedString = Login_Sreen.LoggedUserName;
            EntryDeleteListBox.Items.Clear();
                String[] dataSplit;

                foreach (string data in DataList)
                {
                    if (!string.IsNullOrEmpty(typedString))
                    {
                        if (data.IndexOf(typedString, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            dataSplit = data.Split('_');

                            var culture = new System.Globalization.CultureInfo("de-DE");
                            dayFirst = DateTime.Parse(dataSplit[0]);
                            day = culture.DateTimeFormat.GetDayName(dayFirst.DayOfWeek);
                            dayLast = DateTime.Parse(dataSplit[1]);

                            EntryDeleteListBox.Items.Add(day + " " + dayFirst.ToString("HH:mm") + "-" + dayLast.ToString("HH:mm"));
                        }
                    }
                }
        }
        private void deleteEintrag()
        {
            if (EntryDeleteListBox.SelectedIndex != -1)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Den Eintrag wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String eintrag = "";
                    if(DataList.Count == 0)
                        if (File.Exists("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kWNow + selectedYear + ".txt"))
                        {
                            StreamReader reader = new StreamReader("Reservierungen\\" + comboBoxMN.SelectedValue.ToString() + kWNow + selectedYear + ".txt");
                            while ((eintrag = reader.ReadLine()) != null)
                            {
                                DataList.Add(eintrag);
                            }
                            reader.Close();
                        }

                    String[] DeleteContent;
                    String[] DeleteDate;
                    String[] DeleteTime;
                    String suggestionDelete = EntryDeleteListBox.SelectedItem.ToString();
                    DeleteDate = suggestionDelete.Split(' ');
                    DeleteTime = DeleteDate[1].Split('-');

                    DeleteContent = kwDaysDatum.Content.ToString().Split(' ');
                    DateTime date = DateTime.Parse(DeleteContent[0]);

                    switch (DeleteDate[0])
                    {
                        case "Dienstag":
                            date = date.AddDays(1);
                            break;
                        case "Mittwoch":
                            date = date.AddDays(2);
                            break;
                        case "Donnerstag":
                            date = date.AddDays(3);
                            break;
                        case "Freitag":
                            date = date.AddDays(4);
                            break;
                    }

                    DataList.Remove(date.ToString("dd.MM.yyyy") + " " + DeleteTime[0] + "_" + date.ToString("dd.MM.yyyy") + " " + DeleteTime[1] + "_" + Login_Sreen.LoggedUserName);
                    File.Delete("Reservierungen\\" + machinelist[machineIndex].ToString() + calenderWeek + selectedYear + ".txt");
                    StreamWriter writer = new StreamWriter("Reservierungen\\" + machinelist[machineIndex].ToString() + calenderWeek + selectedYear + ".txt");
                    foreach (String data in DataList)
                        writer.WriteLine(data);
                    writer.Close();
                    loadDataGrid(calenderWeek, machineIndex);
                }
                else if (dialogResult == DialogResult.No)
                { }
            }
            else
            {
                labelTipp.Content = "Eintrag auswählen.";
            }
        }
        private void DeleteEntryClick(object sender, RoutedEventArgs e)
        {
            deleteEintrag();
        }

        private void MachineUnusedLIstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MachineUnusedLIstBox.SelectedValue != null)
                comboBoxMN.SelectedIndex = comboBoxMN.Items.IndexOf(MachineUnusedLIstBox.SelectedValue);
        }

        public class Monday
        {
            public String Montag { get; set; }
        }

        public class Tuesday
        {
            public String Dienstag { get; set; }
        }

        public class Wednesday
        {
            public String Mittwoch { get; set; }
        }

        public class Thursday
        {
            public String Donnerstag { get; set; }
        }

        public class Friday
        {
            public String Freitag { get; set; }
        }

        public class Vorschlag
        {
            public String Freie_Maschinen { get; set; }
        }

        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                calenderWeek = getKW(DateTime.Parse(datePickerField.Text));
                labelKW.Content = "Kalenderwoche " + calenderWeek;
                getDatumVonKW();
                loadDataGrid(calenderWeek, machineIndex);
            }
            catch { }
        }

        

       

    }
}