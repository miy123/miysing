using miysing.Repositories.Interface;
using miysing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eip.Models
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository Song { get;}

        int Complete();
    }
}
