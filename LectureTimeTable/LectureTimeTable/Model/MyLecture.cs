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

        private double myCurrentCredits;

        public double MyCurrentCredits
        {
            get { return myCurrentCredits; }
            set { myCurrentCredits = value; }
        }

        public MyLecture()
        {
            myInterestCourse = new List<LectureTable>();
            mySucessfulCourse = new List<LectureTable>();
            myCurrentCredits = 0;
        }

    }
}
