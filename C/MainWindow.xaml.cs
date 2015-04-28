using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GRU_Verkefni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Name: Kjartan Már Andersen
    /// Role: C# vensl fyrir GRU Lokaverkefni
    /// Created. 10. April 2015
    /// Todo: Allt
    /// Description: CRUD Fyrir meðlimi, CRUD Fyrir atburði, CRUD á þáttakendur, 
    /// má ekki eyða út meðlim ef hann er skráður í atburð,
    /// má ekki eyða út atburð ef meðlimur er í honum,
    /// gefa öðrum notendum admin réttindi
    public partial class MainWindow : Window
    {

        sql sql = new sql();
        public MainWindow()
        {
            
            InitializeComponent();
            upmedcurridtb.IsEnabled = false;
            upatcurridtb.IsEnabled = false;
            upthcurridtb.IsEnabled = false;
            try
            {
                sql.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }
       
        private void inmedbt_Click(object sender, RoutedEventArgs e)
        {
            string inmedus = inmedustb.Text;
            string inmednafn = inmednametb.Text;
            string inmedpass = inmedpasstb.Text;
            string inmedstat = inmedstattb.Text;

            if (inmedus == string.Empty || inmednafn == string.Empty || inmedpass == string.Empty || inmedstat == string.Empty)
            {
                MessageBox.Show("Vantar að fylla út í Textbox");
            }
            else
            {
                try
                {
                    sql.InsertMedlim(inmedus,inmednafn,inmedpass,inmedstat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw ex;
                }
            }
            inmedustb.Text = "";
            inmednametb.Text = "";
            inmedpasstb.Text = "";
            inmedstattb.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            lesamedlb.Items.Clear();
            List<string> linur = new List<string>();
            try
            {
                linur = sql.SelectMedlim();
                foreach (string lin in linur)
                {
                    lesamedlb.Items.Add(lin);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void upmedbt_Click(object sender, RoutedEventArgs e)
        {
            string upmedcurrid = upmedcurridtb.Text;
            string upmedid = upmedidtb.Text;
            string upmedus = upmedustb1.Text;
            string upmednafn = upmednafntb.Text;
            string upmedpass = upmedpasstb.Text;
            string upmedstat = upmedstattb.Text;
            if (upmedcurrid == string.Empty || upmedid == string.Empty || upmedus == string.Empty || upmednafn == string.Empty || upmedpass == string.Empty || upmedstat == string.Empty)
            {
                MessageBox.Show("Vantar að fylla út í Textbox");
            }
            else
            {
                try
                {
                    sql.UpdateMedlim(upmedid, upmedus, upmednafn, upmedpass, upmedstat, upmedcurrid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            upmedidtb.Text = "";
            upmedustb1.Text = "";
            upmednafntb.Text = "";
            upmedpasstb.Text = "";
            upmedstattb.Text = "";
            upmedcurridtb.Text = "";

        }

        private void lesamedlb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lesamedlb.SelectedIndex != -1)
            {
                string nafn = null;
                string[] nafnid = null;
                nafn = lesamedlb.SelectedItem.ToString();
                char split = ';';
                nafnid = nafn.Split(split);
                upmedcurridtb.Text = nafnid[0];
                upmedidtb.Text = nafnid[0];
                upmedustb1.Text = nafnid[1];
                upmednafntb.Text = nafnid[2];
                upmedpasstb.Text = nafnid[3];
                upmedstattb.Text = nafnid[4];

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lesamedlb.Items.Clear();
            string id = delmedidtb.Text;

            try
            {
                sql.DeleteMedlim(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            delmedidtb.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string inatnafn = inatnafntb.Text;
            string inatstad = inatstadtb.Text;
            string inatdag = inatdagtb.Text;
            string inatdesc = inatdesctb.Text;

            if (inatnafn == string.Empty || inatstad == string.Empty || inatdag == string.Empty || inatdesc == string.Empty)
            {
                MessageBox.Show("Vantar að fylla út í textbox");
            }
            else
            {
                try
                {
                    sql.InsertAtburd(inatnafn,inatstad,inatdag,inatdesc);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                    throw ex;
                }
            }
            inatnafntb.Text = "";
            inatstadtb.Text = "";
            inatdagtb.Text = "";
            inatdesctb.Text = "";
        }

        private void lesamedlimbt_Click(object sender, RoutedEventArgs e)
        {
            lesaatburdlb.Items.Clear();
            List<string> linur = new List<string>();
            try
            {
                linur = sql.SelectAtburd();
                foreach (string lin in linur)
                {
                    lesaatburdlb.Items.Add(lin);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void upatbt_Click(object sender, RoutedEventArgs e)
        {
            string upatcurrid = upatcurridtb.Text;
            string upatid = upatidtb.Text;
            string upatnafn = upatnafntb.Text;
            string upatstad = upatstadtb.Text;
            string upatdag = upatdagtb.Text;
            string upatdesc = upatdesctb.Text;
            if (upatcurrid == String.Empty || upatid == String.Empty || upatnafn == String.Empty || upatstad == String.Empty || upatdag == String.Empty || upatdesc == String.Empty)
            {
                MessageBox.Show("Vantar að fylla út í textbox");
            }
            else
            {
                try
                {
                    sql.UppfaeraAtburd(upatid,upatnafn,upatstad,upatdag,upatdesc,upatcurrid);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.ToString());
                }


            }
            upatcurridtb.Text = "";
            upatidtb.Text = "";
            upatnafntb.Text = "";
            upatstadtb.Text = "";
            upatdagtb.Text = "";
            upatdesctb.Text = "";



        }

        private void lesaatburdlb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lesaatburdlb.SelectedIndex != -1)
            {
                string nafn = null;
                string[] nafnid = null;
                nafn = lesaatburdlb.SelectedItem.ToString();
                char split = ';';
                nafnid = nafn.Split(split);
                upatcurridtb.Text = nafnid[0];
                upatidtb.Text = nafnid[0];
                upatnafntb.Text = nafnid[1];
                upatstadtb.Text = nafnid[2];
              //  string[] strengur = nafnid[3].Split(' ');
                upatdagtb.Text = nafnid[3];
                upatdesctb.Text = nafnid[4];
                delattb.Text = nafnid[0];



            }
        }

        private void delatbt_Click(object sender, RoutedEventArgs e)
        {
            lesaatburdlb.Items.Clear();
            string delatid = delattb.Text;

            try
            {
                sql.EydaAtburd(delatid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            delattb.Text = "";
            upatcurridtb.Text = "";
            upatidtb.Text = "";
            upatnafntb.Text = "";
            upatstadtb.Text = "";
            upatdagtb.Text = "";
            upatdesctb.Text = "";
        }

        private void inthabt_Click(object sender, RoutedEventArgs e)
        {
            string inthaat = inthaattb.Text;
            string inthamed = inthamedtb.Text;

            if (inthaat == string.Empty || inthamed == string.Empty)
            {
                MessageBox.Show("Vantar að fylla út í textbox");
            }
            else
            {
                try
                {
                    sql.InsertThattakend(inthaat,inthamed);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            inthaattb.Text = "";
            inthamedtb.Text = "";
        }

        private void lesathat_Click(object sender, RoutedEventArgs e)
        {
            thatlb.Items.Clear();
            List<string> linur = new List<string>();
            try
            {
                linur = sql.SelectThattakend();
                foreach (string lin in linur)
                {
                    thatlb.Items.Add(lin);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string upthatcurrid = upthcurridtb.Text;
            string upthatid = upthaidtb.Text;
            string upthaidmed = upthaidmedtb.Text;
            string upthaidat = upthaidattb.Text;

            if (upthatcurrid == string.Empty || upthatid == string.Empty || upthaidmed == string.Empty || upthaidat == string.Empty)
            {
                MessageBox.Show("Vantar að fylla út í textbox");
            }
            else
            {
                try
                {
                    sql.UppfaeraThattakend(upthatid, upthaidmed, upthaidat, upthatcurrid);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            upthcurridtb.Text = "";
            upthaidtb.Text = "";
            upthaidmedtb.Text = "";
            upthaidattb.Text = "";

        }

        private void thatlb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (thatlb.SelectedIndex != -1)
            {
                string nafn = null;
                string[] nafnid = null;
                nafn = thatlb.SelectedItem.ToString();
                char split = ';';
                nafnid = nafn.Split(split);
                eythatb.Text = nafnid[0];
                upthcurridtb.Text = nafnid[0];
                upthaidtb.Text = nafnid[0];
                upthaidmedtb.Text = nafnid[1];
                upthaidattb.Text = nafnid[2];



            }
        }

        private void eythabt_Click(object sender, RoutedEventArgs e)
        {
            thatlb.Items.Clear();
            string eytha = eythatb.Text;

            try
            {
                sql.EydaAtburd(eytha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            eythatb.Text = "";
            upthcurridtb.Text = "";
            upthaidtb.Text = "";
            upthaidmedtb.Text = "";
            upthaidattb.Text = "";

        }
    }
}
