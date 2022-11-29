

using OnlineCourseRegistration.Domain.Base;

namespace NewOnlineCourseReg.Infrastructure.Data.Repositories.Models
{
    public class CourseRegistrationForm : BaseEntity<string>
    {
        public ICollection<Course> coursesForm { get; init; } = new List<Course>();// this is the registered
                                                                                   //  public ICollection<Course> recommendedListOfCourse { get; init; } = new List<Course>();
                                                                                   // public ICollection<Course> semesterPoolOfCourses { get; init; } = new List<Course>();
        public virtual Student student { get; init; }

        public string semester { get; }
        public string session { get; init; }
        public int minPossibleTotalUnit { get; init; }
        public int maxPossibleTotalUnit { get; init; }

        public CourseRegistrationForm() { }

        private CourseRegistrationForm(string studenId, string session, string semester, ICollection<Course> coursesForm, int minPossibleTotalUnit, int maxPossibleTotalUnit)
        {
            StudentId = studenId;
            this.semester = semester;
            this.session = session;
            this.coursesForm = coursesForm;
            this.minPossibleTotalUnit = minPossibleTotalUnit;
            this.maxPossibleTotalUnit = maxPossibleTotalUnit;
            //
        }

        public static CourseRegistrationForm InitialiseCourseRegistrationForm(string studenId, string session, string semester, ICollection<Course> coursesForm, int minPossibleTotalUnit, int maxPossibleTotalUnit)
        {
            //do all the required stuff and load data from db 
            // if this result in error then terminate process 
            // take care of this later with Monads
            return new CourseRegistrationForm(studenId, session, semester, coursesForm, minPossibleTotalUnit, maxPossibleTotalUnit);
        }

    }
}
