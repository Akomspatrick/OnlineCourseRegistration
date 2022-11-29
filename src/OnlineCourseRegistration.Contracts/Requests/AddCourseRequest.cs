

using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;

namespace OnlineCourseRegistration.Contracts.Requests
{
    public class AddCourseRequest
    {
        public string CampId { get; init; }
        public string FacId { get; init; }
        public string StudentId { get; init; }
        public string Semester { get; init; }
        public string Session { get; init; }
        public string CourseId { get; init; }
    }
    public static class AddCourseRequestExtension{
    
        public static Course ToCourse(this AddCourseRequest request )
        {
            return new Course
            {
                CourseId = request.CourseId,
                StudentId = request.StudentId,
                semester = request.Semester,
                session = request.Session,
                FacId = request.FacId,
                CampId = request.CampId,

            };

        }
    
    }
}
