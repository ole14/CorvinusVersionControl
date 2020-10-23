using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using WebSOAP.Entities;
using WebSOAP.MnbServiceReference;

namespace WebSOAP
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<CurrenciesData> Currencies = new BindingList<CurrenciesData>();
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Value = new DateTime(2020,07,01);
            dateTimePicker2.Value = new DateTime(2020, 09, 30);
            CurrenciesFill();
            RefreshData();
        }

        private void RefreshData()
        {
            Rates.Clear();
            GetWebSoap();
            dataGridView1.DataSource = Rates;
            dataGridView1.AutoResizeColumns();
            chartRateData.DataSource = Rates;
            ChartFill();
        }

        private void CurrenciesFill()
        {
            var mnbService1 = new MNBArfolyamServiceSoapClient();

            var request1 = new GetCurrenciesRequestBody();

            var response1 = mnbService1.GetCurrencies(request1);

            var result1 = response1.GetCurrenciesResult;

            XmlFill(result1);
            
        }

        private void GetWebSoap()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"),
                endDate = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            XmlDataLoad(result);
        }

        private void XmlFill(string result1)
        {
            var xml2 = new XmlDocument();
            xml2.LoadXml(result1);
            
            foreach (XmlElement curre in xml2.DocumentElement)
            {
                var curr = new CurrenciesData();
                Currencies.Add(curr);

                for (int i = 0; i < 75; i++)
                {
                    var child2 = (XmlElement)curre.ChildNodes[i];
                    curr.currency = child2.InnerText;
                    comboBox1.Items.Add(curr.currency);
                }
            }
        }

        private void XmlDataLoad(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement xel in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(xel.GetAttribute("date"));
                var child = (XmlElement)xel.ChildNodes[0];
                if (child == null)
                    continue;
                rate.Currency = child.GetAttribute("curr");

                var unit = decimal.Parse(child.GetAttribute("unit"));
                var values = decimal.Parse(child.InnerText);
                if (unit != 0)
                    rate.Value = (values / unit)/100;
            }
        }

        private void ChartFill()
        {
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartarea = chartRateData.ChartAreas[0];
            chartarea.AxisX.MajorGrid.Enabled = false;
            chartarea.AxisY.MajorGrid.Enabled = false;
            chartarea.AxisY.IsStartedFromZero = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
