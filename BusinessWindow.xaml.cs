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
using System.Windows.Shapes;
using Npgsql;

namespace CPTS451_Milestone1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BusinessWindow : Window
    {
        readonly string businessID = "";
        public BusinessWindow(string inputID)
        {
            InitializeComponent();
            this.businessID = String.Copy(inputID);
            LoadBusinessDetails();
            LoadBusinessNumbers();
        }

        private string BuildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone1db; password = postgresSQL";
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
                        reader.Read();
                        myf(reader);
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

        private void SetBusinessDetails(NpgsqlDataReader reader)
        {
            nameTextBox.Text = reader.GetString(0);
            stateTextBox.Text = reader.GetString(1);
            cityTextBox.Text = reader.GetString(2);
        }

        private void LoadBusinessDetails()
        {
            string sqlStr = "SELECT name, state, city FROM business WHERE business_id = '" + this.businessID + "';";
            ExecuteQuery(sqlStr, SetBusinessDetails);
        }

        private void SetNumInState(NpgsqlDataReader reader)
        {
            stateNumberLabel.Content = reader.GetInt16(0).ToString();
        }

        private void SetNumInCity(NpgsqlDataReader reader)
        {
            cityNumberLabel.Content = reader.GetInt16(0).ToString();
        }

        private void LoadBusinessNumbers()
        {
            string sqlStr1 = "SELECT count(*) from business WHERE state = (SELECT state FROM business WHERE business_id = '" + this.businessID + "');";
            ExecuteQuery(sqlStr1, SetNumInState);
            string sqlStr2 = "SELECT count(*) from business WHERE city = (SELECT city FROM business WHERE business_id = '" + this.businessID + "');";
            ExecuteQuery(sqlStr2, SetNumInCity);
        }
    }
}
