using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class UserInfoBll
    {
        Dao.UserInfoDao dao=null;
        public UserInfoBll ( )
        {
            dao = new Dao . UserInfoDao ( );
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        public string getUserNum ( )
        {
            return dao . getUserNum ( );
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableDepart ( )
        {
            return dao . getTableDepart ( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            return dao . getTableView ( );
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool Delete ( string userNum )
        {
            return dao . Delete ( userNum );
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . UserInfoEntity _model )
        {
            return dao . Save ( _model );
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . UserInfoEntity _model )
        {
            return dao . Edit ( _model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public bool Exists ( string userName ,string tel ,string userNum)
        {
            return dao . Exists ( userName ,tel ,userNum );
        }

        /// <summary>
        /// 是否存在此员工
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool Exists ( string userNum )
        {
            return dao . Exists ( userNum );
        }

        /// <summary>
        /// 注销或反注销
        /// </summary>
        /// <param name="userNu"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool EditConell ( string userNu ,string state )
        {
            return dao . EditConell ( userNu ,state );
        }

    }
}
