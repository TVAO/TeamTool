﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTool.Models.Entities;

namespace TeamTool.Models.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetAllEnumerable();
    }
}
