using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Summary
{
    public partial class MaterialProcurementSummary :FormChild
    {
        public MaterialProcurementSummary ( )
        {
            InitializeComponent ( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,bandedGridView2 ,bandedGridView3 ,bandedGridView4 ,bandedGridView5 ,bandedGridView6 ,bandedGridView7 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.MaterialProcurementSummaryBll _bll=new MulaolaoBll.Bll.MaterialProcurementSummaryBll();
        DataTable tableGun,tableJiao,tableChe,tableSu,tableMu,tableWu,tableAll;
        bool result=false;string strWhere="1=1";string oddNum="R_300-20170415001";
        private void MaterialProcurementSummary_Load ( object sender , EventArgs e )
        {
            Power ( this );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GridViewMoHuSelect . SetFilter ( bandedGridView2 );
            GridViewMoHuSelect . SetFilter ( bandedGridView3 );
            GridViewMoHuSelect . SetFilter ( bandedGridView4 );
            GridViewMoHuSelect . SetFilter ( bandedGridView5 );
            GridViewMoHuSelect . SetFilter ( bandedGridView6 );
            GridViewMoHuSelect . SetFilter ( bandedGridView7 );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            toolDelete . Enabled = true;
        }
        
        #region Main
        protected override void select ( )
        {
            base . select ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BH001='" + oddNum + "'";
            refreGun ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BI001='" + oddNum + "'";
            refreJiao ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BJ001='" + oddNum + "'";
            refreChe ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BK001='" + oddNum + "'";
            refreSu ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BL001='" + oddNum + "'";
            refreMu ( );

            strWhere = "1=1";
            strWhere = strWhere + " AND BM001='" + oddNum + "'";
            refreWu ( );

            query ( );
        }
        protected override void delete ( )
        {
            base . delete ( );

            if ( tabControl1 . SelectedTab . Name == "tabPageOne" )
            {
                if ( MessageBox . Show ( "删除R337.346滚漆成本、用漆量汇总报表?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfGun ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BH001='" + oddNum + "'";
                    refreGun ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageTwo" )
            {
                if ( MessageBox . Show ( "删除R338胶合板库存?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfJiao ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BI001='" + oddNum + "'";
                    refreJiao ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageTre" )
            {
                if ( MessageBox . Show ( "删除R343五金件库存?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfChe ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BJ001='" + oddNum + "'";
                    refreChe ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageFor" )
            {
                if ( MessageBox . Show ( "删除R347塑布件库存?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfSu ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BK001='" + oddNum + "'";
                    refreSu ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageFiv" )
            {
                if ( MessageBox . Show ( "删除R341木材库存?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfMu ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BL001='" + oddNum + "'";
                    refreMu ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageSix" )
            {
                if ( MessageBox . Show ( "删除R342车木件?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfWu ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BM001='" + oddNum + "'";
                    refreWu ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
            if ( tabControl1 . SelectedTab . Name == "tabPageEgi" )
            {
                if ( MessageBox . Show ( "删除库存汇总金额?" , "删除!" , MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                result = _bll . deleteOfAll ( oddNum );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BO001='" + oddNum + "'";
                    tableAll = _bll . GetDataTableOfAll ( oddNum );
                    gridControl1 . DataSource = tableAll;
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
        }
        #endregion
        
        #region All
        void query ( )
        {
            result = _bll . Query ( oddNum );
            tableAll = _bll . GetDataTableOfAll ( oddNum );
            gridControl1 . DataSource = tableAll;
        }
        #endregion

        #region 337
        //Generate
        private void button15_Click ( object sender , EventArgs e )
        {
            //TODO:和464不一致的原因写一下
            result = _bll . GenerateGun ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BH001='" + oddNum + "'";
                refreGun ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfGun ( oddNum );
            }
        }
        //Save
        private void button2_Click ( object sender , EventArgs e )
        {
            bandedGridView1 . UpdateCurrentRow ( );
            result = _bll . saveOfGum ( tableGun );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button1_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BH001='" + oddNum + "'";
            refreGun ( );
        }

        private void bandedGridView1_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreGun ( )
        {
            tableGun = _bll . GetDataTableOfGunList ( strWhere );
            gridControl2 . DataSource = tableGun;
        }
        #endregion

        #region 338
        //Generate
        private void button16_Click ( object sender , EventArgs e )
        {
            result = _bll . GenerateOfJiao ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BI001='" + oddNum + "'";
                refreJiao ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfJiao ( oddNum );
            }
        }
        //Save
        private void button3_Click ( object sender , EventArgs e )
        {
            bandedGridView2 . UpdateCurrentRow ( );
            result = _bll . saveOfJiao ( tableJiao );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button4_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BI001='" + oddNum + "'";
            refreJiao ( );
        }

        private void bandedGridView2_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreJiao ( )
        {
            tableJiao = _bll . GetDataTableOfJiaoList ( strWhere );
            gridControl3 . DataSource = tableJiao;
        }
        #endregion

        #region 343
        //Generate
        private void button17_Click ( object sender , EventArgs e )
        {
            result = _bll . GenerateChe ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BJ001='" + oddNum + "'";
                refreChe ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfChe ( oddNum );
            }
        }
        //Save
        private void button5_Click ( object sender , EventArgs e )
        {
            bandedGridView3 . UpdateCurrentRow ( );
            result = _bll . saveOfChe ( tableChe );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button6_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BJ001='" + oddNum + "'";
            refreChe ( );
        }

        private void bandedGridView3_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreChe ( )
        {
            tableChe = _bll . GetDataTableOfCheList ( strWhere );
            gridControl4 . DataSource = tableChe;
        }
        #endregion

        #region 347
        //Generate
        private void button18_Click ( object sender , EventArgs e )
        {
            result = _bll . GenerateSu ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BK001='" + oddNum + "'";
                refreSu ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfSu ( oddNum );
            }
        }
        //Save
        private void button7_Click ( object sender , EventArgs e )
        {
            bandedGridView4 . UpdateCurrentRow ( );
            result = _bll . saveOfSu ( tableSu );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button8_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BK001='" + oddNum + "'";
            refreSu ( );
        }

        private void bandedGridView4_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreSu ( )
        {
            tableSu = _bll . GetDataTableOfSuList ( strWhere );
            gridControl5 . DataSource = tableSu;
        }
        #endregion

        #region 341
        //Generate
        private void button19_Click ( object sender , EventArgs e )
        {
            result = _bll . GenerateMu ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BL001='" + oddNum + "'";
                refreMu ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfMu ( oddNum );
            }
        }
        //Save
        private void button9_Click ( object sender , EventArgs e )
        {
            bandedGridView5 . UpdateCurrentRow ( );
            result = _bll . saveOfMu ( tableMu );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button10_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BL001='" + oddNum + "'";
            refreMu ( );
        }

        private void bandedGridView5_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreMu ( )
        {
            tableMu = _bll . GetDataTableOfMuList ( strWhere );
            gridControl6 . DataSource = tableMu;
        }
        #endregion

        #region 342
        //Generate
        private void button20_Click ( object sender , EventArgs e )
        {
            result = _bll . GenerateWu ( oddNum );
            if ( result == true )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND BM001='" + oddNum + "'";
                refreWu ( );
            }
            else
            {
                MessageBox . Show ( "生成失败,请重试" );
                _bll . deleteOfWu ( oddNum );
            }
        }
        //Save
        private void button11_Click ( object sender , EventArgs e )
        {
            bandedGridView6 . UpdateCurrentRow ( );
            result = _bll . saveOfWu ( tableWu );
            if ( result == true )
                MessageBox . Show ( "成功保存数据" );
            else
                MessageBox . Show ( "保存数据失败,请重试" );
        }
        //Query
        private void button12_Click ( object sender , EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND BM001='" + oddNum + "'";
            refreWu ( );
        }

        private void bandedGridView6_CustomDrawRowIndicator ( object sender , DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . Kind == DevExpress . Utils . Drawing . IndicatorKind . Band )
            {
                e . Appearance . DrawBackground ( e . Cache , e . Bounds );
                e . Appearance . DrawString ( e . Cache , "  序号" , e . Bounds );
                e . Handled = true;
            }
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void refreWu ( )
        {
            tableWu = _bll . GetDataTableOfWuList ( strWhere );
            gridControl7 . DataSource = tableWu;
        }
        #endregion

    }
}
