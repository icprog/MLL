using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Drawing;
using System. Data;
using System. Linq;
using System. Text;
using System. Windows. Forms;
using Mulaolao. Class;
using Mulaolao. Wages;

namespace Mulaolao.UserCon
{
    public partial class UserControl2 : UserControl
    {
       
        public UserControl2()
        {
            InitializeComponent ( );
        }

        List<TextBox> tbs;
        List<TextBox> tbc;
        List<Label> lbs;
        List<Label> lbc;
        List<Label> lbi;
        List<Label> lbr;

        HeadmanWagesCalculation calCu = new HeadmanWagesCalculation( );

        private void UserControl2_Load ( object sender , EventArgs e )
        {
            tbs = new List<TextBox> ( ) { textBox1 , textBox2 , textBox3 , textBox4 , textBox5 , textBox6 , textBox7 , textBox8 , textBox9 , textBox10 , textBox11 , textBox12 , textBox13 , textBox14 , textBox15 , textBox16 , textBox17 , textBox18 , textBox19 , textBox20 , textBox21 , textBox22 , textBox23 , textBox24 , textBox25 , textBox26 , textBox27 , textBox28 , textBox29 , textBox30 , textBox31 };
            tbc = new List<TextBox> ( ) { textBox32 , textBox34 , textBox35 , textBox36 , textBox37 , textBox38 , textBox39 , textBox40 , textBox41 , textBox42 , textBox43 , textBox44 , textBox45 , textBox46 , textBox47 , textBox38 , textBox39 , textBox50 , textBox51 , textBox52 , textBox53 , textBox54 , textBox55 , textBox56 , textBox57 , textBox58 , textBox59 , textBox60 , textBox61 , textBox62 , textBox63 };
            lbs = new List<Label> ( ) { label45 , label53 , label61 , label98 , label99 , label100 , label101 , label102 , label103 , label104 , label105 , label106 , label107 , label108 , label109 , label110 , label111 , label112 , label113 , label114 , label115 , label116 , label117 , label118 , label119 , label120 , label121 , label122 , label123 , label124 , label125 };
            lbc = new List<Label> ( ) { label46 , label54 , label62 , label128 , label129 , label130 , label131 , label132 , label133 , label134 , label135 , label136 , label137 , label138 , label139 , label140 , label141 , label142 , label143 , label144 , label145 , label146 , label147 , label148 , label149 , label150 , label151 , label152 , label153 , label154 , label155 };
            lbi = new List<Label> ( ) { label47 , label55 , label63 , label158 , label159 , label160 , label161 , label162 , label163 , label164 , label165 , label166 , label167 , label168 , label169 , label170 , label171 , label172 , label173 , label174 , label175 , label176 , label177 , label178 , label179 , label180 , label181 , label182 , label183 , label184 , label185 };
            lbr = new List<Label> ( ) { label48 , label56 , label64 , label188 , label189 , label190 , label191 , label192 , label193 , label194 , label195 , label196 , label197 , label198 , label199 , label200 , label201 , label202 , label203 , label204 , label205 , label206 , label207 , label208 , label209 , label210 , label211 , label212 , label213 , label214 , label215 };
        }

        #region 事件        
        //1日
        private void textBox1_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox1 );
        }
        private void textBox1_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox1. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox1 ) )
            {
                this. textBox1. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label45.Text = calCu.MultiTreDeOne( textBox1 ,textBox32 ,textBox68 );
                label46.Text = calCu.MultiTreDeTwo( textBox1 ,textBox65 ,textBox69 );
                label48.Text = calCu.AddTreDeOne( label45 ,label46 ,label47 );
                label49.Text = calCu.DivisionTreDeOne( label48 ,label45 );
                label308.Text = calCu.AddMultipleDeOne( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox32_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox32 );
        }
        private void textBox32_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox32. Text != "" && !DateDayRegise. threeOneNumTb ( textBox32 ) )
            {
                this. textBox32. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label45. Text = Operation. MultiTb ( textBox1 , textBox32 , textBox68 );
                label48. Text = Operation. MultiLb ( label45 , label46 , label47 );
                label49. Text = Operation. DivisionLb ( label48 , label45 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //2日
        private void textBox2_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox2 );
        }
        private void textBox2_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox2. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox2 ) )
            {
                this. textBox2. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label53. Text = Operation. MultiTb ( textBox2 , textBox34 , textBox68 );
                label54. Text = Operation. MultiTb ( textBox2 , textBox70 , textBox66 );
                label56. Text = Operation. MultiLb ( label53 , label54 , label55 );
                label57. Text = Operation. DivisionLb ( label56 , label53 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox34_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox34 );
        }
        private void textBox34_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox34. Text != "" && !DateDayRegise. threeOneNumTb ( textBox34 ) )
            {
                this. textBox34. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label53. Text = Operation. MultiTb ( textBox2 , textBox34 , textBox68 );
                label56. Text = Operation. MultiLb ( label53 , label54 , label55 );
                label57. Text = Operation. DivisionLb ( label56 , label53 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //3日
        private void textBox3_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox3 );
        }
        private void textBox3_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox3. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox3 ) )
            {
                this. textBox3. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label61. Text = Operation. MultiTb ( textBox3 , textBox35 , textBox68 );
                label62. Text = Operation. MultiTb ( textBox3 , textBox70 , textBox66 );
                label64. Text = Operation. MultiLb ( label61 , label62 , label63 );
                label65. Text = Operation. DivisionLb ( label64 , label61 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox35_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox35 );
        }
        private void textBox35_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox35. Text != "" && !DateDayRegise. threeOneNumTb ( textBox35 ) )
            {
                this. textBox35. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label61. Text = Operation. MultiTb ( textBox3 , textBox35 , textBox68 );
                label64. Text = Operation. MultiLb ( label61 , label62 , label63 );
                label65. Text = Operation. DivisionLb ( label64 , label61 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //4日
        private void textBox4_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox4 );
        }
        private void textBox4_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox4. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox4 ) )
            {
                this. textBox4. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label98. Text = Operation. MultiTb ( textBox4 , textBox36 , textBox68 );
                label128. Text = Operation. MultiTb ( textBox4 , textBox70 , textBox66 );
                label188. Text = Operation. MultiLb ( label98 , label128 , label158 );
                label218. Text = Operation. DivisionLb ( label188 , label98 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox36_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox36 );
        }
        private void textBox36_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox36. Text != "" && !DateDayRegise. threeOneNumTb ( textBox36 ) )
            {
                this. textBox36. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label98. Text = Operation. MultiTb ( textBox4 , textBox36 , textBox68 );
                label188. Text = Operation. MultiLb ( label98 , label128 , label158 );
                label218. Text = Operation. DivisionLb ( label188 , label98 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //5日
        private void textBox5_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox5 );
        }
        private void textBox5_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox5. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox5 ) )
            {
                this. textBox5. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label99. Text = Operation. MultiTb ( textBox5 , textBox37 , textBox68 );
                label129. Text = Operation. MultiTb ( textBox5 , textBox70 , textBox66 );
                label189. Text = Operation. MultiLb ( label99 , label129 , label159 );
                label219. Text = Operation. DivisionLb ( label189 , label99 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox37_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox37 );
        }
        private void textBox37_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox37. Text != "" && !DateDayRegise. threeOneNumTb ( textBox37 ) )
            {
                this. textBox37. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label99. Text = Operation. MultiTb ( textBox5 , textBox37 , textBox68 );
                label189. Text = Operation. MultiLb ( label99 , label129 , label159 );
                label219. Text = Operation. DivisionLb ( label189 , label99 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //6日
        private void textBox6_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox6 );
        }
        private void textBox6_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox6. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox6 ) )
            {
                this. textBox6. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label100. Text = Operation. MultiTb ( textBox6 , textBox38 , textBox68 );
                label130. Text = Operation. MultiTb ( textBox6 , textBox70 , textBox66 );
                label190. Text = Operation. MultiLb ( label100 , label130 , label160 );
                label220. Text = Operation. DivisionLb ( label190 , label100 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox38_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox38 );
        }
        private void textBox38_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox38. Text != "" && !DateDayRegise. threeOneNumTb ( textBox38 ) )
            {
                this. textBox38. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label100. Text = Operation. MultiTb ( textBox6 , textBox38 , textBox68 );
                label190. Text = Operation. MultiLb ( label100 , label130 , label160 );
                label220. Text = Operation. DivisionLb ( label190 , label100 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //7日
        private void textBox7_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox7 );
        }
        private void textBox7_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox7. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox7 ) )
            {
                this. textBox7. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label101. Text = Operation. MultiTb ( textBox7 , textBox39 , textBox68 );
                label131. Text = Operation. MultiTb ( textBox7 , textBox70 , textBox66 );
                label191. Text = Operation. MultiLb ( label101 , label131 , label161 );
                label221. Text = Operation. DivisionLb ( label191 , label101 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox39_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox39 );
        }
        private void textBox39_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox39. Text != "" && !DateDayRegise. threeOneNumTb ( textBox39 ) )
            {
                this. textBox39. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label101. Text = Operation. MultiTb ( textBox7 , textBox39 , textBox68 );
                label191. Text = Operation. MultiLb ( label101 , label131 , label161 );
                label221. Text = Operation. DivisionLb ( label191 , label101 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //8日
        private void textBox8_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox8 );
        }
        private void textBox8_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox8. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox8 ) )
            {
                this. textBox8. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label102. Text = Operation. MultiTb ( textBox8 , textBox40 , textBox68 );
                label132. Text = Operation. MultiTb ( textBox8 , textBox70 , textBox66 );
                label192. Text = Operation. MultiLb ( label102 , label132 , label162 );
                label222. Text = Operation. DivisionLb ( label192 , label102 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox40_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox40 );
        }
        private void textBox40_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox40. Text != "" && !DateDayRegise. threeOneNumTb ( textBox40 ) )
            {
                this. textBox40. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label102. Text = Operation. MultiTb ( textBox8 , textBox40 , textBox68 );
                label192. Text = Operation. MultiLb ( label102 , label132 , label162 );
                label222. Text = Operation. DivisionLb ( label192 , label102 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //9日
        private void textBox9_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox9 );
        }
        private void textBox9_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox9. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox9 ) )
            {
                this. textBox9. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label103. Text = Operation. MultiTb ( textBox9 , textBox41 , textBox68 );
                label133. Text = Operation. MultiTb ( textBox9 , textBox70 , textBox66 );
                label193. Text = Operation. MultiLb ( label103 , label133 , label163 );
                label223. Text = Operation. DivisionLb ( label193 , label103 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox41_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox41 );
        }
        private void textBox41_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox41. Text != "" && !DateDayRegise. threeOneNumTb ( textBox41 ) )
            {
                this. textBox41. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label103. Text = Operation. MultiTb ( textBox9 , textBox41 , textBox68 );
                label193. Text = Operation. MultiLb ( label103 , label133 , label163 );
                label223. Text = Operation. DivisionLb ( label193 , label103 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //10日
        private void textBox10_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox10 );
        }
        private void textBox10_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox10. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox10 ) )
            {
                this. textBox10. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label104. Text = Operation. MultiTb ( textBox10 , textBox42 , textBox68 );
                label134. Text = Operation. MultiTb ( textBox10 , textBox70 , textBox66 );
                label194. Text = Operation. MultiLb ( label104 , label134 , label164 );
                label224. Text = Operation. DivisionLb ( label194 , label104 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox42_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox42 );
        }
        private void textBox42_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox42. Text != "" && !DateDayRegise. threeOneNumTb ( textBox42 ) )
            {
                this. textBox42. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label104. Text = Operation. MultiTb ( textBox10 , textBox42 , textBox68 );
                label194. Text = Operation. MultiLb ( label104 , label134 , label164 );
                label224. Text = Operation. DivisionLb ( label194 , label104 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //11日
        private void textBox11_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox11 );
        }
        private void textBox11_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox11. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox11 ) )
            {
                this. textBox11. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label105. Text = Operation. MultiTb ( textBox11 , textBox43 , textBox68 );
                label135. Text = Operation. MultiTb ( textBox11 , textBox70 , textBox66 );
                label195. Text = Operation. MultiLb ( label105 , label135 , label165 );
                label225. Text = Operation. DivisionLb ( label195 , label105 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox43_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox43 );
        }
        private void textBox43_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox43. Text != "" && !DateDayRegise. threeOneNumTb ( textBox43 ) )
            {
                this. textBox43. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label105. Text = Operation. MultiTb ( textBox11 , textBox43 , textBox68 );
                label195. Text = Operation. MultiLb ( label105 , label135 , label165 );
                label225. Text = Operation. DivisionLb ( label195 , label105 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //12日
        private void textBox12_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox12 );
        }
        private void textBox12_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox12. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox12 ) )
            {
                this. textBox12. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label106. Text = Operation. MultiTb ( textBox12 , textBox44 , textBox68 );
                label136. Text = Operation. MultiTb ( textBox12 , textBox70 , textBox66 );
                label196. Text = Operation. MultiLb ( label106 , label136 , label166 );
                label226. Text = Operation. DivisionLb ( label196 , label106 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox44_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox44 );
        }
        private void textBox44_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox44. Text != "" && !DateDayRegise. threeOneNumTb ( textBox44 ) )
            {
                this. textBox44. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label106. Text = Operation. MultiTb ( textBox12 , textBox44 , textBox68 );
                label196. Text = Operation. MultiLb ( label106 , label136 , label166 );
                label226. Text = Operation. DivisionLb ( label196 , label106 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //13日
        private void textBox13_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox13. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox13_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox13. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox13 ) )
            {
                this. textBox13. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label107. Text = Operation. MultiTb ( textBox13 , textBox45 , textBox68 );
                label137. Text = Operation. MultiTb ( textBox13 , textBox70 , textBox66 );
                label197. Text = Operation. MultiLb ( label107 , label137 , label167 );
                label227. Text = Operation. DivisionLb ( label197 , label107 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox45_KeyPress ( object sender , KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( char. IsPunctuation ( e. KeyChar ) )
            {
                if ( textBox45. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        private void textBox45_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox45. Text != "" && !DateDayRegise. threeOneNumTb ( textBox45 ) )
            {
                this. textBox45. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label107. Text = Operation. MultiTb ( textBox13 , textBox45 , textBox68 );
                label197. Text = Operation. MultiLb ( label107 , label137 , label167 );
                label227. Text = Operation. DivisionLb ( label197 , label107 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //14日
        private void textBox14_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox14 );
        }
        private void textBox14_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox14. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox14 ) )
            {
                this. textBox14. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label108. Text = Operation. MultiTb ( textBox14 , textBox46 , textBox68 );
                label138. Text = Operation. MultiTb ( textBox14 , textBox70 , textBox66 );
                label198. Text = Operation. MultiLb ( label108 , label138 , label168 );
                label228. Text = Operation. DivisionLb ( label198 , label108 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox46_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox46 );
        }
        private void textBox46_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox46. Text != "" && !DateDayRegise. threeOneNumTb ( textBox46 ) )
            {
                this. textBox46. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label108. Text = Operation. MultiTb ( textBox14 , textBox46 , textBox68 );
                label198. Text = Operation. MultiLb ( label108 , label138 , label168 );
                label228. Text = Operation. DivisionLb ( label198 , label108 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //15日
        private void textBox15_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox15 );
        }
        private void textBox15_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox15. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox15 ) )
            {
                this. textBox15. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label109. Text = Operation. MultiTb ( textBox15 , textBox47 , textBox68 );
                label139. Text = Operation. MultiTb ( textBox15 , textBox70 , textBox66 );
                label199. Text = Operation. MultiLb ( label109 , label139 , label169 );
                label229. Text = Operation. DivisionLb ( label199 , label109 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox47_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox47 );
        }
        private void textBox47_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox47. Text != "" && !DateDayRegise. threeOneNumTb ( textBox47 ) )
            {
                this. textBox47. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label109. Text = Operation. MultiTb ( textBox15 , textBox47 , textBox68 );
                label199. Text = Operation. MultiLb ( label109 , label139 , label169 );
                label229. Text = Operation. DivisionLb ( label199 , label109 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //16日
        private void textBox16_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox16 );
        }
        private void textBox16_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox16. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox16 ) )
            {
                this. textBox16. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label110. Text = Operation. MultiTb ( textBox16 , textBox48 , textBox68 );
                label140. Text = Operation. MultiTb ( textBox16 , textBox70 , textBox66 );
                label200. Text = Operation. MultiLb ( label110 , label140 , label170 );
                label230. Text = Operation. DivisionLb ( label200 , label110 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox48_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox48 );
        }
        private void textBox48_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox48. Text != "" && !DateDayRegise. threeOneNumTb ( textBox48 ) )
            {
                this. textBox48. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label110. Text = Operation. MultiTb ( textBox16 , textBox48 , textBox68 );
                label200. Text = Operation. MultiLb ( label110 , label140 , label170 );
                label230. Text = Operation. DivisionLb ( label200 , label110 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //17日
        private void textBox17_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox17 );
        }
        private void textBox17_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox17. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox17 ) )
            {
                this. textBox17. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label111. Text = Operation. MultiTb ( textBox17 , textBox49 , textBox68 );
                label141. Text = Operation. MultiTb ( textBox17 , textBox70 , textBox66 );
                label201. Text = Operation. MultiLb ( label111 , label141 , label171 );
                label231. Text = Operation. DivisionLb ( label201 , label111 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox49_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox49 );
        }
        private void textBox49_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox49. Text != "" && !DateDayRegise. threeOneNumTb ( textBox49 ) )
            {
                this. textBox49. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label111. Text = Operation. MultiTb ( textBox17 , textBox49 , textBox68 );
                label201. Text = Operation. MultiLb ( label111 , label141 , label171 );
                label231. Text = Operation. DivisionLb ( label201 , label111 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //18日
        private void textBox18_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox18 );
        }
        private void textBox18_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox18. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox18 ) )
            {
                this. textBox18. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label112. Text = Operation. MultiTb ( textBox18 , textBox50 , textBox68 );
                label142. Text = Operation. MultiTb ( textBox18 , textBox70 , textBox66 );
                label202. Text = Operation. MultiLb ( label112 , label142 , label172 );
                label232. Text = Operation. DivisionLb ( label202 , label112 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox50_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox50 );
        }
        private void textBox50_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox50. Text != "" && !DateDayRegise. threeOneNumTb ( textBox50 ) )
            {
                this. textBox50. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label112. Text = Operation. MultiTb ( textBox18 , textBox50 , textBox68 );
                label202. Text = Operation. MultiLb ( label112 , label142 , label172 );
                label232. Text = Operation. DivisionLb ( label202 , label112 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //19日
        private void textBox19_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox19 );
        }
        private void textBox19_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox19. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox19 ) )
            {
                this. textBox19. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label113. Text = Operation. MultiTb ( textBox19 , textBox51 , textBox68 );
                label143. Text = Operation. MultiTb ( textBox19 , textBox70 , textBox66 );
                label203. Text = Operation. MultiLb ( label113 , label143 , label173 );
                label233. Text = Operation. DivisionLb ( label203 , label113 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox51_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox51 );
        }
        private void textBox51_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox51. Text != "" && !DateDayRegise. threeOneNumTb ( textBox51 ) )
            {
                this. textBox51. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label113. Text = Operation. MultiTb ( textBox19 , textBox51 , textBox68 );
                label203. Text = Operation. MultiLb ( label113 , label143 , label173 );
                label233. Text = Operation. DivisionLb ( label203 , label113 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //20日
        private void textBox20_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox20 );
        }
        private void textBox20_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox20. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox20 ) )
            {
                this. textBox20. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label114. Text = Operation. MultiTb ( textBox20 , textBox52 , textBox68 );
                label144. Text = Operation. MultiTb ( textBox20 , textBox70 , textBox66 );
                label204. Text = Operation. MultiLb ( label114 , label144 , label174 );
                label234. Text = Operation. DivisionLb ( label204 , label114 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox52_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox52 );
        }
        private void textBox52_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox52. Text != "" && !DateDayRegise. threeOneNumTb ( textBox52 ) )
            {
                this. textBox52. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label114. Text = Operation. MultiTb ( textBox20 , textBox52 , textBox68 );
                label204. Text = Operation. MultiLb ( label114 , label144 , label174 );
                label234. Text = Operation. DivisionLb ( label204 , label114 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //21日
        private void textBox21_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox21 );
        }
        private void textBox21_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox21. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox21 ) )
            {
                this. textBox21. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label115. Text = Operation. MultiTb ( textBox21 , textBox53 , textBox68 );
                label145. Text = Operation. MultiTb ( textBox21 , textBox70 , textBox66 );
                label205. Text = Operation. MultiLb ( label115 , label145 , label175 );
                label235. Text = Operation. DivisionLb ( label205 , label115 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox53_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox53 );
        }
        private void textBox53_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox53. Text != "" && !DateDayRegise. threeOneNumTb ( textBox53 ) )
            {
                this. textBox53. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label115. Text = Operation. MultiTb ( textBox21 , textBox53 , textBox68 );
                label205. Text = Operation. MultiLb ( label115 , label145 , label175 );
                label235. Text = Operation. DivisionLb ( label205 , label115 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //22日
        private void textBox22_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox22 );
        }
        private void textBox22_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox22. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox22 ) )
            {
                this. textBox22. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label116. Text = Operation. MultiTb ( textBox22 , textBox54 , textBox68 );
                label146. Text = Operation. MultiTb ( textBox22 , textBox70 , textBox66 );
                label206. Text = Operation. MultiLb ( label116 , label146 , label176 );
                label236. Text = Operation. DivisionLb ( label206 , label116 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox54_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox54 );
        }
        private void textBox54_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox54. Text != "" && !DateDayRegise. threeOneNumTb ( textBox54 ) )
            {
                this. textBox54. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label116. Text = Operation. MultiTb ( textBox22 , textBox54 , textBox68 );
                label206. Text = Operation. MultiLb ( label116 , label146 , label176 );
                label236. Text = Operation. DivisionLb ( label206 , label116 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //23日
        private void textBox23_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox23 );
        }
        private void textBox23_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox23. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox23 ) )
            {
                this. textBox23. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label117. Text = Operation. MultiTb ( textBox23 , textBox55 , textBox68 );
                label147. Text = Operation. MultiTb ( textBox23 , textBox70 , textBox66 );
                label207. Text = Operation. MultiLb ( label117 , label147 , label177 );
                label237. Text = Operation. DivisionLb ( label207 , label117 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox55_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox55 );
        }
        private void textBox55_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox55. Text != "" && !DateDayRegise. threeOneNumTb ( textBox55 ) )
            {
                this. textBox55. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label117. Text = Operation. MultiTb ( textBox23 , textBox55 , textBox68 );
                label207. Text = Operation. MultiLb ( label117 , label147 , label177 );
                label237. Text = Operation. DivisionLb ( label207 , label117 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //24日
        private void textBox24_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox24 );
        }
        private void textBox24_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox24. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox24 ) )
            {
                this. textBox24. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label118. Text = Operation. MultiTb ( textBox24 , textBox56 , textBox68 );
                label148. Text = Operation. MultiTb ( textBox24 , textBox70 , textBox66 );
                label208. Text = Operation. MultiLb ( label118 , label148 , label178 );
                label238. Text = Operation. DivisionLb ( label208 , label118 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox56_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox56 );
        }
        private void textBox56_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox56. Text != "" && !DateDayRegise. threeOneNumTb ( textBox56 ) )
            {
                this. textBox56. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label118. Text = Operation. MultiTb ( textBox24 , textBox56 , textBox68 );
                label208. Text = Operation. MultiLb ( label118 , label148 , label178 );
                label238. Text = Operation. DivisionLb ( label208 , label118 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //25日
        private void textBox25_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox25 );
        }
        private void textBox25_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox25. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox25 ) )
            {
                this. textBox25. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label119. Text = Operation. MultiTb ( textBox25 , textBox57 , textBox68 );
                label149. Text = Operation. MultiTb ( textBox25 , textBox70 , textBox66 );
                label209. Text = Operation. MultiLb ( label119 , label149 , label179 );
                label239. Text = Operation. DivisionLb ( label209 , label119 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox57_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox57 );
        }
        private void textBox57_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox57. Text != "" && !DateDayRegise. threeOneNumTb ( textBox57 ) )
            {
                this. textBox57. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label119. Text = Operation. MultiTb ( textBox25 , textBox57 , textBox68 );
                label209. Text = Operation. MultiLb ( label119 , label149 , label179 );
                label239. Text = Operation. DivisionLb ( label209 , label119 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //26日
        private void textBox26_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox26 );
        }
        private void textBox26_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox26. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox26 ) )
            {
                this. textBox26. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label120. Text = Operation. MultiTb ( textBox26 , textBox58 , textBox68 );
                label150. Text = Operation. MultiTb ( textBox26 , textBox70 , textBox66 );
                label210. Text = Operation. MultiLb ( label120 , label150 , label180 );
                label240. Text = Operation. DivisionLb ( label210 , label120 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox58_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox58 );
        }
        private void textBox58_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox58. Text != "" && !DateDayRegise. threeOneNumTb ( textBox58 ) )
            {
                this. textBox58. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label120. Text = Operation. MultiTb ( textBox26 , textBox58 , textBox68 );
                label210. Text = Operation. MultiLb ( label120 , label150 , label180 );
                label240. Text = Operation. DivisionLb ( label210 , label120 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //27日
        private void textBox27_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox27 );
        }
        private void textBox27_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox27. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox27 ) )
            {
                this. textBox27. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label121. Text = Operation. MultiTb ( textBox27 , textBox59 , textBox68 );
                label151. Text = Operation. MultiTb ( textBox27 , textBox70 , textBox66 );
                label211. Text = Operation. MultiLb ( label121 , label151 , label181 );
                label241. Text = Operation. DivisionLb ( label211 , label121 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox59_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox27 );
        }
        private void textBox59_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox59. Text != "" && !DateDayRegise. threeOneNumTb ( textBox59 ) )
            {
                this. textBox59. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label121. Text = Operation. MultiTb ( textBox27 , textBox59 , textBox68 );
                label211. Text = Operation. MultiLb ( label121 , label151 , label181 );
                label241. Text = Operation. DivisionLb ( label211 , label121 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //28日
        private void textBox28_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox28 );
        }
        private void textBox28_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox28. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox28 ) )
            {
                this. textBox28. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label122. Text = Operation. MultiTb ( textBox28 , textBox60 , textBox68 );
                label152. Text = Operation. MultiTb ( textBox28 , textBox70 , textBox66 );
                label212. Text = Operation. MultiLb ( label122 , label152 , label182 );
                label242. Text = Operation. DivisionLb ( label212 , label122 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox60_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox60 );
        }
        private void textBox60_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox60. Text != "" && !DateDayRegise. threeOneNumTb ( textBox60 ) )
            {
                this. textBox60. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label122. Text = Operation. MultiTb ( textBox28 , textBox60 , textBox68 );
                label212. Text = Operation. MultiLb ( label122 , label152 , label182 );
                label242. Text = Operation. DivisionLb ( label212 , label122 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //29日
        private void textBox29_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox29 );
        }
        private void textBox29_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox29. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox29 ) )
            {
                this. textBox29. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label123. Text = Operation. MultiTb ( textBox29 , textBox61 , textBox68 );
                label153. Text = Operation. MultiTb ( textBox29 , textBox70 , textBox66 );
                label213. Text = Operation. MultiLb ( label123 , label153 , label183 );
                label243. Text = Operation. DivisionLb ( label213 , label123 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox61_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox61 );
        }
        private void textBox61_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox61. Text != "" && !DateDayRegise. threeOneNumTb ( textBox61 ) )
            {
                this. textBox61. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label123. Text = Operation. MultiTb ( textBox29 , textBox61 , textBox68 );
                label213. Text = Operation. MultiLb ( label123 , label153 , label183 );
                label243. Text = Operation. DivisionLb ( label213 , label123 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //30日
        private void textBox30_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox30 );
        }
        private void textBox30_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox30. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox30 ) )
            {
                this. textBox30. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label124. Text = Operation. MultiTb ( textBox30 , textBox62 , textBox68 );
                label154. Text = Operation. MultiTb ( textBox30 , textBox70 , textBox66 );
                label214. Text = Operation. MultiLb ( label124 , label154 , label184 );
                label244. Text = Operation. DivisionLb ( label214 , label124 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox62_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox62 );
        }
        private void textBox62_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox62. Text != "" && !DateDayRegise. threeOneNumTb ( textBox62 ) )
            {
                this. textBox62. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label124. Text = Operation. MultiTb ( textBox30 , textBox62 , textBox68 );
                label214. Text = Operation. MultiLb ( label124 , label154 , label184 );
                label244. Text = Operation. DivisionLb ( label214 , label124 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //31日
        private void textBox31_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox31 );
        }
        private void textBox31_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox31. Text != "" && !DateDayRegise. threeTwoNumTb ( textBox31 ) )
            {
                this. textBox31. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多一位,小数部分最多二位,如9.99,请重新输入" );
            }
            else
            {
                label125. Text = Operation. MultiTb ( textBox31 , textBox63 , textBox68 );
                label155. Text = Operation. MultiTb ( textBox31 , textBox70 , textBox66 );
                label215. Text = Operation. MultiLb ( label125 , label155 , label185 );
                label245. Text = Operation. DivisionLb ( label215 , label125 );
                label308. Text = Operation. MultiTbs ( tbs );
                label126. Text = Operation. MultiLbs ( lbs );
                label156. Text = Operation. MultiLbs ( lbc );
                label186. Text = Operation. MultiLbs ( lbi );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
                label73. Text = Operation. MultiTbc ( tbs );
            }
        }
        private void textBox63_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox63 );
        }
        private void textBox63_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox63. Text != "" && !DateDayRegise. threeOneNumTb ( textBox63 ) )
            {
                this. textBox63. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
            else
            {
                label125. Text = Operation. MultiTb ( textBox31 , textBox63 , textBox68 );
                label215. Text = Operation. MultiLb ( label125 , label155 , label185 );
                label245. Text = Operation. DivisionLb ( label215 , label125 );
                label96. Text = Operation. MultiTbs ( tbc );
                label126. Text = Operation. MultiLbs ( lbs );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        //定日管人数
        private void textBox64_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //定日人单价
        private void textBox68_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        private void textBox68_LostFocus ( object sender , EventArgs e )
        {
            label45. Text = Operation. MultiTb ( textBox1 , textBox32 , textBox68 );
            label53. Text = Operation. MultiTb ( textBox2 , textBox34 , textBox68 );
            label61. Text = Operation. MultiTb ( textBox3 , textBox35 , textBox68 );
            label98. Text = Operation. MultiTb ( textBox4 , textBox36 , textBox68 );
            label99. Text = Operation. MultiTb ( textBox5 , textBox37 , textBox68 );
            label100. Text = Operation. MultiTb ( textBox6 , textBox38 , textBox68 );
            label101. Text = Operation. MultiTb ( textBox7 , textBox39 , textBox68 );
            label102. Text = Operation. MultiTb ( textBox8 , textBox40 , textBox68 );
            label103. Text = Operation. MultiTb ( textBox9 , textBox41 , textBox68 );
            label104. Text = Operation. MultiTb ( textBox10 , textBox42 , textBox68 );
            label105. Text = Operation. MultiTb ( textBox11 , textBox43 , textBox68 );
            label106. Text = Operation. MultiTb ( textBox12 , textBox44 , textBox68 );
            label107. Text = Operation. MultiTb ( textBox13 , textBox45 , textBox68 );
            label108. Text = Operation. MultiTb ( textBox14 , textBox46 , textBox68 );
            label109. Text = Operation. MultiTb ( textBox15 , textBox47 , textBox68 );
            label110. Text = Operation. MultiTb ( textBox16 , textBox48 , textBox68 );
            label111. Text = Operation. MultiTb ( textBox17 , textBox49 , textBox68 );
            label112. Text = Operation. MultiTb ( textBox18 , textBox50 , textBox68 );
            label113. Text = Operation. MultiTb ( textBox19 , textBox51 , textBox68 );
            label114. Text = Operation. MultiTb ( textBox20 , textBox52 , textBox68 );
            label115. Text = Operation. MultiTb ( textBox21 , textBox53 , textBox68 );
            label116. Text = Operation. MultiTb ( textBox22 , textBox54 , textBox68 );
            label117. Text = Operation. MultiTb ( textBox23 , textBox55 , textBox68 );
            label118. Text = Operation. MultiTb ( textBox24 , textBox56 , textBox68 );
            label119. Text = Operation. MultiTb ( textBox25 , textBox57 , textBox68 );
            label120. Text = Operation. MultiTb ( textBox26 , textBox58 , textBox68 );
            label121. Text = Operation. MultiTb ( textBox27 , textBox59 , textBox68 );
            label122. Text = Operation. MultiTb ( textBox28 , textBox60 , textBox68 );
            label123. Text = Operation. MultiTb ( textBox29 , textBox61 , textBox68 );
            label124. Text = Operation. MultiTb ( textBox30 , textBox62 , textBox68 );
            label125. Text = Operation. MultiTb ( textBox31 , textBox63 , textBox68 );

            label48. Text = Operation. MultiLb ( label45 , label46 , label47 );
            label56. Text = Operation. MultiLb ( label53 , label54 , label55 );
            label64. Text = Operation. MultiLb ( label61 , label62 , label63 );
            label188. Text = Operation. MultiLb ( label98 , label128 , label158 );
            label189. Text = Operation. MultiLb ( label99 , label129 , label159 );
            label190. Text = Operation. MultiLb ( label100 , label130 , label160 );
            label191. Text = Operation. MultiLb ( label101 , label131 , label161 );
            label192. Text = Operation. MultiLb ( label102 , label132 , label162 );
            label193. Text = Operation. MultiLb ( label103 , label133 , label163 );
            label194. Text = Operation. MultiLb ( label104 , label134 , label164 );
            label195. Text = Operation. MultiLb ( label105 , label135 , label165 );
            label196. Text = Operation. MultiLb ( label106 , label136 , label166 );
            label197. Text = Operation. MultiLb ( label107 , label137 , label167 );
            label198. Text = Operation. MultiLb ( label108 , label138 , label168 );
            label199. Text = Operation. MultiLb ( label109 , label139 , label169 );
            label200. Text = Operation. MultiLb ( label110 , label140 , label170 );
            label201. Text = Operation. MultiLb ( label111 , label141 , label171 );
            label202. Text = Operation. MultiLb ( label112 , label142 , label172 );
            label203. Text = Operation. MultiLb ( label113 , label143 , label173 );
            label204. Text = Operation. MultiLb ( label114 , label144 , label174 );
            label205. Text = Operation. MultiLb ( label115 , label145 , label175 );
            label206. Text = Operation. MultiLb ( label116 , label146 , label176 );
            label207. Text = Operation. MultiLb ( label117 , label147 , label177 );
            label208. Text = Operation. MultiLb ( label118 , label148 , label178 );
            label209. Text = Operation. MultiLb ( label119 , label149 , label179 );
            label210. Text = Operation. MultiLb ( label120 , label150 , label180 );
            label211. Text = Operation. MultiLb ( label121 , label151 , label181 );
            label212. Text = Operation. MultiLb ( label122 , label152 , label182 );
            label213. Text = Operation. MultiLb ( label123 , label153 , label183 );
            label214. Text = Operation. MultiLb ( label124 , label154 , label184 );
            label215. Text = Operation. MultiLb ( label125 , label155 , label185 );

            label49. Text = Operation. DivisionLb ( label48 , label45 );
            label57. Text = Operation. DivisionLb ( label56 , label53 );
            label65. Text = Operation. DivisionLb ( label64 , label61 );
            label218. Text = Operation. DivisionLb ( label188 , label98 );
            label219. Text = Operation. DivisionLb ( label189 , label99 );
            label220. Text = Operation. DivisionLb ( label190 , label100 );
            label221. Text = Operation. DivisionLb ( label191 , label101 );
            label222. Text = Operation. DivisionLb ( label192 , label102 );
            label223. Text = Operation. DivisionLb ( label193 , label103 );
            label224. Text = Operation. DivisionLb ( label194 , label104 );
            label225. Text = Operation. DivisionLb ( label195 , label105 );
            label226. Text = Operation. DivisionLb ( label196 , label106 );
            label227. Text = Operation. DivisionLb ( label197 , label107 );
            label228. Text = Operation. DivisionLb ( label198 , label108 );
            label229. Text = Operation. DivisionLb ( label199 , label109 );
            label230. Text = Operation. DivisionLb ( label200 , label110 );
            label231. Text = Operation. DivisionLb ( label201 , label111 );
            label232. Text = Operation. DivisionLb ( label202 , label112 );
            label233. Text = Operation. DivisionLb ( label203 , label113 );
            label234. Text = Operation. DivisionLb ( label204 , label114 );
            label235. Text = Operation. DivisionLb ( label205 , label115 );
            label236. Text = Operation. DivisionLb ( label206 , label116 );
            label237. Text = Operation. DivisionLb ( label207 , label117 );
            label238. Text = Operation. DivisionLb ( label208 , label118 );
            label239. Text = Operation. DivisionLb ( label209 , label119 );
            label240. Text = Operation. DivisionLb ( label210 , label120 );
            label241. Text = Operation. DivisionLb ( label211 , label121 );
            label242. Text = Operation. DivisionLb ( label212 , label122 );
            label243. Text = Operation. DivisionLb ( label213 , label123 );
            label244. Text = Operation. DivisionLb ( label214 , label124 );
            label245. Text = Operation. DivisionLb ( label215 , label125 );

            label126. Text = Operation. MultiLbs ( lbs );
            label216. Text = Operation. MultiLbs ( lbr );
            label246. Text = Operation. DivisionLb ( label216 , label308 );
        }
        //实日管人数
        private void textBox73_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //实月产量
        private void textBox65_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //定日提成%
        private void textBox69_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox69 );
        }
        private void textBox69_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox69. Text != "" && !DateDayRegise. eightSixTb ( textBox69 ) )
            {
                this. textBox69. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多一位,如99.999999,请重新输入" );
            }
        }
        private void textBox69_TextChanged ( object sender , EventArgs e )
        {
            DateDayRegise. textChangeTb ( textBox69 );
        }
        //定月产量
        private void textBox66_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        private void textBox66_LostFocus ( object sender , EventArgs e )
        {
            label46. Text = Operation. MultiTb ( textBox1 , textBox70 , textBox66 );
            label54. Text = Operation. MultiTb ( textBox2 , textBox70 , textBox66 );
            label62. Text = Operation. MultiTb ( textBox3 , textBox70 , textBox66 );
            label128. Text = Operation. MultiTb ( textBox4 , textBox70 , textBox66 );
            label129. Text = Operation. MultiTb ( textBox5 , textBox70 , textBox66 );
            label130. Text = Operation. MultiTb ( textBox6 , textBox70 , textBox66 );
            label131. Text = Operation. MultiTb ( textBox7 , textBox70 , textBox66 );
            label132. Text = Operation. MultiTb ( textBox8 , textBox70 , textBox66 );
            label133. Text = Operation. MultiTb ( textBox9 , textBox70 , textBox66 );
            label134. Text = Operation. MultiTb ( textBox10 , textBox70 , textBox66 );
            label135. Text = Operation. MultiTb ( textBox11 , textBox70 , textBox66 );
            label136. Text = Operation. MultiTb ( textBox12 , textBox70 , textBox66 );
            label137. Text = Operation. MultiTb ( textBox13 , textBox70 , textBox66 );
            label138. Text = Operation. MultiTb ( textBox14 , textBox70 , textBox66 );
            label139. Text = Operation. MultiTb ( textBox15 , textBox70 , textBox66 );
            label140. Text = Operation. MultiTb ( textBox16 , textBox70 , textBox66 );
            label141. Text = Operation. MultiTb ( textBox17 , textBox70 , textBox66 );
            label142. Text = Operation. MultiTb ( textBox18 , textBox70 , textBox66 );
            label143. Text = Operation. MultiTb ( textBox19 , textBox70 , textBox66 );
            label144. Text = Operation. MultiTb ( textBox20 , textBox70 , textBox66 );
            label145. Text = Operation. MultiTb ( textBox21 , textBox70 , textBox66 );
            label146. Text = Operation. MultiTb ( textBox22 , textBox70 , textBox66 );
            label147. Text = Operation. MultiTb ( textBox23 , textBox70 , textBox66 );
            label148. Text = Operation. MultiTb ( textBox24 , textBox70 , textBox66 );
            label149. Text = Operation. MultiTb ( textBox25 , textBox70 , textBox66 );
            label150. Text = Operation. MultiTb ( textBox26 , textBox70 , textBox66 );
            label151. Text = Operation. MultiTb ( textBox27 , textBox70 , textBox66 );
            label152. Text = Operation. MultiTb ( textBox28 , textBox70 , textBox66 );
            label153. Text = Operation. MultiTb ( textBox29 , textBox70 , textBox66 );
            label154. Text = Operation. MultiTb ( textBox30 , textBox70 , textBox66 );
            label155. Text = Operation. MultiTb ( textBox31 , textBox70 , textBox66 );

            label48. Text = Operation. MultiLb ( label45 , label46 , label47 );
            label56. Text = Operation. MultiLb ( label53 , label54 , label55 );
            label64. Text = Operation. MultiLb ( label61 , label62 , label63 );
            label188. Text = Operation. MultiLb ( label98 , label128 , label158 );
            label189. Text = Operation. MultiLb ( label99 , label129 , label159 );
            label190. Text = Operation. MultiLb ( label100 , label130 , label160 );
            label191. Text = Operation. MultiLb ( label101 , label131 , label161 );
            label192. Text = Operation. MultiLb ( label102 , label132 , label162 );
            label193. Text = Operation. MultiLb ( label103 , label133 , label163 );
            label194. Text = Operation. MultiLb ( label104 , label134 , label164 );
            label195. Text = Operation. MultiLb ( label105 , label135 , label165 );
            label196. Text = Operation. MultiLb ( label106 , label136 , label166 );
            label197. Text = Operation. MultiLb ( label107 , label137 , label167 );
            label198. Text = Operation. MultiLb ( label108 , label138 , label168 );
            label199. Text = Operation. MultiLb ( label109 , label139 , label169 );
            label200. Text = Operation. MultiLb ( label110 , label140 , label170 );
            label201. Text = Operation. MultiLb ( label111 , label141 , label171 );
            label202. Text = Operation. MultiLb ( label112 , label142 , label172 );
            label203. Text = Operation. MultiLb ( label113 , label143 , label173 );
            label204. Text = Operation. MultiLb ( label114 , label144 , label174 );
            label205. Text = Operation. MultiLb ( label115 , label145 , label175 );
            label206. Text = Operation. MultiLb ( label116 , label146 , label176 );
            label207. Text = Operation. MultiLb ( label117 , label147 , label177 );
            label208. Text = Operation. MultiLb ( label118 , label148 , label178 );
            label209. Text = Operation. MultiLb ( label119 , label149 , label179 );
            label210. Text = Operation. MultiLb ( label120 , label150 , label180 );
            label211. Text = Operation. MultiLb ( label121 , label151 , label181 );
            label212. Text = Operation. MultiLb ( label122 , label152 , label182 );
            label213. Text = Operation. MultiLb ( label123 , label153 , label183 );
            label214. Text = Operation. MultiLb ( label124 , label154 , label184 );
            label215. Text = Operation. MultiLb ( label125 , label155 , label185 );

            label49. Text = Operation. DivisionLb ( label48 , label45 );
            label57. Text = Operation. DivisionLb ( label56 , label53 );
            label65. Text = Operation. DivisionLb ( label64 , label61 );
            label218. Text = Operation. DivisionLb ( label188 , label98 );
            label219. Text = Operation. DivisionLb ( label189 , label99 );
            label220. Text = Operation. DivisionLb ( label190 , label100 );
            label221. Text = Operation. DivisionLb ( label191 , label101 );
            label222. Text = Operation. DivisionLb ( label192 , label102 );
            label223. Text = Operation. DivisionLb ( label193 , label103 );
            label224. Text = Operation. DivisionLb ( label194 , label104 );
            label225. Text = Operation. DivisionLb ( label195 , label105 );
            label226. Text = Operation. DivisionLb ( label196 , label106 );
            label227. Text = Operation. DivisionLb ( label197 , label107 );
            label228. Text = Operation. DivisionLb ( label198 , label108 );
            label229. Text = Operation. DivisionLb ( label199 , label109 );
            label230. Text = Operation. DivisionLb ( label200 , label110 );
            label231. Text = Operation. DivisionLb ( label201 , label111 );
            label232. Text = Operation. DivisionLb ( label202 , label112 );
            label233. Text = Operation. DivisionLb ( label203 , label113 );
            label234. Text = Operation. DivisionLb ( label204 , label114 );
            label235. Text = Operation. DivisionLb ( label205 , label115 );
            label236. Text = Operation. DivisionLb ( label206 , label116 );
            label237. Text = Operation. DivisionLb ( label207 , label117 );
            label238. Text = Operation. DivisionLb ( label208 , label118 );
            label239. Text = Operation. DivisionLb ( label209 , label119 );
            label240. Text = Operation. DivisionLb ( label210 , label120 );
            label241. Text = Operation. DivisionLb ( label211 , label121 );
            label242. Text = Operation. DivisionLb ( label212 , label122 );
            label243. Text = Operation. DivisionLb ( label213 , label123 );
            label244. Text = Operation. DivisionLb ( label214 , label124 );
            label245. Text = Operation. DivisionLb ( label215 , label125 );

            label156. Text = Operation. MultiLbs ( lbc );
            label216. Text = Operation. MultiLbs ( lbr );
            label246. Text = Operation. DivisionLb ( label216 , label308 );
        }
        //定日提成%
        private void textBox70_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. fractionTb ( e , textBox70 );
        }
        private void textBox70_LostFocus ( object sender , EventArgs e )
        {
            if ( textBox70. Text != "" && !DateDayRegise. eightSixTb ( textBox70 ) )
            {
                this. textBox70. Text = "";
                MessageBox. Show ( "只允许输入整数部分最多三位,小数部分最多一位,如99.999999,请重新输入" );
            }
            else
            {
                label46. Text = Operation. MultiTb ( textBox1 , textBox70 , textBox66 );
                label54. Text = Operation. MultiTb ( textBox2 , textBox70 , textBox66 );
                label62. Text = Operation. MultiTb ( textBox3 , textBox70 , textBox66 );
                label128. Text = Operation. MultiTb ( textBox4 , textBox70 , textBox66 );
                label129. Text = Operation. MultiTb ( textBox5 , textBox70 , textBox66 );
                label130. Text = Operation. MultiTb ( textBox6 , textBox70 , textBox66 );
                label131. Text = Operation. MultiTb ( textBox7 , textBox70 , textBox66 );
                label132. Text = Operation. MultiTb ( textBox8 , textBox70 , textBox66 );
                label133. Text = Operation. MultiTb ( textBox9 , textBox70 , textBox66 );
                label134. Text = Operation. MultiTb ( textBox10 , textBox70 , textBox66 );
                label135. Text = Operation. MultiTb ( textBox11 , textBox70 , textBox66 );
                label136. Text = Operation. MultiTb ( textBox12 , textBox70 , textBox66 );
                label137. Text = Operation. MultiTb ( textBox13 , textBox70 , textBox66 );
                label138. Text = Operation. MultiTb ( textBox14 , textBox70 , textBox66 );
                label139. Text = Operation. MultiTb ( textBox15 , textBox70 , textBox66 );
                label140. Text = Operation. MultiTb ( textBox16 , textBox70 , textBox66 );
                label141. Text = Operation. MultiTb ( textBox17 , textBox70 , textBox66 );
                label142. Text = Operation. MultiTb ( textBox18 , textBox70 , textBox66 );
                label143. Text = Operation. MultiTb ( textBox19 , textBox70 , textBox66 );
                label144. Text = Operation. MultiTb ( textBox20 , textBox70 , textBox66 );
                label145. Text = Operation. MultiTb ( textBox21 , textBox70 , textBox66 );
                label146. Text = Operation. MultiTb ( textBox22 , textBox70 , textBox66 );
                label147. Text = Operation. MultiTb ( textBox23 , textBox70 , textBox66 );
                label148. Text = Operation. MultiTb ( textBox24 , textBox70 , textBox66 );
                label149. Text = Operation. MultiTb ( textBox25 , textBox70 , textBox66 );
                label150. Text = Operation. MultiTb ( textBox26 , textBox70 , textBox66 );
                label151. Text = Operation. MultiTb ( textBox27 , textBox70 , textBox66 );
                label152. Text = Operation. MultiTb ( textBox28 , textBox70 , textBox66 );
                label153. Text = Operation. MultiTb ( textBox29 , textBox70 , textBox66 );
                label154. Text = Operation. MultiTb ( textBox30 , textBox70 , textBox66 );
                label155. Text = Operation. MultiTb ( textBox31 , textBox70 , textBox66 );

                label48. Text = Operation. MultiLb ( label45 , label46 , label47 );
                label56. Text = Operation. MultiLb ( label53 , label54 , label55 );
                label64. Text = Operation. MultiLb ( label61 , label62 , label63 );
                label188. Text = Operation. MultiLb ( label98 , label128 , label158 );
                label189. Text = Operation. MultiLb ( label99 , label129 , label159 );
                label190. Text = Operation. MultiLb ( label100 , label130 , label160 );
                label191. Text = Operation. MultiLb ( label101 , label131 , label161 );
                label192. Text = Operation. MultiLb ( label102 , label132 , label162 );
                label193. Text = Operation. MultiLb ( label103 , label133 , label163 );
                label194. Text = Operation. MultiLb ( label104 , label134 , label164 );
                label195. Text = Operation. MultiLb ( label105 , label135 , label165 );
                label196. Text = Operation. MultiLb ( label106 , label136 , label166 );
                label197. Text = Operation. MultiLb ( label107 , label137 , label167 );
                label198. Text = Operation. MultiLb ( label108 , label138 , label168 );
                label199. Text = Operation. MultiLb ( label109 , label139 , label169 );
                label200. Text = Operation. MultiLb ( label110 , label140 , label170 );
                label201. Text = Operation. MultiLb ( label111 , label141 , label171 );
                label202. Text = Operation. MultiLb ( label112 , label142 , label172 );
                label203. Text = Operation. MultiLb ( label113 , label143 , label173 );
                label204. Text = Operation. MultiLb ( label114 , label144 , label174 );
                label205. Text = Operation. MultiLb ( label115 , label145 , label175 );
                label206. Text = Operation. MultiLb ( label116 , label146 , label176 );
                label207. Text = Operation. MultiLb ( label117 , label147 , label177 );
                label208. Text = Operation. MultiLb ( label118 , label148 , label178 );
                label209. Text = Operation. MultiLb ( label119 , label149 , label179 );
                label210. Text = Operation. MultiLb ( label120 , label150 , label180 );
                label211. Text = Operation. MultiLb ( label121 , label151 , label181 );
                label212. Text = Operation. MultiLb ( label122 , label152 , label182 );
                label213. Text = Operation. MultiLb ( label123 , label153 , label183 );
                label214. Text = Operation. MultiLb ( label124 , label154 , label184 );
                label215. Text = Operation. MultiLb ( label125 , label155 , label185 );

                label49. Text = Operation. DivisionLb ( label48 , label45 );
                label57. Text = Operation. DivisionLb ( label56 , label53 );
                label65. Text = Operation. DivisionLb ( label64 , label61 );
                label218. Text = Operation. DivisionLb ( label188 , label98 );
                label219. Text = Operation. DivisionLb ( label189 , label99 );
                label220. Text = Operation. DivisionLb ( label190 , label100 );
                label221. Text = Operation. DivisionLb ( label191 , label101 );
                label222. Text = Operation. DivisionLb ( label192 , label102 );
                label223. Text = Operation. DivisionLb ( label193 , label103 );
                label224. Text = Operation. DivisionLb ( label194 , label104 );
                label225. Text = Operation. DivisionLb ( label195 , label105 );
                label226. Text = Operation. DivisionLb ( label196 , label106 );
                label227. Text = Operation. DivisionLb ( label197 , label107 );
                label228. Text = Operation. DivisionLb ( label198 , label108 );
                label229. Text = Operation. DivisionLb ( label199 , label109 );
                label230. Text = Operation. DivisionLb ( label200 , label110 );
                label231. Text = Operation. DivisionLb ( label201 , label111 );
                label232. Text = Operation. DivisionLb ( label202 , label112 );
                label233. Text = Operation. DivisionLb ( label203 , label113 );
                label234. Text = Operation. DivisionLb ( label204 , label114 );
                label235. Text = Operation. DivisionLb ( label205 , label115 );
                label236. Text = Operation. DivisionLb ( label206 , label116 );
                label237. Text = Operation. DivisionLb ( label207 , label117 );
                label238. Text = Operation. DivisionLb ( label208 , label118 );
                label239. Text = Operation. DivisionLb ( label209 , label119 );
                label240. Text = Operation. DivisionLb ( label210 , label120 );
                label241. Text = Operation. DivisionLb ( label211 , label121 );
                label242. Text = Operation. DivisionLb ( label212 , label122 );
                label243. Text = Operation. DivisionLb ( label213 , label123 );
                label244. Text = Operation. DivisionLb ( label214 , label124 );
                label245. Text = Operation. DivisionLb ( label215 , label125 );

                label156. Text = Operation. MultiLbs ( lbc );
                label216. Text = Operation. MultiLbs ( lbr );
                label246. Text = Operation. DivisionLb ( label216 , label308 );
            }
        }
        private void textBox70_TextChanged ( object sender , EventArgs e )
        {
            DateDayRegise. textChangeTb ( textBox70 );
        }
        //定初级日工资
        private void textBox67_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //中初级日工资
        private void textBox71_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //高初级日工资
        private void textBox72_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }

        #endregion

        private void label1_Click ( object sender ,EventArgs e )
        {

        }
    }
}
