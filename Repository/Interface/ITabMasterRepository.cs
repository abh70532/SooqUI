﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
    public interface ITabMasterRepository
    {
        Task<List<TabMaster>> GetAllTabSource();
    }
}
