using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class CreatePlayerDto
    {
        [Required]
        //Todo: Add stringlength
        public string Name { get; set; }
    }
}
