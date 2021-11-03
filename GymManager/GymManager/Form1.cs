using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MySql.Data.MySqlClient;

namespace GymManager
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=gymmanager;Uid=bang;Pwd=1234");

        public Form1()
        {
            InitializeComponent();
            Text = "헬스 회원 관리 프로그램";
        }
        string mst;
        string box;
        string ptst;

        // 회원 코드로 검색
        private void ShowDB_Mcode()
        {
            connection.Open();
            if (textBox2.Text == "") { MessageBox.Show("회원 번호를 입력해 주세요."); }
            else
            {
                string selectQuery = "select mcode '회원 번호', mname '이름', age '나이', sex '성별', cellphone '휴대폰', phone '집 전화', mstatus '결제 여부', startperiod '시작 기간',  endperiod '종료 기간', boxinfo '보관함 사용 여부', ptst 'PT 신청' from gymmember where mcode = '" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            connection.Close();
        }
        // 정보 전체 검색
        private void ShowDB()
        {
            connection.Open();
            string selectQuery = "select mcode '회원 번호', mname '이름', age '나이', sex '성별', cellphone '휴대폰', phone '집 전화', mstatus '결제 여부', startperiod '시작 기간',  endperiod '종료 기간', boxinfo '보관함 사용 여부', ptst 'PT 신청' from gymmember";            
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            connection.Close();
        }
        // 정보 등록
        private void button1_Click_1(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO gymmember(mname, age, sex, phone , cellphone, mstatus, startperiod, endperiod, boxinfo, ptst) VALUES('" + textBox1.Text + "'," + numericUpDown1.Value + ", '" + textBox3.Text + "','" + textBox6.Text + "', '" + textBox5.Text + "', '" + mst + "', '" + dateTimePicker1.Value + "', '"+ dateTimePicker2.Value + "' ,'" + box + "' ,'" + ptst + "')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            //이름 빈칸 조건
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // 회원 정보 수정, 삭제 폼
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) // 회원 pt 폼
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // 결제 여부 라디오 버튼 o
        {
            mst = "O";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // 결제 여부 라디오 버튼 x
        {
            mst = "X";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // 보관함 O
        {
            box = "O";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // 보관함 X
        {
            box = "X";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) // PT O
        {
            ptst = "O";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) // PT X
        {
            ptst = "X";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // 회원 코드로 검색 버튼
        {
            ShowDB_Mcode();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //전체 검색 버튼
        {
            ShowDB();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
