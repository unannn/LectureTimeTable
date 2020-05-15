using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    static class Constants
    {
        //현재 메뉴 상태
        public const int START_MENU = 0;
        public const int INTEREST_COURSE = 1;
        public const int ENROLLMENT = 2;
        public const int CURRENT_TIMETABLE = 3;
        public const int PROGRAM_END = 4;
        //UI정렬 관련
        public const int INITIAL_TITLE_BOARDER = 90;

        //사용자 입력 관련
        public const int START_NUMBER = 1;
        public const int WRONG_INPUT = -1;
        public const string WRONG_STRING = null;

        // 데이터 타입
        public const int KEY = 1;
        public const int DEPARTMENT = 2;
        public const int COURSE_NUMBER = 3;
        public const int DIVIDED_CLASS_NUMBER = 4;
        public const int COURSE_TITLE = 5;
        public const int CLASSIFICATION = 6;
        public const int YEAR = 7;
        public const int CREDIT = 8;
        public const int LECTURE_TIME = 9;
        public const int LECTURE_ROOM = 10;
        public const int PROFESSOR_NAME = 11;
        public const int LANGUAGE = 12;

        //관심과목담기

        public const int My_INTEREST_LECTURES = 1;
        public const int INTEREST_LECTURE_SEARCHING = 2;
        public const int INTEREST_LECTURE_DELETION = 3;
        public const int INTEREST_LECTURE_ENDING = 4;

        //수강신청

        public const int My_ENROLLMENT_LECTURES = 1;
        public const int START_ENROLLMENT = 2;
        public const int ENROLLMENT_LECTURE_DELETION = 3;
        public const int ENROLLMENT_ENDING = 4;

        //출력 후 첫줄 좌표
        public const int UNDER_TITLE_Y = 11;
        public const int UNDER_TABLE_Y = 35;

        //날짜

        public const int MONDAY = 0;
        public const int TUESNDAY = 1;
        public const int WEDNESDAY = 2;
        public const int THURSDAY = 3;
        public const int FRIDAY = 4;

    }
}
