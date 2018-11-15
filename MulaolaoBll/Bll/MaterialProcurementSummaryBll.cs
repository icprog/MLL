using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class MaterialProcurementSummaryBll
    {
        private readonly Dao.MaterialProcurementSummaryDao _dao=new Dao.MaterialProcurementSummaryDao();

        /// <summary>
        /// 生成337
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GenerateGun ( string oddNum )
        {
            return _dao . GenerateGun ( oddNum );
        }

        /// <summary>
        /// 获取337数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunList ( string strWhere )
        {
            return _dao . GetDataTableOfGunList ( strWhere );
        }

        /// <summary>
        /// 保存337数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfGum ( DataTable table )
        {
            return _dao . saveOfGum ( table );
        }

        /// <summary>
        /// 删除337数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfGun ( string oddNum )
        {
            return _dao . deleteOfGun ( oddNum );
        }


        /// <summary>
        /// 生成338
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GenerateOfJiao ( string oddNum )
        {
            return _dao . GenerateOfJiao ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfJiaoList ( string strWhere )
        {
            return _dao . GetDataTableOfJiaoList ( strWhere );
        }

        /// <summary>
        /// 删除338数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfJiao ( string oddNum )
        {
            return _dao . deleteOfJiao ( oddNum );
        }

        /// <summary>
        /// 保存338数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfJiao ( DataTable table )
        {
            return _dao . saveOfJiao ( table );
        }

        /// <summary>
        /// 343生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateChe ( string oddNum )
        {
            return _dao . GenerateChe ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCheList ( string strWhere )
        {
            return _dao . GetDataTableOfCheList ( strWhere );
        }

        /// <summary>
        /// 保存343数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfChe ( DataTable table )
        {
            return _dao . saveOfChe ( table );
        }

        /// <summary>
        /// 删除343数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfChe ( string oddNum )
        {
            return _dao . deleteOfChe ( oddNum );
        }


        /// <summary>
        /// 347生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateSu ( string oddNum )
        {
            return _dao . GenerateSu ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSuList ( string strWhere )
        {
            return _dao . GetDataTableOfSuList ( strWhere );
        }

        /// <summary>
        /// 保存343数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfSu ( DataTable table )
        {
            return _dao . saveOfSu ( table );
        }

        /// <summary>
        /// 删除343数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfSu ( string oddNum )
        {
            return _dao . deleteOfSu ( oddNum );
        }

        /// <summary>
        /// 341生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateMu ( string oddNum )
        {
            return _dao . GenerateMu ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuList ( string strWhere )
        {
            return _dao . GetDataTableOfMuList ( strWhere );
        }

        /// <summary>
        /// 保存341数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfMu ( DataTable table )
        {
            return _dao . saveOfMu ( table );
        }

        /// <summary>
        /// 删除341数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfMu ( string oddNum )
        {
            return _dao . deleteOfMu ( oddNum );
        }


        /// <summary>
        /// 342生成
        /// </summary>
        /// <returns></returns>
        public bool GenerateWu ( string oddNum )
        {
            return _dao . GenerateWu ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWuList ( string strWhere )
        {
            return _dao . GetDataTableOfWuList ( strWhere );
        }

        /// <summary>
        /// 保存342数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool saveOfWu ( DataTable table )
        {
            return _dao . saveOfWu ( table );
        }

        /// <summary>
        /// 删除342数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfWu ( string oddNum )
        {
            return _dao . deleteOfWu ( oddNum );
        }


        /// <summary>
        /// 汇总
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Query ( string oddNum )
        {
            return _dao . Query ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string oddNum )
        {
            return _dao . GetDataTableOfAll ( oddNum );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool deleteOfAll ( string oddNum )
        {
            return _dao . deleteOfAll ( oddNum );
        }
    }
}
