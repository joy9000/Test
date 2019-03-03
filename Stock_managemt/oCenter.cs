using System;
using System.Collections.Generic;
//using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Stock_managemt
{
    class oCenter
    {
        //ໃຊ້ຕິດຕໍ່ ຖານຂໍ້ມູນ 

        //public OleDbDataAdapter psqlDaAc = new OleDbDataAdapter();
        //OleDbDataAdapter oleDaAc = new OleDbDataAdapter();
        //OleDbCommand sqlCMA = new OleDbCommand();
        //public static OleDbConnection psoleCon = new OleDbConnection();
        public sqlDataAdapter da = new sqlDataAdapter();
        SqlCommand cm = new SqlCommand();
        SqlConnection cnn = new SqlConnection();

        // ເພດເຈນໜ້າ 

        int nCurrentPage = 1;
        public string psMessRowlable = "";
        public static string pssNavclicked = "";
        public string psPageCheck = "";
        string sRecordID1 = "";
        string sRecordID2 = "";

        //ຜູ້ໃຊ້
        public static string pssUsername = "";
        bool bCheckConnect = false;
        
        //properties .Add, .Update
        public sqlDataAdapter pGSsqlDaAcDB
        {
            get
            {
                return da;
            }
            set
            {
                da = value;
            }
        }
        //Method connect Database
        public void Cpuv_conDataBase()
        {

            string sConn ="";
            try
            {
                bCheckConnect = false;
                sConn = "Data Source=(local);Initial Catalog=DB_Stock;User ID=khomsoft";

                SqlConnection connection  = cnn;
                 if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.ConnectionString = sConn;
                connection.Open();


                bCheckConnect = true;
            }
            catch (Exception ex)
            {
                bCheckConnect = false;
                MessageBox.Show("ບໍ່ສາມາດຕິດຕໍ່ ຖານຂໍ້ມູນໄດ້ : " + ex.Message.ToString(), "ກວດສອບ" 
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //Method ShowData
        public DataSet Cpuds_loadData(string _sSql, string _sNameTable, DataSet _ds)
        {
            DataSet ds;
            try
            {
                _ds.Clear();
                if (bCheckConnect == false)
                {
                    Cpuv_conDataBase();

                }
                sqlDataAdapter da = new sqlDataAdapter();
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();

                cm  = new SqlCommand(_sSql,cnn);
                
                ds = _ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ບໍ່ສາມາດສະແດງຂໍ້ມູນໄດ້ ", "ກວດສອບ"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds = _ds;
            }
            return ds;
        }
        //metod add,edit,delete-->Sql
        public bool Cpub_ActionData(string _sSql)
        {
            bool bCheck = false;
            try
            {
                if (bCheckConnect == false)
                {
                    Cpuv_conDataBase();
                }
                SqlCommand connection = cm;
                connection.CommandType = CommandType.Text;
                connection.CommandText = _sSql;
                connection.Connection = cnn;
                connection.ExecuteNonQuery();
                bCheck = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ບໍສາມາດຈັດການຂໍ້ມູນໄດ້ : " + ex.Message.ToString(), "ກວດສອບ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bCheck = false;

            }
            return bCheck;
        }
        //Method Auotorun
        //_sFname = column name
        //_sTname = tablename
        //_sHname = Headname Ex: DN6011(yyMM)
        //_sLname = 0000---->0001
        public string Cpus_AutoID(string _sFname, string _sTname, string _sHname, string _sLname)
        {
            int nId = 0;
            string sId = "";
            string sStr = "";
            sStr = "Select " + _sFname + "Form " + _sTname + " where" + _sFname + "Like '%" + _sHname + "% '"
            + "Oder by " + _sFname + " desc ;";
            DataSet dsAutorun = new DataSet();
            dsAutorun = Cpuds_loadData(sStr, _sTname, dsAutorun);
            if (dsAutorun.Tables[_sTname].Rows.Count > 0)
            {
                sId = dsAutorun.Tables[_sTname].Rows[0][_sFname].ToString();
                sId = sId.Replace(_sHname, "");
                nId = Convert.ToInt32(sId) + 1;
                return _sHname + nId.ToString(_sLname) + 1;//INV6001-0001
            }
            else
            {
                nId = Convert.ToInt32(_sLname) + 1;
                return _sHname + nId.ToString(_sLname);
            }
        }
        //methoa close All Childen Form
        public Boolean Cpub_CloseChildenForm(Form _FrmCtrls, String _sFrmName)
        {
            foreach (Form Frm in _FrmCtrls.MdiChildren)
            {
                if (Frm.Name == _sFrmName)
                {
                    Frm.Focus();
                    return true;
                }
            }
            return false;
        }
        // Method check input Number Datagridview
        public void Cpu_InputInttoGrid(DataGridView _dgvData, int _ncell, string _sCheck)
        {
            int nLanofStr = _dgvData.Rows.Count - 1;
            for (int nLoop = 0; nLoop <= nLanofStr; nLoop++)
            {
                try
                {


                    string sError = "";
                    if (((_dgvData.Rows[nLoop].Cells[_ncell].Value != null) && (
                        _dgvData.Rows[nLoop].Cells[_ncell].Value.ToString() != "")) && _sCheck == "1")
                    {
                        sError = Convert.ToDouble(_dgvData.Rows[nLoop].Cells[_ncell].Value.ToString()).ToString("####0,00");
                        _dgvData.Rows[nLoop].Cells[_ncell].Value = Convert.ToDouble(
                            _dgvData.Rows[nLoop].Cells[_ncell].Value.ToString()).ToString("#,###0.00");
                    }

                }
                catch
                {
                    if (_sCheck == "1")
                    {
                        _dgvData.Rows[nLoop].Cells[_ncell].Value = "";
                        MessageBox.Show("ກາລຸນາພີມຂໍ້ມູນເປັນຕົວເລກ", "ກວດສອບ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }

        }
        //convert number to string Money
        public string Cpus_ChangNumToString(object _oNumber)
        {
            int nLoop;
            int nLanStr;
            //string sStr = "";
            string[] asCheck = new string[0x11];
            string[] asNumm = new string[] { "", "ໜື່ງ", "ສອງ", "ສາມ", "ສີ່", "ຫ້າ", "ຫົກ", "ເຈັດ", "ແປດ", "ເກົ້າ" };
            asCheck[1] = "";
            asCheck[2] = "";
            asCheck[3] = "";
            asCheck[4] = "";
            asCheck[5] = "ສີບ";
            asCheck[6] = "ຮ້ອຍ";
            asCheck[7] = "ພັນ";
            asCheck[8] = "ສີບພັນ";
            asCheck[9] = "ແສນ";
            asCheck[10] = "ລ້ານ";

            asCheck[11] = "ສີບ";
            asCheck[12] = "ຮ້ອຍ";
            asCheck[13] = "ພັນ";
            asCheck[14] = "ສີບພັນ";
            asCheck[15] = "ແສນ";
            asCheck[0 * 10] = "ລ້ານ";

            double dV;
            bool bCheckNumber = false;
            if (Double.TryParse(_oNumber.ToString().Trim(), out dV))
            {
                bCheckNumber = true;

            }
            if (!bCheckNumber)
            {
                return "ບໍ່ສາມາດພີມຂໍ້ມູນ ຫຼືເປັນຂໍ້ມູນທີ່ບໍ່ແມ່ນຕົວເລກ";
            }
            string sStr = Convert.ToString(_oNumber);
            int nLen = sStr.Length;
            if (nLen > 0x10)
            {
                return "ບໍ່ສາມາດຫາຄ່າທີ່ຫຼາຍກ່ວາລ້ານໄດ້";
            }
            if (nLen == 0)
            {
                return "";
            }
            string[] sLStr = new string[(nLen + 1) + 1];
            sLStr[5] = Convert.ToString(0);
            int nLanOfStr = nLen;
            for (nLoop = 1; nLoop <= nLanOfStr; nLoop++)
            {
                sLStr[(nLen + 1) - nLoop] = sStr.Substring(nLoop - 1, 1);
            }
            sStr = "";
            nLoop = nLen;
            Label_Loop:
            nLanStr = 4;
            if (nLoop >= nLanStr)
            {
                if (((nLoop == 5) || (nLoop == 11)) && (Convert.ToDouble(sLStr[nLoop]) == 2.0))
                {
                    asNumm[2] = "ຊາວ";

                }
                else if (((nLoop == 5) || (nLoop == 11)) && (Convert.ToDouble(sLStr[nLoop]) == 1.0))
                {
                    asNumm[1] = "";
                }
                else if ((((nLoop == 4) && (Convert.ToDouble(sLStr[nLoop]) == 1.0)) && (nLen > 4)) && !(Convert.ToDouble(sLStr[5]) == 0.00))
                {
                    asNumm[1] = "ເອັດ";
                }
                if ((nLen > 10) && ((((nLoop == 10) && (Convert.ToDouble(sLStr[nLoop]) == 1.0)) && (nLen > 10)) && !(Convert.ToDouble(sLStr[11]) == 0.00)))
                {
                    asNumm[1] = "ເອັດ";
                }
                if (!(Convert.ToDouble(sLStr[nLoop]) == 0.00) || (nLoop == 10))
                {
                    sStr = sStr + asNumm[Convert.ToInt32(sLStr[nLoop])] + asCheck[nLoop];
                }
                asNumm[2] = "ສອງ";
                asNumm[1] = "ນື່ງ";
                nLoop += -1;
                goto Label_Loop;

            }
            if (!((nLen == 4) && (Convert.ToDouble(sLStr[4]) == 0.00)))
            {
                sStr = sStr + "ກີບ";
            }
            if (Convert.ToDouble(sLStr[2]) == 2.0)
            {
                asNumm[2] = "ຢີ່";
            }
            if (Convert.ToDouble(sLStr[2]) != 0.00)
            {
                if (!(Convert.ToDouble(sLStr[2]) == 1.0))
                {
                    sStr = sStr + asNumm[Convert.ToInt32(sLStr[2])];

                }
                sStr = sStr + "ຊາວ";
            }
            asNumm[2] = "ສອງ";
            if ((Convert.ToDouble(sLStr[1]) == 1.0) && !(Convert.ToDouble(sLStr[2]) == 0.0))
            {
                asNumm[1] = "ເອັດ";
            }
            sStr = sStr + asNumm[Convert.ToInt32(sLStr[1])];
            if (!(Convert.ToDouble(sLStr[1]) == 0.0) || (Convert.ToDouble(sLStr[2]) == 0.0))
            {
                sStr = sStr + "ສະຕາງ";
            }
            return (sStr + "");
        }
        //Method ພສ ເປັນ ຄສ
        public DateTime Cput_ConvertDate(DateTime _tDate)
        {
            return _tDate.AddYears(-543); //2560-543-->06/12/2017
        }
        //Method paggin
        public enum eNavBtton
        {
            FirstBt = 1,
            LastBt = 4,
            NextBt = 2,
            NoneBt = 5,
            PreviousBt=3
        }
        private void Cprv_FindPagin(DataSet _dsPage, string _sTable, string _sFile, int _nRowGrid)
        {
            int nTotalRowCont = _dsPage.Tables[_sTable].Rows.Count;
            int nPageRows = _nRowGrid;
            int nPages = 0;
            int nPagesall = 0;
            if(((Convert.ToDouble(nTotalRowCont)/ Convert.ToDouble(nPageRows))>1.0) ||
                ((Convert.ToDouble(nTotalRowCont) / Convert.ToDouble(nPageRows)) > 1.0)){
                 if ((nTotalRowCont % nPageRows) == 0)
                {
                    nPagesall = (int)Math.Round((double)(((double)nTotalRowCont) / ((double)nPageRows)));
                }
                 else{
                    nPagesall = (int)Math.Round((double)(Math.Floor((double)(((double)nTotalRowCont) / 
                        ((double)nPageRows))) + 1.0));
                }
            }
            else {
                nPagesall = 1;
            }
            if (nPageRows < nTotalRowCont){
              if ((nTotalRowCont % nPageRows)> 0)
                {
                    nPages = (int)Math.Round((double)(((double)nTotalRowCont) / ((double)nPageRows))+1.0);
                }
                else{
                   nPages = (int)Math.Round((double)(((double)nTotalRowCont) / ((double)nPageRows)));
                } 
            }
            else{
                nPages = 1;
                pssNavclicked = "FitstBt";
            }
            int nLowerBoundary = 0;
            int nUperBoundary = 0;
            switch (pssNavclicked)
            {
                case "FirstBt":
                    nCurrentPage = 1;
                    nLowerBoundary = (nPageRows * nCurrentPage) - (nPageRows - 1);
                    if (nPageRows< nTotalRowCont) {
                        nUperBoundary = nPageRows * nCurrentPage;
                    }
                    else {
                        nUperBoundary = nTotalRowCont;
                    }
                    sRecordID1 = _dsPage.Tables[0].Rows[nLowerBoundary - 1][_sFile].ToString();
                    sRecordID2 = _dsPage.Tables[0].Rows[nUperBoundary - 1][_sFile].ToString();

                    break;
                case "LastBt":

                    nCurrentPage = nPages;
                    nLowerBoundary = (nPageRows * nCurrentPage) - (nPageRows - 1);
                    nUperBoundary = nTotalRowCont;
                    sRecordID1 =_dsPage.Tables[0].Rows[nLowerBoundary - 1][_sFile].ToString();
                    sRecordID2 = _dsPage.Tables[0].Rows[nUperBoundary - 1][_sFile].ToString();
                    break;
                case "NextBt":
                    if(nCurrentPage != nPages)
                    {
                        nCurrentPage++;
                    }
                    nLowerBoundary = (nPageRows * nCurrentPage) - (nPageRows - 1);
                    if(nCurrentPage == nPages)
                    {
                        nUperBoundary = nTotalRowCont;
                    }
                    else{
                        nUperBoundary = nPageRows * nCurrentPage;
                    }
                    sRecordID1 = _dsPage.Tables[0].Rows[nLowerBoundary - 1][_sFile].ToString();
                    sRecordID2 = _dsPage.Tables[0].Rows[nUperBoundary - 1][_sFile].ToString();

                    break;
                case "PreviousBt":
                    if(nCurrentPage != 1)
                    {
                        nCurrentPage--;
                    }
                    nLowerBoundary = (nPageRows * nCurrentPage) - (nPageRows - 1);
                    if (nPageRows < nTotalRowCont) {
                        nUperBoundary = nPageRows * nCurrentPage;
                    }
                    else {
                        nUperBoundary = nTotalRowCont;
                    }
                    sRecordID1 = _dsPage.Tables[0].Rows[nLowerBoundary - 1][_sFile].ToString();
                    sRecordID2 = _dsPage.Tables[0].Rows[nUperBoundary - 1][_sFile].ToString();
                    break;
                default:
                    nLowerBoundary = (nPageRows * nCurrentPage) - (nPageRows - 1);
                    if (nPageRows < nTotalRowCont) {
                        nUperBoundary = nPageRows * nCurrentPage;
                    }
                    else {
                        nUperBoundary = nTotalRowCont;
                    }
                    sRecordID1 = _dsPage.Tables[0].Rows[nLowerBoundary - 1][_sFile].ToString();
                    sRecordID2 = _dsPage.Tables[0].Rows[nUperBoundary - 1][_sFile].ToString();
                    
                    break;
            }

            psMessRowlable = "ໜ້າທີ" + nCurrentPage.ToString() + "/ທັງໝົດ " + nPagesall.ToString();
            pssNavclicked = "";
        }
        // method Data show datagrid of paggination
        public DataGridView Cpudgv_FillDataGridTable (DataGridView _dgvData, DataSet _dsTableData ,
            BindingSource _bngPage, string _sTable, string _sFile, int _nRowGrid)
        {
            try
            {
                _bngPage.DataSource = _dsTableData.Tables[_sTable];
                if(psPageCheck == "") {
                    psMessRowlable = "";
                    Cprv_FindPagin (_dsTableData, _sTable, _nRowGrid);
                }
                _bngPage.Filter = "Convert(" + _sFile + ", 'System.String') >='" + sRecordID1 +
                   "' And Convert(" + _sFile + ",'System.String')<='" + sRecordID2 + "'";
                _dgvData.DataSource = _bngPage;
                if(_dgvData.Rows.Count <= 0)
                {
                    _bngPage.Filter = "Convert (" + _sFile + ", 'System.String') >='" + sRecordID1 +
                        "' And Convert(" + _sFile + ",'System.String')<='" + sRecordID2 + "'";
                }
                _dgvData.DataSource = _bngPage;
                psPageCheck = "";
            }
            catch {
                _dgvData.DataSource = null;
            }
            return _dgvData;
        }

        private void Cprv_FindPagin(DataSet dsTableData, string sTable, int nRowGrid)
        {
            throw new NotImplementedException();
        }

        //Method Lao --> Enlish Use Barcode
        public void Cpuv_SetKeyboardLayuot (InputLanguage _olayout)
        {
            InputLanguage.CurrentInputLanguage = _olayout;
        }
        public InputLanguage Cpuo_GetInputLanguageByName (string _sName)
        {
            foreach( InputLanguage oLang in InputLanguage.InstalledInputLanguages)
            {
                if (oLang.Culture.EnglishName.ToLower().StartsWith(_sName))
                    return oLang;
            }
            return null;
        }
        //Method No iput string (ພີມໄດ້ແຕ່ໂຕເລກ)
        public void Cpu_Currencyonly(KeyPressEventArgs _e, bool _bCheck)
        {
            if (_bCheck) {
                if((!char.IsNumber(_e.KeyChar)&(_e.KeyChar != Convert.ToChar("."))) && !char.IsControl(_e.KeyChar))
                {
                    _e.Handled = true;
                }
            }
            else if(!char.IsNumber(_e.KeyChar)& !char.IsControl(_e.KeyChar))
            {
                _e.Handled = true;
            }
        }
    }
}

