//using Domain.Interfaces;

using LanguageExt;

using MediatR;


using OnlineCourseRegistration.Application.Contracts.Commands;
using OnlineCourseRegistration.Application.Interfaces;
using OnlineCourseRegistration.Contracts.Requests;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace OnlineCourseRegistration.Application.Handlers
{
    public class AddNewCourseCommandHandler : //BaseService,
                                              IRequestHandler<AddNewCourseCommand, Either<string, int>>
    {
        
       private readonly IUnitOfWork _unitOfWork;
       private readonly IStudentRepository<Student> _studentRepository;
        public AddNewCourseCommandHandler( IUnitOfWork unitOfWork, IStudentRepository<Student> studentRepository) //: base(unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
        }

       // public record StudentName(string Firstname, string Lastname);

        public async Task<Either<string, int>> Handle(AddNewCourseCommand request, CancellationToken cancellationToken)
        {
          
            var users = await AddNewCourseAsync(request.course ,_studentRepository);
            return users;

        }
        public async Task<Either<string, int>> AddNewCourseAsync(CourseCommand model, IStudentRepository<Student> _studentRepository)
        {

   
            var Eitherastudent = await _studentRepository.GetWtExtension(filter: s => s.StudentId == model.StudentId, includeProperties: "CourseRegistrationForms.coursesForm");
            return  Eitherastudent.
                Map<Student>(GetActualStudent)
               .Bind (x => AddACourse(x, model, _studentRepository).Result);
          


        }
        private async Task<Either<string, int>> AddACourse(Student astudent, CourseCommand model, IStudentRepository<Student> _studentRepository)
        {
            try
            {             
                astudent.AddCourse(model.ToCourseDomainModel());
                await _studentRepository.UpdateAsync(astudent);
                var x = await _unitOfWork.SaveChangesAsync();
                return Right(x);
            }
            catch (Exception ex)
            {

                return Left(ex.ToString());
            }
        }
        private async Task<Either<string,int>> AddACourseOld(Student astudent, CourseCommand model  , IStudentRepository<Student> _studentRepository)
        {
            try
            {
                var newCourse = model.ToCourseDomainModel();
            var result = astudent.FindCourseRegistrationForm(newCourse);
            if (result != null)
            {
                astudent.AddCourse(newCourse);

                var crs = astudent.FindCourseInRegistrationForm(result, newCourse);
                if (crs == null)
                {
                    result.coursesForm.Add(newCourse);
                     
                }
            }
                await _studentRepository.UpdateAsync(astudent);
             //   await repository.UpdateAsync(astudent);
           

                var x = await _unitOfWork.SaveChangesAsync();
                return Right(x);
            }
            catch (Exception ex)
            {

                return Left(ex.ToString());
            }
        }


        private Student GetActualStudent(IEnumerable<Student> studentlist)
        {
            return studentlist.First();
        }




        //public async Task<AddCourseResponse> AddNewCourseAsync2(AddCourseRequest model)
        //{

        //    var repository = _unitOfWork.AsyncRepository<Student>();
        //    var astudent = repository.Get(filter: s => s.StudentId == model.StudentId, includeProperties: "CourseRegistrationForms.coursesForm").First();

        //    if (astudent != null)
        //    {
        //        var newCourse = model.ToCourse();
        //        var result = astudent.FindCourseRegistrationForm(newCourse);
        //        if (result != null)
        //        {
        //            var crs = astudent.FindCourseInRegistrationForm(result, newCourse);
        //            if (crs == null)
        //            {
        //                result.coursesForm.Add(newCourse);
        //            }
        //        }

        //        await repository.UpdateAsync(astudent);

        //        await _unitOfWork.SaveChangesAsync();

        //        return new AddCourseResponse(model.CampId, model.FacId);

        //    }

        //    throw new Exception("User not found.");
        //}

    }
}
