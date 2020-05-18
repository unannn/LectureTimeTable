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
        //엑셀 파일을 불러와 두개의 테이블 리스트에 담아줌
        public void intializeTable(List<LectureTable> interestTable, List<LectureTable> enrollmentTable)  //엑셀에서 시간표를 불러와 두 테이블 리스트에 한행씩 저장
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

                interestTable.Add(new LectureTable(int.Parse(data.GetValue(1, 1).ToString()), data.GetValue(1, 2).ToString(), int.Parse(data.GetValue(1, 3).ToString()), data.GetValue(1, 4).ToString(), data.GetValue(1, 5).ToString(), data.GetValue(1, 6).ToString(), int.Parse(data.GetValue(1, 7).ToString()), double.Parse(data.GetValue(1, 8).ToString()), data.GetValue(1, 9).ToString(), lectureRoom, data.GetValue(1, 11).ToString(), data.GetValue(1, 12).ToString(), Constants.INTEREST_LECTURE));
                enrollmentTable.Add(new LectureTable(int.Parse(data.GetValue(1, 1).ToString()), data.GetValue(1, 2).ToString(), int.Parse(data.GetValue(1, 3).ToString()), data.GetValue(1, 4).ToString(), data.GetValue(1, 5).ToString(), data.GetValue(1, 6).ToString(), int.Parse(data.GetValue(1, 7).ToString()), double.Parse(data.GetValue(1, 8).ToString()), data.GetValue(1, 9).ToString(), lectureRoom, data.GetValue(1, 11).ToString(), data.GetValue(1, 12).ToString(), Constants.ENROLLMENT_LECTURE));
            }

            application.Workbooks.Close();
            application.Quit();
        }
        //초기 화면
        public void RunInitailScene(LectureView view)  
        {
            int selectedNumber;

            selectedNumber = view.initialView();

            if(selectedNumber != Constants.WRONG_INPUT)
            {
                currentState = selectedNumber;                 //장면 전환               
            }          
        }
        //관심과목 신청 
        public void RunInterestLeactureEnrollment(List<LectureTable> interestTable, MyLecture myLecture, LectureView view,InterestLectureView interestView)
        {            
            int selectedNumber;
            int selectedSearchingType;
            bool isRunning = true;                                 

            while (isRunning)
            {
                Console.Clear();
                view.PrintTitle(Constants.INITIAL_TITLE_BOARDER, " 관심과목 담기 ");
                view.PrintinitialLeactureTable(); //빈 강의테이블 출력

                Console.WriteLine(new string('-', Console.LargestWindowWidth - 4));
                selectedNumber = interestView.PrintInterestLeactureMenu();

                switch (selectedNumber)
                {
                    case Constants.My_INTEREST_LECTURES:  //내가 담은 관심과목
                        interestView.PrintMyInterestLeactures(myLecture);
                        break;

                    case Constants.INTEREST_LECTURE_SEARCHING:  //관심과목 검색 후 신청
                        selectedSearchingType = interestView.SeruchLectureTypes();
                        interestView.StartSelectedItem(selectedSearchingType, interestTable, myLecture);
                        break;

                    case Constants.INTEREST_LECTURE_DELETION:  //관심과목 삭제
                        interestView.DeleteInterestLecture(myLecture, interestTable);
                        break;

                    case Constants.INTEREST_LECTURE_ENDING:
                        isRunning = false;
                        currentState = Constants.START_MENU;          //반복문이 종료되면 시작메뉴로 이동
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }
        //수강 신청
        public void RunLeactureEnrollment(List<LectureTable> interestTable, List<LectureTable> enrollmentTable, MyLecture myLecture, LectureView view, EnrollmentView enrollmentView)
        {
            int selectedNumber;
            int selectedSearchingType;
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                view.PrintTitle(Constants.INITIAL_TITLE_BOARDER, " 수강 신청 "); //부제출력
                view.PrintinitialLeactureTable(); //빈 강의테이블 출력

                Console.WriteLine(new string('-', Console.LargestWindowWidth - 4));

                selectedNumber = enrollmentView.PrintEnrollmentMenu();

                switch (selectedNumber)
                {
                    case Constants.My_ENROLLMENT_LECTURES:           //현재 수강신청한 강의 보기
                        enrollmentView.PrintLeactures(myLecture.mySucessfulCourse,myLecture);
                        break;

                    case Constants.START_ENROLLMENT:                 //수강신청 시작
                        selectedSearchingType = enrollmentView.SeruchLectureTypes();
                        enrollmentView.StartEnrollment(selectedSearchingType, interestTable, enrollmentTable, myLecture);
                        break;

                    case Constants.ENROLLMENT_LECTURE_DELETION:      //신청한 과목 삭제
                        enrollmentView.DeleteEnrollmentLecture(myLecture,enrollmentTable);
                        break;

                    case Constants.ENROLLMENT_ENDING:              //수강신청 종료
                        isRunning = false;
                        currentState = Constants.START_MENU;
                        Console.Clear();
                        break;

                    default:   //위 네가지 입력이 아닐경우 재시작
                        break;
                }
            }
        }                    
        //시간표        
        public void RunCurrentTimetable(MyLecture myLecture, LectureView view)
        {
            Console.Clear();
            view.PrintTitle(Constants.INITIAL_TITLE_BOARDER, " 내 시간표 "); //부제출력

            view.PrintTimeTable(myLecture.mySucessfulCourse);

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Sheets sheets = workbook.Sheets;
            Excel._Worksheet worksheet = (Excel._Worksheet)application.ActiveSheet;

            var data = new object[25, 6];
            
            data[0, 1] = "월";
            data[0, 2] = "화";
            data[0, 3] = "수";
            data[0, 4] = "목";
            data[0, 5] = "금";


            for (int time = 0; time < 24; time++)
            {


                data[time + 1, 0] = "";

                if (time / 4 == 0) data[time + 1, 0] += "0";
                data[time + 1, 0] += ((time + 16) / 2).ToString() + ":";
                if (time % 2 == 1) data[time + 1, 0] += "30";
                else data[time + 1, 0] += "00";

                for (int day = 0; day < 5; day++)
                {
                    for (int lectureCount = 0; lectureCount < myLecture.mySucessfulCourse.Count; lectureCount++)
                    {
                        if (myLecture.mySucessfulCourse[lectureCount].timeTable[time, day] == 1)
                        {
                            data[time + 1, day + 1] = myLecture.mySucessfulCourse[lectureCount].CourseTitle + "\n" + myLecture.mySucessfulCourse[lectureCount].LectureRoom;
                        }
                    }
                }
            }

            var startCell = worksheet.Cells[1, 1];
            var endCell = worksheet.Cells[25, 6];
            var writeRange = worksheet.Range[startCell, endCell];

            writeRange.Value2 = data;

            worksheet.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\TimeTable.xlsx");

            application.Workbooks.Close();
            application.Quit();

            Currentstate = Constants.START_MENU;
        }
    }
}
