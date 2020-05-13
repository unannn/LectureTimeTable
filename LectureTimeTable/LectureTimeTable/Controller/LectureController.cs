using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LTT
{
    class LectureController
    {
        public void intializeTable(List<LectureTable> lectureTable)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(Environment.CurrentDirectory + "\\2020년 1학기 강의시간표.xlsx");
            Excel.Sheets sheets = workbook.Sheets;
            Excel.Worksheet worksheet = sheets["sheet1"] as Excel.Worksheet;
            for (int line = 2; line <= 161; line++)
            {
                Excel.Range cellRange = worksheet.get_Range("A" + line, "L" + line) as Excel.Range;
                Array data = cellRange.Cells.Value2;
                object nullexception = data.GetValue(1, 10);
                string lectureRoom = null;
                if(nullexception != null){
                    lectureRoom = nullexception.ToString();
                }
                //Console.WriteLine(int.Parse(data.GetValue(1, 1).ToString()) + data.GetValue(1, 2).ToString() + int.Parse(data.GetValue(1, 3).ToString()) + int.Parse(data.GetValue(1, 4).ToString()) + data.GetValue(1, 5).ToString() + data.GetValue(1, 6).ToString() + int.Parse(data.GetValue(1, 7).ToString()) + double.Parse(data.GetValue(1, 8).ToString()) + data.GetValue(1, 9).ToString() + lectureRoom + data.GetValue(1, 11).ToString() + data.GetValue(1, 12).ToString());
                lectureTable.Add(new LectureTable(int.Parse(data.GetValue(1, 1).ToString()), data.GetValue(1, 2).ToString(), int.Parse(data.GetValue(1, 3).ToString()), int.Parse(data.GetValue(1, 4).ToString()), data.GetValue(1, 5).ToString(), data.GetValue(1, 6).ToString(), int.Parse(data.GetValue(1, 7).ToString()), double.Parse(data.GetValue(1, 8).ToString()), data.GetValue(1, 9).ToString(), lectureRoom, data.GetValue(1, 11).ToString(), data.GetValue(1, 12).ToString()));
            }

            application.Workbooks.Close();
            application.Quit();
        }
    }
}
