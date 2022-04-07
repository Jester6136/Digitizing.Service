using Library.DataModel;
using Library.Common.Helper;
using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UTEHY.Common.Helper
{
    public class ExportDocx : DocxHelper
    {
        //public static string CreateGroupTypeRefTemplate(int opt, string filename, Dictionary<string, string> dictionaryData, List<WebsiteGroupTypeRefModel> data)
        //{
        //    string res = "";
        //    try
        //    {
        //        using (DocX document = DocX.Load(filename))
        //        {
        //            ReplaceTime(document, null);
        //            ReplaceData(dictionaryData, null, document);
        //            int cRow = 1;
        //            if (data != null && data.Count > 0)
        //            {
        //                Novacode.Table myTable = FindTableWithText(document.Tables, fTempTableData, out int Row, out int cCell);
        //                if (data.Count > 0)
        //                {
        //                    for (int i = 0; i < data.Count; i++)
        //                    {
        //                        Novacode.Row newRow = myTable.InsertRow(myTable.Rows[cRow], cRow + i + 1);
        //                        newRow.Cells[0].Paragraphs.First().Append((i + 1).ToString()).ReplaceText(fTempTableData, "");
        //                        newRow.Cells[1].Paragraphs.First().Append(data[i].group_type_rcd);
        //                        newRow.Cells[2].Paragraphs.First().Append(data[i].group_type_name);
        //                        newRow.Cells[3].Paragraphs.First().Append(data[i].sort_order.ToString());
        //                    }
        //                    cRow += 1;
        //                }
        //                myTable.RemoveRow(1);
        //            }
        //            document.ReplaceText(fTempTableData, "");
        //            document.Save();
        //            document.Dispose();
        //        }
        //        if (opt == 2)
        //            ConvertDocx2Html(filename, filename.Replace(".docx", ""), 48);
        //        else if (opt == 3)
        //            ConvertDocx2Pdf(filename, filename.Replace(".docx", ""), 48);
        //    }
        //    catch (Exception ex)
        //    {
        //        res = ex.Message;
        //    }
        //    return res;
        //}

    }
}


