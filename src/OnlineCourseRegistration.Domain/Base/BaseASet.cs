using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseRegistration.Domain.Base
{

    public record BaseOfASet(string CampId, string FacId, string DeptId, string ProgId, string ProgOptionId,
        string AsetId);


}
