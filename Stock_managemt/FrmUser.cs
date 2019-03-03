using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stock_managemt
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        oCenter oC_Cn = new oCenter();
        string sData1, sData2;
        //private object lsvShowData;
        //private object lsvShowdata;

        private void Wprv_Lock(bool _bCheck)
        {
            cmdAdd.Enabled = _bCheck;
            cmdEdit.Enabled = !_bCheck;
            cmdDelete.Enabled = !_bCheck;
        }
        private void Wprv_Clear()
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            Wprv_Lock(true);
        }
        // save ຂໍ້ມູນເຂົ້າ sAction ແມ່ນ ການກະທຳເຊັ່ນ: ເອົາຄ່າເຂົ້າ,ລືບ,ລ້າງ,ແກ້ໄຂ
        private void Wprv_SaveData(string _sAction)
        {
            string sSql = "";
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("ກາລຸນາພີມຊື່ໃສ່ Username", "ກວດສອບ", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtUsername.Focus();
                return;
            }
            if (txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("ກາລຸນາພີມຊື່ໃສ່ password", "ກວດສອບ", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtpassword.Focus();
                return;
            }
            if (_sAction.ToUpper() == "ADD")
            {
                sSql = "insert into B_User(Log_User,Log_pass) Values('" + txtUsername.Text.Trim() + "'," +
                "'" + txtpassword.Text.Trim() + "' )";
            }
            else if (_sAction.ToUpper() == "EDIT")
            {
                if (MessageBox.Show("ທ່ານຕ້ອງການແກ້ໄຂຂໍ້ມູນນີ້ບໍ", "ກວດສອບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                sSql = "Update B_User Set Log_pass ='" + txtpassword.Text.Trim() + "'Where Log_User='" + txtUsername.Text.Trim() + "'";

            }
            else if (_sAction.ToUpper() == "DELETE")
            {
                if (MessageBox.Show("ທ່ານຕ້ອງການລືບຂໍ້ມູນນີ້ບໍ", "ກວດສອບ", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                sSql = "Delete from B_User Where Log_User='" + txtUsername.Text.Trim() + "'";
            }
            if (oC_Cn.Cpub_ActionData(sSql))
            {

                MessageBox.Show("ຮຽບຮ້ອຍແລ້ວ", "ກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Wprv_ShowData();
            }

        }
        // show ຂໍ້ມູນໃນຫົວຂອງ listView 
        private void Wprv_ShowGrid()
        {
            try
            {
                lsvShowData.GridLines = true;
                lsvShowData.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                lsvShowData.Columns.Add("Username", 160, HorizontalAlignment.Center);
                lsvShowData.Columns.Add("Password", 160, HorizontalAlignment.Center);

            }
            catch
            {
            }
        }
        private void Wprv_AddData(string _sData1, string _sData2)
        {
            try
            {
                ListViewItem oItem = new ListViewItem();
                ListViewItem.ListViewSubItem oItemSub;
                oItem.Text = _sData1;
                oItemSub = new ListViewItem.ListViewSubItem();
                oItemSub.Text = _sData2;
                oItem.SubItems.Add(oItemSub);

                lsvShowData.Items.Add(oItem);

            }
            catch
            {
            }

        }
        // method show data
        private void Wprv_ShowData()
        {
            DataSet ds = new DataSet();
            lsvShowData.Clear();

            string sSql = "Select * From B_User";
            ds = oC_Cn.Cpuds_loadData(sSql, "B_User", ds);
            if (ds.Tables["B_User"].Rows.Count != 0)
            {
                for( int nR = 0; nR <= ds.Tables["B_User"].Rows.Count - 1; nR++){
                    sData1 = "";
                    sData2 = "";
                    sData1 = ds.Tables["B_User"].Rows[nR]["Log_User"].ToString();
                    sData2 = ds.Tables["B_User"].Rows[nR]["Log_Pass"].ToString();
                    Wprv_AddData(sData1, sData2);

                }
                Wprv_ShowGrid();
                Wprv_Clear();
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Wprv_SaveData ("ADD");
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            Wprv_SaveData("EDIT");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            Wprv_SaveData("DELETE");
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            Wprv_Clear();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvShowData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lsvShowData.SelectedItems.Count !=0)
            {
                txtUsername.Text = lsvShowData.SelectedItems[0].SubItems[0].Text;
                txtpassword.Text = lsvShowData.SelectedItems[0].SubItems[1].Text;
                Wprv_Lock(false);
            }
        }

        private void FrmUser_Load_1(object sender, EventArgs e)
        {
            Wprv_ShowData();
        }

        //private void FrmUser_Load(object sender, EventArgs e)
        //{

        //}
    }

}

