using System.Collections.Generic;
using System.Collections.Specialized;
using WebApplication3StarWars.Domain;
using WebApplication3StarWars.Services.Factory;
using WebApplication3StarWars.Services.Splitter;

namespace WebApplication3StarWars.Services.Repository
{
    public class SaveRepository : ISaveRepository 
    {
        private readonly ISplitter _splitter;
        private readonly IRebelFactory _rebelFactory;

        public SaveRepository(ISplitter splitter, IRebelFactory rebelFactory)
        {
            _splitter = splitter;
            _rebelFactory = rebelFactory;
        }

        public List<Rebel> SaveRebels(StringCollection rebelStringCollection)
        {
            var rebelList = new List<Rebel>();
            
            foreach (var item in rebelStringCollection)
            {
                var data = _splitter.Split(item);
                var rebel = _rebelFactory.Create(data[0], data[1]);
                rebelList.Add(rebel);
            }

            return rebelList;
        }

    }
}
