using API.Model;
using API.Repository;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Adapter 
{
    public class AdapterClass : IAdapterInterface
    {
        public IRepository repos { get; }

        public AdapterClass(IMapper mapper, IConfiguration configuration)
        {
            repos = new ModelBase(mapper, configuration);
        }
    }
}
