using Camefor.Cache.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camefor.Cache.Redis
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
    /// 修改描述 ：  定义缓存接口                                 
    /// </summary> 
    public class CacheByRedis : ICache
    {
        #region Key-Value
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T Read<T>(string cacheKey, int dbId = 0) where T : class
        {
            return new RedisCache(dbId, null).StringGet<T>(cacheKey);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void Write<T>(string cacheKey, T value, int dbId = 0) where T : class
        {
            new RedisCache(dbId, null).StringSet<T>(cacheKey, value);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void Write<T>(string cacheKey, T value, TimeSpan expireTime, int dbId = 0) where T : class
        {
            new RedisCache(dbId, null).StringSet<T>(cacheKey, value, expireTime);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void Remove(string cacheKey, int dbId = 0)
        {
            new RedisCache(dbId, null).KeyDelete(cacheKey);
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveAll(int dbId = 0)
        {
            new RedisCache().FlushDatabase(dbId);
        }
        #endregion
        #region List

        #region 同步方法

        /// <summary>
        /// 移除指定ListId的内部List的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListRemove<T>(string cacheKey, T value, int dbId = 0) where T : class
        {
            new RedisCache(dbId, null).ListRemove<T>(cacheKey, value);
        }

        /// <summary>
        /// 获取指定key的List
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> ListRange<T>(string cacheKey, int dbId = 0) where T : class
        {
            return new RedisCache(dbId, null).ListRange<T>(cacheKey);
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListRightPush<T>(string cacheKey, T value, int dbId = 0) where T : class
        {
            new RedisCache(dbId, null).ListRightPush(cacheKey, value);
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ListRightPop<T>(string cacheKey, int dbId = 0) where T : class
        {
            return new RedisCache(dbId, null).ListRightPop<T>(cacheKey);

        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void ListLeftPush<T>(string cacheKey, T value, int dbId = 0) where T : class
        {
            new RedisCache(dbId, null).ListLeftPush<T>(cacheKey, value);
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ListLeftPop<T>(string cacheKey, int dbId = 0) where T : class
        {
            return new RedisCache(dbId, null).ListLeftPop<T>(cacheKey);
        }

        /// <summary>
        /// 获取集合中的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long ListLength(string cacheKey, int dbId = 0)
        {
            return new RedisCache(dbId, null).ListLength(cacheKey);
        }

        #endregion 同步方法

        #endregion List
    }
}
