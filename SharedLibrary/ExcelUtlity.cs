﻿using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace SharedLibrary
{
    public class ExcelUtlity
    {
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        /// <summary>
        /// FUNCTION FOR EXPORT TO EXCEL
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        //public bool WriteDataTableToExcel(System.Data.DataTable dataTable, 
        //    string worksheetName, 
        //    string saveAsLocation, string ReporType)
        //{
        //    Microsoft.Office.Interop.Excel.Application excel;
        //    Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        //    Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        //    Microsoft.Office.Interop.Excel.Range excelCellrange;

        //    try
        //    {
        //        // Start Excel and get Application object.
        //        excel = new Microsoft.Office.Interop.Excel.Application();

        //        // for making Excel visible
        //        excel.Visible = false;
        //        excel.DisplayAlerts = false;

        //        // Creation a new Workbook
        //        excelworkBook = excel.Workbooks.Add(Type.Missing);

        //        // Workk sheet
        //        excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
        //        excelSheet.Name = worksheetName;


        //        excelSheet.Cells[1, 1] = ReporType;
        //        excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

        //        // loop through each row and add values to our sheet
        //        int rowcount = 2;

        //        foreach (DataRow datarow in dataTable.Rows)
        //        {
        //            rowcount += 1;
        //            for (int i = 1; i <= dataTable.Columns.Count; i++)
        //            {
        //                // on the first iteration we add the column headers
        //                if (rowcount == 3)
        //                {
        //                    excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
        //                    excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

        //                }

        //                excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

        //                //for alternate rows
        //                if (rowcount > 3)
        //                {
        //                    if (i == dataTable.Columns.Count)
        //                    {
        //                        if (rowcount % 2 == 0)
        //                        {
        //                            excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
        //                            FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
        //                        }

        //                    }
        //                }

        //            }

        //        }

        //        // now we resize the columns
        //        excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
        //        excelCellrange.EntireColumn.AutoFit();
        //        Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
        //        border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        //        border.Weight = 2d;


        //        excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
        //        FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


        //        //now save the workbook and exit Excel


        //        excelworkBook.SaveAs(saveAsLocation); ;
        //        excelworkBook.Close();
        //        excel.Quit();

        //        releaseObject(excel);
        //        releaseObject(excelSheet);
        //        releaseObject(excelworkBook);
        //        releaseObject(excelCellrange);


        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        excel = null;
        //        excelSheet = null;
        //        excelCellrange = null;
        //        excelworkBook = null;
        //        GC.Collect();
        //    }

        //}


        public void WriteDataTableToExcel(DataTable dtSrc,
                            string worksheetName,
                            string saveAsLocation)
        {
            using (ExcelPackage objExcelPackage = new ExcelPackage())
            {
                #region Datatable write
                //foreach (DataTable dtSrc in p_dsSrc.Rows)
                //{
                    //Create the worksheet    
                    ExcelWorksheet objWorksheet 
                        = objExcelPackage.Workbook.Worksheets.Add(worksheetName);
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1    
                    objWorksheet.Cells["A1"].LoadFromDataTable(dtSrc, true);
                    objWorksheet.Cells.Style.Font.SetFromFont(new Font("Calibri", 10));
                    objWorksheet.Cells.AutoFitColumns();
                    #region Format the header
                    using (ExcelRange objRange = objWorksheet.Cells["A1:XFD1"])
                    {
                        objRange.Style.Font.Bold = true;
                        objRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        objRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        objRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        objRange.Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);
                    }
                    #endregion
                //}
                #endregion
                #region Delete/Create File 
                //Write it back to the client    
                if (File.Exists(saveAsLocation))
                    File.Delete(saveAsLocation);

                //Create excel file on physical disk    
                FileStream objFileStrm = File.Create(saveAsLocation);
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes(saveAsLocation, objExcelPackage.GetAsByteArray());
                #endregion
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        //public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        //{
        //    range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
        //    range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
        //    if (IsFontbool )
        //    {
        //        range.Font.Bold = IsFontbool;
        //    }
        //}

    }
}
