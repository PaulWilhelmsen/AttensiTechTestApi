using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto
{
    public class PlayerRecordDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public int Score { get; set; }
        public int TimeSpent { get; set; }
    }
}
