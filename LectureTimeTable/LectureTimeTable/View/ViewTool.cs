using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class ViewTool
    {
        protected void PrintLeftGap(int leftGap)
        {
            string whiteSpace = new string(' ', leftGap);

            Console.Write(whiteSpace);
        }

        public void PrintTitle(int leftGap, string subtitle)           //제목 출력
        {
            string bar = new string('-', Console.LargestWindowWidth - 4);


            Console.WriteLine(bar);
            Console.WriteLine(bar);
            Console.WriteLine();
            PrintLeftGap(leftGap);
            Console.WriteLine(" EN# 학사정보시스템 ");
            Console.WriteLine();
            Console.WriteLine(bar);
            PrintLeftGap(leftGap);
            Console.WriteLine(subtitle);
            Console.WriteLine(bar);

        }

        protected void PrintMenu(List<string> menu, int leftGap)  //메뉴리스트를 입력받아 출력
        {
            foreach (string item in menu)
            {
                PrintLeftGap(leftGap);
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

        protected void PrintFailMessage(string message, int leftGap)
        {
            PrintLeftGap(leftGap);
            Console.WriteLine(message);
            PrintLeftGap(leftGap);
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
        }

        protected void PrintOneRowLecture(LectureTable lecture)        //하나의 강의정보 한줄로 출력
        {
            string bar = new string('-', Console.LargestWindowWidth - 4);

            PrintOneCell(lecture.Key.ToString(), Constants.KEY);
            PrintOneCell(lecture.DepartmentOfOpening, Constants.DEPARTMENT);
            PrintOneCell(lecture.CourseNumber.ToString(), Constants.COURSE_NUMBER);
            PrintOneCell(lecture.DividedClassNumber, Constants.DIVIDED_CLASS_NUMBER);
            PrintOneCell(lecture.CourseTitle, Constants.COURSE_TITLE);
            PrintOneCell(lecture.Classification, Constants.CLASSIFICATION);
            PrintOneCell(lecture.Year.ToString(), Constants.YEAR);
            PrintOneCell(lecture.Credit.ToString(), Constants.CREDIT);
            PrintOneCell(lecture.DayAndLectureTime, Constants.LECTURE_TIME);
            PrintOneCell(lecture.LectureRoom, Constants.LECTURE_ROOM);
            PrintOneCell(lecture.ProfessorName, Constants.PROFESSOR_NAME);
            PrintOneCell(lecture.Language, Constants.LANGUAGE);

            Console.WriteLine(bar);

        }

        protected void PrintLectureItemName()
        {
            string bar = new string('-', Console.LargestWindowWidth - 4);   //강의 항목별 이름 출력


            PrintOneCell("NO", Constants.KEY);
            PrintOneCell("개설학과전공", Constants.DEPARTMENT);
            PrintOneCell("학수번호", Constants.COURSE_NUMBER);
            PrintOneCell("분반", Constants.DIVIDED_CLASS_NUMBER);
            PrintOneCell("교과목명", Constants.COURSE_TITLE);
            PrintOneCell("이수구분", Constants.CLASSIFICATION);
            PrintOneCell("학년", Constants.YEAR);
            PrintOneCell("학점", Constants.CREDIT);
            PrintOneCell("요일 및 강의시간", Constants.LECTURE_TIME);
            PrintOneCell("강의실", Constants.LECTURE_ROOM);
            PrintOneCell("교수명", Constants.PROFESSOR_NAME);
            PrintOneCell("강의언어", Constants.LANGUAGE);

            PrintOneCell(" ", Constants.KEY);
            PrintOneCell(" ", Constants.DEPARTMENT);
            PrintOneCell(" ", Constants.COURSE_NUMBER);
            PrintOneCell(" ", Constants.DIVIDED_CLASS_NUMBER);
            PrintOneCell(" ", Constants.COURSE_TITLE);
            PrintOneCell(" ", Constants.CLASSIFICATION);
            PrintOneCell(" ", Constants.YEAR);
            PrintOneCell(" ", Constants.CREDIT);
            PrintOneCell(" ", Constants.LECTURE_TIME);
            PrintOneCell(" ", Constants.LECTURE_ROOM);
            PrintOneCell(" ", Constants.PROFESSOR_NAME);
            PrintOneCell(" ", Constants.LANGUAGE);

            Console.WriteLine(bar);
        }

        private void PrintOneCell(string data, int type)         //type 으로 들어온 데이터 타입에 따라 강의 정보에서 한 요소를 출력함
        {
            switch (type)
            {
                case Constants.KEY:
                    Console.Write(data);
                    PrintSpace(4 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.DEPARTMENT:
                    Console.Write(data);
                    PrintSpace(19 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.COURSE_NUMBER:
                    Console.Write(data);
                    PrintSpace(8 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.DIVIDED_CLASS_NUMBER:
                    Console.Write(data);
                    PrintSpace(5 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.COURSE_TITLE:
                    Console.Write(data);
                    PrintSpace(32 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.CLASSIFICATION:
                    Console.Write(data);
                    PrintSpace(10 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.YEAR:
                    Console.Write(data);
                    PrintSpace(4 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.CREDIT:
                    Console.Write(data);
                    PrintSpace(5 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.LECTURE_TIME:
                    Console.Write(data);
                    PrintSpace(40 + -Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.LECTURE_ROOM:
                    if (data != null)
                    {
                        Console.Write(data);
                        PrintSpace(15 - Encoding.Default.GetByteCount(data));
                    }
                    else                //강의실이 없을 수있음
                    {
                        PrintSpace(15);
                    }
                    Console.Write("|");
                    break;

                case Constants.PROFESSOR_NAME:
                    Console.Write(data);
                    PrintSpace(27 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                case Constants.LANGUAGE:
                    Console.Write(data);
                    PrintSpace(8 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;

                default:
                    break;
            }
        }

        private void PrintSpace(int number)
        {
            string spaceBar = new string(' ', number);
            Console.Write(spaceBar);
        }

        public void PrintBlankTable(int line)
        {
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine(new string(' ', 188));
            }
        }
        public int SearchLecture(List<LectureTable> lecturetable, string word, int serchType)
        {
            int rowNumber = 0;

            if (word == null) return rowNumber;

            Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

            switch (serchType)
            {
                case Constants.DEPARTMENT:
                    foreach (LectureTable row in lecturetable)
                    {
                        if (row.DepartmentOfOpening.Contains(word) == true)
                        {
                            PrintOneRowLecture(row);
                            ++rowNumber;
                        }
                    }

                    break;

                case Constants.COURSE_TITLE:
                    foreach (LectureTable row in lecturetable)
                    {
                        if (row.CourseTitle.Contains(word) == true)
                        {
                            PrintOneRowLecture(row);
                            ++rowNumber;
                        }
                    }
                    break;
                case Constants.PROFESSOR_NAME:
                    foreach (LectureTable row in lecturetable)
                    {
                        if (row.ProfessorName.Contains(word) == true)
                        {
                            PrintOneRowLecture(row);
                            ++rowNumber;
                        }
                    }
                    break;
            }

            return rowNumber;
        }
        protected int SearchLecture(List<LectureTable> lecturetable, int number, int serchType)
        {
            int rowNumber = 0;

            if (number == Constants.WRONG_INPUT) return rowNumber;


            Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

            switch (serchType)
            {
                case Constants.COURSE_NUMBER:
                    foreach (LectureTable row in lecturetable)
                    {
                        if (row.CourseNumber == number)
                        {
                            PrintOneRowLecture(row);
                            ++rowNumber;
                        }
                    }
                    break;
                case Constants.YEAR:
                    foreach (LectureTable row in lecturetable)
                    {
                        if (row.Year == number)
                        {
                            PrintOneRowLecture(row);
                            ++rowNumber;
                        }
                    }
                    break;
            }
            return rowNumber;
        }

        protected void EnrollmentInInterest(MyLecture myLecture, List<LectureTable> interestTable, List<LectureTable> enrollmentTable)  //관심과목에서 수강신청 메소드
        {
            int addLectureNumber;
            int lectureTableIndex;

            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(17);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            Console.WriteLine();

            Console.Write("수강신청할 강의 NO. 입력 : ");
            addLectureNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, 160);

            if (addLectureNumber != Constants.WRONG_INPUT)
            {                
                if (myLecture.MyEnrollmentCredits <= 21)   //수강신청한 학점이 21 이하일 때만
                {
                    for (lectureTableIndex = 0; lectureTableIndex < myLecture.myInterestCourse.Count; lectureTableIndex++)  //입력받은 NO의 강의를 찾음
                    {
                        if (myLecture.myInterestCourse[lectureTableIndex].Key == addLectureNumber) break;
                    }

                    if (lectureTableIndex == myLecture.myInterestCourse.Count)        // 찾지못하면 종료
                    {
                        PrintFailMessage("강의를 찾을 수 없습니다.", 0);
                        return;
                    }
                    //강의를 찾은 경우
                    for (int Enrollment = 0; Enrollment < myLecture.mySucessfulCourse.Count; Enrollment++)
                    {
                        if (myLecture.mySucessfulCourse[Enrollment].CourseNumber == myLecture.myInterestCourse[lectureTableIndex].CourseNumber)
                        {
                            PrintFailMessage("학수번호가 같은 강의가 존재합니다.", 0);
                            return;
                        }
                    }

                    // 위에 조건들을 통과하면 수강신청 실행
                    //for(int i = 0;i < enrollmentTable.Count;i++)
                    //{
                    //    if (enrollmentTable[i].Key == myLecture.myInterestCourse[lectureTableIndex].Key)
                    //    {
                    //        myLecture.MyInterestCredits -= enrollmentTable[i].Credit;
                    //        myLecture.mySucessfulCourse.Add(enrollmentTable[i]);   //수강신청 성공
                    //        myLecture.MyEnrollmentCredits += enrollmentTable[i].Credit;
                    //        myLecture.myInterestCourse.RemoveAt(lectureTableIndex);
                    //        enrollmentTable.RemoveAt(i);

                    //        PrintFailMessage("수강신청을 완료 했습니다.", 0);

                    //        return;
                    //    }
                    //}

                    myLecture.MyInterestCredits -= myLecture.myInterestCourse[lectureTableIndex].Credit;
                    myLecture.mySucessfulCourse.Add(myLecture.myInterestCourse[lectureTableIndex]);   //수강신청 성공
                    myLecture.MyEnrollmentCredits += myLecture.myInterestCourse[lectureTableIndex].Credit;
                    myLecture.myInterestCourse.RemoveAt(lectureTableIndex);

                    PrintFailMessage("수강신청을 완료 했습니다.", 0);
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
        
        protected bool CheckOverlapTable(int[,] fixing, int[,] newOne) //시간표가 겹치는지 체크함

        {
            bool isOverlap = false;

            for (int row = 0; row < 24; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    if (fixing[row, column] == newOne[row, column] && fixing[row, column] == 1) 
                    {
                        isOverlap = true;
                        return isOverlap;
                    }
                }
            }

            return isOverlap;
        }

        protected void PrintTableBox(LectureTable OneLecture)
        {
            
        }
    }
}
