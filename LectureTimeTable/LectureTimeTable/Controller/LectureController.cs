using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class LectureController
    {
        private int currentState;
        
        public int Currentstate
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public LectureController()
        {
            currentState = Constants.START_MENU;
        }
         
        public void intializeTable(List<LectureTable> lectureTable)  //엑셀에서 시간표를 불러와 lectureTable 리스트에 한행씩 저장
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(Environment.CurrentDirectory + "\\2020년 1학기 강의시간표.xlsx");
            Excel.Sheets sheets = workbook.Sheets;
            Excel.Worksheet worksheet = sheets["sheet1"] as Excel.Worksheet;

            for (int line = 2; line <= 161; line++)
            {
                Excel.Range cellRange = worksheet.get_Range("A" + line, "L" + line) as Excel.Range;   //worksheet에서 한 행 씩 가져옴
                Array data = cellRange.Cells.Value2;
                object nullexception = data.GetValue(1, 10);  //강의실 정보는 비어있을 수 있으므로 
                string lectureRoom = null;

                if (nullexception != null){                  //널체크를 해준 뒤 lectureRoom에 넣어주어 따로 불러옴
                    lectureRoom = nullexception.ToString();
                }

                lectureTable.Add(new LectureTable(int.Parse(data.GetValue(1, 1).ToString()), data.GetValue(1, 2).ToString(), int.Parse(data.GetValue(1, 3).ToString()), int.Parse(data.GetValue(1, 4).ToString()), data.GetValue(1, 5).ToString(), data.GetValue(1, 6).ToString(), int.Parse(data.GetValue(1, 7).ToString()), double.Parse(data.GetValue(1, 8).ToString()), data.GetValue(1, 9).ToString(), lectureRoom, data.GetValue(1, 11).ToString(), data.GetValue(1, 12).ToString()));
            }

            application.Workbooks.Close();
            application.Quit();
        }

        public void RunInitailScene(LectureView view)
        {
            int selectedNumber;

            selectedNumber = view.initialView();

            if(selectedNumber != Constants.WRONG_INPUT)
            {
                currentState = selectedNumber;                 //장면 전환               
            }          
        }

        public void RunEnrollment(List<LectureTable> lectureTable, MyLecture myLecture, LectureView view)
        {
            view.PrintAllLeactureTable(lectureTable);
        }
    }
}
