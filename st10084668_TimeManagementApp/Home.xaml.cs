using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DLLCalcs;
using st10084668_TimeManagementApp.Model;
using Module = st10084668_TimeManagementApp.Model.Module;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Lifetime;

namespace st10084668_TimeManagementApp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
    
        //Global instan
        ModuleContext mcon = new ModuleContext();
        Module m = new Module();

        SelfStudyContext scon = new SelfStudyContext();
        SelfStudy ss = new SelfStudy();

        //Delegate declaration
        public delegate void showUserDelegate(string name);

        public Home()
        {
            InitializeComponent();
            bindGridView1();//shows the modules when form loads
            populateCombox();//populate combox
            bindGridView2();//shows the self study records when the form loads

            showUserDelegate nud = delegate (string name)
            {
                lbluser.Content += name;
            };
            nud.Invoke(Login.username);
            }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Exiting application
            Application.Current.Shutdown();
        }

       
        //add modules to combobox
        public void populateCombox()
        {
            cmbxCode.Items.Clear();//clear combobox first
            cmbxCode2.Items.Clear();//clear combobox first
            var userQuery = mcon.Modules.Where(u => u.username == Login.username);//finds the user
            var usermodData = userQuery.ToList();//create the list
            foreach (Module md in usermodData)
            {
                cmbxCode.Items.Add(md.moduleCode);// add module to combobox
                cmbxCode2.Items.Add(md.moduleCode);
            }
            }

        //Binding module datagrid
        public void bindGridView1()
        {
            //connect to db
            string conString1 = ConfigurationManager.ConnectionStrings["ModuleContext"].ConnectionString;
            string CmdString1 = string.Empty;
            using (SqlConnection con1 = new SqlConnection(conString1))
            {
                CmdString1 = "SELECT * FROM Modules WHERE (username='" + Login.username + "')"; //query table to only show modules for a specific user
                SqlCommand cmd1 = new SqlCommand(CmdString1, con1);
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dt1);
                DataGrid1.ItemsSource = dt1.DefaultView;//display in datagrid

            }
           

            
        }//end module datagrid binding

        //binding self study records to datagrid
        public void bindGridView2()
        {
            //connect to db
            string conString2 = ConfigurationManager.ConnectionStrings["SelfStudyContext"].ConnectionString;//set connection string
            string CmdString2 = string.Empty;
            using (SqlConnection con2 = new SqlConnection(conString2))//using connection string
            {

                CmdString2 = "SELECT dateOfStudy,moduleCode,hoursWorked FROM SelfStudies WHERE (username='" + Login.username + "')"; //query table to only show self study records for a specific user
                SqlCommand cmd2 = new SqlCommand(CmdString2, con2);
                DataTable dt2 = new DataTable();
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                sda2.Fill(dt2);
                DataGrid2.ItemsSource = dt2.DefaultView; //display in datagrid

            }
            


        }//end selfstudy datagrid binding 

        public void clearModtb()
        {

            //Clear all textboxes
            tbCode.Clear();
            tbName.Clear();
            tbCredits.Clear();
            tbHrsPWk.Clear();
            tbNumWeeks.Clear();
            DatePicker1.SelectedDate=null;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                //check if all fields are filled
                if ((tbName.Text.Length != 0) && (tbCode.Text.Length != 0) && (tbCredits.Text.Length != 0) && (tbHrsPWk.Text.Length != 0) && (tbNumWeeks.Text.Length != 0) && (DatePicker1.SelectedDate != null))
                {
                    if (MessageBox.Show("Please verify that the entry is correct", "Confirm Entry", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes )//if the user clicks yes
                    {
                        var userQuery = mcon.Modules.Where(u => u.username == Login.username);//find user
                        var usermodData = userQuery.ToList();//create list


                        string userExists = "";
                        foreach (Module md in usermodData)
                        {
                            if (md.username == Login.username)
                            {
                                userExists = "True";
                            }
                            else
                            {
                                userExists = "False";
                            }
                        }//end userExists foreach


                        switch (userExists)
                        {
                         case "True" :
                         var modQuery = mcon.Modules.Where(u => u.username == Login.username);
                        var modData = modQuery.ToList();//create list




                        bool modExists = false;//set default value
                        foreach (Module md in modData)
                        {

                            if ((md.username == Login.username) && (md.moduleCode == tbCode.Text.Trim()))//finding if the module exists
                            {
                                modExists = true;
                                MessageBox.Show("This module has already been entered", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                clearModtb();//clear fields
                            }
                            else
                            {
                                modExists = false;
                            }
                        }//end foreach

                        switch (modExists)
                        {
                            case false:
                                insertDbMod();//insert into module table
                                        break;
                        }//end inner switch
                                break;

                        default: insertDbMod();//inserts into the module table
                        break;
                         }//end outer switch

                    }//end if the username confirms entry
                }//end if all the textboxes are filled in
                else
                {
                    MessageBox.Show("Fields cannot be left blank .\nPlease try again","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }catch(Exception)
            {
   
            }
        }//btnAdd end

        public void insertDbMod()
        {
            try
            {
                try
                {
                    //Get values to insert into database
                    m.username = Login.username;
                    m.moduleCode = tbCode.Text.Trim();
                    m.moduleName = tbName.Text.Trim();
                    m.credits = Convert.ToInt32(tbCredits.Text.Trim());
                    m.classHrsPerWeek = Convert.ToInt32(tbHrsPWk.Text.Trim());
                    m.weeksInSemester = Convert.ToInt32(tbNumWeeks.Text.Trim());
                    m.startDate = DateTime.Parse(DatePicker1.Text);
                    m.selfStudyHrs = Calculations.CalcHoursPerWeek(m.credits, m.weeksInSemester, m.classHrsPerWeek);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure that all fields are filled in correctly","Failed",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                //insert into db
                //use usercontext to push the data
                mcon.Modules.Add(m); //insert module into db
                int a = mcon.SaveChanges();
                if (a > 0)//if the module was added sucessfully to the db
                {
                    MessageBox.Show("Module has been added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    bindGridView1();//refresh datagrid
                    populateCombox();//populate module combobox
                    //clear textboxes
                    clearModtb();
                }//end if
                else//if module didnt not get added to db
                {
                    MessageBox.Show("Whoops! something went wrong.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }//end else
            }
            catch (Exception)
            {
               
            }
        }
        private void btnHoursWorked_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((DatePicker2.SelectedDate != null) && (cmbxCode.Text.Length != 0) && (tbHoursWorked.Text.Length != 0)) //if all fields are filled in
                {
                   

                        if (MessageBox.Show("Please verify that the entry is correct", "Confirm Entry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            insertDbSS();//insert into self study table
                            clearSStb();//clear previous entry
                        }

                    

                }
                else //if a field does not have a value
                {
                    MessageBox.Show("Please ensure that all fields are filled in", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

            }
                

        }//end button click

        public void clearSStb()
        {
            //clear fields
            DatePicker2.SelectedDate = null;
            tbHoursWorked.Clear();
            cmbxCode.SelectedItem = null;
        }

        //insert into self study table
      public void insertDbSS()
        {
            try
            {
                try
                {
                    //get values 
                    ss.username = Login.username;
                    ss.dateOfStudy = DateTime.Parse(DatePicker2.Text.Trim());
                    ss.moduleCode = cmbxCode.Text;
                    ss.hoursWorked = Convert.ToInt32(tbHoursWorked.Text.Trim());
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure that all fields are filled in correctly", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                //get work week value
                DateTime startDate = DateTime.Now;
                var Querydb = mcon.Modules.Where(u => u.username == Login.username && u.moduleCode == (cmbxCode.SelectedItem.ToString()));
                var data = Querydb.ToList();

                if (data != null)
                {
                    foreach (Module qm in data)
                    {
                        startDate = qm.startDate;
                    }
                    ss.workWeek = Calculations.workWeek(ss.dateOfStudy, startDate);

                    scon.SelfStudies.Add(ss); //insert self study record into db
                    int a = scon.SaveChanges();
                    if (a > 0)//if the record was added sucessfully to the db
                    {
                        MessageBox.Show("Study session has been added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        bindGridView2();//refresh datagrid
                    }//end if
                    else//if record didnt not get added to db
                    {
                        MessageBox.Show("Whoops! something went wrong.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }//end else
                }
              
            }
            catch(Exception)
            {
               
            }
        }//end method

        

        private void cmbxCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //as the module changes the start date will change in date picker
            var Querydb = mcon.Modules.Where(u => u.username == Login.username && u.moduleCode == cmbxCode.SelectedItem.ToString());
            var data = Querydb.ToList();
            foreach (Module qm in data)
            {
                DatePicker2.SelectedDate = null;
                DatePicker2.DisplayDateStart = qm.startDate;
            }
        }

        private void cmbxCode2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               
                //Declare variables
                DateTime startDate = DateTime.Now;
                int selfstudyhrs = 0;
                int count = 0;
                int extraHrs = 0;

                //Query to get the start date of semester and self study hours per week
                var Querydb = mcon.Modules.Where(u => u.username == Login.username && u.moduleCode == cmbxCode2.SelectedItem.ToString());
                var data = Querydb.ToList();
                foreach (Module qm in data)
                {
                    startDate = qm.startDate;
                    selfstudyhrs = qm.selfStudyHrs;
                }

                //calculate current week
                int currentweek = Calculations.currentWeek(startDate);

                //Query to get study session details
                var Querydb2 = scon.SelfStudies.Where(u => u.username == Login.username && u.moduleCode == cmbxCode2.SelectedItem.ToString());
                var data2 = Querydb2.ToList();

                foreach (SelfStudy qs in data2)
                {
                    if (currentweek == qs.workWeek)
                    {
                        count += qs.hoursWorked;//Add up hours worked in the current week
                    }
                }

                //set values
                int  remSelfstudyhrs = selfstudyhrs - count;
                int hoursSpentThisWeek = count;



                //if the total hours studied for the week is greater than the required self study hours
                if (count>selfstudyhrs)
                {
                    extraHrs = hoursSpentThisWeek-selfstudyhrs;//calculate remaining hrs
                    remSelfstudyhrs = 0;//set remaining hours to zero
                }

                //Display values
                lblHrsRem.Content = remSelfstudyhrs;
                lblHrsSpent.Content = hoursSpentThisWeek;
                lblExtraHrs.Content = extraHrs;
            }
            catch (Exception)
            {
             
            }
        }//end method

        
    }//class
}//namespace
