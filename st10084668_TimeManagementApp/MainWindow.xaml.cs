using st10084668_TimeManagementApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace st10084668_TimeManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private BackgroundWorker bgWorker = new BackgroundWorker();

        //Declare variables
        private int workersState;

        public int loadVal = 0;

        //get and set
        public int WorkerState
        {
            get { return workersState; }
            set
            {
                workersState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WorkerState)));
            }
        }

        //Create tables when program starts
        public void createOnStartUp()
        {
            //instant
            User u = new User();
            UserContext ucon = new UserContext();

            ModuleContext mcon = new ModuleContext();
            Module m = new Module();

            SelfStudyContext scon = new SelfStudyContext();
            SelfStudy ss = new SelfStudy();

            //add to db
            ucon.Users.Add(u);
            mcon.Modules.Add(m);
            scon.SelfStudies.Add(ss);
        }
        public MainWindow()
        {
            InitializeComponent();
            createOnStartUp();//creates the tables on start up
            DataContext = this;

            //Exception handling
            try
            {
                // Increases the value of the progress bar
                bgWorker.DoWork += (s, e) =>
                {
                    for (int i = 0; i < 101; i++)
                    {
                        System.Threading.Thread.Sleep(40);//controls the speed of progress bar
                        WorkerState = i;

                    }

                };

                bgWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Exiting application
            Application.Current.Shutdown();
        }



        private void Pb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Moves to home page once the progress bar has reach max value of 100
            if (Pb.Value >= Pb.Maximum)
            {
                System.Threading.Thread.Sleep(500);//controls speed of the program



                LoginOrRegister lr = new LoginOrRegister();
                lr.Show(); //shows the login/register window
                this.Hide();//Hides current window
            }
        }
    }
}