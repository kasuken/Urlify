using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urlify.Shared;

namespace Urlify.Server
{
    public interface IUrlifyService
    {
        IEnumerable<UrlifyLink> FindAll();
        UrlifyLink FindOne(int id);
        int Insert(UrlifyLink url);
        bool Update(UrlifyLink url);
    }
}
