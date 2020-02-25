﻿using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Interfaces
{
    public interface ISize
    {
        IEnumerable<Size> GetSizes { get; }
    }
}
