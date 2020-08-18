using System;
using System.Collections.Generic;

namespace HungryPizza.API.DTO
{
    public class ApiResponseDto
    {
        public bool Success { get; set; } = true;

        public object Result { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public Exception Exception { get; set; }
    }
}
