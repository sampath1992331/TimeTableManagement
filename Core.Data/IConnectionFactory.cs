﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
