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
namespace formysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection mc;
        MySqlDataAdapter mda;
        DataSet ds;

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from student";
            mda = new MySqlDataAdapter(sql, mc);
            ds = new DataSet();
            mda.Fill(ds, "student");
            dataGridView1.DataSource = ds.Tables["student"];
            mc.Close();
        }
        private void button1_Click(object sender, EventArgs e)
            {
                string M_str_sqlcon = "server=localhost;user id=root;password=123456;database=today_schema;";                                                                                           
                mc = new MySqlConnection(M_str_sqlcon);
                try
                {
                    mc.Open();
                    MessageBox.Show("���ݿ����ӳɹ���");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mda == null || ds == null)
            {
                MessageBox.Show("��������");
                return;
            }
            try
            {
                string msg = "���Ƿ�ȷ�������������";
                if (1 == (int)MessageBox.Show(msg, "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(mda);
                    mda.Update(ds, "student");
                    MessageBox.Show("��ӳɹ�", "��ʾ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "������Ϣ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mda == null || ds == null)
            {
                MessageBox.Show("���ȵ�������");
                return;
            }
            try
            {
                string msg = "��ȷ��Ҫ�޸���";
                if (1 == (int)MessageBox.Show(msg, "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(mda);
                    mda.Update(ds, "student");
                    MessageBox.Show("�޸ĳɹ�", "��ʾ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "������Ϣ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int s_id = (int)dataGridView1.Rows[index].Cells[0].Value;
            string sql = "delete from student where s_id=" + s_id + "";
            mc.Open();
            MySqlCommand cmd = mc.CreateCommand();
            cmd.CommandText = sql;
            int i = cmd.ExecuteNonQuery();
            if (i < 0)
            {
                mc.Close();
                MessageBox.Show("ɾ��ʧ��");
                return;
            }
            mc.Close();
        }

    }
}
