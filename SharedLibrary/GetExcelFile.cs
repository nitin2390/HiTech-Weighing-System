using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SharedLibrary
{
    public class GetExcelFile
    {
        public string FileName { get; set; }
        public int MyProperty { get; set; }
        public IList result { get; set; }
        public ObjectContext ctx { get; set; }
        public GetExcelFile(IList<T> presult)
        {
            this.result = presult;
        }
        private Application excel;
        private Workbook worKbooK;
        private Worksheet worKsheeT;
        private Range celLrangE;
        private System.Data.DataTable ExportToExcel()
        {
            return ConvertToDataTable(this.result);
        }
        private System.Data.DataTable ExportToExcel1(IQueryable result, ObjectContext ctx)
        {
            try
            {
                EntityConnection conn = ctx.Connection as EntityConnection;
                using (SqlConnection SQLCon = new SqlConnection(conn.StoreConnection.ConnectionString))
                {
                    ObjectQuery query = result as ObjectQuery;
                    using (SqlCommand Cmd = new SqlCommand(query.ToTraceString(), SQLCon))
                    {
                        foreach (var param in query.Parameters)
                        {
                            Cmd.Parameters.AddWithValue(param.Name, param.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                        {
                            using (System.Data.DataTable dt = new System.Data.DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
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
        public bool ExportDataSetToExcel()
        {
            try
            {
                excel = new Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);


                worKsheeT = (Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "StudentRepoertCard";

                worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 8]].Merge();
                worKsheeT.Cells[1, 1] = "Student Report Card";
                worKsheeT.Cells.Font.Size = 15;


                int rowcount = 2;

                foreach (DataRow datarow in ExportToExcel().Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= ExportToExcel().Columns.Count; i++)
                    {

                        if (rowcount == 3)
                        {
                            worKsheeT.Cells[2, i] = ExportToExcel().Columns[i - 1].ColumnName;
                            worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        worKsheeT.Cells[rowcount, i] = datarow[i - 1].ToString();
                        if (rowcount > 3)
                        {
                            if (i == ExportToExcel().Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    celLrangE = worKsheeT.Range[worKsheeT.Cells[rowcount, 1], worKsheeT.Cells[rowcount, ExportToExcel().Columns.Count]];
                                }

                            }
                        }

                    }

                }
                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, ExportToExcel().Columns.Count]];
                celLrangE.EntireColumn.AutoFit();
                Borders border = celLrangE.Borders;
                border.LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;
                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, ExportToExcel().Columns.Count]];
                string ExcelFolderPath = Path.GetFullPath(@"..\..\ExcelOutput")+ "\\nitin.xls";
                worKbooK.SaveAs(ExcelFolderPath);
                worKbooK.Close();
                excel.Quit();
                return true;

            }
            catch (Exception ex)
            {
                string strMesssage = ex.Message;
                return false;
            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }
        }
        
    }
    
}
