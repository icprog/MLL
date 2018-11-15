using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;
using DevExpress . XtraTreeList . Nodes;
using StudentMgr;
using System . Data . SqlClient;

namespace text
{
    public partial class Form2 : Form
    {
        public Form2 ( )
        {
            InitializeComponent ( );
        }

        List<Orag> list = new List<Orag>();

        private void Form2_Load ( object sender , EventArgs e )
        {
            list = new List<Orag> { new Orag ( 1 , 0 , "上海公司" ) , new Orag ( 2 , 1 , "上海公司1" ) , new Orag ( 3 , 1 , "上海公司2" ) , new Orag ( 4 , 1 , "上海公司3" ) , new Orag ( 7 , 3 , "上海公司2-1" ) , new Orag ( 5 , 0 , "北京公司" ) , new Orag ( 6 , 0 , "杭州公司" )  , new Orag ( 8 , 5 , "北京公司1" ) , new Orag ( 7 , 6 , "杭州公司1" ) };
            Addnode ( );

            treeList1 . DataSource = CreateTreeListTable ( );

            DataTable table = new DataTable ( );
            table . Columns . Add ( "check" ,typeof ( System . String ) );
            DataRow row = table . NewRow ( );
            row [ "check" ] = "1";
            table . Rows . Add ( row );
            row = table . NewRow ( );
            row [ "check" ] = "2";
            table . Rows . Add ( row );
            gridControl1 . DataSource = table;            
        }

        public void Addnode ( )
        {
            for ( int i = 0 ; i < list . Count ; i++ )
            {
                if ( list [ i ] . pid == 0 )
                {
                    TreeNode pnode = new TreeNode ( );
                    pnode . Text = list [ i ] . name;
                    pnode . Tag = list [ i ] . id;
                    treeView1 . Nodes . Add ( pnode );
                    AddChildnode ( list [ i ] . id , pnode );
                }
            }
        }

        public void AddChildnode ( int pid , TreeNode pnode )
        {
            for ( int i = 0 ; i < list . Count ; i++ )
            {
                if ( list [ i ] . pid == pid )
                {
                    TreeNode cnode = new TreeNode ( );
                    cnode . Text = list [ i ] . name;
                    cnode . Tag = list [ i ] . id;
                    pnode . Nodes . Add ( cnode );
                    AddChildnode ( list [ i ] . id , cnode );
                }
            }
        }

        private void treeView1_AfterSelect ( object sender , TreeViewEventArgs e )
        {

        }

        /// <summary>
        /// 构造一棵树型表结构
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTreeListTable ( )
        {

            DataTable dt = new DataTable ( );

            DataColumn dcOID = new DataColumn ( "KeyFieldName" , Type . GetType ( "System.Int32" ) );
            DataColumn dcParentOID = new DataColumn ( "ParentFieldName" , Type . GetType ( "System.Int32" ) );
            DataColumn dcNodeName = new DataColumn ( "NodeName" , Type . GetType ( "System.String" ) );
            DataColumn dcNodeCode = new DataColumn ( "NodeCode" , Type . GetType ( "System.String" ) );
            DataColumn dcOthers = new DataColumn ( "Others" , Type . GetType ( "System.String" ) );

            dt . Columns . Add ( dcOID );
            dt . Columns . Add ( dcParentOID );
            dt . Columns . Add ( dcNodeName );
            dt . Columns . Add ( dcNodeCode );
            dt . Columns . Add ( dcOthers );

            //以上代码完成了DataTable的构架，但是里面是没有任何数据的

            DataRow dr1 = dt . NewRow ( );
            dr1 [ "KeyFieldName" ] = 1;
            dr1 [ "ParentFieldName" ] = DBNull . Value;
            dr1 [ "NodeName" ] = "根节点名称";
            dr1 [ "NodeCode" ] = "根节点编码";
            dr1 [ "Others" ] = "其他";
            dt . Rows . Add ( dr1 );

            DataRow dr4 = dt . NewRow ( );
            dr4 [ "KeyFieldName" ] = 4;
            dr4 [ "ParentFieldName" ] = DBNull . Value;
            dr4 [ "NodeName" ] = "根节点名称";
            dr4 [ "NodeCode" ] = "根节点编码";
            dr4 [ "Others" ] = "其他";
            dt . Rows . Add ( dr4 );

            DataRow dr2 = dt . NewRow ( );
            dr2 [ "KeyFieldName" ] = 2;
            dr2 [ "ParentFieldName" ] = 1;
            dr2 [ "NodeName" ] = "节点子节点名称";
            dr2 [ "NodeCode" ] = "节点子节点编码";
            dr2 [ "Others" ] = "其他";
            dt . Rows . Add ( dr2 );

            DataRow dr3 = dt . NewRow ( );
            dr3 [ "KeyFieldName" ] = 3;
            dr3 [ "ParentFieldName" ] = 1;
            dr3 [ "NodeName" ] = "节点子节点名称";
            dr3 [ "NodeCode" ] = "节点子节点编码";
            dr3 [ "Others" ] = "其他";
            dt . Rows . Add ( dr3 );

            DataRow dr5 = dt . NewRow ( );
            dr5 [ "KeyFieldName" ] = 5;
            dr5 [ "ParentFieldName" ] = 4;
            dr5 [ "NodeName" ] = "节点子节点名称";
            dr5 [ "NodeCode" ] = "节点子节点编码";
            dr5 [ "Others" ] = "其他";
            dt . Rows . Add ( dr5 );

            DataRow dr6 = dt . NewRow ( );
            dr6 [ "KeyFieldName" ] = 6;
            dr6 [ "ParentFieldName" ] = 5;
            dr6 [ "NodeName" ] = "节点子节点名称";
            dr6 [ "NodeCode" ] = "节点子节点编码";
            dr6 [ "Others" ] = "其他";
            dt . Rows . Add ( dr6 );

            return dt;

        }

        /// <summary>
        /// 点击节点前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_BeforeCheckNode ( object sender , DevExpress . XtraTreeList . CheckNodeEventArgs e )
        {
            e . State = ( e . PrevState == CheckState . Checked ? CheckState . Unchecked : CheckState . Checked );
        }

        //点击节点后
        private void treeList1_AfterCheckNode ( object sender , DevExpress . XtraTreeList . NodeEventArgs e )
        {
            setCheckChildNodes ( e . Node , e . Node . CheckState );
            setCheckParentNodes ( e . Node , e . Node . CheckState );
        }

        //选择子节点时触发
        void setCheckChildNodes ( TreeListNode node , CheckState check )
        {
            for ( int i = 0 ; i < node . Nodes . Count ; i++ )
            {
                node . Nodes [ i ] . CheckState = check;
                setCheckChildNodes ( node . Nodes [ i ] , check );
            }
        }

        //选择父节点时触发
        void setCheckParentNodes ( TreeListNode node , CheckState check )
        {
            if ( node . ParentNode != null )
            {
                bool b = false;
                CheckState state;

                for ( int i = 0 ; i < node . ParentNode . Nodes . Count ; i++ )
                {
                    state = ( CheckState ) node . ParentNode . Nodes [ i ] . CheckState;
                    if ( !check . Equals ( state ) )
                    {
                        b = !b;
                        break;
                    }
                }

                node . ParentNode . CheckState = b ? CheckState . Indeterminate : check;
                setCheckParentNodes ( node . ParentNode , check );
            }
        }

        //判断此节点下的所有子节点是否选中
        Boolean IsChildsChecked ( TreeListNode node )
        {
            for ( int i = 0 ; i < node . Nodes . Count ; i++ )
            {
                if ( node . Nodes [ i ] . CheckState == CheckState . Unchecked )
                    return false;
                if ( node . Nodes [ i ] . HasChildren )
                    IsChildsChecked ( node . Nodes [ i ] );
            }

            return true;
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            //DateTime? dt = null;
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAM SET AM007=@AM007 WHERE AM002='17070246'" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@AM007",SqlDbType.DateTime)
            };
            parameter [ 0 ] . Value = DBNull . Value;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
        }
    }

    public class Orag
    {
        public int id
        {
            get;set;
        }
        public int pid
        {
            get; set;
        }
        public string name
        {
            get;set;
        }

        public Orag ( int id , int pid , string name )
        {
            this . id = id;
            this . pid = pid;
            this . name = name;
        }
    }

}
