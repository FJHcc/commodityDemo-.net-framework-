using System;
using System.Collections.Generic;
using System.Text;

namespace Commodity.IService
{
    public interface ITagService
    {

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool NewTag(TagDto tag);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool DeleteTag(string name);

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool EditTag(TagDto tag, string name);

        /// <summary>
        /// 标签列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<TagDto> TagList();
    }
}
