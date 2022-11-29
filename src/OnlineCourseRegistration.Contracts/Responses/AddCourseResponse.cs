namespace OnlineCourseRegistration.Contracts.Responses
{
    //public class AddCourseResponse
    //{
    //    public string CampId { get; init; }
    //    public string FacId { get; init; }
    //}
    public record AddCourseResponse(
        string CampId,
        string FacId);
}
