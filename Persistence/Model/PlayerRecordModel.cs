using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Model
{
    public class PlayerRecordModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public int Score { get; set; }
        public int TimeSpent { get; set; }
    }
}
