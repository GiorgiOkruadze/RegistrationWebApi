using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.ValidationErrors
{
    public class ErrorResponse
    {
        public IEnumerable<ErrorMessage> Errors { get; set; } = new List<ErrorMessage>();
    }
}
