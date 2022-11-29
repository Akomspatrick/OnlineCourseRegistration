

using OnlineCourseRegistration.Domain.Base;

namespace OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities
{

    //public record Course(string CampId, string FacId, string DeptId, string ProgId, string ProgOptionId, string AsetId,
    //    string AsessionId, string SemesterId, string CourseId, string CourseName, decimal CourseUnit, string LevelToDo,
    //    string CourseNature, string HasPreq, string LecturesInCharge, string Venue, string Theprog);

    // public record Course(string CampId, string FacId,  string semester , string CourseId );
    public class Course : BaseEntity<string>
    {   public string CourseId { get; set; }
        public string CampId { get; set; }
        public string FacId { get; set; }
        public string semester { get; set; }
        public string session { get; set; }
        // public ICollection <CourseRegistrationForm>  CourseRegistrationForm { get; set; }
        public CourseRegistrationForm  CourseRegistrationForm { get; set; }


       // public static bool  operator == (Course lhs, Course rhs)=> lhs.CourseId.Equals (rhs.CourseId);

       // public static bool operator !=(Course lhs, Course rhs) =>! lhs.CourseId.Equals(rhs.CourseId);

    }
    public class Coursexxx
    {
        public string CampId { get; init; }
        public string FacId { get; init; }
        public string DeptId { get; init; }
        public string ProgId { get; init; }
        public string ProgOptionId { get; init; }

        public string AsetId { get; init; }
        public string AsessionId { get; init; }
        public string SemesterId { get; init; }
        public string CourseId { get; init; }
        public string CourseName { get; init; }
        public string CourseUnit { get; init; }
        public string LevelToDo { get; init; }
        public string CourseNature { get; init; }
        public string HasPreq { get; init; }
        public string LecturesInCharge { get; init; }
        public string Venue { get; init; }
        public string ProgType { get; init; }


        public Coursexxx(string CampId, string FacId, string DeptId, string ProgId, string ProgOptionId, string AsetId, string AsessionId, string SemesterId, string CourseId, string CourseName, decimal CourseUnit, string LevelToDo, string CourseNature, string HasPreq, string LecturesInCharge, string Venue, string Theprog)
        {
            //myCampId = CampId;
            //myFacId = FacId;
            //myDeptId = DeptId;
            //myProgId = ProgId;
            //myProgOptionId = ProgOptionId;
            //myAsetId = AsetId;
            //myAsessionId = AsessionId;
            //mySemesterId = SemesterId;
            //myCourseId = CourseId;
            //myCourseName = CourseName;
            //myCourseUnit = CourseUnit;
            //myLevelToDo = LevelToDo;
            //myCourseNature = CourseNature;
            //myHasPreq = HasPreq;
            //myLecturesInCharge = LecturesInCharge;
            //myVenue = Venue;
            //myTheprog = Theprog;

        }
    }
}
