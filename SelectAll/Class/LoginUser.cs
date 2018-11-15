using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace SelectAll . Class
{
    public static class LoginUser
    {
        private static string _userName;
        private static string _userNum;

        private static string _num;

        public static string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        public static string UserNum
        {
            get
            {
                return _userNum;
            }

            set
            {
                _userNum = value;
            }
        }

        public static string Num
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }
    }
}
