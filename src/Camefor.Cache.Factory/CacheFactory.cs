using Camefor.Cache.Base;
using Camefor.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camefor.Cache.Factory
{
    /// <summary>
    /// 描   述  ：                          
    /// 版   本  ： V1.0.0                            
    /// 创 建 人 ： rhyswang                                  
    /// 日    期 ：                         
    /// 创 建 人 ：                                   
    /// 创建时间 ：                                  
    /// 修 改 人 ：                                   
    /// 修改时间 ：                                   
    /// 修改描述 ： 定义缓存工厂类                                  
    /// </summary> 
    public class CacheFactory
    {
        /// <summary>
        /// 获取缓存实例
        /// </summary>
        /// <returns></returns>
        public static ICache CaChe()
        {
            return new CacheByRedis();
        }
    }
}
