using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;

namespace GymManager
{
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=gymmanager;Uid=bang;Pwd=1234");

        public Form5()
        {
            InitializeComponent();
            Text = "PT 그래프";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
        private void Chart()
        {
            connection.Open();
            if (textBox8.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else
            {
                try
                {
                    string selectQuery = "select mcode '회원 번호', mname '이름', bw 'PT 전 체중(kg)', bm 'PT 전 근육량(kg)', bf 'PT 전 체지방(kg)', aw 'PT 후 체중(kg)', am 'PT 후 근육량(kg)', af 'PT 후 체지방(kg)' from gympt where mcode = '" + textBox8.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        chart1.Series["체중"].Points.AddXY("PT 전", sdr.GetInt32("PT 전 체중(kg)"));
                        chart1.Series["체중"].Points.AddXY("PT 후", sdr.GetInt32("PT 후 체중(kg)"));
                        chart1.Series["근육량"].Points.AddXY("PT 전", sdr.GetInt32("PT 전 근육량(kg)"));
                        chart1.Series["근육량"].Points.AddXY("PT 후", sdr.GetInt32("PT 후 근육량(kg)"));
                        chart1.Series["체지방"].Points.AddXY("PT 전", sdr.GetInt32("PT 전 체지방(kg)"));
                        chart1.Series["체지방"].Points.AddXY("PT 후", sdr.GetInt32("PT 후 체지방(kg)"));
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }
        private void ShowDBgympt()
        {
            connection.Open();
            if (textBox8.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else
            {
                try
                {
                    string selectQuery = "select mcode '회원 번호', mname '이름', bw 'PT 전 체중(kg)', bm 'PT 전 근육량(kg)', bf 'PT 전 체지방(kg)', aw 'PT 후 체중(kg)', am 'PT 후 근육량(kg)', af 'PT 후 체지방(kg)' from gympt where mcode = '" + textBox8.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowDBgympt();
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["체중"].Points.Clear();
            chart1.Series["근육량"].Points.Clear();
            chart1.Series["체지방"].Points.Clear();
            Chart();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}