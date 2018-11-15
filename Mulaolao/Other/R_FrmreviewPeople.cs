using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Data. SqlClient;
using System. Drawing;
using System. Linq;
using System. Text;
using System. Windows. Forms;
using StudentMgr;
using Mulaolao. Class;

namespace Mulaolao. Other
{
    public partial class R_FrmreviewPeople : Form
    {
        public R_FrmreviewPeople (Form1 fm )
        {
            this. MdiParent = fm;
            InitializeComponent ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        DataTable gxNum;
        DataTable buName;
        DataTable singleTable;
        DataTable level;
        private void R_FrmreviewPeople_Load ( object sender , EventArgs e )
        {
            //程序名称
            gxNum = SqlHelper. ExecuteDataTable ( "SELECT CX01,CX02 FROM R_MLLCXMC" );
            comboBox1. DataSource = gxNum;
            comboBox1. DisplayMember = "CX01";
            comboBox1. ValueMember = "CX02";
            //姓名
            buName = SqlHelper. ExecuteDataTable ( "SELECT DBA001,DBA002 FROM TPADBA" );
            DataTable reName = buName. Copy ( );
            comboBox3. DataSource = reName;
            comboBox3. DisplayMember = "DBA002";
            comboBox3. ValueMember = "DBA001";
            DataTable reNamee = buName. Copy ( );
            comboBox6. DataSource = reNamee;
            comboBox6. DisplayMember = "DBA002";
            comboBox6. ValueMember = "DBA001";
            //表
            singleTable = SqlHelper. ExecuteDataTable ( "SELECT AB01,CX02,(SELECT DBA002 FROM TPADBA WHERE DBA001=AB02) DBA002,AB03,(SELECT DBA002 FROM TPADBA WHERE DBA001=AB04) DBA02,AB02 FROM R_PQAB A,R_MLLCXMC B WHERE A.AB01=B.CX01" );
            gridControl1. DataSource = singleTable;
            //级别
            level = singleTable. DefaultView. ToTable ( true , "AB03" );
            comboBox2. DataSource = level;
            comboBox2. DisplayMember = "AB03";
        }

        string AB1 = "", AB2 = "", AB04 = "";
        int AB3 = 0;
        //新建
        private void button1_Click ( object sender , EventArgs e )
        {
            if ( comboBox1. Text == "" )
            {
                MessageBox. Show ( "请选择表号" );
            }
            else if ( comboBox3. Text == "" )
            {
                MessageBox. Show ( "请选择送审人" );
            }
            else if ( buName. Select ( "DBA001='" + AB2 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择送审人" );
            }
            else if ( comboBox2. Text == "" )
            {
                MessageBox. Show ( "请录入送审级别" );
            }
            else if ( comboBox6. Text == "" )
            {
                MessageBox. Show ( "请选择执行人" );
            }
            else if ( buName. Select ( "DBA001='" + AB04 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择执行人" );
            }
            else
            {
                AB1 = comboBox1. Text;
                if ( comboBox2. Text != "" )
                {
                    AB3 = Convert. ToInt32 ( comboBox2. Text );
                }
                else
                {
                    AB3 = 1;
                }
                DataTable da = SqlHelper. ExecuteDataTable ( "SELECT * FROM R_PQAB WHERE AB01=@AB01 AND AB02=@AB02" , new System. Data. SqlClient. SqlParameter ( "@AB01" , AB1 ) , new System. Data. SqlClient. SqlParameter ( "@AB02" , AB2 ) );
                if ( da. Rows. Count < 1 )
                {
                    int count = SqlHelper. ExecuteNonQuery ( "INSERT INTO R_PQAB (AB01,AB02,AB03,AB04) VALUES (@AB01,@AB02,@AB03,@AB04)" , new SqlParameter ( "@AB01" , AB1 ) , new SqlParameter ( "@AB02" , AB2 ) , new SqlParameter ( "@AB03" , AB3 ) , new SqlParameter ( "@AB04" , AB04 ) );
                    if ( count < 1 )
                    {
                        MessageBox. Show ( "录入数据失败" );
                    }
                    else
                    {
                        MessageBox. Show ( "成功录入数据" );
                        DataRow row;
                        row = singleTable. NewRow ( );
                        row ["AB01"] = AB1;
                        row ["CX02"] = textBox1. Text;
                        row ["DBA002"] = comboBox3. Text;
                        row ["AB03"] = AB3;
                        row ["DBA02"] = comboBox6. Text;
                        row ["AB02"] = AB2;
                        singleTable. Rows. Add ( row );

                        //级别
                        level = singleTable. DefaultView. ToTable ( true , "AB03" );
                        comboBox2. DataSource = level;
                        comboBox2. DisplayMember = "AB03";
                    }
                }
                else
                {
                    MessageBox. Show ( "表号:" + comboBox1. Text + "\n\r送审人:" + comboBox3. Text + "\n\r的记录已经存在，请核实后再录入" );
                }
            }
        }
        //编辑
        private void button2_Click ( object sender , EventArgs e )
        {
            if ( comboBox1. Text == "" )
            {
                MessageBox. Show ( "请选择表号" );
            }
            else if ( comboBox3. Text == "" )
            {
                MessageBox. Show ( "请选择送审人" );
            }
            else if ( buName. Select ( "DBA001='" + AB2 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择送审人" );
            }
            else if ( comboBox2. Text == "" )
            {
                MessageBox. Show ( "请录入送审级别" );
            }
            else if ( comboBox6. Text == "" )
            {
                MessageBox. Show ( "请选择执行人" );
            }
            else if ( buName. Select ( "DBA001='" + AB04 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择执行人" );
            }
            else
            {
                AB1 = comboBox1. Text;
                if ( comboBox2. Text != "" )
                {
                    AB3 = Convert. ToInt32 ( comboBox2. Text );
                }
                else
                {
                    AB3 = 1;
                }
                if ( ab1 == AB1 && ab2 == AB2 )
                {
                    int count = SqlHelper. ExecuteNonQuery ( "UPDATE R_PQAB SET AB03=@AB03,AB04=@AB04 WHERE AB01=@AB01 AND AB02=@AB02" , new SqlParameter ( "@AB01" , AB1 ) , new SqlParameter ( "@AB02" , AB2 ) , new SqlParameter ( "@AB03" , AB3 ) , new SqlParameter ( "@AB04" , AB04 ) );
                    if ( count < 1 )
                    {
                        MessageBox. Show ( "编辑数据失败" );
                    }
                    else
                    {
                        MessageBox. Show ( "成功编辑数据" );
                        int num = gridView1. FocusedRowHandle;
                        DataRow row;
                        row = singleTable. Rows [num];
                        row. BeginEdit ( );
                        row ["AB01"] = AB1;
                        row ["CX02"] = textBox1. Text;
                        row ["DBA002"] = comboBox3. Text;
                        row ["AB03"] = AB3;
                        row ["DBA02"] = comboBox6. Text;
                        row ["AB02"] = AB2;
                        row. EndEdit ( );

                        //级别
                        level = singleTable. DefaultView. ToTable ( true , "AB03" );
                        comboBox2. DataSource = level;
                        comboBox2. DisplayMember = "AB03";
                    }
                }
                else
                {
                    if ( singleTable. Select ( "AB01='" + AB1 + "' AND AB02='" + AB2 + "'" ). Length > 0 )
                    {
                        MessageBox. Show ( "已经存在\n\r表号:" + AB1 + "\n\r送审人:" + AB2 + "\n\r的记录，请核实后再编辑" );
                    }
                    else
                    {
                        int count = SqlHelper. ExecuteNonQuery ( "UPDATE R_PQAB SET AB01=@AB01,AB02=@AB02,AB03=@AB03,AB04=@AB04 WHERE AB01=@AB1 AND AB02=@AB2" , new SqlParameter ( "@AB01" , AB1 ) , new SqlParameter ( "@AB02" , AB2 ) , new SqlParameter ( "@AB03" , AB3 ) , new SqlParameter ( "@AB04" , AB04 ) , new SqlParameter ( "@AB1" , ab1 ) , new SqlParameter ( "@AB2" , ab2 ) );
                        if ( count < 1 )
                        {
                            MessageBox. Show ( "编辑数据失败" );
                        }
                        else
                        {
                            MessageBox. Show ( "成功编辑数据" );
                            int num = gridView1. FocusedRowHandle;
                            DataRow row;
                            row = singleTable. Rows [num];
                            row. BeginEdit ( );
                            row ["AB01"] = AB1;
                            row ["CX02"] = textBox1. Text;
                            row ["DBA001"] = comboBox3. Text;
                            row ["AB03"] = AB3;
                            row ["DBA01"] = comboBox6. Text;
                            row ["AB02"] = AB2;
                            row. EndEdit ( );

                            //级别
                            level = singleTable. DefaultView. ToTable ( true , "AB03" );
                            comboBox2. DataSource = level;
                            comboBox2. DisplayMember = "AB03";
                        }
                    }
                }
            }
        }
        //删除
        private void button3_Click ( object sender , EventArgs e )
        {
            if ( comboBox1. Text == "" )
            {
                MessageBox. Show ( "请选择表号" );
            }
            else if ( comboBox3. Text == "" )
            {
                MessageBox. Show ( "请选择送审人" );
            }
            else if ( buName. Select ( "DBA001='" + AB2 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择送审人" );
            }
            else if ( comboBox2. Text == "" )
            {
                MessageBox. Show ( "请录入送审级别" );
            }
            else if ( comboBox6. Text == "" )
            {
                MessageBox. Show ( "请选择执行人" );
            }
            else if ( buName. Select ( "DBA001='" + AB04 + "'" ). Length < 1 )
            {
                MessageBox. Show ( "请重新选择执行人" );
            }
            else
            {
                AB1 = comboBox1. Text;
                if ( singleTable. Select ( "AB01='" + AB1 + "' AND AB02='" + AB2 + "'" ). Length > 0 )
                {
                    int count = SqlHelper. ExecuteNonQuery ( "DELETE FROM R_PQAB WHERE AB01=@AB01 AND AB02=@AB02" , new SqlParameter ( "@AB01" , AB1 ) , new SqlParameter ( "@AB02" , AB2 ) );
                    if ( count < 1 )
                    {
                        MessageBox. Show ( "删除数据失败" );
                    }
                    else
                    {
                        MessageBox. Show ( "成功删除数据" );
                        int num = gridView1. FocusedRowHandle;
                        singleTable. Rows. RemoveAt ( num );

                        //级别
                        level = singleTable. DefaultView. ToTable ( true , "AB03" );
                        comboBox2. DataSource = level;
                        comboBox2. DisplayMember = "AB03";
                    }
                }
                else
                {
                    MessageBox. Show ( "不存在\n\r表号:" + AB1 + "\n\r送审人:" + comboBox3. Text + "\n\r的数据，请核实后再删除" );
                }
            }
        }
        //表号
        private void comboBox1_SelectedValueChanged ( object sender , EventArgs e )
        {
            if ( comboBox1. Text != "" && gxNum. Select ( "CX01='" + comboBox1. Text + "'" ). Length > 0 )
                textBox1. Text = comboBox1. SelectedValue. ToString ( );
        }
        //表
        string ab1 = "", ab2 = "";
        private void gridView1_FocusedRowChanged ( object sender , DevExpress. XtraGrid. Views. Base. FocusedRowChangedEventArgs e )
        {
            if ( gridView1. RowCount < 1 )
            {
                comboBox1. Text = "";
                textBox1. Text = "";
                comboBox3. Text = "";
                comboBox2. Text = "";
                comboBox6. Text = "";
            }
            else
            {
                comboBox1. Text = gridView1. GetFocusedRowCellValue ( "AB01" ). ToString ( );
                textBox1. Text = gridView1. GetFocusedRowCellValue ( "CX02" ). ToString ( );
                comboBox3. Text = gridView1. GetFocusedRowCellValue ( "DBA002" ). ToString ( );
                comboBox2. Text = gridView1. GetFocusedRowCellValue ( "AB03" ). ToString ( );
                comboBox6. Text = gridView1. GetFocusedRowCellValue ( "DBA02" ). ToString ( );
                ab1 = comboBox1. Text;
                ab2 = gridView1. GetFocusedRowCellValue ( "AB02" ). ToString ( );
            }
        }
        private void gridView1_Click ( object sender , EventArgs e )
        {
            if ( gridView1. RowCount == 1 )
            {
                comboBox1. Text = gridView1. GetFocusedRowCellValue ( "AB01" ). ToString ( );
                textBox1. Text = gridView1. GetFocusedRowCellValue ( "CX02" ). ToString ( );
                comboBox3. Text = gridView1. GetFocusedRowCellValue ( "DBA002" ). ToString ( );
                comboBox2. Text = gridView1. GetFocusedRowCellValue ( "AB03" ). ToString ( );
                comboBox6. Text = gridView1. GetFocusedRowCellValue ( "DBA02" ). ToString ( );
                ab1 = comboBox1. Text;
                ab2 = gridView1. GetFocusedRowCellValue ( "AB02" ). ToString ( );
            }
        }
        //级别
        private void comboBox2_KeyPress ( object sender , KeyPressEventArgs e )
        {
            DateDayRegise. intgra ( e );
        }
        //送审人
        private void comboBox3_TextChanged ( object sender , EventArgs e )
        {
            if ( comboBox3. Text != "" && buName. Select ( "DBA002='" + comboBox3. Text + "'" ). Length > 0 )
                AB2 = comboBox3. SelectedValue. ToString ( );            
        }
        //执行人
        private void comboBox6_TextChanged ( object sender , EventArgs e )
        {
            if ( comboBox6. Text != "" && buName. Select ( "DBA002='" + comboBox6. Text + "'" ). Length > 0 )
                AB04 = comboBox6. SelectedValue. ToString ( );
        }
    }
}
