using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;


namespace OnlineCourseRegistration.Controllers
{
    public static class IActionResultExtension
    {
        public static ObjectResult ToResponse<L, R>(this Either<L, R> result, ControllerBase ctrlr )
        {
            return result.Match<ObjectResult>(
                             Left: value => ctrlr.NotFound("Baddd"),
                             Right: value => ctrlr. Ok(value));
        }



    }
}
