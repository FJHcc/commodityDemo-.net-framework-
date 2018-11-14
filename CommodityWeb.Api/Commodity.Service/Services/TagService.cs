using Commodity.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commodity.Service.Services
{
    public class TagService : ITagService
    {
        public bool DeleteTag(string name)
        {
            throw new NotImplementedException();
        }

        public bool EditTag(TagDto tag, string name)
        {
            throw new NotImplementedException();
        }

        public bool NewTag(TagDto tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagDto> TagList()
        {
            throw new NotImplementedException();
        }
    }
}
