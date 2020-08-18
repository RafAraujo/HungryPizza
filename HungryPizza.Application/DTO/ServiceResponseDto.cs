using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.Application.DTO
{
    public class ServiceResponseDto
    {
        public bool Success
        {
            get => !Errors.Any();
        }

        public object Result { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
