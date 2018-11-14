using System.Web.Http;
using WebActivatorEx;
using CommodityWeb;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CommodityWeb
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "CommodityWeb");
                        //将xml注释文件引入
                        c.IncludeXmlComments(string.Format("{0}/bin/CommodityWeb.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}
