using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace Mulaolao . Class
{
    public class DateTimePickerCustom
    {
        /// <summary>
        /// 设置时间控件默认位空
        /// </summary>
        /// <param name="dtp"></param>
        public static void custom ( DateTimePicker dtp )
        {
            dtp . Format = System . Windows . Forms . DateTimePickerFormat . Custom;
            dtp . CustomFormat = "     ";
        }
    }
}
