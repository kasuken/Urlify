using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urlify.Server;
using Urlify.Shared;

public class LiteDbUrlifyService : IUrlifyService
{
    private LiteDatabase _liteDb;

    public LiteDbUrlifyService(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
    }

    public IEnumerable<UrlifyLink> FindAll()
    {
        return _liteDb.GetCollection<UrlifyLink>("UrlifyLinks")
            .FindAll();
    }

    public UrlifyLink FindOne(int id)
    {
        return _liteDb.GetCollection<UrlifyLink>("UrlifyLinks")
            .Find(x => x.Id == id).FirstOrDefault();
    }

    public int Insert(UrlifyLink url)
    {
        return _liteDb.GetCollection<UrlifyLink>("UrlifyLinks")
            .Insert(url).AsInt32;
    }

    public bool Update(UrlifyLink url)
    {
        return _liteDb.GetCollection<UrlifyLink>("UrlifyLinks")
            .Update(url);
    }
}

