using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class MyLecture
    {
        public List<LectureTable> myInterestCourse;
        public List<LectureTable> mySucessfulCourse;

        private double myInterestCredits;
        private double myEnrollmentCredits;

        public double MyInterestCredits
        {
            get { return myInterestCredits; }
            set { myInterestCredits = value; }
        }

        public double MyEnrollmentCredits
        {
            get { return myEnrollmentCredits; }
            set { myEnrollmentCredits = value; }
        }

        public MyLecture()
        {
            myInterestCourse = new List<LectureTable>();
            mySucessfulCourse = new List<LectureTable>();
            myInterestCredits = 0;
            myEnrollmentCredits = 0;
        }

    }
}
