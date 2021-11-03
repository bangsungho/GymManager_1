using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core.Records.General;

namespace GymManager
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=gymmanager;Uid=bang;Pwd=1234");

        public Form3()
        {
            InitializeComponent();
            Text = "회원 PT 관리";
        }

        private void ShowDB_ptst() //PT 신청한 회원 검색
        {
            connection.Open();
            string selectQuery = "select mcode '회원 번호', mname '이름', ptst 'PT 신청' from gymmember where ptst = 'O'";
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        private void ShowDBgympt() 
        {
            connection.Open();
            if (textBox8.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else
            {
                string selectQuery = "select mcode '회원 번호', mname '이름', bw 'PT 전 체중(kg)', bm 'PT 전 근육량(kg)', bf 'PT 전 체지방(kg)', aw 'PT 후 체중(kg)', am 'PT 후 근육량(kg)', af 'PT 후 체지방(kg)' from gympt where mcode = '" + textBox8.Text + "'";
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            connection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ShowDBgympt();
        }

        private void button2_Click(object sender, EventArgs e) // PT 전 체중, 근육량, 체지방량 삽입
        {
            string insertQuery = "INSERT INTO gympt(mname, bw, bm, bf) VALUES('"+textBox9.Text+"', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            if (textBox9.Text == "") { MessageBox.Show("이름은 빈 칸일 수 없습니다."); }
            else if (textBox1.Text == "") { MessageBox.Show("PT 전 체중을 입력해 주세요."); }
            else if (textBox2.Text == "") { MessageBox.Show("PT 전 근육량을 입력해 주세요."); }
            else if (textBox3.Text == "") { MessageBox.Show("PT 전 체지방을 입력해 주세요."); }
            else
            {
                try
                {
                    // 메세지 출력
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("등록 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("등록 되지 않았습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            connection.Close();
        }
        private void button4_Click(object sender, EventArgs e) // PT 전 체중, 근육량, 체지방량 입력(update)
        {
            string updateQuery = "update gympt set mname = '" + textBox9.Text + "', aw = '" + textBox4.Text + "',  am = '" + textBox5.Text + "', af = '" + textBox6.Text + "'where mcode = '"+textBox8.Text+"'";
            connection.Open();
            MySqlCommand command = new MySqlCommand(updateQuery, connection);
            if (textBox8.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else if (textBox9.Text == "") { MessageBox.Show("이름은 빈 칸일 수 없습니다."); }
            else if (textBox4.Text == "") { MessageBox.Show("PT 후 체중을 입력해 주세요."); }
            else if (textBox5.Text == "") { MessageBox.Show("PT 후 근육량을 입력해 주세요."); }
            else if (textBox6.Text == "") { MessageBox.Show("PT 후 체지방을 입력해 주세요."); }
            else
            {
                try
                {
                    // 메세지 출력
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("등록 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("등록 되지 않았습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e) // 그래프
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) // PT 받는 회원 검색
        {
            ShowDB_ptst();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
