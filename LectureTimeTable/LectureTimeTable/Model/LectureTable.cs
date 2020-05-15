using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class LectureTable
    {
        private int key;                    //primary key
        private string departmentOfOpening;  //개설학과전공
        private int courseNumber;            //학수번호
        private string dividedClassNumber;        //분반
        private string courseTitle;            //교과목명
        private string classification; //이수구분 (전공필수 등)
        private int year;    //학년
        private double credit; // 학점
        private string dayAndLectureTime;     //요일및강의시간
        private string lectureRoom;             //강의실
        private string professorName;          //교수명
        private string language;              //언어
        private string[] separatedTime;
        public int[,] timeTable;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public string DepartmentOfOpening
        {
            get { return departmentOfOpening; }
            set { departmentOfOpening = value; }
        }

        public int CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }

        public string DividedClassNumber
        {
            get { return dividedClassNumber; }
            set { dividedClassNumber = value; }
        }

        public string CourseTitle
        {
            get { return courseTitle; }
            set { courseTitle = value; }
        }
        
        public string Classification
        {
            get { return classification; }
            set { classification = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public string DayAndLectureTime
        {
            get { return dayAndLectureTime; }
            set { dayAndLectureTime = value; }
        }
        public string LectureRoom
        {
            get { return lectureRoom; }
            set { lectureRoom = value; }
        }
        public string ProfessorName
        {
            get { return professorName; }
            set { professorName = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value;}
        }

        public LectureTable(int key,string departmentOfOpening,int courseNumber, string dividedClassNumber,string courseTitle,string classification,int year, double credit,string dayAndLectureTime,string lectureRoom,string professorName,string language )
        {
            this.key = key;
            this.departmentOfOpening = departmentOfOpening;
            this.courseNumber = courseNumber;
            this.dividedClassNumber = dividedClassNumber;
            this.courseTitle = courseTitle;
            this.classification = classification;
            this.year = year;
            this.credit = credit;
            this.dayAndLectureTime = dayAndLectureTime;
            this.lectureRoom = lectureRoom;
            this.professorName = professorName;
            this.language = language;
            timeTable = new int[24, 5];                    //시간정보 담을 배열 크기 설정


            separatedTime = dayAndLectureTime.Split(' ');  //날짜및 시간 문자열 자르기

            if (separatedTime.Length == 5)                  //,없애기
            {
                separatedTime[2] = separatedTime[2].Substring(0, 11);
            }
            else if (separatedTime.Length == 4)
            {
                separatedTime[1] = separatedTime[1].Substring(0, 11);
            }

            InitializeArrayToZero(ref timeTable);


            switch (separatedTime.Length)
            {
                case 2:
                    SetTwoStringTime(ref timeTable, separatedTime);
                    break;
                case 3:
                    SetThreeStringTime(ref timeTable, separatedTime);
                    break;
                case 4:
                    SetFourStringTime(ref timeTable, separatedTime);
                    break;
                case 5:
                    SetFiveStringTime(ref timeTable, separatedTime);
                    break;
            }
        }

        private void InitializeArrayToZero(ref int[,] timeTable)
        {
            for(int row = 0;row < 24; row++)
            {
                for(int column = 0;column < 5; column++)
                {
                    timeTable[row,column] = 0;
                }
            }
        }

        private void SetTwoStringTime(ref int[,] timeTable,string[] separatedTime)
        {
            string[] startANdEnd = separatedTime[1].Split('~');
            string start = startANdEnd[0];
            string end = startANdEnd[1];
            double startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1])/60.0;
            double endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;
            int day = 0;
                    
            day = ReturnDay(separatedTime[0]);
            
            for(double st = startTime;st < endTime;st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }
        }

        private void SetThreeStringTime(ref int[,] timeTable, string[] separatedTime)
        {
            string[] startANdEnd = separatedTime[2].Split('~');
            string start = startANdEnd[0];
            string end = startANdEnd[1];
            double startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1]) / 60.0;
            double endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;
            int day = 0;

            day = ReturnDay(separatedTime[0]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }

            day = ReturnDay(separatedTime[1]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }
        }

        private void SetFourStringTime(ref int[,] timeTable, string[] separatedTime)
        {
            string[] startANdEnd = separatedTime[1].Split('~');
            string start = startANdEnd[0];
            string end = startANdEnd[1];
            double startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1]) / 60.0;
            double endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;
            int day = 0;

            day = ReturnDay(separatedTime[0]);            //앞의 요일

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }

            startANdEnd = separatedTime[3].Split('~');  //뒤의 요일
            start = startANdEnd[0];
            end = startANdEnd[1];
            startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1]) / 60.0;
            endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;

            day = ReturnDay(separatedTime[2]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }
        }

        private void SetFiveStringTime(ref int[,] timeTable, string[] separatedTime)
        {
            string[] startANdEnd = separatedTime[2].Split('~');
            string start = startANdEnd[0];
            string end = startANdEnd[1];
            double startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1]) / 60.0;
            double endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;
            int day = 0;

            day = ReturnDay(separatedTime[0]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }

            day = ReturnDay(separatedTime[1]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }

            startANdEnd = separatedTime[4].Split('~');  //뒤의 요일
            start = startANdEnd[0];
            end = startANdEnd[1];
            startTime = double.Parse(start.Split(':')[0]) + double.Parse(start.Split(':')[1]) / 60.0;
            endTime = double.Parse(end.Split(':')[0]) + double.Parse(end.Split(':')[1]) / 60.0;

            day = ReturnDay(separatedTime[3]);

            for (double st = startTime; st < endTime; st += 0.5)
            {
                timeTable[Convert.ToInt32(st * 2) - 16, day] = 1;
            }
        }

        private int ReturnDay(string dayInString)
        {
            int day = 0;

            switch (dayInString)
            {
                case "월":
                    day = Constants.MONDAY;
                    break;
                case "화":
                    day = Constants.TUESNDAY;
                    break;
                case "수":
                    day = Constants.WEDNESDAY;
                    break;
                case "목":
                    day = Constants.THURSDAY;
                    break;
                case "금":
                    day = Constants.FRIDAY;
                    break;
            }

            return day;
        }
    }
}
