using OnlineCourseRegistration.Contracts.Requests;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Contracts.Commands
{
    public class CourseCommand
    {
        public string CampId { get; init; }
        public string FacId { get; init; }
        public string StudentId { get; init; }
        public string Semester { get; init; }
        public string Session { get; init; }
        public string CourseId { get; init; }
    }

    public static class CourseCommandExtension
    {

        public static Course ToCourseDomainModel(this CourseCommand request)
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
