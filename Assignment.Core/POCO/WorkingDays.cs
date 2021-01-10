using Dapper.Contrib.Extensions;
using System;

namespace Core.POCO
{
    [Table("WorkingDays")]
    public class WorkingDays
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

    }
}
