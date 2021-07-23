using Repository.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IAdapterInterface
    {
        IRepository repos { get; }
    }
}
