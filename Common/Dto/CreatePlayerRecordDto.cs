using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Dto
{
    public class CreatePlayerRecordDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PlayerId { get; set; }
        
        [Required]
        public int Score { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public int TimeSpent { get; set; }
    }
}
