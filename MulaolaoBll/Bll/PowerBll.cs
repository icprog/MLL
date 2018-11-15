using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
  public  class PowerBll
    {
        Dao.PowerDao _dal=null;
        public PowerBll ( )
        {
            _dal = new Dao . PowerDao ( );
        }

        /// <summary>
        /// 获取人员信息和部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserInfo ( )
        {
            return _dal . getUserInfo ( );
        }


        /// <summary>
        /// 获取程序信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            return _dal . getProInfo ( );
        }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string userNum )
        {
            return _dal . getTableView ( userNum );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary . PowerEntity _model )
        {
            return _dal . Insert ( _model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . PowerEntity _model )
        {
            return _dal . Edit ( _model );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . PowerEntity _model )
        {
            return _dal . Delete ( _model );
        }

        }
}
