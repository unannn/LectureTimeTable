using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class EnrollmentView:ViewTool
    {
        public int PrintEnrollmentMenu()
        {
            int selectedItem = 0;

            List<string> menu = new List<string>()
            {
                "1. 내가 신청한 강의",
                "2. 수강 신청",
                "3, 신청한 강의 삭제",
                "4. 수강신청 종료"
            };

           
            Console.WriteLine();

            PrintMenu(menu, Constants.INITIAL_TITLE_BOARDER);

            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);
            Console.Write(" 메뉴 선택 : ");

            selectedItem = Exception.Instance.InputNumber(Constants.START_NUMBER, menu.Count);

            if (selectedItem == Constants.WRONG_INPUT)
            {
                PrintFailMessage("다시 입력해 주세요.", Constants.INITIAL_TITLE_BOARDER);
            }

            PrintBlankTable(10, Constants.UNDER_TABLE_Y+1);

            return selectedItem;
        }

        public int PrintLeactures(List<LectureTable> lectures, MyLecture myLecture)   //내가 관심과목으로 담은 강의들 리스트 출력
        {
            int rowNumber = 0;


            if (lectures.Count != 0)
            {
                Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

                foreach (LectureTable row in lectures)
                {
                    PrintOneRowLecture(row);
                    rowNumber++;
                }

                PrintBlankTable(14, Constants.UNDER_TABLE_Y+1);


                Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 2);

                if (myLecture.myInterestCourse != lectures)Console.WriteLine("현재 신청한 학점 : {0}/21 ", myLecture.MyEnrollmentCredits);
                else Console.WriteLine("현재 관심과목으로 담은 학점 : {0}/24 ", myLecture.MyInterestCredits);

                PrintFailMessage("", Constants.INITIAL_TITLE_BOARDER);
            }
            else
            {
                PrintBlankTable(10, Constants.UNDER_TABLE_Y+2);

                PrintFailMessage("수강 신청한 강의가 없습니다", Constants.INITIAL_TITLE_BOARDER);


            }

            return rowNumber;
        }

        public int SeruchLectureTypes()
        {
            List<string> serchingItem = new List<string>()
            {
                "1. 개설학과전공으로 검색",
                "2. 학수번호와 분반으로 검색",
                "3. 교과목명으로 검색",
                "4. 학년으로 검색",
                "5, 교수명으로 검색",
                "6. 관심과목으로 검색",
                "7. 검색 종료"
            };
            int inputNumber;

            PrintBlankTable(10, Constants.UNDER_TABLE_Y+1);
            Console.WriteLine();
            PrintMenu(serchingItem, Constants.INITIAL_TITLE_BOARDER);
            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);

            Console.Write("메뉴 선택 : ");

            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, serchingItem.Count);

            return inputNumber;
        }

        public void StartEnrollment(int selectedItem, List<LectureTable> interestTable, List<LectureTable> enrollmentTable, MyLecture myLecture)
        {
            string searchWord = null;
            int searchNumber;
            int dividedClassNumber;
            int addLectureNumber;
            int rowNumber = 0;
            int lectureTableIndex;

            PrintBlankTable(16, Constants.UNDER_TABLE_Y + 1);

            Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop + 1);

            switch (selectedItem)
            {
                case 1:     //개설학과전공
                    Console.Write("개설학과전공 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(enrollmentTable, searchWord, Constants.DEPARTMENT);
                    break;

                case 2:     //학수번호
                    Console.Write("학수번호 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 100000);

                    Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop);

                    Console.Write("분반 : ");
                    dividedClassNumber = Exception.Instance.InputNumber(1, 21);
                    rowNumber = SearchLecture(enrollmentTable, searchNumber, dividedClassNumber);
                    break;

                case 3:     //교과목명
                    Console.Write("교과목명 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(enrollmentTable, searchWord, Constants.COURSE_TITLE);
                    break;

                case 4:    //학년
                    Console.Write("이수학년 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 4);
                    rowNumber = SearchLectureOnYear(enrollmentTable, searchNumber);
                    break;

                case 5:    //교수명
                    Console.Write("교수명 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(enrollmentTable, searchWord, Constants.PROFESSOR_NAME);
                    break;

                case 6:   //관심과목담기한 강의
                    rowNumber = PrintLeactures(myLecture.myInterestCourse,myLecture);
                    if(rowNumber != 0) EnrollmentInInterest(myLecture,interestTable, enrollmentTable);
                    return;

                case 7:    //종료
                    return;
            }

            if (rowNumber == 0) //검색한 강의가 조회되지 않을 때
            {
                Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y + 3);
                PrintFailMessage("검색한 강의를 찾을 수 없습니다.", Constants.INITIAL_TITLE_BOARDER);
                return;
            }

            if (rowNumber < 13) Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 3); 
            else Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop + 3);

            if (selectedItem != 6)
            {
                Console.Write("수강신청할 강의 NO. 입력 : ");
                addLectureNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);
                 
                if (addLectureNumber != Constants.WRONG_INPUT)
                {
                    for (lectureTableIndex = 0; lectureTableIndex < enrollmentTable.Count; lectureTableIndex++)
                    {
                        if (enrollmentTable[lectureTableIndex].Key == addLectureNumber) break;
                    }

                    if (lectureTableIndex == enrollmentTable.Count)   //반복 문을 모두 돌때 까지 탈출 하지 못했으므로
                    {
                        PrintFailMessage("해당 강의가 없습니다.", Constants.INITIAL_TITLE_BOARDER);
                        return;
                    }

                    if (myLecture.MyEnrollmentCredits + enrollmentTable[lectureTableIndex].Credit <= 21)   //수강신청한 학점이 21 이하일 때만
                    {
                        for (int row = 0; row < myLecture.mySucessfulCourse.Count; row++)
                        {
                            if (myLecture.mySucessfulCourse[row].CourseNumber == enrollmentTable[lectureTableIndex].CourseNumber)   //학수번호가 같을 경우
                            {
                                PrintFailMessage("이미 추가된 강의입니다.", Constants.INITIAL_TITLE_BOARDER);
                                return;
                            }
                        }

                        for (int row = 0; row < myLecture.mySucessfulCourse.Count; row++)
                        {
                            if(CheckOverlapTable(myLecture.mySucessfulCourse[row].timeTable, enrollmentTable[lectureTableIndex].timeTable))      //시간표가 겹치면
                            {
                                PrintFailMessage("시간이 겹치는 강의가 존재 합니다.", Constants.INITIAL_TITLE_BOARDER);
                                return;
                            }
                        }
                        
                        myLecture.mySucessfulCourse.Add(enrollmentTable[lectureTableIndex]);
                        myLecture.MyEnrollmentCredits += enrollmentTable[lectureTableIndex].Credit;
                        enrollmentTable.RemoveAt(lectureTableIndex);

                        PrintFailMessage("수강신청을 완료 했습니다.", Constants.INITIAL_TITLE_BOARDER);
                    }
                    else
                    {
                        PrintFailMessage("더이상 담을 수 없습니다.", Constants.INITIAL_TITLE_BOARDER);
                    }
                }
                else
                {
                    PrintFailMessage("잘못된 입력입니다.", Constants.INITIAL_TITLE_BOARDER);
                }
            }
        }

        public void DeleteEnrollmentLecture(MyLecture myLecture, List<LectureTable> enrollmentTable)  //삭제하면 관심과목이 아닐때도 관심과목으로 복구되는것 수정할것 
        {
            int inputNumber;

            PrintLeactures(myLecture.mySucessfulCourse, myLecture);
            Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop - 1);

            if (myLecture.mySucessfulCourse.Count == 0) return;  //수강신청한 강의가 없을 경우 종료

            Console.Write("삭제할 과목의 NO 입력 : ");
            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);

            if (inputNumber != Constants.WRONG_INPUT)
            {
                for (int row = 0; row < myLecture.mySucessfulCourse.Count; row++)
                {
                    if (inputNumber == myLecture.mySucessfulCourse[row].Key)
                    {
                        if (myLecture.mySucessfulCourse[row].InterestOrEnrollment == Constants.INTEREST_LECTURE)  //관심과목에서 신청된 강의였을 경우 관심과목으로 되돌아감
                        {
                            myLecture.MyEnrollmentCredits -= myLecture.mySucessfulCourse[row].Credit;
                            myLecture.MyInterestCredits += myLecture.mySucessfulCourse[row].Credit;
                            myLecture.myInterestCourse.Add(myLecture.mySucessfulCourse[row]);
                            myLecture.mySucessfulCourse.RemoveAt(row);
                            PrintFailMessage("삭제되었습니다.", Constants.INITIAL_TITLE_BOARDER);

                            return;
                        }

                        myLecture.MyEnrollmentCredits -= myLecture.mySucessfulCourse[row].Credit;
                        enrollmentTable.Add(myLecture.mySucessfulCourse[row]);
                        myLecture.mySucessfulCourse.RemoveAt(row);
                        PrintFailMessage("삭제되었습니다.", Constants.INITIAL_TITLE_BOARDER);

                        return;
                      
                    }
                }
            }

            PrintFailMessage("해당 강의가 없습니다.", Constants.INITIAL_TITLE_BOARDER);
        }
    }
}
