using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class OutbandChoiceBll
    {
        Dao.OutbandChoiceDao dao = new Dao.OutbandChoiceDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="number"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string number ,DataTable table )
        {
            return dao.GetDataTable( number ,table );
        }

        /// <summary>
        /// 获取341入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWood ( DataTable table )
        {
            return dao.GetDataTableOfWood( table );
        }


        /// <summary>
        /// 获取342入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCheMuJian ( DataTable table ,string number )
        {
            return dao.GetDataTableOfCheMuJian( table ,number );
        }

        /// <summary>
        /// 获取343入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfHardWare ( DataTable table ,string number )
        {
            return dao.GetDataTableOfHardWare( table ,number );
        }

        /// <summary>
        /// 获取347入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAccess ( DataTable table ,string number )
        {
            return dao.GetDataTableOfAccess( table ,number );
        }

        /// <summary>
        /// 获取337入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunQi ( DataTable table ,string number ,string oddNum)
        {
            return dao . GetDataTableOfGunQi ( table ,number ,oddNum );
        }

        /// <summary>
        /// 获取338记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfContrast ( string oddNum )
        {
            return dao.GetDataTableOfContrast( oddNum );
        }

        /// <summary>
        /// 获取341记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuCai ( string oddNum )
        {
            return dao.GetDataTableOfMuCai( oddNum );
        }

        /// <summary>
        /// 获取342记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfChe ( string oddNum )
        {
            return dao.GetDataTableOfChe( oddNum );
        }


        /// <summary>
        /// 获取343记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfHardware ( string oddNum )
        {
            return dao.GetDataTableOfHardware( oddNum );
        }

        /// <summary>
        /// 获取347记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPlastic ( string oddNum )
        {
            return dao.GetDataTableOfPlastic( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum )
        {
            return dao.GetDataTableOf( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuCaiAll ( string oddNum )
        {
            return dao.GetDataTableOfMuCaiAll( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunQiAll ( string oddNum )
        {
            return dao.GetDataTableOfGunQiAll( oddNum );
        }
    }
}
