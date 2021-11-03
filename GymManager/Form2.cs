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

namespace GymManager
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=gymmanager;Uid=bang;Pwd=1234");

        public Form2()
        {
            InitializeComponent();
            Text = "정보 수정, 삭제";
        }
        string mst;
        string box;
        string ptst;

        private void ShowDB_Mcode()
        {
            connection.Open();
            if (textBox2.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else {
                string selectQuery = "select mcode '회원 번호', mname '이름', age '나이', sex '성별', cellphone '휴대폰', phone '집 전화', mstatus '결제 여부', startperiod '시작 기간',  endperiod '종료 기간', boxinfo '보관함 사용 여부', ptst 'PT 신청' from gymmember where mcode = '" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e) // 회원 정보 삭제
        {
            string deleteQuery = "delete from gymmember where mcode = '"+ textBox2.Text +"'";
            connection.Open();
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);
            if (textBox2.Text == "")
            {
                MessageBox.Show("회원 번호를 입력해 주세요.");
            }
            else
            {
                try
                {
                    // 메세지 출력
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("삭제 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("삭제 되지 않았습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e) // 회원 정보 조건 검색
        {
            ShowDB_Mcode();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // 회원 정보 수정
        {
            string updateQuery = "update gymmember set mname = '" + textBox1.Text + "',age = " + numericUpDown1.Value + ", sex = '" + textBox3.Text + "',phone = '" + textBox6.Text + "', cellphone = '" + textBox5.Text + "', mstatus = '" + mst + "', startperiod = '" + dateTimePicker1.Value + "', endperiod = '" + dateTimePicker2.Value + "', boxinfo = '" + box + "', ptst = '" + ptst + "'where mcode = '" + textBox2.Text +"'" ;
            connection.Open();
            MySqlCommand command = new MySqlCommand(updateQuery, connection);
            if (textBox1.Text == "")
            {
                MessageBox.Show("이름은 빈 칸일 수 없습니다.");
            }
            else
            {
                try
                {
                    // 메세지 출력
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("수정 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("수정 되지 않았습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            connection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mst = "O";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mst = "X";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            box = "O";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            box = "X";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ptst = "O";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ptst = "X";
        }
    }
}
