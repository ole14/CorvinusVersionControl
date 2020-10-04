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

                CreateTable();

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
            string[] headers = new string[]
            {
                "Kód"
                ,"Eladó"
                ,"Oldal"
                ,"Kerület"
                ,"Lift"
                ,"Szobák száma"
                ,"Alapterület (m2)"
                ,"Ár (mFt)"
                ,"Négyzetméter ár (Ft/m2)"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                x1Sheet.Cells[1, i + 1] = headers[i];
            }

            object[,] values = new object[Flats.Count, headers.Length];

            int szamlal = 0;
            foreach (Flat f in Flats)
            {
                values[szamlal, 0] = f.Code;
                values[szamlal, 1] = f.Vendor;
                values[szamlal, 2] = f.Side;
                values[szamlal, 3] = f.District;
                if (f.Elevator == true)
                {
                    values[szamlal, 4] = "Van";
                }
                else
                {
                    values[szamlal, 4] = "Nincs";
                }
                values[szamlal, 5] = f.NumberOfRooms;
                values[szamlal, 6] = f.FloorArea;
                values[szamlal, 7] = f.Price;
                values[szamlal, 8] = "";
                szamlal++;
            }

            x1Sheet.get_Range(
                        GetCell(2, 1),
                        GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }

            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }

        private void LoadData() 
        {
            Flats = context.Flats.ToList();
        }

    }
}
