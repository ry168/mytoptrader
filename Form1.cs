using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace StockTrade
{
    public partial class Form1 : Form
    {
        const int INT_THREAD_CHG_COLOR_INTERVAL = 600;
        const int INT_THREAD_CHECK_INTERVAL = 1;
        const int INT_DEFAULT_INTERVAL = 1;
        const int INT_ENABLE_STOP_LOSS_DELAY = 60000;
        const string REGION_US = "US";
        const string REGION_HK = "HK";
        const string REGION_UK = "UK";
        System.Data.DataTable dt_US;
        System.Data.DataTable dt_HK;
        System.Data.DataTable dt_UK;

        public Form1()
        {
            InitializeComponent();

            string[] arr_stkLst_US = ReadStockListInTXT(REGION_US);
            string[] arr_stkLst_HK = ReadStockListInTXT(REGION_HK);
            string[] arr_stkLst_UK = ReadStockListInTXT(REGION_UK);

            //Initial the datatable for diff region.
            InitializeCDataTable(arr_stkLst_US, arr_stkLst_HK, arr_stkLst_UK);

            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private string[] ReadStockListInTXT(string region)
        {
            string startupPath = Environment.CurrentDirectory;

            List<string> lst_StockList = new List<string>();
            try
            {
                foreach (string line in File.ReadLines(startupPath + @"\StockList\" + region + ".txt"))
                {
                    lst_StockList.Add(line);
                }
            }
            catch (Exception)
            {
                lst_StockList.Add("n/a");
                lst_StockList.Add("n/a");
            }
            return lst_StockList.ToArray();
        }

        private void InitializeCDataTable(string[] arr_stkLst_US, string[] arr_stkLst_HK, string[] arr_stkLst_UK)
        {
            #region US stock list
            //Declare a DataTable and call to GetDetails
            dt_US = new System.Data.DataTable(REGION_US);
            // Here we create a DataTable with # columns.
            dt_US.Columns.Add("Stock", typeof(string));         //Stock No
            dt_US.Columns.Add("CurrPx", typeof(decimal));       //Last Px
            dt_US.Columns.Add("50DMA", typeof(decimal));        //50-d Moving Average
            dt_US.Columns.Add("C_Px<50MA", typeof(bool));       //Is CurrPx < 50-d MA?
            dt_US.Columns.Add("ExePx", typeof(decimal));        //Executed Px
            dt_US.Columns.Add("OpenCase", typeof(bool));        //Opened case already? (For prog check use only)
            dt_US.Columns.Add("StopLossPx", typeof(decimal));   //Stop loss price

            // Here we add # DataRows.
            for (int i = 0; i < arr_stkLst_US.Length; i++)
            {
                dt_US.Rows.Add(arr_stkLst_US[i], 0, 0, null, null, false, 0);
            }

            dataGridView_US.AutoGenerateColumns = true;
            dataGridView_US.DataSource = dt_US;
            #endregion

            #region HK stock list
            //Declare a DataTable and call to GetDetails
            dt_HK = new System.Data.DataTable(REGION_HK);
            // Here we create a DataTable with # columns.
            dt_HK.Columns.Add("Stock", typeof(string));         //Stock No
            dt_HK.Columns.Add("CurrPx", typeof(decimal));       //Last Px
            dt_HK.Columns.Add("50DMA", typeof(decimal));        //50-d Moving Average
            dt_HK.Columns.Add("C_Px<50MA", typeof(bool));       //Is CurrPx < 50-d MA?
            dt_HK.Columns.Add("ExePx", typeof(decimal));        //Executed Px
            dt_HK.Columns.Add("OpenCase", typeof(bool));        //Opened case already? (For prog check use only)
            dt_HK.Columns.Add("StopLossPx", typeof(decimal));   //Stop loss price

            // Here we add # DataRows.
            for (int i = 0; i < arr_stkLst_HK.Length; i++)
            {
                dt_HK.Rows.Add(arr_stkLst_HK[i], 0, 0, null, null, false, 0);
            }

            dataGridView_HK.AutoGenerateColumns = true;
            dataGridView_HK.DataSource = dt_HK;
            #endregion

            #region UK stock list
            //Declare a DataTable and call to GetDetails
            dt_UK = new System.Data.DataTable(REGION_UK);
            // Here we create a DataTable with # columns.
            dt_UK.Columns.Add("Stock", typeof(string));         //Stock No
            dt_UK.Columns.Add("CurrPx", typeof(decimal));       //Last Px
            dt_UK.Columns.Add("50DMA", typeof(decimal));        //50-d Moving Average
            dt_UK.Columns.Add("C_Px<50MA", typeof(bool));       //Is CurrPx < 50-d MA?
            dt_UK.Columns.Add("ExePx", typeof(decimal));        //Executed Px
            dt_UK.Columns.Add("OpenCase", typeof(bool));        //Opened case already? (For prog check use only)
            dt_UK.Columns.Add("StopLossPx", typeof(decimal));   //Stop loss price

            // Here we add # DataRows.
            for (int i = 0; i < arr_stkLst_UK.Length; i++)
            {
                dt_UK.Rows.Add(arr_stkLst_UK[i], 0, 0, null, null, false, 0);
            }

            dataGridView_UK.AutoGenerateColumns = true;
            dataGridView_UK.DataSource = dt_UK;
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create a thread to call the API to get latest Stock price and show in GridView periodically (ex. 10sec)
            Thread thread_US = new Thread(() => GetJsonUpdStockPx(dataGridView_US, dt_US));
            thread_US.IsBackground = true;
            thread_US.Start();

            //Create a thread to call the API to get latest Stock price and show in GridView periodically (ex. 10sec)
            Thread thread_HK = new Thread(() => GetJsonUpdStockPx(dataGridView_HK, dt_HK));
            thread_HK.IsBackground = true;
            thread_HK.Start();

            //Create a thread to call the API to get latest Stock price and show in GridView periodically (ex. 10sec)
            Thread thread_UK = new Thread(() => GetJsonUpdStockPx(dataGridView_UK, dt_UK));
            thread_UK.IsBackground = true;
            thread_UK.Start();

            cmbUpdInterval.SelectedItem = "5";
        }

        public void GetJsonUpdStockPx(DataGridView dataGridView, DataTable dt)
        {
            while (true)
            {
                bool bool_KeepProcess = true;
                //if (dataGridView == dataGridView_HK && chkUpdHK.Checked == false)
                //    bool_KeepProcess = false;
                //else if (dataGridView == dataGridView_US && chkUpdUS.Checked == false)
                //    bool_KeepProcess = false;
                //else if (dataGridView == dataGridView_UK && chkUpdUK.Checked == false)
                //    bool_KeepProcess = false;

                if (dataGridView == dataGridView_HK && radUpdHK.Checked == false)
                    bool_KeepProcess = false;
                else if (dataGridView == dataGridView_US && radUpdUS.Checked == false)
                    bool_KeepProcess = false;
                else if (dataGridView == dataGridView_UK && radUpdUK.Checked == false)
                    bool_KeepProcess = false;


                if (bool_KeepProcess)
                {
                    //string str_URL = "https://query.yahooapis.com/v1/public/yql?q=select%20Name,symbol,Open,PreviousClose,Change,ChangeRealtime,DaysLow,DaysHigh,YearLow,YearHigh,DaysRange,FiftydayMovingAverage,TwoHundreddayMovingAverage%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%220001.hk+0002.hk%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

                    string str_GetStockList = ConvertURLForYahooAPI(dt);
                    if (str_GetStockList.Length > 0)
                    {
                        string str_URL = "https://query.yahooapis.com/v1/public/yql?q=select%20PreviousClose,Change,FiftydayMovingAverage%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22" + str_GetStockList + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&datetime=" + DateTime.Now.ToString("yyyyMMddhhmmssffffff");
                        var json = new WebClient().DownloadString(str_URL);

                        RootObject searchResult = JsonConvert.DeserializeObject<RootObject>(json);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (searchResult.query.results.quote[i].Change == null)
                                searchResult.query.results.quote[i].Change = 0;

                            decimal dec_CurrPx = Convert.ToDecimal(searchResult.query.results.quote[i].PreviousClose) + Convert.ToDecimal(searchResult.query.results.quote[i].Change);
                            decimal dec_50DMA = Convert.ToDecimal(searchResult.query.results.quote[i].FiftydayMovingAverage);
                            if ((decimal)dt.Rows[i]["CurrPx"] != dec_CurrPx)
                            {
                                int currRow = i;
                                Thread thread = new Thread(() => ChangeGV_Color(dataGridView, currRow, 1)); //curr row, 1 = CurrPx column
                                thread.IsBackground = true;
                                thread.Start();
                            }
                            dt.Rows[i]["CurrPx"] = dec_CurrPx;
                            dt.Rows[i]["50DMA"] = dec_50DMA;


                            //Only check at the first round (When prog run)
                            if (string.IsNullOrEmpty(dt.Rows[i]["C_Px<50MA"].ToString()))
                            {
                                if (dec_CurrPx < dec_50DMA)
                                    dt.Rows[i]["C_Px<50MA"] = true;
                                else
                                    dt.Rows[i]["C_Px<50MA"] = false;
                            }
                            else
                            {
                                try
                                {
                                    if (!Convert.ToBoolean(dt.Rows[i]["OpenCase"]))
                                        if (Convert.ToBoolean(dt.Rows[i]["C_Px<50MA"]) && dec_CurrPx >= dec_50DMA)
                                        {
                                            //original: Last Px < 50-d MA, but currently Last Px >= 50-d MA
                                            /****Open case for BUY****/

                                            //Set opened case = Ture
                                            dt.Rows[i]["OpenCase"] = true;
                                            dt.Rows[i]["ExePx"] = dec_CurrPx;
                                            dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                                            int currRow = i;
                                            Thread thread = new Thread(() => OpenCaseForBuy(dataGridView, dt, currRow)); //i = curr row
                                            thread.IsBackground = true;
                                            thread.Start();
                                        }
                                        else if (!Convert.ToBoolean(dt.Rows[i]["C_Px<50MA"]) && dec_50DMA >= dec_CurrPx)
                                        {
                                            //original: Last Px > 50-d MA, but currently Last Px <= 50-d MA
                                            /****Open case for SELL****/

                                            //Set opened case = Ture
                                            dt.Rows[i]["OpenCase"] = true;
                                            dt.Rows[i]["ExePx"] = dec_CurrPx;
                                            dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                                            int currRow = i;
                                            Thread thread = new Thread(() => OpenCaseForSell(dataGridView, dt, currRow)); //i = curr row
                                            thread.IsBackground = true;
                                            thread.Start();
                                        }
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                        dataGridView.DataSource = dt;
                    }
                }
                int int_SelectedValue = Convert.ToInt32(cmbUpdInterval.SelectedItem) * 1000;    //in seconds
                Thread.Sleep(int_SelectedValue);
            }
        }


        public string ConvertURLForYahooAPI(DataTable dt)
        {
            List<string> lst_StockName = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                lst_StockName.Add(row.Field<string>(0));
            }
            return String.Join("+", lst_StockName.ToArray());
        }

        private void chkAutoRefreshLastPx_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Update the time interval to get latest stock price
        private void cmbUpdInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int int_SelectedValue = Convert.ToInt32(cmbUpdInterval.SelectedItem) * 1000;    //in seconds
        }

        private void ChangeGV_Color(DataGridView dataGridView, int row, int col)
        {
            dataGridView.Rows[row].Cells[col].Style.ForeColor = Color.Red;
            Thread.Sleep(INT_THREAD_CHG_COLOR_INTERVAL);
            dataGridView.Rows[row].Cells[col].Style.ForeColor = Color.Black;
        }

        private void OpenCaseForBuy(DataGridView dataGridView, DataTable dt, int int_ProcessRow)
        {
            //Ref: http://isnotnothing.blogspot.hk/2014/10/winform-app-ui-thread-memo.html
            //System will enable checking the stop loss function after 1 minute
            Thread.Sleep(INT_ENABLE_STOP_LOSS_DELAY);

            while (true)
            {
                try
                {
                    decimal dec_ExePx = (decimal)dt.Rows[int_ProcessRow]["ExePx"];
                    decimal dec_CurrPx = (decimal)dt.Rows[int_ProcessRow]["CurrPx"];
                    decimal dec_50DMA = (decimal)dt.Rows[int_ProcessRow]["50DMA"];

                    decimal dec_CompareBig = Math.Max(dec_ExePx, dec_50DMA);
                    if (dec_CurrPx < dec_CompareBig)
                    {
                        dt.Rows[int_ProcessRow]["StopLossPx"] = dec_CurrPx;
                        dataGridView.Rows[int_ProcessRow].DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //System will keep checking the stop loss 1 sec later
                Thread.Sleep(INT_THREAD_CHECK_INTERVAL);
            }
        }

        private void OpenCaseForSell(DataGridView dataGridView, DataTable dt, int int_ProcessRow)
        {
            //System will enable checking the stop loss function after 1 minute
            Thread.Sleep(INT_ENABLE_STOP_LOSS_DELAY);

            while (true)
            {
                try
                {
                    decimal dec_ExePx = (decimal)dt.Rows[int_ProcessRow]["ExePx"];
                    decimal dec_CurrPx = (decimal)dt.Rows[int_ProcessRow]["CurrPx"];
                    decimal dec_50DMA = (decimal)dt.Rows[int_ProcessRow]["50DMA"];

                    decimal dec_CompareSmall = Math.Min(dec_ExePx, dec_50DMA);
                    if (dec_CurrPx > dec_CompareSmall)
                    {
                        dt.Rows[int_ProcessRow]["StopLossPx"] = dec_CurrPx;
                        dataGridView.Rows[int_ProcessRow].DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //System will keep checking the stop loss 1 sec later
                Thread.Sleep(INT_THREAD_CHECK_INTERVAL);
            }
        }

        private void datagridview_SelectionChanged(object sender, EventArgs e)
        {
            string str_Display = "";
            DataGridView data = (DataGridView)sender;
            foreach (DataGridViewRow row in data.SelectedRows)
            {
                bool bool_OpenedCase = (bool)row.Cells[5].Value;
                if (bool_OpenedCase)
                {
                    decimal dec_SubTotal = 0;
                    string str_Stock = (string)row.Cells[0].Value;
                    decimal dec_CurrPx = (decimal)row.Cells[1].Value;
                    decimal dec_50DMA = (decimal)row.Cells[2].Value;
                    bool bool_CurrPx_vs_50DMA = (bool)row.Cells[3].Value;
                    decimal dec_ExePx = (decimal)row.Cells[4].Value;
                    decimal dec_StopLossPx = (decimal)row.Cells[6].Value;

                    if (bool_CurrPx_vs_50DMA)
                        if (dec_StopLossPx != 0)
                            dec_SubTotal = dec_StopLossPx - dec_ExePx;
                        else
                            dec_SubTotal = dec_CurrPx - dec_ExePx;
                    else
                        if (dec_StopLossPx != 0)
                            dec_SubTotal = dec_ExePx - dec_StopLossPx;
                        else
                            dec_SubTotal = dec_ExePx - dec_CurrPx;

                    str_Display = str_Stock + " P/L " + dec_SubTotal + Environment.NewLine;
                }
            }

            if (str_Display.Length > 0)
                MessageBox.Show(str_Display);
        }

        private void datagridview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //place your own dialog or do nonthing here
        }

        private void dataGridView_US_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
