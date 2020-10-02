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
using Npgsql;

namespace CheckinCountChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string businessID;
        public MainWindow(string id)
        {
            this.businessID = id;
            InitializeComponent();
            ColumnChart();
        }

        private void ColumnChart()
        {
            List<KeyValuePair<string, int>> myChartData = new List<KeyValuePair<string, int>>();

            myChartData.Add(new KeyValuePair<string, int>("January", 0));
            myChartData.Add(new KeyValuePair<string, int>("February", 0));
            myChartData.Add(new KeyValuePair<string, int>("March", 0));
            myChartData.Add(new KeyValuePair<string, int>("April", 0));
            myChartData.Add(new KeyValuePair<string, int>("May", 0));
            myChartData.Add(new KeyValuePair<string, int>("June", 0));
            myChartData.Add(new KeyValuePair<string, int>("July", 0));
            myChartData.Add(new KeyValuePair<string, int>("August", 0));
            myChartData.Add(new KeyValuePair<string, int>("September", 0));
            myChartData.Add(new KeyValuePair<string, int>("October", 0));
            myChartData.Add(new KeyValuePair<string, int>("November", 0));
            myChartData.Add(new KeyValuePair<string, int>("December", 0));

            using (var conn = new NpgsqlConnection("Host = localhost; Username = postgres; Database = YelpDB; password = Alb3rt184011!!!"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "Select month_, count(business_id) from checkin where business_id = '"+businessID+"' group by month_ order by month_";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int monthNum = int.Parse(reader.GetString(0));
                            string month = "";
                            if (monthNum == 1)
                            {
                                month = "January";
                            }
                            else if (monthNum == 2)
                            {
                                month = "February";
                            }
                            else if (monthNum == 3)
                            {
                                month = "March";
                            }
                            else if (monthNum == 4)
                            {
                                month = "April";
                            }
                            else if (monthNum == 5)
                            {
                                month = "May";
                            }
                            else if (monthNum == 6)
                            {
                                month = "June";
                            }
                            else if (monthNum == 7)
                            {
                                month = "July";
                            }
                            else if (monthNum == 8)
                            {
                                month = "August";
                            }
                            else if (monthNum == 9)
                            {
                                month = "September";
                            }
                            else if (monthNum == 10)
                            {
                                month = "October";
                            }
                            else if (monthNum == 11)
                            {
                                month = "November";
                            }
                            else if (monthNum == 12)
                            {
                                month = "December";
                            }
                            if(month != "")
                            {
                                myChartData.RemoveAt(monthNum - 1);
                                myChartData.Insert(monthNum - 1, new KeyValuePair<string, int>(month, reader.GetInt32(1)));                    
                            }
                            
                        }
                    }
                }
            }
            myChart.DataContext = myChartData;
        }
    }
}