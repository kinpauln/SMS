/* ***********************************************
 * 作者 :汤晓华/tension 任何转载请务必保留此头部信息 版权所有 盗版必究
 * Email:kinpauln@126.com
 * 描述 :
 * 创建时间:2011-10-17 22:50:26
 * 修改历史:
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;
using System.Xml.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace SMS.UI.Mvc3.Demo.Helpers
{
    public static class RouteHelper
    {
        /// <summary>
        /// 从XML文件中注册路由规则
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="cfgFile"></param>
        public static void Register(this RouteCollection routes, string cfgFile)
        {

            IList<Route> Routes = GetRoutes(cfgFile);

            foreach (var item in Routes)
            {
                //路由规则对象
                object obj = CreateObjectFormString(item.ToString(), item.Name);
                routes.MapRoute(
                       item.Name,               // Route name
                       item.Url,                // URL with parameters
                        obj                     // Parameter defaults
                   );

            }
        }

        /// <summary>
        ///  从XML文件中注册路由规则 默认文件为网站根目录下MapRoute.config
        /// </summary>
        /// <param name="routes"></param>
        public static void Register(this RouteCollection routes)
        {
            Register(routes, string.Format("{0}\\{1}", ServerInfo.GetRootPath(),System.Configuration.ConfigurationManager.AppSettings["RouteConfigName"]));
        }


        /// <summary>
        /// 从string动态创建类对象
        /// </summary>
        /// <param name="codeString"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        private static object CreateObjectFormString(string codeString, string className)
        {
            CSharpCodeProvider ccp = new CSharpCodeProvider();
            CompilerParameters param = new CompilerParameters(new string[] { "System.dll" });
            CompilerResults cr = ccp.CompileAssemblyFromSource(param, codeString);
            Type type = cr.CompiledAssembly.GetType(className);
            return type.GetConstructor(System.Type.EmptyTypes).Invoke(null);
        }

        /// <summary>
        /// 从XML文件中解析路由规则
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        private static IList<Route> GetRoutes(string configFile)   
        {
            StringBuilder sb = new StringBuilder();


            Console.WriteLine(sb.ToString());
            IList<Route> Routes = new List<Route>();

            XElement xe = XElement.Load(configFile);

            #region MyRegion
            foreach (var item in xe.Elements("MapRoute"))
            {

                //名称属性
                XAttribute xaName = item.Attribute("name");
                if (xaName == null || string.IsNullOrEmpty(xaName.Value))
                {
                    throw new ArgumentNullException("name！说明：路由配置文件中某规则缺少name属性或name属性的值为空字符串");
                }

                //URL属性
                XAttribute urlName = item.Attribute("url");
                if (urlName == null || string.IsNullOrEmpty(urlName.Value))
                {
                    throw new ArgumentNullException("url！说明：路由配置文件中某规则缺少url属性或url属性的值为空字符串");
                }


                Dictionary<string, string> DictParams = new Dictionary<string, string>();



                #region MyRegion
                foreach (var pItem in item.Element("Params").Elements("Item"))
                {
                    XAttribute itemKey = pItem.Attribute("key");
                    if (itemKey == null || string.IsNullOrEmpty(itemKey.Value))
                    {
                        throw new ArgumentNullException("Item->key！说明：路由配置文件中某规则缺少Item->key属性或Item->key属性的值为空字符串");
                    }

                    XAttribute itemDefault = pItem.Attribute("default");
                    if (itemDefault == null || string.IsNullOrEmpty(itemDefault.Value))
                    {
                        throw new ArgumentNullException("Item->default！说明：路由配置文件中某规则缺少Item->default属性或Item->default属性的值为空字符串");
                    }
                    DictParams.Add(itemKey.Value, itemDefault.Value);
                }
                #endregion

                Routes.Add(new Route() { Name = xaName.Value, Url = urlName.Value, Params = DictParams });


            }
            #endregion

            return Routes;
        }
    }


    /// <summary>
    /// 路由规则
    /// </summary>
    public class Route
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Params { get; set; }

        /// <summary>
        /// 重写ToString 方法 产生需要动态代码段
        /// </summary> 
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("public class {0}", Name);
            sb.Append("{");
            foreach (var item in Params)
            {
                sb.AppendFormat("public string {0}", item.Key);
                sb.Append("{get{return \"");
                sb.Append(item.Value);
                sb.Append("\";}} ");
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}
