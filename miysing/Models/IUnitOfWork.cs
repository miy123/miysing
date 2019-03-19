﻿using miysing.Repositories.Interface;
using miysing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miysing.Models
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository Song { get;}
        ISongRecordRepository SongRecord { get; }
        int Complete();
    }
}
