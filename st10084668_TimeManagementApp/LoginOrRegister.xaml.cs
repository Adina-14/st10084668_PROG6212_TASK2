using DLLCalcs;
using st10084668_TimeManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace st10084668_TimeManagementApp
{
    /// <summary>
    /// Interaction logic for LoginOrRegister.xaml
    /// </summary>
    public partial class LoginOrRegister : Window
    {
        //global instant
        User user = new User();
        UserContext userContext = new UserContext();
    
        public LoginOrRegister()
        {
            InitializeComponent();
        }

        //clears textboxes
        public void clearregTb()
        {
            tbRUser.Clear();
            tbRPass.Clear();
        }

        //Password validation
        public bool validatePassword(string password)
        {
            //if the password matches criteria
            if (Regex.IsMatch(password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,10}$"))
            {
                return true;
            }
            else//if password doesnt match criteria
            {

                return false;
            }
               
        }
        //Register button
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try//try/catch for exception handling
            {
                if ((tbRUser.Text.Trim() != "") && (tbRPass.Text.Trim() != "")) //if the textboxes are not empty
                {
                    //Check if username exists in db

                    var u = userContext.Users.Find(tbRUser.Text.Trim()); //finding the username the user has entered in the database


                    if (u != null)//if the username is found
                    {
                        MessageBox.Show("Sorry this username is already in use.\nPlease login or enter another username", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else//if the username does not exist in the db
                    {
                        //validate password
                        bool passValid = validatePassword(tbRPass.Text.Trim());

                        switch (passValid)
                        {
                            case true: //if password is valid
                                       //get values from textboxes
                                user.username = tbRUser.Text.Trim();//trim cuts out any extra spaces
                                string hashedPassword = Hash.HashPassword(tbRPass.Text.Trim());//hashing the register password
                                user.password = hashedPassword;

                                //use usercontext to push the data
                                userContext.Users.Add(user); //insert username and hashed password into db
                                int a = userContext.SaveChanges();
                                if (a > 0)
                                {
                                    MessageBox.Show("Congrats you have succesfully registered!\n" +
                                        "You may now login", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                    tbLuser.Text = tbRUser.Text.Trim();
                                    clearregTb();//clear textboxes

                                }//end if
                                else
                                {
                                    MessageBox.Show("Whoops! something went wrong.", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                }//end else
                                break;//break
                            case false: //if the password is not valid display error message
                                MessageBox.Show("Password not valid!\n" +
                                    "Please ensure that your password contains:\n" +
                                    "-8-10 characters \n" +
                                    "-One upper case character\n" +
                                    "-One lower case character\n" +
                                    "-One special character\n" +
                                    "-One digit", "Criteria not met", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                        }//end switch
                    }//end if the username doesnt exist
                }//end if all the fields are filled in
               
                else //if fields are left blank
                {
                    MessageBox.Show("Please ensure that all fields are filled in. ", "Entries incomplete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception )
            {
               
            }//end exception handling

        }

        //Login button
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try//try/catch for exception handling
            {
                if ((tbLuser.Text.Trim() != "") && (tbLPass.Text.Trim() != "")) //if the textboxes are not empty
                {

                    //Check if username exists in db
                    
                        var u = userContext.Users.Find(tbLuser.Text.Trim()); //finding the username the user has entered in the database
                        if (u != null)//if the username is found
                        {
                            if (u.password != Hash.HashPassword(tbLPass.Text.Trim())) //if the password the user entered does not match the password in the db
                            {
                                MessageBox.Show("Invalid password", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);//display error message
                            }
                            else if (u.password == Hash.HashPassword(tbLPass.Text.Trim())) //if the entered password matches the password in the db
                            {
                                MessageBox.Show("Login Successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information); //display message

                                Login.username = tbLuser.Text.Trim();
                                //Move to next window if details are correct
                                Home h = new Home();
                                h.Show();//Shows next window
                                this.Hide();//Hides current window
                            }//end else if

                        }//end if
                        else
                        {
                        //Display message if the username was not found
                            MessageBox.Show("Username was not found", "Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);//if the username was not found displau error message
                        }//end else
                  

                }//end if 
                else //if fields are left blank
                {
                    MessageBox.Show("Please ensure that all fields are filled in. ", "Entries incomplete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception )
            {
                
            }//end catch
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Exiting application
            Application.Current.Shutdown();
        }
    }
}
