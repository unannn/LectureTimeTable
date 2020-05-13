using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    class LectureTable
    {
        private int key;
        private string departmentOfOpening;
        private int courseNumber;
        private int dividedClassNumber;
        private string courseTitle;
        private string classification; //이수구분 (전공필수 등)
        private int year;    //학년
        private double credit; // 학점
        private string dayAndLectureTime;
        private string lectureRoom;
        private string professorName;
        private string language;
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

        public int DividedClassNumber
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
        public LectureTable(int key,string departmentOfOpening,int courseNumber, int dividedClassNumber,string courseTitile,string classification,int year, double credit,string dayAndLectureTime,string lectureRoom,string professorName,string language )
        {
            this.key = key;
            this.departmentOfOpening = departmentOfOpening;
            this.courseNumber = courseNumber;
            this.dividedClassNumber = dividedClassNumber;
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
