using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Contracts.Commands
{
    internal class AddNewCourseCommandValidator : AbstractValidator<AddNewCourseCommand>
    {
        public AddNewCourseCommandValidator()
        {
            RuleFor(v => v.course.CourseId).MinimumLength(3).MaximumLength(6).NotEmpty();
           // RuleFor(v => v.course.CourseId).MaximumLength(6).MaximumLength(6).NotEmpty();



        }
    }


}
