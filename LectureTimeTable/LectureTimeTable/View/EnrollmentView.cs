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
                "4. 수강신청 담기 종료"
            };

            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(14);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            Console.WriteLine();

            PrintMenu(menu, 0);

            Console.Write(" 메뉴 선택 : ");

            selectedItem = Exception.Instance.InputNumber(Constants.START_NUMBER, menu.Count);

            if (selectedItem == Constants.WRONG_INPUT)
            {
                PrintFailMessage("다시 입력해 주세요.", Constants.INITIAL_TITLE_BOARDER);
            }

            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(10);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);

            return selectedItem;
        }

        public void PrintMyEnrollmentLeactures(MyLecture myLecture)   //내가 관심과목으로 담은 강의들 리스트 출력
        {
            Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

            if (myLecture.myInterestCourse.Count != 0)
            {
                foreach (LectureTable row in myLecture.myInterestCourse)
                {
                    PrintOneRowLecture(row);
                }
                Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 3);
                PrintFailMessage("", 0);
            }
            else
            {
                PrintFailMessage("관심과목으로 담은 강의가 없습니다", 0);
                Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);
                PrintBlankTable(2);
            }
        }
        public void StartEnrollment(int selectedItem, List<LectureTable> lectureTable, MyLecture myLecture)
        {
            string searchWord = null;
            int searchNumber;
            int addLectureNumber;
            int rowNumber = 0;
            switch (selectedItem)
            {
                case 1:     //개설학과전공
                    Console.Write("개설학과전공 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.DEPARTMENT);
                    break;

                case 2:     //학수번호
                    Console.Write("학수번호 검색 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 100000);
                    rowNumber = SearchLecture(lectureTable, searchNumber, Constants.COURSE_NUMBER);
                    break;

                case 3:     //교과목명
                    Console.Write("교과목명 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.COURSE_TITLE);
                    break;

                case 4:    //학년
                    Console.Write("이수학년 검색 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 4);
                    rowNumber = SearchLecture(lectureTable, searchNumber, Constants.YEAR);
                    break;

                case 5:    //교수명
                    Console.Write("교수명 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.PROFESSOR_NAME);
                    break;

                case 6:    //종료
                    return;
            }

            if (rowNumber == 0)
            {
                PrintFailMessage("검색한 강의를 찾을 수 없습니다.", 0);
                return;
            }

            if (rowNumber < 13) Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 3);
            else Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop + 3);

            if (selectedItem != 6)
            {
                Console.Write("관심과목에 담을 NO. 입력 : ");
                addLectureNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, lectureTable.Count);

                if (addLectureNumber != Constants.WRONG_INPUT)
                {
                    if (myLecture.MyCurrentCredits + lectureTable[addLectureNumber - 1].Credit <= 24)   //현재 관심과목에담은 학점이 24 이하일 때만
                    {
                        for (int row = 0; row < myLecture.myInterestCourse.Count; row++)
                        {
                            if (myLecture.myInterestCourse[row].CourseNumber == lectureTable[addLectureNumber - 1].CourseNumber)   //학수번호가 같을 경우
                            {
                                PrintFailMessage("이미 추가된 강의입니다.", 0);
                                return;
                            }
                        }

                        myLecture.myInterestCourse.Add(lectureTable[addLectureNumber - 1]);
                        myLecture.MyCurrentCredits += lectureTable[addLectureNumber - 1].Credit;
                        PrintFailMessage("관심과목에 추가되었습니다.", 0);
                    }
                    else
                    {
                        PrintFailMessage("더이상 담을 수 없습니다.", 0);
                    }
                }
                else
                {
                    PrintFailMessage("잘못된 입력입니다.", 0);
                }
            }
        }

        public void DeleteEnrollmentLecture(MyLecture myLecture)
        {
            int inputNumber;
            PrintMyEnrollmentLeactures(myLecture);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            PrintBlankTable(1);

            Console.Write("삭제할 과목의 NO 입력 : ");
            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);

            if (inputNumber != Constants.WRONG_INPUT)
            {
                for (int row = 0; row < myLecture.myInterestCourse.Count; row++)
                {
                    if (inputNumber == myLecture.myInterestCourse[row].Key)
                    {
                        myLecture.myInterestCourse.RemoveAt(row);
                        PrintFailMessage("삭제되었습니다.", 0);
                        return;
                    }
                }
            }

            PrintFailMessage("해당 강의가 없습니다.", 0);
        }
    }
}
