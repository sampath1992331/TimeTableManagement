using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dapper
{
    public class TTMUnitOfWork: UnitOfWork, ITTMUnitOfWork
    {
        public TTMUnitOfWork(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
          
        }
    }
}
