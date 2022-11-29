using LanguageExt;
using MediatR;

using OnlineCourseRegistration.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Application.Contracts.Commands
{
    public record AddNewCourseCommand(CourseCommand course) : IRequest<Either<string, int>>;

}
