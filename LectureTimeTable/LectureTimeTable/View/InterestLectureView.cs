using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class InterestLectureView:ViewTool
    {
        public int PrintInterestLeactureMenu()
        {
            int selectedItem = 0;
            List<string> menu = new List<string>()
            {
                "1. 내 관심과목",
                "2. 관심과목 검색",
                "3, 관심과목 삭제",
                "4. 관심과목 담기 종료"
            };
            
            Console.WriteLine();
           
            PrintMenu(menu, Constants.INITIAL_TITLE_BOARDER);

            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);
            Console.Write("메뉴 선택 : ");

            selectedItem = Exception.Instance.InputNumber(Constants.START_NUMBER, menu.Count);

            if (selectedItem == Constants.WRONG_INPUT)
            {
                PrintFailMessage("다시 입력해 주세요.", Constants.INITIAL_TITLE_BOARDER);
            }
            
            PrintBlankTable(10, Constants.UNDER_TABLE_Y+1);

            return selectedItem;
        }

        public void PrintMyInterestLeactures(MyLecture myLecture)   //내가 관심과목으로 담은 강의들 리스트 출력
        {
            
            if (myLecture.myInterestCourse.Count != 0)
            {
                Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

                foreach (LectureTable row in myLecture.myInterestCourse)
                {
                    PrintOneRowLecture(row);
                }

                Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 3);
                Console.WriteLine("현재 관심과목으로 담은 학점 : {0}/24 ", myLecture.MyInterestCredits);
                PrintFailMessage("", Constants.INITIAL_TITLE_BOARDER);
            }
            else
            {
                Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y + 2);

                PrintFailMessage("관심과목으로 담은 강의가 없습니다", Constants.INITIAL_TITLE_BOARDER);
               
            }
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
                "6. 검색 종료"
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

        public void StartSelectedItem(int selectedItem, List<LectureTable> interestTable, MyLecture myLecture)
        {
            string searchWord = null;
            int searchNumber;
            int dividedClassNumber;
            int addLectureNumber;
            int rowNumber = 0;
            int lectureTableIndex;

            PrintBlankTable(14, Constants.UNDER_TABLE_Y+1);

            Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER,Console.CursorTop + 1);

            switch (selectedItem)
            {
                case 1:     //개설학과전공
                    Console.Write("개설학과전공 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(interestTable, searchWord, Constants.DEPARTMENT);
                    break;

                case 2:     //학수번호와 분반으로 검색
                    Console.Write("학수번호 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 100000);

                    Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop);

                    Console.Write("분반 : ");
                    dividedClassNumber = Exception.Instance.InputNumber(1, 21); 

                    rowNumber = SearchLecture(interestTable, searchNumber, dividedClassNumber);
                    break;

                case 3:     //교과목명
                    Console.Write("교과목명 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(interestTable, searchWord, Constants.COURSE_TITLE);
                    break;

                case 4:    //학년
                    Console.Write("이수학년 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 4);
                    rowNumber = SearchLectureOnYear(interestTable, searchNumber);
                    break;

                case 5:    //교수명
                    Console.Write("교수명 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(interestTable, searchWord, Constants.PROFESSOR_NAME);
                    break;

                case 6:    //종료
                    return;
            }

            if (rowNumber == 0)
            {
                Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y + 3);
                PrintFailMessage("검색한 강의를 찾을 수 없습니다.", Constants.INITIAL_TITLE_BOARDER);
                return;
            }

            if (rowNumber < 13) Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Constants.UNDER_TABLE_Y + 3);   //커서 이동
            else Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop + 3);

            if (selectedItem != 6)
            {
                Console.Write("관심과목에 담을 NO. 입력 : ");
                addLectureNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);
                
                if (addLectureNumber != Constants.WRONG_INPUT)
                {
                    for (lectureTableIndex = 0; lectureTableIndex < interestTable.Count; lectureTableIndex++)
                    {
                        if (interestTable[lectureTableIndex].Key == addLectureNumber) break;
                    }

                    if (lectureTableIndex == interestTable.Count)
                    {
                        PrintFailMessage("해당 강의가 없습니다.", Constants.INITIAL_TITLE_BOARDER);
                        return;
                    }

                    if (myLecture.MyInterestCredits + interestTable[lectureTableIndex].Credit <= 24)   //현재 관심과목에담은 학점이 24 이하일 때만
                    {
                        for (int row = 0; row < myLecture.myInterestCourse.Count; row++)
                        {
                            if (myLecture.myInterestCourse[row].CourseNumber == interestTable[lectureTableIndex].CourseNumber)   //학수번호가 같을 경우
                            {
                                PrintFailMessage("이미 추가된 강의입니다.", Constants.INITIAL_TITLE_BOARDER);
                                return;
                            }
                        }

                        myLecture.myInterestCourse.Add(interestTable[lectureTableIndex]);
                        myLecture.MyInterestCredits += interestTable[lectureTableIndex].Credit;
                        interestTable.RemoveAt(lectureTableIndex);

                        PrintFailMessage("관심과목에 추가되었습니다.", Constants.INITIAL_TITLE_BOARDER);
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

        public void DeleteInterestLecture(MyLecture myLecture, List<LectureTable> interestTable)
        {
            int inputNumber;

            PrintMyInterestLeactures(myLecture);
            Console.SetCursorPosition(Constants.INITIAL_TITLE_BOARDER, Console.CursorTop - 1);

            if (myLecture.myInterestCourse.Count == 0) return; //관심과목으로 담은 강의가 없을 경우 종료

            Console.Write("삭제할 과목의 NO 입력 : ");
            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);

            if (inputNumber != Constants.WRONG_INPUT)
            {
                for (int row = 0; row < myLecture.myInterestCourse.Count; row++)
                {
                    if (inputNumber == myLecture.myInterestCourse[row].Key)
                    {
                        myLecture.MyInterestCredits -= myLecture.myInterestCourse[row].Credit;
                        interestTable.Add(myLecture.myInterestCourse[row]);
                        myLecture.myInterestCourse.RemoveAt(row);

                        PrintFailMessage("삭제되었습니다.", Constants.INITIAL_TITLE_BOARDER);
                        return;
                    }
                }
            }

            PrintFailMessage("해당 강의가 없습니다.", Constants.INITIAL_TITLE_BOARDER);
        }
    }
}

