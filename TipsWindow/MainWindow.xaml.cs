using Npgsql;
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

namespace TipsWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool commandRead = false;
        private string business_id;
        private string user_id;
        private int tipCount = 0;
        private int friendsCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.AddColumns2BusinessGrid();
            this.AddColumns2FriendsTipGrid();
        }

        public MainWindow(string business_id, string user_id)
        {
            InitializeComponent();

            if (user_id == null || user_id == string.Empty)
            {
                this.likeButton.IsEnabled = false;
            }
            this.business_id = business_id;
            this.user_id = user_id;

            this.AddColumns2BusinessGrid();
            this.AddColumns2FriendsTipGrid();
            this.CreateQueryForBusinessGrid();
            this.TipWindow.Title = "Latest Tips";
        }

        private void CreateQueryForBusinessGrid()
        {
            this.businessGrid.Items.Clear();
            this.friendsTipGrid.Items.Clear();
            this.tipCount = 0;
            this.friendsCount = 0;
            string command = "select * from tip as T_, users as U where T_.business_id = '" + business_id + "' and U.user_id = t_.user_id order by date_ desc;";

            this.commandRead = false;
            this.ExecuteQuery(command, PopulateBusinessGrid);

            if (user_id != string.Empty)
            {
                string command1 = "select distinct friend_id from friend where user_id = '" + user_id + "';";
;

                this.commandRead = false;

                this.ExecuteQuery(command1, FriendTipGridHelper);
            }

            this.businessTipCount.Header = "Business Tips: " + this.tipCount.ToString();
            this.friendTipCount.Header = "Tips from friend who reviewd this business: " + this.friendsCount.ToString();
        }

        private void PopulateBusinessGrid(NpgsqlDataReader reader)
        {
            if (reader.HasRows)
            {
                businessGrid.Items.Add(new Tip()
                {
                    UserID = reader.GetString(1),
                    Date = reader.GetString(2),
                    Likes = reader.GetInt32(3),
                    Text = reader.GetString(4),
                    UserName = reader.GetString(6),
                    BusinessID = this.business_id,
                }); 
            }

            this.tipCount++;
        }

        private void FriendTipGridHelper(NpgsqlDataReader reader)
        {
            if (reader.HasRows)
            {
                string command = "select * from tip as T_, users as U where T_.business_id = '" + business_id.ToString() + "' and T_.user_id = '" + reader.GetString(0) +
                "' and U.user_id = '" + reader.GetString(0) + "';";
                this.commandRead = false;

                this.ExecuteQuery(command, PopulateFriendTipsGrid);
            }
        }

        private void PopulateFriendTipsGrid(NpgsqlDataReader reader)
        {
            if (reader.HasRows)
            {
                this.friendsTipGrid.Items.Add(new Tip()
                {
                    Date = reader.GetString(2),
                    Text = reader.GetString(4),
                    UserName = reader.GetString(6),
                });

                this.friendsCount++;
            }

            
        }


        private void AddColumns2BusinessGrid()
        {
            DataGridTextColumn col1 = new DataGridTextColumn
            {
                Binding = new Binding("Date"),
                Header = "Date",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            businessGrid.Columns.Add(col1);

            DataGridTextColumn col2 = new DataGridTextColumn
            {
                Binding = new Binding("UserName"),
                Header = "User Name",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            businessGrid.Columns.Add(col2);

            DataGridTextColumn col3 = new DataGridTextColumn
            {
                Binding = new Binding("Likes"),
                Header = "Likes",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            businessGrid.Columns.Add(col3);

            DataGridTextColumn col4 = new DataGridTextColumn
            {
                Binding = new Binding("Text"),
                Header = "Text",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),

            };
            businessGrid.Columns.Add(col4);
        }

        private void AddColumns2FriendsTipGrid()
        {
            DataGridTextColumn col1 = new DataGridTextColumn
            {
                Binding = new Binding("UserName"),
                Header = "User Name",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            friendsTipGrid.Columns.Add(col1);

            DataGridTextColumn col2 = new DataGridTextColumn
            {
                Binding = new Binding("Date"),
                Header = "Date",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            friendsTipGrid.Columns.Add(col2);

            DataGridTextColumn col3 = new DataGridTextColumn
            {
                Binding = new Binding("Text"),
                Header = "Text",
                Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto),
            };
            friendsTipGrid.Columns.Add(col3);
        }

        private void addTipButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (this.tipTextBox.Text != null || this.tipTextBox.Text != string.Empty)
            {
                string command = "INSERT INTO tip VALUES('"
                                   + this.business_id + "', '"
                                   + this.user_id + "', '"
                                   + DateTime.Now.ToString() + "', "
                                   + 0 + ", '" + tipTextBox.Text + "');";
                this.commandRead = false;

                ExecuteQuery(command, this.PopulateBusinessGrid);
                this.CreateQueryForBusinessGrid();

            } 
            else
            {
                
            }
        }

        private void LikeButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (this.businessGrid.SelectedItem != null)
            {
                Tip current = businessGrid.SelectedItem as Tip;

                string command = "update tip set likes_ = likes_ + 1 where business_id = '" + current.BusinessID.ToString() + "' and" +
                    " user_id = '" + current.UserID + "' and date_ = '" + current.Date.ToString() + "';";
                this.commandRead = false;

                this.ExecuteQuery(command, this.PopulateBusinessGrid);
                this.CreateQueryForBusinessGrid();
            } 
            else
            {

            }
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = myyelpdb; password = Alb3rt184011!!!";
        }

        private void ExecuteQuery(string sqlstr, Action<NpgsqlDataReader> myf)
        {
            using (var connection = new NpgsqlConnection(BuildConnectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlstr;
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            myf(reader);
                            commandRead = true;
                        }

                        if (commandRead == false)
                        {
                            myf(reader);
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                        System.Windows.MessageBox.Show("SQL Error - " + ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        
    }
}
