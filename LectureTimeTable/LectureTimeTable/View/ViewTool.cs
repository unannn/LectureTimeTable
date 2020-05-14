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
        protected void PrintTitle(int leftGap)           //제목 출력
        {
            string bar = new string('-', Console.LargestWindowWidth - 4);
            

            Console.WriteLine(bar);
            Console.WriteLine(bar);
            Console.WriteLine();
            PrintLeftGap(leftGap);
            Console.WriteLine(" EN# 학사정보시스템 ");
            Console.WriteLine();
            Console.WriteLine(bar);
            Console.WriteLine(bar);

        }

        protected void PrintMenu(List<string> menu, int leftGap)  //메뉴리스트를 입력받아 출력
        {
            foreach (string item in menu)
            {
                Console.WriteLine();
                PrintLeftGap(leftGap);
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

        protected void PrintFailMessage(string message,int leftGap)
        {
            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);
            Console.WriteLine(message);
            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);
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

            Console.WriteLine();
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
            
            Console.WriteLine(bar);
        }

        private void PrintOneCell(string data,int type)
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
                case Constants. CREDIT:
                    Console.Write(data);
                    PrintSpace(5 - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;
                case Constants.LECTURE_TIME:
                    Console.Write(data);
                    PrintSpace(40+ - Encoding.Default.GetByteCount(data));
                    Console.Write("|");
                    break;
                case Constants.LECTURE_ROOM:
                    if (data != null)
                    {
                        Console.Write(data);
                        PrintSpace(15 - Encoding.Default.GetByteCount(data));
                    }
                    else
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
    }
}
