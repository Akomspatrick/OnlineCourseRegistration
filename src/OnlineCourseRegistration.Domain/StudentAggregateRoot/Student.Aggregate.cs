using OnlineCourseRegistration.Domain.Base;
using OnlineCourseRegistration.Domain.Events;

namespace OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities
{
    public partial class Student : IAggregateRoot
    {
        //private void InitCourseRegistrationForm()
        //{
        //    //this will load the courseform 
        //    //throw new NotImplementedException();
        //}

        public void AddCourse(Course course)
        {
            var courselist = CourseRegistrationForms.Where(p => p.semester == course.semester && p.session == course.session).ToList();
            if (courselist != null)
            {
                //var cors = courselist.First().coursesForm.Select(p => p.CourseId == course.CourseId);
                 var cors = courselist.First().coursesForm.Where(p => p.CourseId == course.CourseId).FirstOrDefault();
                if (cors  == null)
                {
                    courselist[0].coursesForm.Add(course);


                    var addEvent = new CourseFormSubmittedDomainEvent()
                    {
                        courseRegistrationForm = courselist[0]
                    };

                    AddEventToList(addEvent);
                }
            }
            else
            {
                //  courselist.Add()
                // Courselist can never be null because it is always created , if it was not created it should come here
            }

        }

        public void DeleteCourse(Course course)

        {
            // this will remove a course from CourseForm
            var courselist = CourseRegistrationForms.Where(p => p.semester == course.semester && p.session == course.session).ToList();
            if (courselist != null)
            {
                var cors = courselist.First().coursesForm.Select(p => p.CourseId == course.CourseId);
                if (cors.Count() < 1)
                {
                    courselist[0].coursesForm.Remove(course);
                }
            }
            else
            {
                //  courselist.Add()
                // Courselist can never be null because it is always created , if it was not created it should come here
            }
        }

        public Course FindCourseInRegistrationForm(CourseRegistrationForm form, Course course)
        {
            var crs = form.coursesForm.Where(p => p.CourseId == course.CourseId).FirstOrDefault();

            return crs;

        }
        public CourseRegistrationForm FindCourseRegistrationForm(Course course)
        {
            var courselist = CourseRegistrationForms.Where(p => p.semester == course.semester && p.session == course.session).FirstOrDefault();
            if (courselist != null)
            {
                return courselist;
            }
            else
            {
                return CourseRegistrationForm.InitialiseCourseRegistrationForm(StudentId, course.session, course.semester, new List<Course>(), 0, 0);
            }
        }
        //public Student LoadCourseRegistrationForm_RemovebcItisSameAsInitbutNo( string Sem)
        //{
        //    // this is same as initcourseregform all these are to be loaded from the db using student Id 
        //    string session = "1";
        //    string semester = "1";
        //    var coursesForm = new List<Course>();
        //    int minPossibleTotalUnit = 1;
        //    int maxPossibleTotalUnit = 1;

        //    var corseregform = CourseRegistrationForm.InitialiseCourseRegistrationForm(this.StudentId,session, semester, coursesForm, minPossibleTotalUnit, maxPossibleTotalUnit);

        //    return new Student(this.StudentId , this.Name, new List<CourseRegistrationForm>() { corseregform });
        //}
        public void SaveCourseRegistrationForm(string MatricNo, int Sem)
        {
            // Just send an email containing the course saved
        }
    }
}
