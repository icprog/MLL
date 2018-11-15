
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mulaolao.Class
{
    public static class Ergodic
    {
        public static void FormEvery ( Form fm )
        {
            foreach ( Control ct in fm.Controls )
            {
                if ( ct.GetType( ) == typeof( System.Windows.Forms.Panel ) )
                {
                    Panel sc = ct as Panel;
                    foreach ( Control cto in sc.Controls )
                    {
                        if ( cto.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = cto as TextBox;
                            tb.Text = "";
                            continue;
                        }
                        if ( cto.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = cto as ComboBox;
                            cb.Text = "";
                            continue;
                        }
                    }
                }

                if ( ct.GetType( ).ToString( ) == "System.Windows.Forms.GroupBox" )
                {
                    #region  一层
                    GroupBox gb = ct as GroupBox;
                    foreach ( Control cn in gb.Controls )
                    {
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                        {
                            #region  四层
                            TableLayoutPanel lp = cn as TableLayoutPanel;
                            foreach ( Control rl in lp.Controls )
                            {
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                {
                                    TextBox tb = rl as TextBox;
                                    tb.Text = "";
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                {
                                    ComboBox cb = rl as ComboBox;
                                    cb.Text = "";
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                {
                                    RadioButton rb = rl as RadioButton;
                                    rb.Checked = false;
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                {
                                    CheckBox cb = rl as CheckBox;
                                    cb.Checked = false;
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                {
                                    PictureBox pb = rl as PictureBox;
                                    pb.Image = null;
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                {
                                    DateTimePicker tp = rl as DateTimePicker;
                                    tp.Value = MulaolaoBll . Drity . GetDt ( );
                                    continue;
                                }
                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                                {
                                    #region 五层
                                    TableLayoutPanel pn = rl as TableLayoutPanel;
                                    foreach ( Control nn in pn.Controls )
                                    {
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                        {
                                            TextBox tb = nn as TextBox;
                                            tb.Text = "";
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                        {
                                            ComboBox cb = nn as ComboBox;
                                            cb.Text = "";
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                        {
                                            RadioButton rb = nn as RadioButton;
                                            rb.Checked = false;
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                        {
                                            CheckBox cb = nn as CheckBox;
                                            cb.Checked = false;
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                        {
                                            PictureBox pb = nn as PictureBox;
                                            pb.Image = null;
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                        {
                                            DateTimePicker tp = nn as DateTimePicker;
                                            tp.Value = MulaolaoBll . Drity . GetDt ( );
                                            continue;
                                        }
                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                                        {
                                            #region
                                            TableLayoutPanel no = nn as TableLayoutPanel;
                                            foreach ( Control io in no.Controls )
                                            {
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                                {
                                                    TextBox tb = io as TextBox;
                                                    tb.Text = "";
                                                    continue;
                                                }
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                                {
                                                    ComboBox cb = io as ComboBox;
                                                    cb.Text = "";
                                                    continue;
                                                }
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                                {
                                                    RadioButton rb = io as RadioButton;
                                                    rb.Checked = false;
                                                    continue;
                                                }
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                                {
                                                    CheckBox cb = io as CheckBox;
                                                    cb.Checked = false;
                                                    continue;
                                                }
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                                {
                                                    PictureBox pb = io as PictureBox;
                                                    pb.Image = null;
                                                    continue;
                                                }
                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                                {
                                                    DateTimePicker tp = io as DateTimePicker;
                                                    tp.Value = MulaolaoBll . Drity . GetDt ( );
                                                    continue;
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.GroupBox" )
                        {
                            #region 二层
                            GroupBox bx = cn as GroupBox;
                            foreach ( Control cx in bx.Controls )
                            {
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.GroupBox" )
                                {
                                    #region  三层
                                    GroupBox ox = cx as GroupBox;
                                    foreach ( Control lx in ox.Controls )
                                    {
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                                        {
                                            #region  四层
                                            TableLayoutPanel lp = lx as TableLayoutPanel;
                                            foreach ( Control rl in lp.Controls )
                                            {
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                                {
                                                    TextBox tb = rl as TextBox;
                                                    tb.Text = "";
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                                {
                                                    ComboBox cb = rl as ComboBox;
                                                    cb.Text = "";
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                                {
                                                    RadioButton rb = rl as RadioButton;
                                                    rb.Checked = false;
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                                {
                                                    CheckBox cb = rl as CheckBox;
                                                    cb.Checked = false;
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                                {
                                                    PictureBox pb = rl as PictureBox;
                                                    pb.Image = null;
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                                {
                                                    DateTimePicker tp = rl as DateTimePicker;
                                                    tp.Value = MulaolaoBll . Drity . GetDt ( );
                                                    continue;
                                                }
                                                if ( rl.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                                                {
                                                    #region 五层
                                                    TableLayoutPanel pn = rl as TableLayoutPanel;
                                                    foreach ( Control nn in pn.Controls )
                                                    {
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                                        {
                                                            TextBox tb = nn as TextBox;
                                                            tb.Text = "";
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                                        {
                                                            ComboBox cb = nn as ComboBox;
                                                            cb.Text = "";
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                                        {
                                                            RadioButton rb = nn as RadioButton;
                                                            rb.Checked = false;
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                                        {
                                                            CheckBox cb = nn as CheckBox;
                                                            cb.Checked = false;
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                                        {
                                                            PictureBox pb = nn as PictureBox;
                                                            pb.Image = null;
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                                        {
                                                            DateTimePicker tp = nn as DateTimePicker;
                                                            tp.Value = MulaolaoBll . Drity . GetDt ( );
                                                            continue;
                                                        }
                                                        if ( nn.GetType( ).ToString( ) == "System.Windows.Forms.TableLayoutPanel" )
                                                        {
                                                            #region
                                                            TableLayoutPanel no = nn as TableLayoutPanel;
                                                            foreach ( Control io in no.Controls )
                                                            {
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                                                {
                                                                    TextBox tb = io as TextBox;
                                                                    tb.Text = "";
                                                                    continue;
                                                                }
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                                                {
                                                                    ComboBox cb = io as ComboBox;
                                                                    cb.Text = "";
                                                                    continue;
                                                                }
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                                                {
                                                                    RadioButton rb = io as RadioButton;
                                                                    rb.Checked = false;
                                                                    continue;
                                                                }
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                                                {
                                                                    CheckBox cb = io as CheckBox;
                                                                    cb.Checked = false;
                                                                    continue;
                                                                }
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                                                {
                                                                    PictureBox pb = io as PictureBox;
                                                                    pb.Image = null;
                                                                    continue;
                                                                }
                                                                if ( io.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                                                {
                                                                    DateTimePicker tp = io as DateTimePicker;
                                                                    tp.Value = MulaolaoBll . Drity . GetDt ( );
                                                                    continue;
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                        {
                                            TextBox tb = lx as TextBox;
                                            tb.Text = "";
                                            continue;
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                        {
                                            ComboBox cb = lx as ComboBox;
                                            cb.Text = "";
                                            continue;
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                        {
                                            RadioButton rb = lx as RadioButton;
                                            rb.Checked = false;
                                            continue;
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                        {
                                            CheckBox cb = lx as CheckBox;
                                            cb.Checked = false;
                                            continue;
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                        {
                                            PictureBox pb = lx as PictureBox;
                                            pb.Image = null;
                                            continue;
                                        }
                                        if ( lx.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                        {
                                            DateTimePicker tp = lx as DateTimePicker;
                                            tp.Value = MulaolaoBll . Drity . GetDt ( );
                                            continue;
                                        }
                                    }
                                    #endregion
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                                {
                                    TextBox tb = cx as TextBox;
                                    tb.Text = "";
                                    continue;
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                                {
                                    ComboBox cb = cx as ComboBox;
                                    cb.Text = "";
                                    continue;
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                                {
                                    RadioButton rb = cx as RadioButton;
                                    rb.Checked = false;
                                    continue;
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                                {
                                    CheckBox cb = cx as CheckBox;
                                    cb.Checked = false;
                                    continue;
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                                {
                                    PictureBox pb = cx as PictureBox;
                                    pb.Image = null;
                                    continue;
                                }
                                if ( cx.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                                {
                                    DateTimePicker tp = cx as DateTimePicker;
                                    tp.Value = MulaolaoBll . Drity . GetDt ( );
                                    continue;
                                }
                            }
                            #endregion
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                        {
                            TextBox tb = cn as TextBox;
                            tb.Text = "";
                            continue;
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                        {
                            ComboBox cb = cn as ComboBox;
                            cb.Text = "";
                            continue;
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                        {
                            RadioButton rb = cn as RadioButton;
                            rb.Checked = false;
                            continue;
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                        {
                            CheckBox cb = cn as CheckBox;
                            cb.Checked = false;
                            continue;
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                        {
                            PictureBox pb = cn as PictureBox;
                            pb.Image = null;
                            continue;
                        }
                        if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.DateTimePicker" )
                        {
                            DateTimePicker tp = cn as DateTimePicker;
                            tp.Value = MulaolaoBll . Drity . GetDt ( );
                            continue;
                        }
                    }
                    #endregion                  
                }

                if ( ct.GetType( ).ToString( ) == "System.Windows.Forms.SplitContainer" )
                {
                    SplitContainer sp = ct as SplitContainer;
                    foreach ( Control con in sp.Controls )
                    {
                        if ( con.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                        {
                            SplitterPanel pan = con as SplitterPanel;
                            foreach ( Control cn in pan.Controls )
                            {
                                if ( cn.GetType( ) == typeof( TextBox ) )
                                {
                                    TextBox tb = cn as TextBox;
                                    tb.Text = "";
                                    continue;
                                }
                                if ( cn.GetType( ) == typeof( ComboBox ) )
                                {
                                    ComboBox cb = cn as ComboBox;
                                    cb.Text = "";
                                    continue;
                                }
                                #region
                                if ( cn.GetType( ) == typeof( SplitContainer ) )
                                {
                                    SplitContainer split = cn as SplitContainer;
                                    foreach ( Control splitCon in cn.Controls )
                                    {
                                        if ( splitCon.GetType( ) == typeof( SplitterPanel ) )
                                        {
                                            SplitterPanel panel = splitCon as SplitterPanel;
                                            foreach ( Control panelCon in panel.Controls )
                                            {
                                                if ( panelCon.GetType( ) == typeof( TabControl ) )
                                                {
                                                    TabControl tab = panelCon as TabControl;
                                                    foreach ( Control tabCon in tab.Controls )
                                                    {
                                                        if ( tabCon.GetType( ) == typeof( TabPage ) )
                                                        {
                                                            TabPage page = tabCon as TabPage;
                                                            foreach ( Control pageCon in page.Controls )
                                                            {
                                                                if ( pageCon.GetType( ) == typeof( SplitContainer ) )
                                                                {
                                                                    SplitContainer splitc = pageCon as SplitContainer;
                                                                    foreach ( Control splitcCon in splitc.Controls )
                                                                    {
                                                                        if ( splitcCon.GetType( ) == typeof( SplitterPanel ) )
                                                                        {
                                                                            SplitterPanel rpanel = splitcCon as SplitterPanel;
                                                                            foreach ( Control rpanelCon in rpanel.Controls )
                                                                            {
                                                                                if ( rpanelCon.GetType( ) == typeof( TextBox ) )
                                                                                {
                                                                                    TextBox box = rpanelCon as TextBox;
                                                                                    box.Text = "";
                                                                                    continue;
                                                                                }
                                                                                if ( rpanelCon.GetType( ) == typeof( ComboBox ) )
                                                                                {
                                                                                    ComboBox box = rpanelCon as ComboBox;
                                                                                    box.Text = "";
                                                                                    continue;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }

                if ( ct.GetType( ) == typeof( TabControl ) )
                {
                    TabControl tab = ct as TabControl;
                    foreach ( Control con in tab.Controls )
                    {
                        if ( con.GetType( ) == typeof( TabPage ) )
                        {
                            TabPage page = con as TabPage;
                            foreach ( Control pa in page.Controls )
                            {
                                if ( pa.GetType( ) == typeof( SplitContainer ) )
                                {
                                    SplitContainer sp = pa as SplitContainer;
                                    foreach ( Control contr in sp.Controls )
                                    {
                                        if ( contr.GetType( ) == typeof( SplitterPanel ) )
                                        {
                                            SplitterPanel pan = contr as SplitterPanel;
                                            foreach ( Control cpn in pan.Controls )
                                            {
                                                if ( cpn.GetType( ) == typeof( TextBox ) )
                                                {
                                                    TextBox tb = cpn as TextBox;
                                                    tb.Text = "";
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( ComboBox ) )
                                                {
                                                    ComboBox cb = cpn as ComboBox;
                                                    cb.Text = "";
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( DateTimePicker ) )
                                                {
                                                    DateTimePicker dt = cpn as DateTimePicker;
                                                    dt.Text = "";
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( GroupBox ) )
                                                {
                                                    GroupBox box = cpn as GroupBox;
                                                    foreach ( Control bo in box.Controls )
                                                    {
                                                        if ( bo.GetType( ) == typeof( TextBox ) )
                                                        {
                                                            TextBox tb = bo as TextBox;
                                                            tb.Text = "";
                                                            continue;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void GroupboxEvery ( GroupBox gb )
        {
            foreach ( Control cn in gb.Controls )
            {
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.GroupBox" )
                {
                    GroupBox gbx = cn as GroupBox;
                    foreach ( Control con in gbx.Controls )
                    {
                        if ( con.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                        {
                            TextBox tb = con as TextBox;
                            tb.Text = "";
                            continue;
                        }
                        if ( con.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                        {
                            ComboBox cb = con as ComboBox;
                            cb.Text = "";
                            continue;
                        }
                    }
                }
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                {
                    TextBox tb = cn as TextBox;
                    tb.Text = "";
                    continue;
                }
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                {
                    ComboBox cb = cn as ComboBox;
                    cb.Text = "";
                    continue;
                }
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                {
                    RadioButton rb = cn as RadioButton;
                    rb.Checked = false;
                    continue;
                }
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                {
                    CheckBox cb = cn as CheckBox;
                    cb.Checked = false;
                    continue;
                }
                if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                {
                    PictureBox pb = cn as PictureBox;
                    pb.Image = null;
                    continue;
                }
            }
        }
        public static void PanelEvery ( Panel sct )
        {
            foreach ( Control cto in sct.Controls )
            {
                if ( cto.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cto as TextBox;
                    tb.Text = "";
                    continue;
                }
                if ( cto.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cto as ComboBox;
                    cb.Text = "";
                    continue;
                }
            }
        }
        public static void GroupboxEvery ( GroupBox[] gb )
        {
            foreach ( GroupBox gbs in gb )
            {
                foreach ( Control cn in gbs.Controls )
                {
                    if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.TextBox" )
                    {
                        TextBox tb = cn as TextBox;
                        tb.Text = "";
                        continue;
                    }
                    if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.ComboBox" )
                    {
                        ComboBox cb = cn as ComboBox;
                        cb.Text = "";
                        continue;
                    }
                    if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.RadioButton" )
                    {
                        RadioButton rb = cn as RadioButton;
                        rb.Checked = false;
                        continue;
                    }
                    if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.CheckBox" )
                    {
                        CheckBox cb = cn as CheckBox;
                        cb.Checked = false;
                        continue;
                    }
                    if ( cn.GetType( ).ToString( ) == "System.Windows.Forms.PictureBox" )
                    {
                        PictureBox pb = cn as PictureBox;
                        pb.Image = null;
                        continue;
                    }
                }
            }
        }
        public static void CbtbEvery<T> ( List<T> ct )
        {
            foreach ( var cb in ct )
            {
                if ( cb.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cbx = cb as ComboBox;
                    cbx.Text = "";
                    continue;
                }
                if ( cb.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cb as TextBox;
                    tb.Text = "";
                    continue;
                }
            }
        }
        public static void GroupboxEveryEnableFalse ( GroupBox gb )
        {
            foreach ( Control cn in gb.Controls )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                {
                    GroupBox gbs = cn as GroupBox;
                    foreach ( Control con in gbs.Controls )
                    {

                        if ( con.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                        {
                            GroupBox gbsx = con as GroupBox;
                            foreach ( Control cont in gbsx.Controls )
                            {
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cont as TextBox;
                                    tb.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cont as ComboBox;
                                    cb.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox ck = cont as CheckBox;
                                    ck.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cont as RadioButton;
                                    rb.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                {
                                    Button bt = cont as Button;
                                    bt.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker dp = cont as DateTimePicker;
                                    dp.Enabled = false;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tl = cont as TableLayoutPanel;
                                    tl.Enabled = false;

                                    foreach ( Control ct in tl.Controls )
                                    {
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = ct as TextBox;
                                            tb.Enabled = false;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = ct as ComboBox;
                                            cb.Enabled = false;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = ct as CheckBox;
                                            cbx.Enabled = false;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = ct as RadioButton;
                                            rb.Enabled = false;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                        {
                                            TableLayoutPanel tp = ct as TableLayoutPanel;
                                            tp.Enabled = false;
                                            foreach ( Control cx in tp.Controls )
                                            {
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox tb = cx as TextBox;
                                                    tb.Enabled = false;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cb = cx as ComboBox;
                                                    cb.Enabled = false;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                                {
                                                    CheckBox cbx = cx as CheckBox;
                                                    cbx.Enabled = false;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                                {
                                                    RadioButton rb = cx as RadioButton;
                                                    rb.Enabled = false;
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if ( con.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = con as TextBox;
                            tb.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = con as ComboBox;
                            cb.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox ck = con as CheckBox;
                            ck.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = con as RadioButton;
                            rb.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.Button ) )
                        {
                            Button bt = con as Button;
                            bt.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                        {
                            DateTimePicker dp = con as DateTimePicker;
                            dp.Enabled = false;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tl = con as TableLayoutPanel;
                            tl.Enabled = false;

                            foreach ( Control ct in tl.Controls )
                            {
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = ct as TextBox;
                                    tb.Enabled = false;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = ct as ComboBox;
                                    cb.Enabled = false;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = ct as CheckBox;
                                    cbx.Enabled = false;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = ct as RadioButton;
                                    rb.Enabled = false;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tp = ct as TableLayoutPanel;
                                    tp.Enabled = false;
                                    foreach ( Control cx in tp.Controls )
                                    {
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = cx as TextBox;
                                            tb.Enabled = false;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = cx as ComboBox;
                                            cb.Enabled = false;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = cx as CheckBox;
                                            cbx.Enabled = false;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = cx as RadioButton;
                                            rb.Enabled = false;
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cn as TextBox;
                    tb.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cn as ComboBox;
                    cb.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                {
                    CheckBox ck = cn as CheckBox;
                    ck.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                {
                    RadioButton rb = cn as RadioButton;
                    rb.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.Button ) )
                {
                    Button bt = cn as Button;
                    bt.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                {
                    DateTimePicker dp = cn as DateTimePicker;
                    dp.Enabled = false;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                {
                    TableLayoutPanel tl = cn as TableLayoutPanel;
                    tl.Enabled = false;

                    foreach ( Control ct in tl.Controls )
                    {
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = ct as TextBox;
                            tb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = ct as ComboBox;
                            cb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox cbx = ct as CheckBox;
                            cbx.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = ct as RadioButton;
                            rb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tp = ct as TableLayoutPanel;
                            tp.Enabled = false;
                            foreach ( Control cx in tp.Controls )
                            {
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cx as TextBox;
                                    tb.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cx as ComboBox;
                                    cb.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = cx as CheckBox;
                                    cbx.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cx as RadioButton;
                                    rb.Enabled = false;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void PanelEnableFalse ( Panel spl )
        {
            foreach ( Control cto in spl.Controls )
            {
                if ( cto.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cto as TextBox;
                    tb.Enabled = false;
                    continue;
                }
                if ( cto.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cto as ComboBox;
                    cb.Enabled = false;
                    continue;
                }
                if ( cto.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                {
                    DateTimePicker dt = cto as DateTimePicker;
                    dt.Enabled = false;
                    continue;
                }
            }
        }
        public static void GroupboxEveryEnableTrue ( GroupBox gb )
        {
            foreach ( Control cn in gb.Controls )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                {
                    GroupBox gbs = cn as GroupBox;
                    foreach ( Control con in gbs.Controls )
                    {
                        if ( con.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                        {
                            GroupBox gbsx = con as GroupBox;
                            foreach ( Control cont in gbsx.Controls )
                            {
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cont as TextBox;
                                    tb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cont as ComboBox;
                                    cb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox ck = cont as CheckBox;
                                    ck.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cont as RadioButton;
                                    rb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                {
                                    Button bt = cont as Button;
                                    bt.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker dp = cont as DateTimePicker;
                                    dp.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tl = cont as TableLayoutPanel;
                                    tl.Enabled = true;

                                    foreach ( Control ct in tl.Controls )
                                    {
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = ct as TextBox;
                                            tb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = ct as ComboBox;
                                            cb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = ct as CheckBox;
                                            cbx.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = ct as RadioButton;
                                            rb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                        {
                                            TableLayoutPanel tp = ct as TableLayoutPanel;
                                            tp.Enabled = true;
                                            foreach ( Control cx in tp.Controls )
                                            {
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox tb = cx as TextBox;
                                                    tb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cb = cx as ComboBox;
                                                    cb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                                {
                                                    CheckBox cbx = cx as CheckBox;
                                                    cbx.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                                {
                                                    RadioButton rb = cx as RadioButton;
                                                    rb.Enabled = true;
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = con as TextBox;
                            tb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = con as ComboBox;
                            cb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox ck = con as CheckBox;
                            ck.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = con as RadioButton;
                            rb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.Button ) )
                        {
                            Button bt = con as Button;
                            bt.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                        {
                            DateTimePicker dp = con as DateTimePicker;
                            dp.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tl = con as TableLayoutPanel;
                            tl.Enabled = true;

                            foreach ( Control ct in tl.Controls )
                            {
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = ct as TextBox;
                                    tb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = ct as ComboBox;
                                    cb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = ct as CheckBox;
                                    cbx.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = ct as RadioButton;
                                    rb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tp = ct as TableLayoutPanel;
                                    tp.Enabled = true;
                                    foreach ( Control cx in tp.Controls )
                                    {
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = cx as TextBox;
                                            tb.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = cx as ComboBox;
                                            cb.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = cx as CheckBox;
                                            cbx.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = cx as RadioButton;
                                            rb.Enabled = true;
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cn as TextBox;
                    tb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cn as ComboBox;
                    cb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                {
                    CheckBox ck = cn as CheckBox;
                    ck.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                {
                    RadioButton rb = cn as RadioButton;
                    rb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.Button ) )
                {
                    Button bt = cn as Button;
                    bt.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                {
                    DateTimePicker dp = cn as DateTimePicker;
                    dp.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                {
                    TableLayoutPanel tl = cn as TableLayoutPanel;
                    tl.Enabled = false;

                    foreach ( Control ct in tl.Controls )
                    {
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = ct as TextBox;
                            tb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = ct as ComboBox;
                            cb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox cbx = ct as CheckBox;
                            cbx.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = ct as RadioButton;
                            rb.Enabled = false;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tp = ct as TableLayoutPanel;
                            tp.Enabled = false;
                            foreach ( Control cx in tp.Controls )
                            {
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cx as TextBox;
                                    tb.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cx as ComboBox;
                                    cb.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = cx as CheckBox;
                                    cbx.Enabled = false;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cx as RadioButton;
                                    rb.Enabled = false;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void PanelEnableTrue ( Panel spl )
        {
            foreach ( Control cto in spl.Controls )
            {
                if ( cto.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cto as TextBox;
                    tb.Enabled = true;
                    continue;
                }
                if ( cto.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cto as ComboBox;
                    cb.Enabled = true;
                    continue;
                }
                if ( cto.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                {
                    DateTimePicker dt = cto as DateTimePicker;
                    dt.Enabled = true;
                    continue;
                }
            }
        }
        public static void FormGroupboxEnableFalse ( Form fm ,GroupBox[] gb )
        {
            foreach ( GroupBox gbx in gb )
            {
                foreach ( Control cn in gbx.Controls )
                {
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                    {
                        GroupBox gbs = cn as GroupBox;
                        foreach ( Control con in gbs.Controls )
                        {
                            if ( con.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                            {
                                GroupBox gbsx = con as GroupBox;
                                foreach ( Control cont in gbsx.Controls )
                                {
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = cont as TextBox;
                                        tb.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = cont as ComboBox;
                                        cb.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox ck = cont as CheckBox;
                                        ck.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = cont as RadioButton;
                                        rb.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                    {
                                        Button bt = cont as Button;
                                        bt.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                    {
                                        DateTimePicker dp = cont as DateTimePicker;
                                        dp.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = cont as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = false;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                    {
                                        TableLayoutPanel tl = cont as TableLayoutPanel;
                                        tl.Enabled = false;

                                        foreach ( Control ct in tl.Controls )
                                        {
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                            {
                                                TextBox tb = ct as TextBox;
                                                tb.Enabled = false;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                            {
                                                ComboBox cb = ct as ComboBox;
                                                cb.Enabled = false;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                            {
                                                CheckBox cbx = ct as CheckBox;
                                                cbx.Enabled = false;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                            {
                                                RadioButton rb = ct as RadioButton;
                                                rb.Enabled = false;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                            {
                                                DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                                dp.Enabled = false;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                            {
                                                TableLayoutPanel tp = ct as TableLayoutPanel;
                                                tp.Enabled = false;
                                                foreach ( Control cx in tp.Controls )
                                                {
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                    {
                                                        TextBox tb = cx as TextBox;
                                                        tb.Enabled = false;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                    {
                                                        ComboBox cb = cx as ComboBox;
                                                        cb.Enabled = false;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                                    {
                                                        CheckBox cbx = cx as CheckBox;
                                                        cbx.Enabled = false;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                                    {
                                                        RadioButton rb = cx as RadioButton;
                                                        rb.Enabled = false;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                                    {
                                                        DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                                        dp.Enabled = false;
                                                        continue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if ( con.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                            {
                                TextBox tb = con as TextBox;
                                tb.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                            {
                                ComboBox cb = con as ComboBox;
                                cb.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                            {
                                CheckBox ck = con as CheckBox;
                                ck.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                            {
                                RadioButton rb = con as RadioButton;
                                rb.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.Button ) )
                            {
                                Button bt = con as Button;
                                bt.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                            {
                                DateTimePicker dp = con as DateTimePicker;
                                dp.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit dp = con as DevExpress.XtraEditors.LookUpEdit;
                                dp.Enabled = false;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                            {
                                TableLayoutPanel tl = con as TableLayoutPanel;
                                tl.Enabled = false;

                                foreach ( Control ct in tl.Controls )
                                {
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = ct as TextBox;
                                        tb.Enabled = false;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = ct as ComboBox;
                                        cb.Enabled = false;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox cbx = ct as CheckBox;
                                        cbx.Enabled = false;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = ct as RadioButton;
                                        rb.Enabled = false;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = false;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                    {
                                        TableLayoutPanel tp = ct as TableLayoutPanel;
                                        tp.Enabled = false;
                                        foreach ( Control cx in tp.Controls )
                                        {
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                            {
                                                TextBox tb = cx as TextBox;
                                                tb.Enabled = false;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                            {
                                                ComboBox cb = cx as ComboBox;
                                                cb.Enabled = false;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                            {
                                                CheckBox cbx = cx as CheckBox;
                                                cbx.Enabled = false;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                            {
                                                RadioButton rb = cx as RadioButton;
                                                rb.Enabled = false;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                            {
                                                DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                                dp.Enabled = false;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                    {
                        TextBox tb = cn as TextBox;
                        tb.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                    {
                        ComboBox cb = cn as ComboBox;
                        cb.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                    {
                        CheckBox ck = cn as CheckBox;
                        ck.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                    {
                        RadioButton rb = cn as RadioButton;
                        rb.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.Button ) )
                    {
                        Button bt = cn as Button;
                        bt.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                    {
                        DateTimePicker dp = cn as DateTimePicker;
                        dp.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                    {
                        DevExpress.XtraEditors.LookUpEdit dp = cn as DevExpress.XtraEditors.LookUpEdit;
                        dp.Enabled = false;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                    {
                        TableLayoutPanel tl = cn as TableLayoutPanel;
                        tl.Enabled = false;

                        foreach ( Control ct in tl.Controls )
                        {
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                            {
                                TextBox tb = ct as TextBox;
                                tb.Enabled = false;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                            {
                                ComboBox cb = ct as ComboBox;
                                cb.Enabled = false;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                            {
                                CheckBox cbx = ct as CheckBox;
                                cbx.Enabled = false;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                            {
                                RadioButton rb = ct as RadioButton;
                                rb.Enabled = false;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                dp.Enabled = false;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                            {
                                TableLayoutPanel tp = ct as TableLayoutPanel;
                                tp.Enabled = false;
                                foreach ( Control cx in tp.Controls )
                                {
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = cx as TextBox;
                                        tb.Enabled = false;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = cx as ComboBox;
                                        cb.Enabled = false;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox cbx = cx as CheckBox;
                                        cbx.Enabled = false;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = cx as RadioButton;
                                        rb.Enabled = false;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = false;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void FormGroupboxEnableTrue ( Form fm ,GroupBox[] gb )
        {
            foreach ( GroupBox gbx in gb )
            {
                foreach ( Control cn in gbx.Controls )
                {
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                    {
                        GroupBox gbs = cn as GroupBox;
                        foreach ( Control con in gbs.Controls )
                        {
                            if ( con.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                            {
                                GroupBox gbsx = con as GroupBox;
                                foreach ( Control cont in gbsx.Controls )
                                {
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = cont as TextBox;
                                        tb.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = cont as ComboBox;
                                        cb.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox ck = cont as CheckBox;
                                        ck.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = cont as RadioButton;
                                        rb.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                    {
                                        Button bt = cont as Button;
                                        bt.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                    {
                                        DateTimePicker dp = cont as DateTimePicker;
                                        dp.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = cont as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = true;
                                        continue;
                                    }
                                    if ( cont.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                    {
                                        TableLayoutPanel tl = cont as TableLayoutPanel;
                                        tl.Enabled = true;

                                        foreach ( Control ct in tl.Controls )
                                        {
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                            {
                                                TextBox tb = ct as TextBox;
                                                tb.Enabled = true;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                            {
                                                ComboBox cb = ct as ComboBox;
                                                cb.Enabled = true;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                            {
                                                CheckBox cbx = ct as CheckBox;
                                                cbx.Enabled = true;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                            {
                                                RadioButton rb = ct as RadioButton;
                                                rb.Enabled = true;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                            {
                                                DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                                dp.Enabled = true;
                                                continue;
                                            }
                                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                            {
                                                TableLayoutPanel tp = ct as TableLayoutPanel;
                                                tp.Enabled = true;
                                                foreach ( Control cx in tp.Controls )
                                                {
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                    {
                                                        TextBox tb = cx as TextBox;
                                                        tb.Enabled = true;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                    {
                                                        ComboBox cb = cx as ComboBox;
                                                        cb.Enabled = true;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                                    {
                                                        CheckBox cbx = cx as CheckBox;
                                                        cbx.Enabled = true;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                                    {
                                                        RadioButton rb = cx as RadioButton;
                                                        rb.Enabled = true;
                                                        continue;
                                                    }
                                                    if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                                    {
                                                        DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                                        dp.Enabled = true;
                                                        continue;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if ( con.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                            {
                                TextBox tb = con as TextBox;
                                tb.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                            {
                                ComboBox cb = con as ComboBox;
                                cb.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                            {
                                CheckBox ck = con as CheckBox;
                                ck.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                            {
                                RadioButton rb = con as RadioButton;
                                rb.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.Button ) )
                            {
                                Button bt = con as Button;
                                bt.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                            {
                                DateTimePicker dp = con as DateTimePicker;
                                dp.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit dp = con as DevExpress.XtraEditors.LookUpEdit;
                                dp.Enabled = true;
                                continue;
                            }
                            if ( con.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                            {
                                TableLayoutPanel tl = con as TableLayoutPanel;
                                tl.Enabled = true;

                                foreach ( Control ct in tl.Controls )
                                {
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = ct as TextBox;
                                        tb.Enabled = true;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = ct as ComboBox;
                                        cb.Enabled = true;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox cbx = ct as CheckBox;
                                        cbx.Enabled = true;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = ct as RadioButton;
                                        rb.Enabled = true;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = true;
                                        continue;
                                    }
                                    if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                    {
                                        TableLayoutPanel tp = ct as TableLayoutPanel;
                                        tp.Enabled = true;
                                        foreach ( Control cx in tp.Controls )
                                        {
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                            {
                                                TextBox tb = cx as TextBox;
                                                tb.Enabled = true;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                            {
                                                ComboBox cb = cx as ComboBox;
                                                cb.Enabled = true;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                            {
                                                CheckBox cbx = cx as CheckBox;
                                                cbx.Enabled = true;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                            {
                                                RadioButton rb = cx as RadioButton;
                                                rb.Enabled = true;
                                                continue;
                                            }
                                            if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                            {
                                                DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                                dp.Enabled = true;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                    {
                        TextBox tb = cn as TextBox;
                        tb.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                    {
                        ComboBox cb = cn as ComboBox;
                        cb.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                    {
                        CheckBox ck = cn as CheckBox;
                        ck.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                    {
                        RadioButton rb = cn as RadioButton;
                        rb.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.Button ) )
                    {
                        Button bt = cn as Button;
                        bt.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                    {
                        DateTimePicker dp = cn as DateTimePicker;
                        dp.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                    {
                        DevExpress.XtraEditors.LookUpEdit dp = cn as DevExpress.XtraEditors.LookUpEdit;
                        dp.Enabled = true;
                        continue;
                    }
                    if ( cn.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                    {
                        TableLayoutPanel tl = cn as TableLayoutPanel;
                        tl.Enabled = true;

                        foreach ( Control ct in tl.Controls )
                        {
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                            {
                                TextBox tb = ct as TextBox;
                                tb.Enabled = true;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                            {
                                ComboBox cb = ct as ComboBox;
                                cb.Enabled = true;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                            {
                                CheckBox cbx = ct as CheckBox;
                                cbx.Enabled = true;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                            {
                                RadioButton rb = ct as RadioButton;
                                rb.Enabled = true;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit dp = ct as DevExpress.XtraEditors.LookUpEdit;
                                dp.Enabled = true;
                                continue;
                            }
                            if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                            {
                                TableLayoutPanel tp = ct as TableLayoutPanel;
                                tp.Enabled = true;
                                foreach ( Control cx in tp.Controls )
                                {
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                    {
                                        TextBox tb = cx as TextBox;
                                        tb.Enabled = true;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                    {
                                        ComboBox cb = cx as ComboBox;
                                        cb.Enabled = true;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                    {
                                        CheckBox cbx = cx as CheckBox;
                                        cbx.Enabled = true;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                    {
                                        RadioButton rb = cx as RadioButton;
                                        rb.Enabled = true;
                                        continue;
                                    }
                                    if ( cx.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit dp = cx as DevExpress.XtraEditors.LookUpEdit;
                                        dp.Enabled = true;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void FormControlEnableTrue ( Form fm ,Control[] gb )
        {
            foreach ( Control cn in gb )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                {
                    GroupBox gbs = cn as GroupBox;
                    foreach ( Control con in gbs.Controls )
                    {
                        if ( con.GetType( ) == typeof( System.Windows.Forms.GroupBox ) )
                        {
                            GroupBox gbsx = con as GroupBox;
                            foreach ( Control cont in gbsx.Controls )
                            {
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cont as TextBox;
                                    tb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cont as ComboBox;
                                    cb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox ck = cont as CheckBox;
                                    ck.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cont as RadioButton;
                                    rb.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                {
                                    Button bt = cont as Button;
                                    bt.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker dp = cont as DateTimePicker;
                                    dp.Enabled = true;
                                    continue;
                                }
                                if ( cont.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tl = cont as TableLayoutPanel;
                                    tl.Enabled = true;

                                    foreach ( Control ct in tl.Controls )
                                    {
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = ct as TextBox;
                                            tb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = ct as ComboBox;
                                            cb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = ct as CheckBox;
                                            cbx.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = ct as RadioButton;
                                            rb.Enabled = true;
                                            continue;
                                        }
                                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                        {
                                            TableLayoutPanel tp = ct as TableLayoutPanel;
                                            tp.Enabled = true;
                                            foreach ( Control cx in tp.Controls )
                                            {
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox tb = cx as TextBox;
                                                    tb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cb = cx as ComboBox;
                                                    cb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                                {
                                                    CheckBox cbx = cx as CheckBox;
                                                    cbx.Enabled = true;
                                                    continue;
                                                }
                                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                                {
                                                    RadioButton rb = cx as RadioButton;
                                                    rb.Enabled = true;
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if ( con.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = con as TextBox;
                            tb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = con as ComboBox;
                            cb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox ck = con as CheckBox;
                            ck.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = con as RadioButton;
                            rb.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.Button ) )
                        {
                            Button bt = con as Button;
                            bt.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                        {
                            DateTimePicker dp = con as DateTimePicker;
                            dp.Enabled = true;
                            continue;
                        }
                        if ( con.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tl = con as TableLayoutPanel;
                            tl.Enabled = true;

                            foreach ( Control ct in tl.Controls )
                            {
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = ct as TextBox;
                                    tb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = ct as ComboBox;
                                    cb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = ct as CheckBox;
                                    cbx.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = ct as RadioButton;
                                    rb.Enabled = true;
                                    continue;
                                }
                                if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                                {
                                    TableLayoutPanel tp = ct as TableLayoutPanel;
                                    tp.Enabled = true;
                                    foreach ( Control cx in tp.Controls )
                                    {
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                        {
                                            TextBox tb = cx as TextBox;
                                            tb.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                        {
                                            ComboBox cb = cx as ComboBox;
                                            cb.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                        {
                                            CheckBox cbx = cx as CheckBox;
                                            cbx.Enabled = true;
                                            continue;
                                        }
                                        if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                        {
                                            RadioButton rb = cx as RadioButton;
                                            rb.Enabled = true;
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                {
                    TextBox tb = cn as TextBox;
                    tb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                {
                    ComboBox cb = cn as ComboBox;
                    cb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                {
                    CheckBox ck = cn as CheckBox;
                    ck.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                {
                    RadioButton rb = cn as RadioButton;
                    rb.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.Button ) )
                {
                    Button bt = cn as Button;
                    bt.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                {
                    DateTimePicker dp = cn as DateTimePicker;
                    dp.Enabled = true;
                    continue;
                }
                if ( cn.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                {
                    TableLayoutPanel tl = cn as TableLayoutPanel;
                    tl.Enabled = true;

                    foreach ( Control ct in tl.Controls )
                    {
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                        {
                            TextBox tb = ct as TextBox;
                            tb.Enabled = true;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                        {
                            ComboBox cb = ct as ComboBox;
                            cb.Enabled = true;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                        {
                            CheckBox cbx = ct as CheckBox;
                            cbx.Enabled = true;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                        {
                            RadioButton rb = ct as RadioButton;
                            rb.Enabled = true;
                            continue;
                        }
                        if ( ct.GetType( ) == typeof( System.Windows.Forms.TableLayoutPanel ) )
                        {
                            TableLayoutPanel tp = ct as TableLayoutPanel;
                            tp.Enabled = true;
                            foreach ( Control cx in tp.Controls )
                            {
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox tb = cx as TextBox;
                                    tb.Enabled = true;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cb = cx as ComboBox;
                                    cb.Enabled = true;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.CheckBox ) )
                                {
                                    CheckBox cbx = cx as CheckBox;
                                    cbx.Enabled = true;
                                    continue;
                                }
                                if ( cx.GetType( ) == typeof( System.Windows.Forms.RadioButton ) )
                                {
                                    RadioButton rb = cx as RadioButton;
                                    rb.Enabled = true;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void FormEverySpli ( Form fm )
        {
            foreach ( Control cn in fm.Controls )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                {
                    SplitContainer sc = cn as SplitContainer;
                    foreach ( Control cnt in sc.Controls )
                    {
                        if ( cnt.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                        {
                            SplitterPanel sp = cnt as SplitterPanel;
                            foreach ( Control to in sp.Controls )
                            {
                                if ( to.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox box = to as TextBox;
                                    box.Text = "";
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cob = to as ComboBox;
                                    cob.Text = "";
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker cob = to as DateTimePicker;
                                    cob.Text = "";
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                                {
                                    SplitContainer sct = to as SplitContainer;
                                    foreach ( Control con in sct.Controls )
                                    {
                                        if ( con.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                                        {
                                            SplitterPanel spa = con as SplitterPanel;
                                            foreach ( Control dol in spa.Controls )
                                            {
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox box = dol as TextBox;
                                                    box.Text = "";
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cob = dol as ComboBox;
                                                    cob.Text = "";
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                                {
                                                    DateTimePicker cob = dol as DateTimePicker;
                                                    cob.Text = "";
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void FormEverySpliEnableTrue ( Form fm )
        {
            foreach ( Control cn in fm.Controls )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                {
                    SplitContainer sc = cn as SplitContainer;
                    foreach ( Control cnt in sc.Controls )
                    {
                        if ( cnt.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                        {
                            SplitterPanel sp = cnt as SplitterPanel;
                            foreach ( Control to in sp.Controls )
                            {
                                if ( to.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox box = to as TextBox;
                                    box.Enabled = true;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cob = to as ComboBox;
                                    cob.Enabled = true;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker cob = to as DateTimePicker;
                                    cob.Enabled = true;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( Button ) )
                                {
                                    Button btn = to as Button;
                                    btn.Enabled = true;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( GroupBox ) )
                                {
                                    GroupBox box = to as GroupBox;
                                    foreach ( Control boxCon in box.Controls )
                                    {
                                        if ( boxCon.GetType( ) == typeof( TextBox ) )
                                        {
                                            TextBox boxT = boxCon as TextBox;
                                            boxT.Enabled = true;
                                            continue;
                                        }
                                    }
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                                {
                                    SplitContainer sct = to as SplitContainer;
                                    foreach ( Control con in sct.Controls )
                                    {
                                        if ( con.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                                        {
                                            SplitterPanel spa = con as SplitterPanel;
                                            foreach ( Control dol in spa.Controls )
                                            {
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox box = dol as TextBox;
                                                    box.Enabled = true;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cob = dol as ComboBox;
                                                    cob.Enabled = true;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                                {
                                                    DateTimePicker cob = dol as DateTimePicker;
                                                    cob.Enabled = true;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( Button ) )
                                                {
                                                    Button btn = dol as Button;
                                                    btn.Enabled = true;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( TabControl ) )
                                                {
                                                    TabControl tab = dol as TabControl;
                                                    foreach ( Control tabCon in tab.Controls )
                                                    {
                                                        if ( tabCon.GetType( ) == typeof( TabPage ) )
                                                        {
                                                            TabPage page = tabCon as TabPage;
                                                            foreach ( Control pa in page.Controls )
                                                            {
                                                                if ( pa.GetType( ) == typeof( SplitContainer ) )
                                                                {
                                                                    SplitContainer spCon = pa as SplitContainer;
                                                                    foreach ( Control contr in spCon.Controls )
                                                                    {
                                                                        if ( contr.GetType( ) == typeof( SplitterPanel ) )
                                                                        {
                                                                            SplitterPanel pan = contr as SplitterPanel;
                                                                            foreach ( Control cpn in pan.Controls )
                                                                            {
                                                                                if ( cpn.GetType( ) == typeof( TextBox ) )
                                                                                {
                                                                                    TextBox tb = cpn as TextBox;
                                                                                    tb.Enabled = true;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( ComboBox ) )
                                                                                {
                                                                                    ComboBox cb = cpn as ComboBox;
                                                                                    cb.Enabled = true;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( DateTimePicker ) )
                                                                                {
                                                                                    DateTimePicker dt = cpn as DateTimePicker;
                                                                                    dt.Enabled = true;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( Button ) )
                                                                                {
                                                                                    Button btn = cpn as Button;
                                                                                    btn.Enabled = true;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( GroupBox ) )
                                                                                {
                                                                                    GroupBox box = cpn as GroupBox;
                                                                                    foreach ( Control bo in box.Controls )
                                                                                    {
                                                                                        if ( bo.GetType( ) == typeof( TextBox ) )
                                                                                        {
                                                                                            TextBox tb = bo as TextBox;
                                                                                            tb.Enabled = true;
                                                                                            continue;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.TabControl ) )
                                {
                                    TabControl tab = to as TabControl;
                                    foreach ( Control tabCon in tab.Controls )
                                    {
                                        if ( tabCon.GetType( ) == typeof( System.Windows.Forms.TabPage ) )
                                        {
                                            TabPage page = tabCon as TabPage;
                                            foreach ( Control pageCon in page.Controls )
                                            {
                                                if ( pageCon.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                                                {
                                                    SplitContainer split = pageCon as SplitContainer;
                                                    foreach ( Control splitCon in split.Controls )
                                                    {
                                                        if ( splitCon.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                                                        {
                                                            SplitterPanel panel = splitCon as SplitterPanel;
                                                            foreach ( Control panelCon in panel.Controls )
                                                            {
                                                                if ( panelCon.GetType( ) == typeof( TextBox ) )
                                                                {
                                                                    TextBox box = panelCon as TextBox;
                                                                    box.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( ComboBox ) )
                                                                {
                                                                    ComboBox box = panelCon as ComboBox;
                                                                    box.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( DateTimePicker ) )
                                                                {
                                                                    DateTimePicker picker = panelCon as DateTimePicker;
                                                                    picker.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( Button ) )
                                                                {
                                                                    Button btn = panelCon as Button;
                                                                    btn.Enabled = false;
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ( cn.GetType( ) == typeof( TabControl ) )
                {
                    TabControl tab = cn as TabControl;
                    foreach ( Control tabCon in tab.Controls )
                    {
                        if ( tabCon.GetType( ) == typeof( TabPage ) )
                        {
                            TabPage page = tabCon as TabPage;
                            foreach ( Control pa in page.Controls )
                            {
                                if ( pa.GetType( ) == typeof( SplitContainer ) )
                                {
                                    SplitContainer spCon = pa as SplitContainer;
                                    foreach ( Control contr in spCon.Controls )
                                    {
                                        if ( contr.GetType( ) == typeof( SplitterPanel ) )
                                        {
                                            SplitterPanel pan = contr as SplitterPanel;
                                            foreach ( Control cpn in pan.Controls )
                                            {
                                                if ( cpn.GetType( ) == typeof( TextBox ) )
                                                {
                                                    TextBox tb = cpn as TextBox;
                                                    tb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( ComboBox ) )
                                                {
                                                    ComboBox cb = cpn as ComboBox;
                                                    cb.Enabled = true;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( DateTimePicker ) )
                                                {
                                                    DateTimePicker dt = cpn as DateTimePicker;
                                                    dt.Enabled = true;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( Button ) )
                                                {
                                                    Button btn = cpn as Button;
                                                    btn.Enabled = true;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( GroupBox ) )
                                                {
                                                    GroupBox box = cpn as GroupBox;
                                                    foreach ( Control bo in box.Controls )
                                                    {
                                                        if ( bo.GetType( ) == typeof( TextBox ) )
                                                        {
                                                            TextBox tb = bo as TextBox;
                                                            tb.Enabled = true;
                                                            continue;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void FormEverySpliEnableFalse ( Form fm )
        {
            foreach ( Control cn in fm.Controls )
            {
                if ( cn.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                {
                    SplitContainer sc = cn as SplitContainer;
                    foreach ( Control cnt in sc.Controls )
                    {
                        if ( cnt.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                        {
                            SplitterPanel sp = cnt as SplitterPanel;
                            foreach ( Control to in sp.Controls )
                            {
                                if ( to.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                {
                                    TextBox box = to as TextBox;
                                    box.Enabled = false;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                {
                                    ComboBox cob = to as ComboBox;
                                    cob.Enabled = false;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                {
                                    DateTimePicker cob = to as DateTimePicker;
                                    cob.Enabled = false;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                {
                                    Button btn = to as Button;
                                    btn.Enabled = false;
                                    continue;
                                }
                                if ( to.GetType( ) == typeof( GroupBox ) )
                                {
                                    GroupBox box = to as GroupBox;
                                    foreach ( Control boxCon in box.Controls )
                                    {
                                        if ( boxCon.GetType( ) == typeof( TextBox ) )
                                        {
                                            TextBox boxT = boxCon as TextBox;
                                            boxT.Enabled = false;
                                            continue;
                                        }
                                    }
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                                {
                                    SplitContainer sct = to as SplitContainer;
                                    foreach ( Control con in sct.Controls )
                                    {
                                        if ( con.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                                        {
                                            SplitterPanel spa = con as SplitterPanel;
                                            foreach ( Control dol in spa.Controls )
                                            {
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.TextBox ) )
                                                {
                                                    TextBox box = dol as TextBox;
                                                    box.Enabled = false;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.ComboBox ) )
                                                {
                                                    ComboBox cob = dol as ComboBox;
                                                    cob.Enabled = false;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.DateTimePicker ) )
                                                {
                                                    DateTimePicker cob = dol as DateTimePicker;
                                                    cob.Enabled = false;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( System.Windows.Forms.Button ) )
                                                {
                                                    Button btn = dol as Button;
                                                    btn.Enabled = false;
                                                    continue;
                                                }
                                                if ( dol.GetType( ) == typeof( TabControl ) )
                                                {
                                                    TabControl tab = dol as TabControl;
                                                    foreach ( Control tabCon in tab.Controls )
                                                    {
                                                        if ( tabCon.GetType( ) == typeof( TabPage ) )
                                                        {
                                                            TabPage page = tabCon as TabPage;
                                                            foreach ( Control pa in page.Controls )
                                                            {
                                                                if ( pa.GetType( ) == typeof( SplitContainer ) )
                                                                {
                                                                    SplitContainer spCon = pa as SplitContainer;
                                                                    foreach ( Control contr in spCon.Controls )
                                                                    {
                                                                        if ( contr.GetType( ) == typeof( SplitterPanel ) )
                                                                        {
                                                                            SplitterPanel pan = contr as SplitterPanel;
                                                                            foreach ( Control cpn in pan.Controls )
                                                                            {
                                                                                if ( cpn.GetType( ) == typeof( TextBox ) )
                                                                                {
                                                                                    TextBox tb = cpn as TextBox;
                                                                                    tb.Enabled = false;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( ComboBox ) )
                                                                                {
                                                                                    ComboBox cb = cpn as ComboBox;
                                                                                    cb.Enabled = false;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( DateTimePicker ) )
                                                                                {
                                                                                    DateTimePicker dt = cpn as DateTimePicker;
                                                                                    dt.Enabled = false;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( Button ) )
                                                                                {
                                                                                    Button btn = cpn as Button;
                                                                                    btn.Enabled = false;
                                                                                    continue;
                                                                                }
                                                                                if ( cpn.GetType( ) == typeof( GroupBox ) )
                                                                                {
                                                                                    GroupBox box = cpn as GroupBox;
                                                                                    foreach ( Control bo in box.Controls )
                                                                                    {
                                                                                        if ( bo.GetType( ) == typeof( TextBox ) )
                                                                                        {
                                                                                            TextBox tb = bo as TextBox;
                                                                                            tb.Enabled = false;
                                                                                            continue;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if ( to.GetType( ) == typeof( System.Windows.Forms.TabControl ) )
                                {
                                    TabControl tab = to as TabControl;
                                    foreach ( Control tabCon in tab.Controls )
                                    {
                                        if ( tabCon.GetType( ) == typeof( System.Windows.Forms.TabPage ) )
                                        {
                                            TabPage page = tabCon as TabPage;
                                            foreach ( Control pageCon in page.Controls )
                                            {
                                                if ( pageCon.GetType( ) == typeof( System.Windows.Forms.SplitContainer ) )
                                                {
                                                    SplitContainer split = pageCon as SplitContainer;
                                                    foreach ( Control splitCon in split.Controls )
                                                    {
                                                        if ( splitCon.GetType( ) == typeof( System.Windows.Forms.SplitterPanel ) )
                                                        {
                                                            SplitterPanel panel = splitCon as SplitterPanel;
                                                            foreach ( Control panelCon in panel.Controls )
                                                            {
                                                                if ( panelCon.GetType( ) == typeof( TextBox ) )
                                                                {
                                                                    TextBox box = panelCon as TextBox;
                                                                    box.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( ComboBox ) )
                                                                {
                                                                    ComboBox box = panelCon as ComboBox;
                                                                    box.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( DateTimePicker ) )
                                                                {
                                                                    DateTimePicker picker = panelCon as DateTimePicker;
                                                                    picker.Enabled = false;
                                                                    continue;
                                                                }
                                                                if ( panelCon.GetType( ) == typeof( Button ) )
                                                                {
                                                                    Button btn = panelCon as Button;
                                                                    btn.Enabled = false;
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ( cn.GetType( ) == typeof( TabControl ) )
                {
                    TabControl tab = cn as TabControl;
                    foreach ( Control tabCon in tab.Controls )
                    {
                        if ( tabCon.GetType( ) == typeof( TabPage ) )
                        {
                            TabPage page = tabCon as TabPage;
                            foreach ( Control pa in page.Controls )
                            {
                                if ( pa.GetType( ) == typeof( SplitContainer ) )
                                {
                                    SplitContainer spCon = pa as SplitContainer;
                                    foreach ( Control contr in spCon.Controls )
                                    {
                                        if ( contr.GetType( ) == typeof( SplitterPanel ) )
                                        {
                                            SplitterPanel pan = contr as SplitterPanel;
                                            foreach ( Control cpn in pan.Controls )
                                            {
                                                if ( cpn.GetType( ) == typeof( TextBox ) )
                                                {
                                                    TextBox tb = cpn as TextBox;
                                                    tb.Enabled = false;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( ComboBox ) )
                                                {
                                                    ComboBox cb = cpn as ComboBox;
                                                    cb.Enabled = false;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( DateTimePicker ) )
                                                {
                                                    DateTimePicker dt = cpn as DateTimePicker;
                                                    dt.Enabled = false;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( Button ) )
                                                {
                                                    Button btn = cpn as Button;
                                                    btn.Enabled = false;
                                                    continue;
                                                }
                                                if ( cpn.GetType( ) == typeof( GroupBox ) )
                                                {
                                                    GroupBox box = cpn as GroupBox;
                                                    foreach ( Control bo in box.Controls )
                                                    {
                                                        if ( bo.GetType( ) == typeof( TextBox ) )
                                                        {
                                                            TextBox tb = bo as TextBox;
                                                            tb.Enabled = false;
                                                            continue;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SpliEnableFalse ( List<SplitContainer> spList )
        {
            foreach ( SplitContainer split in spList )
            {
                foreach ( Control conSpli in split.Controls )
                {
                    if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                    {
                        SplitterPanel spli = conSpli as SplitterPanel;
                        foreach ( Control sp in spli.Controls )
                        {
                            if ( sp.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox box = sp as TextBox;
                                box.Enabled = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox box = sp as ComboBox;
                                box.Enabled = false;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( CheckBox ) )
                            {
                                CheckBox box = sp as CheckBox;
                                box . Enabled = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( DateTimePicker ) )
                            {
                                DateTimePicker date = sp as DateTimePicker;
                                date.Enabled = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( Button ) )
                            {
                                Button btn = sp as Button;
                                btn.Enabled = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                                btn.Enabled = false;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                            {
                                DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                                btn . Enabled = false;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . ComboBoxEdit ) )
                            {
                                DevExpress . XtraEditors . ComboBoxEdit btn = sp as DevExpress . XtraEditors . ComboBoxEdit;
                                btn . Enabled = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox box = sp as GroupBox;
                                foreach ( Control boxCon in box.Controls )
                                {
                                    if ( boxCon.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox text = boxCon as TextBox;
                                        text.Enabled = false;
                                        continue;
                                    }
                                    if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox text = boxCon as ComboBox;
                                        text.Enabled = false;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SpliEnableTrue ( List<SplitContainer> spList )
        {
            foreach ( SplitContainer split in spList )
            {
                foreach ( Control conSpli in split.Controls )
                {
                    if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                    {
                        SplitterPanel spli = conSpli as SplitterPanel;
                        foreach ( Control sp in spli.Controls )
                        {
                            if ( sp.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox box = sp as TextBox;
                                box.Enabled = true;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox box = sp as ComboBox;
                                box.Enabled = true;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( CheckBox ) )
                            {
                                CheckBox box = sp as CheckBox;
                                box . Enabled = true;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( DateTimePicker ) )
                            {
                                DateTimePicker date = sp as DateTimePicker;
                                date.Enabled = true;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( Button ) )
                            {
                                Button btn = sp as Button;
                                btn.Enabled = true;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                                btn.Enabled = true;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                            {
                                DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                                btn . Enabled = true;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . ComboBoxEdit ) )
                            {
                                DevExpress . XtraEditors . ComboBoxEdit btn = sp as DevExpress . XtraEditors . ComboBoxEdit;
                                btn . Enabled = true;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox box = sp as GroupBox;
                                foreach ( Control boxCon in box.Controls )
                                {
                                    if ( boxCon.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox text = boxCon as TextBox;
                                        text.Enabled = true;
                                        continue;
                                    }
                                    if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox text = boxCon as ComboBox;
                                        text.Enabled = true;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SpliClear ( List<SplitContainer> spList )
        {
            foreach ( SplitContainer split in spList )
            {
                foreach ( Control conSpli in split.Controls )
                {
                    if ( conSpli.GetType( ) == typeof( SplitterPanel ) )
                    {
                        SplitterPanel spli = conSpli as SplitterPanel;
                        foreach ( Control sp in spli.Controls )
                        {
                            if ( sp.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox box = sp as TextBox;
                                box.Text = "";
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox box = sp as ComboBox;
                                box.Text = "";
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( CheckBox ) )
                            {
                                CheckBox box = sp as CheckBox;
                                box . Checked = false;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                            {
                                DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                                btn.EditValue = null;
                                btn.ItemIndex = -1;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                            {
                                DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                                btn . EditValue = null;
                                btn . Text = string . Empty;
                                continue;
                            }
                            if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . ComboBoxEdit ) )
                            {
                                DevExpress . XtraEditors . ComboBoxEdit btn = sp as DevExpress . XtraEditors . ComboBoxEdit;
                                btn . EditValue = null;
                                btn . Text = string . Empty;
                                continue;
                            }
                            if ( sp.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox box = sp as GroupBox;
                                foreach ( Control boxCon in box.Controls )
                                {
                                    if ( boxCon.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox text = boxCon as TextBox;
                                        text.Text = "";
                                        continue;
                                    }
                                    if ( boxCon.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox text = boxCon as ComboBox;
                                        text.Text = "";
                                        continue;
                                    }
                                    if ( boxCon.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                                    {
                                        DevExpress.XtraEditors.LookUpEdit btn = boxCon as DevExpress.XtraEditors.LookUpEdit;
                                        btn.EditValue = null;
                                        btn.ItemIndex = -1;
                                        continue;
                                    }
                                }
                            }
                            if ( sp.GetType( ) == typeof( TableLayoutPanel ) )
                            {
                                TableLayoutPanel tab = sp as TableLayoutPanel;
                                foreach ( Control tabCon in tab.Controls )
                                {
                                    if ( tabCon.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox box = tabCon as TextBox;
                                        box.Text = "";
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void LookUpEditState ( List<DevExpress.XtraEditors.LookUpEdit> listLook )
        {
            foreach ( DevExpress.XtraEditors.LookUpEdit look in listLook )
            {
                look.EditValue = null;
                look.ItemIndex = -1;
            }
        }
        public static void TablePageEnableFalse ( List<TabPage> pageList )
        {
            foreach ( TabPage split in pageList )
            {
                foreach ( Control sp in split.Controls )
                {
                    if ( sp.GetType( ) == typeof( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box.Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TextBox ) )
                    {
                        TextBox box = sp as TextBox;
                        box.Enabled = false;
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box . Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( ComboBox ) )
                    {
                        ComboBox box = sp as ComboBox;
                        box.Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( DateTimePicker ) )
                    {
                        DateTimePicker date = sp as DateTimePicker;
                        date.Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( Button ) )
                    {
                        Button btn = sp as Button;
                        btn.Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                    {
                        DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                        btn.Enabled = false;
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                    {
                        DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                        btn . Enabled = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TableLayoutPanel ) )
                    {
                        TableLayoutPanel tp = sp as TableLayoutPanel;
                        foreach ( Control tpcon in tp.Controls )
                        {
                            if ( tpcon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox tpbox = tpcon as TextBox;
                                tpbox.Enabled = false;
                                continue;
                            }
                            if ( tpcon.GetType( ) == typeof( DateTimePicker ) )
                            {
                                DateTimePicker dpbox = tpcon as DateTimePicker;
                                dpbox.Enabled = false;
                                continue;
                            }
                        }
                    }
                    if ( sp.GetType( ) == typeof( GroupBox ) )
                    {
                        GroupBox box = sp as GroupBox;
                        foreach ( Control boxCon in box.Controls )
                        {
                            if ( boxCon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox text = boxCon as TextBox;
                                text.Enabled = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox text = boxCon as ComboBox;
                                text.Enabled = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( CheckBox ) )
                            {
                                CheckBox bo = boxCon as CheckBox;
                                bo.Enabled = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( RadioButton ) )
                            {
                                RadioButton butt = boxCon as RadioButton;
                                butt.Enabled = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox oup = boxCon as GroupBox;
                                foreach ( Control grou in oup.Controls )
                                {
                                    if ( grou.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox b = grou as TextBox;
                                        b.Enabled = false;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox cb = grou as ComboBox;
                                        cb.Enabled = false;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( DateTimePicker ) )
                                    {
                                        DateTimePicker dt = grou as DateTimePicker;
                                        dt.Enabled = false;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( RadioButton ) )
                                    {
                                        RadioButton rb = grou as RadioButton;
                                        rb.Enabled = false;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void TablePageEnableTrue ( List<TabPage> pageList )
        {
            foreach ( TabPage split in pageList )
            {
                foreach ( Control sp in split.Controls )
                {
                    if ( sp.GetType( ) == typeof( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box.Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TextBox ) )
                    {
                        TextBox box = sp as TextBox;
                        box.Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( ComboBox ) )
                    {
                        ComboBox box = sp as ComboBox;
                        box.Enabled = true;
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box . Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( DateTimePicker ) )
                    {
                        DateTimePicker date = sp as DateTimePicker;
                        date.Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( Button ) )
                    {
                        Button btn = sp as Button;
                        btn.Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                    {
                        DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                        btn.Enabled = true;
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                    {
                        DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                        btn . Enabled = true;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TableLayoutPanel ) )
                    {
                        TableLayoutPanel tp = sp as TableLayoutPanel;
                        foreach ( Control tpcon in tp.Controls )
                        {
                            if ( tpcon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox tpbox = tpcon as TextBox;
                                tpbox.Enabled = true;
                                continue;
                            }
                            if ( tpcon.GetType( ) == typeof( DateTimePicker ) )
                            {
                                DateTimePicker dpbox = tpcon as DateTimePicker;
                                dpbox.Enabled = true;
                                continue;
                            }
                        }
                    }
                    if ( sp.GetType( ) == typeof( GroupBox ) )
                    {
                        GroupBox box = sp as GroupBox;
                        foreach ( Control boxCon in box.Controls )
                        {
                            if ( boxCon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox text = boxCon as TextBox;
                                text.Enabled = true;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox text = boxCon as ComboBox;
                                text.Enabled = true;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( CheckBox ) )
                            {
                                CheckBox bo = boxCon as CheckBox;
                                bo.Enabled = true;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( RadioButton ) )
                            {
                                RadioButton butt = boxCon as RadioButton;
                                butt.Enabled = true;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox oup = boxCon as GroupBox;
                                foreach ( Control grou in oup.Controls )
                                {
                                    if ( grou.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox b = grou as TextBox;
                                        b.Enabled = true;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox cb = grou as ComboBox;
                                        cb.Enabled = true;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( DateTimePicker ) )
                                    {
                                        DateTimePicker dt = grou as DateTimePicker;
                                        dt.Enabled = true;
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( RadioButton ) )
                                    {
                                        RadioButton rb = grou as RadioButton;
                                        rb.Enabled = true;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void TablePageEnableClear ( List<TabPage> pageList )
        {
            foreach ( TabPage split in pageList )
            {
                foreach ( Control sp in split.Controls )
                {
                    if ( sp.GetType( ) == typeof( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box.Checked = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TextBox ) )
                    {
                        TextBox box = sp as TextBox;
                        box.Text = "";
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( ComboBox ) )
                    {
                        ComboBox box = sp as ComboBox;
                        box.Text = "";
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( CheckBox ) )
                    {
                        CheckBox box = sp as CheckBox;
                        box . Checked = false;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( DevExpress.XtraEditors.LookUpEdit ) )
                    {
                        DevExpress.XtraEditors.LookUpEdit btn = sp as DevExpress.XtraEditors.LookUpEdit;
                        btn.EditValue = null;
                        continue;
                    }
                    if ( sp . GetType ( ) == typeof ( DevExpress . XtraEditors . GridLookUpEdit ) )
                    {
                        DevExpress . XtraEditors . GridLookUpEdit btn = sp as DevExpress . XtraEditors . GridLookUpEdit;
                        btn . EditValue = null;
                        btn . Text = string . Empty;
                        continue;
                    }
                    if ( sp.GetType( ) == typeof( TableLayoutPanel ) )
                    {
                        TableLayoutPanel tp = sp as TableLayoutPanel;
                        foreach ( Control tpcon in tp.Controls )
                        {
                            if ( tpcon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox tpbox = tpcon as TextBox;
                                tpbox.Text = "";
                                continue;
                            }
                            if ( tpcon.GetType( ) == typeof( DateTimePicker ) )
                            {
                                DateTimePicker dpbox = tpcon as DateTimePicker;
                                dpbox.Value = MulaolaoBll . Drity . GetDt ( );
                                continue;
                            }
                        }
                    }
                    if ( sp.GetType( ) == typeof( GroupBox ) )
                    {
                        GroupBox box = sp as GroupBox;
                        foreach ( Control boxCon in box.Controls )
                        {
                            if ( boxCon.GetType( ) == typeof( TextBox ) )
                            {
                                TextBox text = boxCon as TextBox;
                                text.Text = "";
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( ComboBox ) )
                            {
                                ComboBox text = boxCon as ComboBox;
                                text.Text = "";
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( CheckBox ) )
                            {
                                CheckBox bo = boxCon as CheckBox;
                                bo.Checked = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( RadioButton ) )
                            {
                                RadioButton butt = boxCon as RadioButton;
                                butt.Checked = false;
                                continue;
                            }
                            if ( boxCon.GetType( ) == typeof( GroupBox ) )
                            {
                                GroupBox oup = boxCon as GroupBox;
                                foreach ( Control grou in oup.Controls )
                                {
                                    if ( grou.GetType( ) == typeof( TextBox ) )
                                    {
                                        TextBox b = grou as TextBox;
                                        b.Text = "";
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( ComboBox ) )
                                    {
                                        ComboBox cb = grou as ComboBox;
                                        cb.Text = "";
                                        continue;
                                    }
                                    if ( grou.GetType( ) == typeof( RadioButton ) )
                                    {
                                        RadioButton rb = grou as RadioButton;
                                        rb.Checked = false;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
