﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestHelper.IDataAccessLayer
{
    public interface IInputData
    {
        Task<IEnumerable<Tuple<DateTime, string>>> GetRawDataAsync(DateTime start, DateTime end);
    }
}
