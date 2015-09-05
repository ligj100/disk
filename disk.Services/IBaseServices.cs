using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core;

namespace disk.Services
{
    public partial interface IBaseServices<T> where T:BaseEntity
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Modify(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 根据Id获取实体数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetById(int Id);
    }
}
