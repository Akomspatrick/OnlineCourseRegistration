using FluentValidation;
//using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace NewOnlineCourseReg.Application.Behaviours
{
    internal class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :
        IRequest<TResponse>
    {
        public readonly IEnumerable<IValidator <TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        //{
        //     var context = new ValidationContext(request);

        //    var failures = _validators
        //        .Select(v=>v.Validate(context))
        //        .SelectMany(v=>v.Errors)
        //        .Where(f=>f != null).ToList();
        //    if (failures.Count !=0)
        //    {
        //        throw new ValidationException(failures);
        //    }
        //    return next();
        //}
    }
}
