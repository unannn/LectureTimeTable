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
        }       
    }
}
