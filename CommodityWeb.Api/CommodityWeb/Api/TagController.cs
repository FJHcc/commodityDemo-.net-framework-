using Commodity.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommodityWeb.Api
{
    /// <summary>
    /// 标签Api
    /// </summary>
    public class TagController : ApiController
    {
        #region 申明服务变量
        private readonly ITagService _tagService;
        #endregion

        #region 构造函数，依赖注入
        /// <summary>
        /// 构造函数，依赖注入
        /// </summary>
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        #endregion



        #region 标签
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        public bool NewTag(TagDto tag)
        {
            return true;
        }
        #endregion
    }
}
