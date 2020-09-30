using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExcelExport
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats;

        Excel.Application x1App; // Alkalmazás változó
        Excel.Workbook x1WB; //Munkafüzet
        Excel.Worksheet x1Sheet; //Munkalap neve
        
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void CreateExcel()
        {
            try
            {
                x1App = new Excel.Application(); //ez indítja az excelt és tölti be az objektumot
                x1WB = x1App.Workbooks.Add(Missing.Value); //Új munkafüzet
                x1Sheet = x1WB.ActiveSheet(); //Új munkalap

                // CreateTable();

                x1App.Visible = true;
                x1App.UserControl = true;

            }
            catch (Exception ex)
            {

                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                //hibára futva excel bezárása
                x1WB.Close(false, Type.Missing, Type.Missing);
                x1App.Quit();
                x1WB = null;
                x1App = null;
            }
        }

        private void CreateTable()
        {
            throw new NotImplementedException();
        }

        private void LoadData() 
        {
            Flats = context.Flats.ToList();
        }

    }
}
