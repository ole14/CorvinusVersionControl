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
        public Form1()
        {
            InitializeComponent();
            GetWebSoap();
            dataGridView1.DataSource = Rates;
            dataGridView1.AutoResizeColumns();
            chartRateData.DataSource = Rates;
            ChartFill();
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

        private void GetWebSoap()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            XmlDataLoad(result);
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
                rate.Currency = child.GetAttribute("curr");

                var unit = decimal.Parse(child.GetAttribute("unit"));
                var values = decimal.Parse(child.InnerText);
                if (unit != 0)
                    rate.Value = (values / unit)/100;
            }
        }
    }
}
