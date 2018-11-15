using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Schedule_control;
using Mulaolao.Class;
using StudentMgr;

namespace Mulaolao.Schedule_control
{
    public partial class R_Frmyanpinchangqiancehua : Form
    {
        public R_Frmyanpinchangqiancehua(Form fm )
        {
            this.MdiParent = fm;
            InitializeComponent();
        }
        yanpinSelect ys = new yanpinSelect();
        string CQ01 = "", CQ02 = "", CQ03 = "", CQ04 = "", CQ05 = "", CQ06 = "", CQ07 = "", CQ08 = "", CQ09 = "",  CQ11 = "", CQ12 = "", CQ13 = "", CQ14 = "", CQ15 = "", CQ16 = "", CQ17 = "", CQ18 = "", CQ19 = "", CQ20 = "", CQ21 = "", CQ22 = "", CQ23 = "", CQ24 = "", CQ25 = "", CQ26 = "", CQ27 = "", CQ28 = "", CQ29 = "", CQ30 = "", CQ31 = "", CQ32 = "", CQ33 = "", CQ45 = "", CQ46 = "", CQ47 = "", CQ48 = "", CQ49 = "", CQ50 = "", CQ51 = "", CQ52 = "", CQ53 = "", CQ54 = "", CQ55 = "", CQ56 = "", CQ57 = "", CQ58 = "", CQ59 = "", CQ60 = "", CQ61 = "", CQ62 = "", CQ63 = "", CQ64 = "", CQ65 = "", CQ66 = "",  CQ78 = "", CQ79 = "", CQ80 = "", CQ81 = "", CQ82 = "", CQ83 = "", CQ84 = "", CQ85 = "", CQ86 = "", CQ87 = "", CQ88 = "", CQ89 = "", CQ90 = "", CQ91 = "", CQ92 = "", CQ93 = "", CQ94 = "", CQ95 = "", CQ96 = "", CQ97 = "", CQ98 = "", CQ99 = "", CQ100 = "";

        private void R_Frmyanpinchangqiancehua_Load( object sender, EventArgs e )
        {

        }

        int CQ10 = 0, CQ34 = 0, CQ35 = 0, CQ36 = 0, CQ37 = 0, CQ38 = 0, CQ39 = 0, CQ40 = 0, CQ41 = 0, CQ42 = 0, CQ43 = 0, CQ44 = 0/*, CQ67 = 0, CQ68 = 0, CQ69 = 0, CQ70 = 0, CQ71 = 0, CQ72 = 0, CQ73 = 0, CQ74 = 0, CQ75 = 0, CQ76 = 0, CQ77 = 0*/;

        //查询
        private void toolSelect_Click( object sender, EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable("SELECT * FROM R_YPCQCEDYRWD");
            if (da.Rows.Count < 0)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    ys.comboBox1.Items.Add(da.Rows[i]["CQ01"].ToString());
                }
                ys.PassDataBetweenForm += new yanpinSelect.PassDataBetweenFormHandler(ys_PassDataBetweenForm);
                ys.Close();

                DataTable de = SqlHelper.ExecuteDataTable("SELECT * FROM R_YPCQCEDYRWD WHERE CQ01=@CQ01");
                textBox1.Text = de.Rows[0]["CQ02"].ToString();
                textBox2.Text = de.Rows[0]["CQ03"].ToString();
                textBox3.Text = de.Rows[0]["CQ04"].ToString();
                textBox5.Text = de.Rows[0]["CQ05"].ToString();
                textBox6.Text = de.Rows[0]["CQ06"].ToString();
                if (de.Rows[0]["CQ07"].ToString() == "一部")
                {
                    radioButton1.Checked = true;
                }
                else if (de.Rows[0]["CQ07"].ToString() == "二部")
                {
                    radioButton2.Checked = true;
                }
                else if (de.Rows[0]["CQ07"].ToString() == "三部")
                {
                    radioButton3.Checked = true;
                }
                else if (de.Rows[0]["CQ07"].ToString() == "四部")
                {
                    radioButton4.Checked = true;
                }
                else if (de.Rows[0]["CQ07"].ToString() == "打样间")
                {
                    radioButton5.Checked = true;
                }
                else if (de.Rows[0]["CQ07"].ToString() == "委外")
                {
                    radioButton6.Checked = true;
                }
                comboBox1.Text= de.Rows[0]["CQ08"].ToString();
                comboBox2.Text = de.Rows[0]["CQ09"].ToString();
                textBox7.Text = de.Rows[0]["CQ10"].ToString();
                if (de.Rows[0]["CQ11"].ToString() == "T")
                {
                    checkBox6.Checked = true;
                }
                if (de.Rows[0]["CQ12"].ToString() == "T")
                {
                    checkBox2.Checked = true;
                }
                if (de.Rows[0]["CQ13"].ToString() == "T")
                {
                    checkBox3.Checked = true;
                }
                if (de.Rows[0]["CQ14"].ToString() == "T")
                {
                    checkBox4.Checked = true;
                }
                string[] st = de.Rows[0]["CQ15"].ToString().Split(',');
                if (st[0]== "T")
                {
                    checkBox5.Checked = true;
                    textBox8.Text = st[1];
                }
                textBox9.Text = de.Rows[0]["CQ16"].ToString();
                if (de.Rows[0]["CQ17"].ToString() == "T")
                {
                    checkBox7.Checked = true;
                }
                if (de.Rows[0]["CQ18"].ToString() == "T")
                {
                    checkBox8.Checked = true;
                }
                if (de.Rows[0]["CQ19"].ToString() == "T")
                {
                    checkBox9.Checked = true;
                }
                if (de.Rows[0]["CQ20"].ToString() == "T")
                {
                    checkBox10.Checked = true;
                }
                if (de.Rows[0]["CQ21"].ToString() == "T")
                {
                    checkBox11.Checked = true;
                }
                string[] sr = de.Rows[0]["CQ22"].ToString().Split(',');
                if (sr[0] == "T")
                {
                    checkBox12.Checked = true;
                    textBox10.Text = sr[1];
                }
                if (de.Rows[0]["CQ23"].ToString() == "T")
                {
                    checkBox18.Checked = true;
                }
                if (de.Rows[0]["CQ24"].ToString() == "T")
                {
                    checkBox17.Checked = true;
                }
                if (de.Rows[0]["CQ25"].ToString() == "T")
                {
                    checkBox16.Checked = true;
                }
                string[] si = de.Rows[0]["CQ26"].ToString().Split(',');
                if (si[0] == "T")
                {
                    checkBox13.Checked = true;
                    textBox11.Text = si[1];
                }
                textBox12.Text = de.Rows[0]["CQ28"].ToString();
                textBox13.Text = de.Rows[0]["CQ29"].ToString();
                textBox14.Text = de.Rows[0]["CQ30"].ToString();
                textBox15.Text = de.Rows[0]["CQ31"].ToString();
                textBox16.Text = de.Rows[0]["CQ32"].ToString();
                textBox17.Text = de.Rows[0]["CQ33"].ToString();
                textBox18.Text = de.Rows[0]["CQ34"].ToString();
                textBox19.Text = de.Rows[0]["CQ35"].ToString();
                textBox20.Text = de.Rows[0]["CQ36"].ToString();
                textBox21.Text = de.Rows[0]["CQ37"].ToString();
                textBox22.Text = de.Rows[0]["CQ38"].ToString();
                textBox23.Text = de.Rows[0]["CQ39"].ToString();
                textBox24.Text = de.Rows[0]["CQ40"].ToString();
                textBox25.Text = de.Rows[0]["CQ41"].ToString();
                textBox26.Text = de.Rows[0]["CQ42"].ToString();
                textBox27.Text = de.Rows[0]["CQ43"].ToString();
                textBox28.Text = de.Rows[0]["CQ44"].ToString();
                textBox29.Text = de.Rows[0]["CQ45"].ToString();
                textBox30.Text = de.Rows[0]["CQ46"].ToString();
                textBox31.Text = de.Rows[0]["CQ47"].ToString();
                textBox32.Text = de.Rows[0]["CQ48"].ToString();
                textBox33.Text = de.Rows[0]["CQ49"].ToString();
                textBox34.Text = de.Rows[0]["CQ50"].ToString();
                textBox35.Text = de.Rows[0]["CQ51"].ToString();
                textBox36.Text = de.Rows[0]["CQ52"].ToString();
                textBox37.Text = de.Rows[0]["CQ53"].ToString();
                textBox38.Text = de.Rows[0]["CQ54"].ToString();
                textBox39.Text = de.Rows[0]["CQ55"].ToString();
                textBox40.Text = de.Rows[0]["CQ56"].ToString();
                textBox41.Text = de.Rows[0]["CQ57"].ToString();
                textBox42.Text = de.Rows[0]["CQ58"].ToString();
                textBox43.Text = de.Rows[0]["CQ59"].ToString();
                textBox44.Text = de.Rows[0]["CQ60"].ToString();
                textBox45.Text = de.Rows[0]["CQ61"].ToString();
                textBox46.Text = de.Rows[0]["CQ62"].ToString();
                textBox47.Text = de.Rows[0]["CQ63"].ToString();
                textBox48.Text = de.Rows[0]["CQ64"].ToString();
                textBox49.Text = de.Rows[0]["CQ65"].ToString();
                textBox50.Text = de.Rows[0]["CQ66"].ToString();
                textBox51.Text = de.Rows[0]["CQ67"].ToString();
                textBox52.Text = de.Rows[0]["CQ68"].ToString();
                textBox53.Text = de.Rows[0]["CQ69"].ToString();
                textBox54.Text = de.Rows[0]["CQ70"].ToString();
                textBox55.Text = de.Rows[0]["CQ71"].ToString();
                textBox56.Text = de.Rows[0]["CQ72"].ToString();
                textBox57.Text = de.Rows[0]["CQ73"].ToString();
                textBox58.Text = de.Rows[0]["CQ74"].ToString();
                textBox59.Text = de.Rows[0]["CQ75"].ToString();
                textBox60.Text = de.Rows[0]["CQ76"].ToString();
                textBox61.Text = de.Rows[0]["CQ77"].ToString();
                if (de.Rows[0]["CQ78"].ToString() == "T")
                {
                    checkBox14.Checked = true;
                }
                if (de.Rows[0]["CQ79"].ToString() == "T")
                {
                    checkBox15.Checked = true;
                }
                if (de.Rows[0]["CQ80"].ToString() == "T")
                {
                    checkBox19.Checked = true;
                }
                if (de.Rows[0]["CQ81"].ToString() == "T")
                {
                    checkBox20.Checked = true;
                }
                if (de.Rows[0]["CQ82"].ToString() == "T")
                {
                    checkBox21.Checked = true;
                }
                if (de.Rows[0]["CQ83"].ToString() == "T")
                {
                    checkBox22.Checked = true;
                }
                if (de.Rows[0]["CQ84"].ToString() == "T")
                {
                    checkBox23.Checked = true;
                }
                if (de.Rows[0]["CQ85"].ToString() == "T")
                {
                    checkBox24.Checked = true;
                }
                textBox62.Text = de.Rows[0]["CQ86"].ToString();
                if (de.Rows[0]["CQ87"].ToString() == "T")
                {
                    checkBox32.Checked = true;
                }
                if (de.Rows[0]["CQ88"].ToString() == "T")
                {
                    checkBox31.Checked = true;
                }
                if (de.Rows[0]["CQ89"].ToString() == "T")
                {
                    checkBox30.Checked = true;
                }
                if (de.Rows[0]["CQ90"].ToString() == "T")
                {
                    checkBox25.Checked = true;
                }
                textBox63.Text = de.Rows[0]["CQ91"].ToString();
                textBox64.Text = de.Rows[0]["CQ92"].ToString();
                textBox65.Text = de.Rows[0]["CQ93"].ToString();
                textBox66.Text = de.Rows[0]["CQ94"].ToString();
                textBox67.Text = de.Rows[0]["CQ95"].ToString();
                textBox68.Text = de.Rows[0]["CQ96"].ToString();
                textBox69.Text = de.Rows[0]["CQ97"].ToString();
                textBox70.Text = de.Rows[0]["CQ98"].ToString();
                textBox71.Text = de.Rows[0]["CQ99"].ToString();
                textBox72.Text = de.Rows[0]["CQ100"].ToString();
            }
        }
        string cq01 = "";
        private void ys_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            textBox4.Text = e.ConOne;
            cq01 = textBox4.Text;
        }
        //新增
        private void toolAdd_Click( object sender, EventArgs e )
        {
            CQ01= textBox4.Text;
            CQ02 = textBox1.Text;
            CQ03 = textBox2.Text;
            CQ04 = textBox3.Text;
            CQ05 = textBox5.Text;
            CQ06 = textBox6.Text;
            if (radioButton1.Checked)
            {
                CQ07 = "一部";
            }
            else if (radioButton2.Checked)
            {
                CQ07 = "二部";
            }
            else if (radioButton3.Checked)
            {
                CQ07 = "三部";
            }
            else if (radioButton4.Checked)
            {
                CQ07 = "四部";
            }
            else if (radioButton5.Checked)
            {
                CQ07 = "打样间";
            }
            else if (radioButton6.Checked)
            {
                CQ07 = "委外";
            }
            CQ08 = comboBox1.Text;
            CQ09 = comboBox2.Text;
            CQ10 = Convert.ToInt32(textBox7.Text);
            if (checkBox6.Checked)
            {
                CQ11 = "T";
            }
            if (checkBox2.Checked)
            {
                CQ12 = "T";
            }
            if (checkBox3.Checked)
            {
                CQ13 = "T";
            }
            if (checkBox4.Checked)
            {
                CQ14 = "T";
            }
            if (checkBox5.Checked)
            {
                CQ15 = "T" + "," + textBox8.Text;
            }
            CQ16 = textBox9.Text;
            if (checkBox7.Checked)
            {
                CQ17 = "T";
            }
            if (checkBox8.Checked)
            {
                CQ18 = "T";
            }
            if (checkBox9.Checked)
            {
                CQ19 = "T";
            }
            if (checkBox10.Checked)
            {
                CQ20 = "T";
            }
            if (checkBox11.Checked)
            {
                CQ21 = "T";
            }
            if (checkBox12.Checked)
            {
                CQ22 = "T" + "," + textBox10.Text;
            }
            if (checkBox18.Checked)
            {
                CQ23 = "T";
            }
            if (checkBox17.Checked)
            {
                CQ24 = "T";
            }
            if (checkBox16.Checked)
            {
                CQ25 = "T";
            }
            if (checkBox13.Checked)
            {
                CQ26 = "T" + "," + textBox11.Text;
            }
            CQ28 = textBox12.Text;
            CQ29 = textBox13.Text;
            CQ30 = textBox14.Text;
            CQ31 = textBox15.Text;
            CQ32 = textBox16.Text;
            CQ33 = textBox17.Text;
            CQ34 = Convert.ToInt32(textBox18.Text);
            CQ35 = Convert.ToInt32(textBox19.Text);
            CQ36 = Convert.ToInt32(textBox20.Text);
            CQ37 = Convert.ToInt32(textBox21.Text);
            CQ38 = Convert.ToInt32(textBox22.Text);
            CQ39 = Convert.ToInt32(textBox23.Text);
            CQ40 = Convert.ToInt32(textBox24.Text);
            CQ41 = Convert.ToInt32(textBox25.Text);
            CQ42 = Convert.ToInt32(textBox26.Text);
            CQ43 = Convert.ToInt32(textBox27.Text);
            CQ44 = Convert.ToInt32(textBox28.Text);
            CQ45 = textBox29.Text;
            CQ46 = textBox30.Text;
            CQ47 = textBox31.Text;
            CQ48 = textBox32.Text;
            CQ49 = textBox33.Text;
            CQ50 = textBox34.Text;
            CQ51 = textBox35.Text;
            CQ52 = textBox36.Text;
            CQ53 = textBox37.Text;
            CQ54 = textBox38.Text;
            CQ55 = textBox39.Text;
            CQ56 = textBox40.Text;
            CQ57 = textBox41.Text;
            CQ58 = textBox42.Text;
            CQ59 = textBox43.Text;
            CQ60 = textBox44.Text;
            CQ61 = textBox45.Text;
            CQ62 = textBox46.Text;
            CQ63 = textBox47.Text;
            CQ64 = textBox48.Text;
            CQ65 = textBox49.Text;
            CQ66 = textBox50.Text;
            //CQ67 = Convert.ToInt32(textBox51.Text);
            //CQ68 = Convert.ToInt32(textBox52.Text);
            //CQ69 = Convert.ToInt32(textBox53.Text);
            //CQ70 = Convert.ToInt32(textBox54.Text);
            //CQ71 = Convert.ToInt32(textBox55.Text);
            //CQ72 = Convert.ToInt32(textBox56.Text);
            //CQ73 = Convert.ToInt32(textBox57.Text);
            //CQ74 = Convert.ToInt32(textBox58.Text);
            //CQ75 = Convert.ToInt32(textBox59.Text);
            //CQ76 = Convert.ToInt32(textBox60.Text);
            //CQ77 = Convert.ToInt32(textBox61.Text);
            if (checkBox14.Checked)
            {
                CQ78 = "T";
            }
            if (checkBox15.Checked)
            {
                CQ79 = "T";
            }
            if (checkBox19.Checked)
            {
                CQ80 = "T";
            }
            if (checkBox20.Checked)
            {
                CQ81 = "T";
            }
            if (checkBox21.Checked)
            {
                CQ82 = "T";
            }
            if (checkBox22.Checked)
            {
                CQ83 = "T";
            }
            if (checkBox23.Checked)
            {
                CQ84 = "T";
            }
            if (checkBox24.Checked)
            {
                CQ85 = "T";
            }
            CQ86 = textBox62.Text;
            if (checkBox32.Checked)
            {
                CQ87 = "T";
            }
            if (checkBox31.Checked)
            {
                CQ88 = "T";
            }
            if (checkBox30.Checked)
            {
                CQ89 = "T";
            }
            if (checkBox25.Checked)
            {
                CQ90 = "T";
            }
            CQ91 = textBox63.Text;
            CQ92 = textBox64.Text;
            CQ93 = textBox65.Text;
            CQ94 = textBox66.Text;
            CQ95 = textBox67.Text;
            CQ96 = textBox68.Text;
            CQ97 = textBox69.Text;
            CQ98 = textBox70.Text;
            CQ99 = textBox71.Text;
            CQ100 = textBox72.Text;

            DataTable dl = SqlHelper.ExecuteDataTable("SELECT * FROM R_YPCQCEDYRWD");
            if (dl.Rows.Count < 0)
            {
                //, @CQ67, @CQ68, @CQ69, @CQ70, @CQ71, @CQ72, @CQ73, @CQ74, @CQ75, @CQ76, @CQ77
                int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_YPCQCEDYRWD (CQ01, CQ02, CQ03, CQ04, CQ05, CQ06, CQ07, CQ08, CQ09,  CQ11, CQ12, CQ13, CQ14, CQ15, CQ16, CQ17, CQ18, CQ19, CQ20, CQ21, CQ22, CQ23, CQ24, CQ25, CQ26, CQ27, CQ28, CQ29, CQ30, CQ31, CQ32, CQ33,CQ45, CQ46, CQ47,CQ48, CQ49, CQ50, CQ51, CQ52, CQ53, CQ54, CQ55, CQ56, CQ57, CQ58, CQ59, CQ60, CQ61, CQ62, CQ63, CQ64,CQ65, CQ66,  CQ78, CQ79, CQ80, CQ81, CQ82, CQ83, CQ84, CQ85, CQ86, CQ87, CQ88, CQ89, CQ90, CQ91, CQ92, CQ93, CQ94, CQ95, CQ96, CQ97, CQ98, CQ99, CQ100,CQ10, CQ34, CQ35, CQ36, CQ37, CQ38, CQ39, CQ40, CQ41, CQ42, CQ43, CQ44) VALUES (@CQ01, @CQ02, @CQ03, @CQ04, @CQ05, @CQ06, @CQ07, @CQ08, @CQ09,  @CQ11, @CQ12, @CQ13, @CQ14, @CQ15, @CQ16, @CQ17, @CQ18, @CQ19, @CQ20, @CQ21, @CQ22, @CQ23, @CQ24, @CQ25, @CQ26, @CQ27, @CQ28, @CQ29, @CQ30, @CQ31, @CQ32, @CQ33,@CQ45, @CQ46, @CQ47,@CQ48, @CQ49, @CQ50, @CQ51, @CQ52, @CQ53, @CQ54, @CQ55, @CQ56, @CQ57, @CQ58, @CQ59, @CQ60, @CQ61, @CQ62, @CQ63, @CQ64,@CQ65, @CQ66,  @CQ78, @CQ79, @CQ80, @CQ81, @CQ82, @CQ83, @CQ84, @CQ85, @CQ86, @CQ87, @CQ88, @CQ89, @CQ90, @CQ91, @CQ92, @CQ93, @CQ94, @CQ95, @CQ96, @CQ97, @CQ98, @CQ99, @CQ100,@CQ10, @CQ34, @CQ35, @CQ36, @CQ37, @CQ38, @CQ39, @CQ40, @CQ41, @CQ42, @CQ43, @CQ44)", new SqlParameter("@CQ01", CQ01), new SqlParameter("@CQ02", CQ02), new SqlParameter("@CQ03", CQ03), new SqlParameter("@CQ04", CQ04), new SqlParameter("@CQ05", CQ05), new SqlParameter("@CQ06", CQ06), new SqlParameter("@CQ07", CQ07), new SqlParameter("@CQ08", CQ08), new SqlParameter("@CQ09", CQ09), new SqlParameter("@CQ10", CQ10), new SqlParameter("@CQ11", CQ11), new SqlParameter("@CQ12", CQ12), new SqlParameter("@CQ13", CQ13), new SqlParameter("@CQ14", CQ14), new SqlParameter("@CQ15", CQ15), new SqlParameter("@CQ16", CQ16), new SqlParameter("@CQ17", CQ17), new SqlParameter("@CQ18", CQ18), new SqlParameter("@CQ19", CQ19), new SqlParameter("@CQ20", CQ20), new SqlParameter("@CQ21", CQ21), new SqlParameter("@CQ22", CQ22), new SqlParameter("@CQ23", CQ23), new SqlParameter("@CQ24", CQ24), new SqlParameter("@CQ25", CQ25), new SqlParameter("@CQ26", CQ26), new SqlParameter("@CQ27", CQ27), new SqlParameter("@CQ28", CQ28), new SqlParameter("@CQ29", CQ29), new SqlParameter("@CQ30", CQ30), new SqlParameter("@CQ31", CQ31), new SqlParameter("@CQ32", CQ32), new SqlParameter("@CQ33", CQ33), new SqlParameter("@CQ34", CQ34), new SqlParameter("@CQ35", CQ35), new SqlParameter("@CQ36", CQ36), new SqlParameter("@CQ37", CQ37), new SqlParameter("@CQ38", CQ38), new SqlParameter("@CQ39", CQ39), new SqlParameter("@CQ40", CQ40), new SqlParameter("@CQ41", CQ41), new SqlParameter("@CQ42", CQ42), new SqlParameter("@CQ43", CQ43), new SqlParameter("@CQ44", CQ44), new SqlParameter("@CQ45", CQ45), new SqlParameter("@CQ46", CQ46), new SqlParameter("@CQ47", CQ47), new SqlParameter("@CQ48", CQ48), new SqlParameter("@CQ49", CQ49), new SqlParameter("@CQ50", CQ50), new SqlParameter("@CQ51", CQ51), new SqlParameter("@CQ52", CQ52), new SqlParameter("@CQ53", CQ53), new SqlParameter("@CQ54", CQ54), new SqlParameter("@CQ55", CQ55), new SqlParameter("@CQ56", CQ56), new SqlParameter("@CQ57", CQ57), new SqlParameter("@CQ58", CQ58), new SqlParameter("@CQ59", CQ59), new SqlParameter("@CQ60", CQ60), new SqlParameter("@CQ61", CQ61), new SqlParameter("@CQ62", CQ62), new SqlParameter("@CQ63", CQ63), new SqlParameter("@CQ64", CQ64), new SqlParameter("@CQ65", CQ65), new SqlParameter("@CQ66", CQ66)/*, new SqlParameter("@CQ67", CQ67), new SqlParameter("@CQ68", CQ68), new SqlParameter("@CQ69", CQ69), new SqlParameter("@CQ70", CQ70), new SqlParameter("@CQ71", CQ71), new SqlParameter("@CQ72", CQ72), new SqlParameter("@CQ73", CQ73), new SqlParameter("@CQ74", CQ74), new SqlParameter("@CQ75", CQ75), new SqlParameter("@CQ76", CQ76), new SqlParameter("@CQ77", CQ77)*/, new SqlParameter("@CQ78", CQ78), new SqlParameter("@CQ79", CQ79), new SqlParameter("@CQ80", CQ80), new SqlParameter("@CQ81", CQ81), new SqlParameter("@CQ82", CQ82), new SqlParameter("@CQ83", CQ83), new SqlParameter("@CQ84", CQ84), new SqlParameter("@CQ85", CQ85), new SqlParameter("@CQ86", CQ86), new SqlParameter("@CQ87", CQ87), new SqlParameter("@CQ88", CQ88), new SqlParameter("@CQ89", CQ89), new SqlParameter("@CQ90", CQ90), new SqlParameter("@CQ91", CQ91), new SqlParameter("@CQ92", CQ92), new SqlParameter("@CQ93", CQ93), new SqlParameter("@CQ94", CQ94), new SqlParameter("@CQ95", CQ95), new SqlParameter("@CQ96", CQ96), new SqlParameter("@CQ97", CQ97), new SqlParameter("@CQ98", CQ98), new SqlParameter("@CQ99", CQ99), new SqlParameter("@CQ100", CQ100));
                if (count < 0)
                {
                    MessageBox.Show("录入数据失败");
                }
                else
                {
                    MessageBox.Show("成功录入数据");
                }
            }
            else
            {
                for (int i = 0; i < dl.Rows.Count; i++)
                {
                    if (dl.Rows[i]["CQ01"].ToString() == textBox4.Text)
                    {
                        //, CQ67 = @CQ67, CQ68 = @CQ68, CQ69 = @CQ69, CQ70 = @CQ70, CQ71 = @CQ71, CQ72 = @CQ72, CQ73 = @CQ73, CQ74 = @CQ74, CQ75 = @CQ75, CQ76 = @CQ76, CQ77 = @CQ77
                        int count = SqlHelper.ExecuteNonQuery("UPDATE R_YPCQCEDYRWD SET CQ01=@CQ01, CQ02=@CQ02, CQ03=@CQ03, CQ04=@CQ04, CQ05=@CQ05, CQ06=@CQ06, CQ07=@CQ07, CQ08=@CQ08, CQ09=@CQ09,  CQ11=@CQ11, CQ12=@CQ12, CQ13=@CQ13, CQ14=@CQ14, CQ15=@CQ15, CQ16=@CQ16, CQ17=@CQ17, CQ18=@CQ18, CQ19=@CQ19, CQ20=@CQ20, CQ21=@CQ21, CQ22=@CQ22, CQ23=@CQ23, CQ24=@CQ24, CQ25=@CQ25, CQ26=@CQ26, CQ27=@CQ27, CQ28=@CQ28, CQ29=@CQ29, CQ30=@CQ30, CQ31=@CQ31, CQ32=@CQ32, CQ33=@CQ33,CQ45=@CQ45, CQ46=@CQ46, CQ47=@CQ47,CQ48=@CQ48, CQ49=@CQ49, CQ50=@CQ50, CQ51=@CQ51, CQ52=@CQ52, CQ53=@CQ53, CQ54=@CQ54, CQ55=@CQ55, CQ56=@CQ56, CQ57=@CQ57, CQ58=@CQ58, CQ59=@CQ59, CQ60=@CQ60, CQ61=@CQ61, CQ62=@CQ62, CQ63=@CQ63, CQ64=@CQ64,CQ65=@CQ65, CQ66=@CQ66,  CQ78=@CQ78, CQ79=@CQ79, CQ80=@CQ80, CQ81=@CQ81, CQ82=@CQ82, CQ83=@CQ83, CQ84=@CQ84, CQ85=@CQ85, CQ86=@CQ86, CQ87=@CQ87, CQ88=@CQ88, CQ89=@CQ89, CQ90=@CQ90, CQ91=@CQ91, CQ92=@CQ92, CQ93=@CQ93, CQ94=@CQ94, CQ95=@CQ95, CQ96=@CQ96, CQ97=@CQ97, CQ98=@CQ98, CQ99=@CQ99, CQ100=@CQ100,CQ10=@CQ10, CQ34=@CQ34, CQ35=@CQ35, CQ36=@CQ36, CQ37=@CQ37, CQ38=@CQ38, CQ39=@CQ39, CQ40=@CQ40, CQ41=@CQ41, CQ42=@CQ42, CQ43=@CQ43, CQ44=@CQ44", new SqlParameter("@CQ01", CQ01), new SqlParameter("@CQ02", CQ02), new SqlParameter("@CQ03", CQ03), new SqlParameter("@CQ04", CQ04), new SqlParameter("@CQ05", CQ05), new SqlParameter("@CQ06", CQ06), new SqlParameter("@CQ07", CQ07), new SqlParameter("@CQ08", CQ08), new SqlParameter("@CQ09", CQ09), new SqlParameter("@CQ10", CQ10), new SqlParameter("@CQ11", CQ11), new SqlParameter("@CQ12", CQ12), new SqlParameter("@CQ13", CQ13), new SqlParameter("@CQ14", CQ14), new SqlParameter("@CQ15", CQ15), new SqlParameter("@CQ16", CQ16), new SqlParameter("@CQ17", CQ17), new SqlParameter("@CQ18", CQ18), new SqlParameter("@CQ19", CQ19), new SqlParameter("@CQ20", CQ20), new SqlParameter("@CQ21", CQ21), new SqlParameter("@CQ22", CQ22), new SqlParameter("@CQ23", CQ23), new SqlParameter("@CQ24", CQ24), new SqlParameter("@CQ25", CQ25), new SqlParameter("@CQ26", CQ26), new SqlParameter("@CQ27", CQ27), new SqlParameter("@CQ28", CQ28), new SqlParameter("@CQ29", CQ29), new SqlParameter("@CQ30", CQ30), new SqlParameter("@CQ31", CQ31), new SqlParameter("@CQ32", CQ32), new SqlParameter("@CQ33", CQ33), new SqlParameter("@CQ34", CQ34), new SqlParameter("@CQ35", CQ35), new SqlParameter("@CQ36", CQ36), new SqlParameter("@CQ37", CQ37), new SqlParameter("@CQ38", CQ38), new SqlParameter("@CQ39", CQ39), new SqlParameter("@CQ40", CQ40), new SqlParameter("@CQ41", CQ41), new SqlParameter("@CQ42", CQ42), new SqlParameter("@CQ43", CQ43), new SqlParameter("@CQ44", CQ44), new SqlParameter("@CQ45", CQ45), new SqlParameter("@CQ46", CQ46), new SqlParameter("@CQ47", CQ47), new SqlParameter("@CQ48", CQ48), new SqlParameter("@CQ49", CQ49), new SqlParameter("@CQ50", CQ50), new SqlParameter("@CQ51", CQ51), new SqlParameter("@CQ52", CQ52), new SqlParameter("@CQ53", CQ53), new SqlParameter("@CQ54", CQ54), new SqlParameter("@CQ55", CQ55), new SqlParameter("@CQ56", CQ56), new SqlParameter("@CQ57", CQ57), new SqlParameter("@CQ58", CQ58), new SqlParameter("@CQ59", CQ59), new SqlParameter("@CQ60", CQ60), new SqlParameter("@CQ61", CQ61), new SqlParameter("@CQ62", CQ62), new SqlParameter("@CQ63", CQ63), new SqlParameter("@CQ64", CQ64), new SqlParameter("@CQ65", CQ65), new SqlParameter("@CQ66", CQ66), /*new SqlParameter("@CQ67", CQ67), new SqlParameter("@CQ68", CQ68), new SqlParameter("@CQ69", CQ69), new SqlParameter("@CQ70", CQ70), new SqlParameter("@CQ71", CQ71), new SqlParameter("@CQ72", CQ72), new SqlParameter("@CQ73", CQ73), new SqlParameter("@CQ74", CQ74), new SqlParameter("@CQ75", CQ75), new SqlParameter("@CQ76", CQ76), new SqlParameter("@CQ77", CQ77),*/ new SqlParameter("@CQ78", CQ78), new SqlParameter("@CQ79", CQ79), new SqlParameter("@CQ80", CQ80), new SqlParameter("@CQ81", CQ81), new SqlParameter("@CQ82", CQ82), new SqlParameter("@CQ83", CQ83), new SqlParameter("@CQ84", CQ84), new SqlParameter("@CQ85", CQ85), new SqlParameter("@CQ86", CQ86), new SqlParameter("@CQ87", CQ87), new SqlParameter("@CQ88", CQ88), new SqlParameter("@CQ89", CQ89), new SqlParameter("@CQ90", CQ90), new SqlParameter("@CQ91", CQ91), new SqlParameter("@CQ92", CQ92), new SqlParameter("@CQ93", CQ93), new SqlParameter("@CQ94", CQ94), new SqlParameter("@CQ95", CQ95), new SqlParameter("@CQ96", CQ96), new SqlParameter("@CQ97", CQ97), new SqlParameter("@CQ98", CQ98), new SqlParameter("@CQ99", CQ99), new SqlParameter("@CQ100", CQ100));
                        if (count < 0)
                        {
                            MessageBox.Show("录入数据失败");
                        }
                        else
                        {
                            MessageBox.Show("成功录入数据");
                        }
                    }
                    else
                    {
                        //, @CQ67, @CQ68, @CQ69, @CQ70, @CQ71, @CQ72, @CQ73, @CQ74, @CQ75, @CQ76, @CQ77
                        int count = SqlHelper.ExecuteNonQuery("INSERT INTO R_YPCQCEDYRWD (CQ01, CQ02, CQ03, CQ04, CQ05, CQ06, CQ07, CQ08, CQ09,  CQ11, CQ12, CQ13, CQ14, CQ15, CQ16, CQ17, CQ18, CQ19, CQ20, CQ21, CQ22, CQ23, CQ24, CQ25, CQ26, CQ27, CQ28, CQ29, CQ30, CQ31, CQ32, CQ33,CQ45, CQ46, CQ47,CQ48, CQ49, CQ50, CQ51, CQ52, CQ53, CQ54, CQ55, CQ56, CQ57, CQ58, CQ59, CQ60, CQ61, CQ62, CQ63, CQ64,CQ65, CQ66,  CQ78, CQ79, CQ80, CQ81, CQ82, CQ83, CQ84, CQ85, CQ86, CQ87, CQ88, CQ89, CQ90, CQ91, CQ92, CQ93, CQ94, CQ95, CQ96, CQ97, CQ98, CQ99, CQ100,CQ10, CQ34, CQ35, CQ36, CQ37, CQ38, CQ39, CQ40, CQ41, CQ42, CQ43, CQ44) VALUES (@CQ01, @CQ02, @CQ03, @CQ04, @CQ05, @CQ06, @CQ07, @CQ08, @CQ09,  @CQ11, @CQ12, @CQ13, @CQ14, @CQ15, @CQ16, @CQ17, @CQ18, @CQ19, @CQ20, @CQ21, @CQ22, @CQ23, @CQ24, @CQ25, @CQ26, @CQ27, @CQ28, @CQ29, @CQ30, @CQ31, @CQ32, @CQ33,@CQ45, @CQ46, @CQ47,@CQ48, @CQ49, @CQ50, @CQ51, @CQ52, @CQ53, @CQ54, @CQ55, @CQ56, @CQ57, @CQ58, @CQ59, @CQ60, @CQ61, @CQ62, @CQ63, @CQ64,@CQ65, @CQ66,  @CQ78, @CQ79, @CQ80, @CQ81, @CQ82, @CQ83, @CQ84, @CQ85, @CQ86, @CQ87, @CQ88, @CQ89, @CQ90, @CQ91, @CQ92, @CQ93, @CQ94, @CQ95, @CQ96, @CQ97, @CQ98, @CQ99, @CQ100,@CQ10, @CQ34, @CQ35, @CQ36, @CQ37, @CQ38, @CQ39, @CQ40, @CQ41, @CQ42, @CQ43, @CQ44)", new SqlParameter("@CQ01", CQ01), new SqlParameter("@CQ02", CQ02), new SqlParameter("@CQ03", CQ03), new SqlParameter("@CQ04", CQ04), new SqlParameter("@CQ05", CQ05), new SqlParameter("@CQ06", CQ06), new SqlParameter("@CQ07", CQ07), new SqlParameter("@CQ08", CQ08), new SqlParameter("@CQ09", CQ09), new SqlParameter("@CQ10", CQ10), new SqlParameter("@CQ11", CQ11), new SqlParameter("@CQ12", CQ12), new SqlParameter("@CQ13", CQ13), new SqlParameter("@CQ14", CQ14), new SqlParameter("@CQ15", CQ15), new SqlParameter("@CQ16", CQ16), new SqlParameter("@CQ17", CQ17), new SqlParameter("@CQ18", CQ18), new SqlParameter("@CQ19", CQ19), new SqlParameter("@CQ20", CQ20), new SqlParameter("@CQ21", CQ21), new SqlParameter("@CQ22", CQ22), new SqlParameter("@CQ23", CQ23), new SqlParameter("@CQ24", CQ24), new SqlParameter("@CQ25", CQ25), new SqlParameter("@CQ26", CQ26), new SqlParameter("@CQ27", CQ27), new SqlParameter("@CQ28", CQ28), new SqlParameter("@CQ29", CQ29), new SqlParameter("@CQ30", CQ30), new SqlParameter("@CQ31", CQ31), new SqlParameter("@CQ32", CQ32), new SqlParameter("@CQ33", CQ33), new SqlParameter("@CQ34", CQ34), new SqlParameter("@CQ35", CQ35), new SqlParameter("@CQ36", CQ36), new SqlParameter("@CQ37", CQ37), new SqlParameter("@CQ38", CQ38), new SqlParameter("@CQ39", CQ39), new SqlParameter("@CQ40", CQ40), new SqlParameter("@CQ41", CQ41), new SqlParameter("@CQ42", CQ42), new SqlParameter("@CQ43", CQ43), new SqlParameter("@CQ44", CQ44), new SqlParameter("@CQ45", CQ45), new SqlParameter("@CQ46", CQ46), new SqlParameter("@CQ47", CQ47), new SqlParameter("@CQ48", CQ48), new SqlParameter("@CQ49", CQ49), new SqlParameter("@CQ50", CQ50), new SqlParameter("@CQ51", CQ51), new SqlParameter("@CQ52", CQ52), new SqlParameter("@CQ53", CQ53), new SqlParameter("@CQ54", CQ54), new SqlParameter("@CQ55", CQ55), new SqlParameter("@CQ56", CQ56), new SqlParameter("@CQ57", CQ57), new SqlParameter("@CQ58", CQ58), new SqlParameter("@CQ59", CQ59), new SqlParameter("@CQ60", CQ60), new SqlParameter("@CQ61", CQ61), new SqlParameter("@CQ62", CQ62), new SqlParameter("@CQ63", CQ63), new SqlParameter("@CQ64", CQ64), new SqlParameter("@CQ65", CQ65), new SqlParameter("@CQ66", CQ66), /*new SqlParameter("@CQ67", CQ67), new SqlParameter("@CQ68", CQ68), new SqlParameter("@CQ69", CQ69), new SqlParameter("@CQ70", CQ70), new SqlParameter("@CQ71", CQ71), new SqlParameter("@CQ72", CQ72), new SqlParameter("@CQ73", CQ73), new SqlParameter("@CQ74", CQ74), new SqlParameter("@CQ75", CQ75), new SqlParameter("@CQ76", CQ76), new SqlParameter("@CQ77", CQ77),*/ new SqlParameter("@CQ78", CQ78), new SqlParameter("@CQ79", CQ79), new SqlParameter("@CQ80", CQ80), new SqlParameter("@CQ81", CQ81), new SqlParameter("@CQ82", CQ82), new SqlParameter("@CQ83", CQ83), new SqlParameter("@CQ84", CQ84), new SqlParameter("@CQ85", CQ85), new SqlParameter("@CQ86", CQ86), new SqlParameter("@CQ87", CQ87), new SqlParameter("@CQ88", CQ88), new SqlParameter("@CQ89", CQ89), new SqlParameter("@CQ90", CQ90), new SqlParameter("@CQ91", CQ91), new SqlParameter("@CQ92", CQ92), new SqlParameter("@CQ93", CQ93), new SqlParameter("@CQ94", CQ94), new SqlParameter("@CQ95", CQ95), new SqlParameter("@CQ96", CQ96), new SqlParameter("@CQ97", CQ97), new SqlParameter("@CQ98", CQ98), new SqlParameter("@CQ99", CQ99), new SqlParameter("@CQ100", CQ100));
                        if (count < 0)
                        {
                            MessageBox.Show("录入数据失败");
                        }
                        else
                        {
                            MessageBox.Show("成功录入数据");
                        }
                    }
                }
            }
        }
        //删除
        private void toolDelete_Click( object sender, EventArgs e )
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("请查询需要删除的数据");
            }
            else
            {
                CQ01 = textBox4.Text;
                int count = SqlHelper.ExecuteNonQuery("DELETE FROM R_YPCQCEDYRWD WHERE CQ01=@CQ01",new SqlParameter("@CQ01",CQ01));
                if (count < 0)
                {
                    MessageBox.Show("删除数据失败");
                }
                else
                {
                    Ergodic.FormEvery(this);
                    MessageBox.Show("成功删除数据");
                }
            }
        }
        //更改
        private void toolUpdate_Click( object sender, EventArgs e )
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("请查询需要更改的数据");
            }
            else
            {
                CQ01 = textBox4.Text;
                CQ02 = textBox1.Text;
                CQ03 = textBox2.Text;
                CQ04 = textBox3.Text;
                CQ05 = textBox5.Text;
                CQ06 = textBox6.Text;
                if (radioButton1.Checked)
                {
                    CQ07 = "一部";
                }
                else if (radioButton2.Checked)
                {
                    CQ07 = "二部";
                }
                else if (radioButton3.Checked)
                {
                    CQ07 = "三部";
                }
                else if (radioButton4.Checked)
                {
                    CQ07 = "四部";
                }
                else if (radioButton5.Checked)
                {
                    CQ07 = "打样间";
                }
                else if (radioButton6.Checked)
                {
                    CQ07 = "委外";
                }
                CQ08 = comboBox1.Text;
                CQ09 = comboBox2.Text;
                CQ10 = Convert.ToInt32(textBox7.Text);
                if (checkBox6.Checked)
                {
                    CQ11 = "T";
                }
                if (checkBox2.Checked)
                {
                    CQ12 = "T";
                }
                if (checkBox3.Checked)
                {
                    CQ13 = "T";
                }
                if (checkBox4.Checked)
                {
                    CQ14 = "T";
                }
                if (checkBox5.Checked)
                {
                    CQ15 = "T" + "," + textBox8.Text;
                }
                CQ16 = textBox9.Text;
                if (checkBox7.Checked)
                {
                    CQ17 = "T";
                }
                if (checkBox8.Checked)
                {
                    CQ18 = "T";
                }
                if (checkBox9.Checked)
                {
                    CQ19 = "T";
                }
                if (checkBox10.Checked)
                {
                    CQ20 = "T";
                }
                if (checkBox11.Checked)
                {
                    CQ21 = "T";
                }
                if (checkBox12.Checked)
                {
                    CQ22 = "T" + "," + textBox10.Text;
                }
                if (checkBox18.Checked)
                {
                    CQ23 = "T";
                }
                if (checkBox17.Checked)
                {
                    CQ24 = "T";
                }
                if (checkBox16.Checked)
                {
                    CQ25 = "T";
                }
                if (checkBox13.Checked)
                {
                    CQ26 = "T" + "," + textBox11.Text;
                }
                CQ28 = textBox12.Text;
                CQ29 = textBox13.Text;
                CQ30 = textBox14.Text;
                CQ31 = textBox15.Text;
                CQ32 = textBox16.Text;
                CQ33 = textBox17.Text;
                CQ34 = Convert.ToInt32(textBox18.Text);
                CQ35 = Convert.ToInt32(textBox19.Text);
                CQ36 = Convert.ToInt32(textBox20.Text);
                CQ37 = Convert.ToInt32(textBox21.Text);
                CQ38 = Convert.ToInt32(textBox22.Text);
                CQ39 = Convert.ToInt32(textBox23.Text);
                CQ40 = Convert.ToInt32(textBox24.Text);
                CQ41 = Convert.ToInt32(textBox25.Text);
                CQ42 = Convert.ToInt32(textBox26.Text);
                CQ43 = Convert.ToInt32(textBox27.Text);
                CQ44 = Convert.ToInt32(textBox28.Text);
                CQ45 = textBox29.Text;
                CQ46 = textBox30.Text;
                CQ47 = textBox31.Text;
                CQ48 = textBox32.Text;
                CQ49 = textBox33.Text;
                CQ50 = textBox34.Text;
                CQ51 = textBox35.Text;
                CQ52 = textBox36.Text;
                CQ53 = textBox37.Text;
                CQ54 = textBox38.Text;
                CQ55 = textBox39.Text;
                CQ56 = textBox40.Text;
                CQ57 = textBox41.Text;
                CQ58 = textBox42.Text;
                CQ59 = textBox43.Text;
                CQ60 = textBox44.Text;
                CQ61 = textBox45.Text;
                CQ62 = textBox46.Text;
                CQ63 = textBox47.Text;
                CQ64 = textBox48.Text;
                CQ65 = textBox49.Text;
                CQ66 = textBox50.Text;
                //CQ67 = Convert.ToInt32(textBox51.Text);
                //CQ68 = Convert.ToInt32(textBox52.Text);
                //CQ69 = Convert.ToInt32(textBox53.Text);
                //CQ70 = Convert.ToInt32(textBox54.Text);
                //CQ71 = Convert.ToInt32(textBox55.Text);
                //CQ72 = Convert.ToInt32(textBox56.Text);
                //CQ73 = Convert.ToInt32(textBox57.Text);
                //CQ74 = Convert.ToInt32(textBox58.Text);
                //CQ75 = Convert.ToInt32(textBox59.Text);
                //CQ76 = Convert.ToInt32(textBox60.Text);
                //CQ77 = Convert.ToInt32(textBox61.Text);
                if (checkBox14.Checked)
                {
                    CQ78 = "T";
                }
                if (checkBox15.Checked)
                {
                    CQ79 = "T";
                }
                if (checkBox19.Checked)
                {
                    CQ80 = "T";
                }
                if (checkBox20.Checked)
                {
                    CQ81 = "T";
                }
                if (checkBox21.Checked)
                {
                    CQ82 = "T";
                }
                if (checkBox22.Checked)
                {
                    CQ83 = "T";
                }
                if (checkBox23.Checked)
                {
                    CQ84 = "T";
                }
                if (checkBox24.Checked)
                {
                    CQ85 = "T";
                }
                CQ86 = textBox62.Text;
                if (checkBox32.Checked)
                {
                    CQ87 = "T";
                }
                if (checkBox31.Checked)
                {
                    CQ88 = "T";
                }
                if (checkBox30.Checked)
                {
                    CQ89 = "T";
                }
                if (checkBox25.Checked)
                {
                    CQ90 = "T";
                }
                CQ91 = textBox63.Text;
                CQ92 = textBox64.Text;
                CQ93 = textBox65.Text;
                CQ94 = textBox66.Text;
                CQ95 = textBox67.Text;
                CQ96 = textBox68.Text;
                CQ97 = textBox69.Text;
                CQ98 = textBox70.Text;
                CQ99 = textBox71.Text;
                CQ100 = textBox72.Text;
                /*, CQ67=@CQ67, CQ68=@CQ68, CQ69=@CQ69, CQ70=@CQ70, CQ71=@CQ71, CQ72=@CQ72, CQ73=@CQ73, CQ74=@CQ74, CQ75=@CQ75, CQ76=@CQ76, CQ77=@CQ77*/
                int count = SqlHelper.ExecuteNonQuery("UPDATE R_YPCQCEDYRWD SET CQ01=@CQ01, CQ02=@CQ02, CQ03=@CQ03, CQ04=@CQ04, CQ05=@CQ05, CQ06=@CQ06, CQ07=@CQ07, CQ08=@CQ08, CQ09=@CQ09,  CQ11=@CQ11, CQ12=@CQ12, CQ13=@CQ13, CQ14=@CQ14, CQ15=@CQ15, CQ16=@CQ16, CQ17=@CQ17, CQ18=@CQ18, CQ19=@CQ19, CQ20=@CQ20, CQ21=@CQ21, CQ22=@CQ22, CQ23=@CQ23, CQ24=@CQ24, CQ25=@CQ25, CQ26=@CQ26, CQ27=@CQ27, CQ28=@CQ28, CQ29=@CQ29, CQ30=@CQ30, CQ31=@CQ31, CQ32=@CQ32, CQ33=@CQ33,CQ45=@CQ45, CQ46=@CQ46, CQ47=@CQ47,CQ48=@CQ48, CQ49=@CQ49, CQ50=@CQ50, CQ51=@CQ51, CQ52=@CQ52, CQ53=@CQ53, CQ54=@CQ54, CQ55=@CQ55, CQ56=@CQ56, CQ57=@CQ57, CQ58=@CQ58, CQ59=@CQ59, CQ60=@CQ60, CQ61=@CQ61, CQ62=@CQ62, CQ63=@CQ63, CQ64=@CQ64,CQ65=@CQ65, CQ66=@CQ66,  CQ78=@CQ78, CQ79=@CQ79, CQ80=@CQ80, CQ81=@CQ81, CQ82=@CQ82, CQ83=@CQ83, CQ84=@CQ84, CQ85=@CQ85, CQ86=@CQ86, CQ87=@CQ87, CQ88=@CQ88, CQ89=@CQ89, CQ90=@CQ90, CQ91=@CQ91, CQ92=@CQ92, CQ93=@CQ93, CQ94=@CQ94, CQ95=@CQ95, CQ96=@CQ96, CQ97=@CQ97, CQ98=@CQ98, CQ99=@CQ99, CQ100=@CQ100,CQ10=@CQ10, CQ34=@CQ34, CQ35=@CQ35, CQ36=@CQ36, CQ37=@CQ37, CQ38=@CQ38, CQ39=@CQ39, CQ40=@CQ40, CQ41=@CQ41, CQ42=@CQ42, CQ43=@CQ43, CQ44=@CQ44", new SqlParameter("@CQ01", CQ01), new SqlParameter("@CQ02", CQ02), new SqlParameter("@CQ03", CQ03), new SqlParameter("@CQ04", CQ04), new SqlParameter("@CQ05", CQ05), new SqlParameter("@CQ06", CQ06), new SqlParameter("@CQ07", CQ07), new SqlParameter("@CQ08", CQ08), new SqlParameter("@CQ09", CQ09), new SqlParameter("@CQ10", CQ10), new SqlParameter("@CQ11", CQ11), new SqlParameter("@CQ12", CQ12), new SqlParameter("@CQ13", CQ13), new SqlParameter("@CQ14", CQ14), new SqlParameter("@CQ15", CQ15), new SqlParameter("@CQ16", CQ16), new SqlParameter("@CQ17", CQ17), new SqlParameter("@CQ18", CQ18), new SqlParameter("@CQ19", CQ19), new SqlParameter("@CQ20", CQ20), new SqlParameter("@CQ21", CQ21), new SqlParameter("@CQ22", CQ22), new SqlParameter("@CQ23", CQ23), new SqlParameter("@CQ24", CQ24), new SqlParameter("@CQ25", CQ25), new SqlParameter("@CQ26", CQ26), new SqlParameter("@CQ27", CQ27), new SqlParameter("@CQ28", CQ28), new SqlParameter("@CQ29", CQ29), new SqlParameter("@CQ30", CQ30), new SqlParameter("@CQ31", CQ31), new SqlParameter("@CQ32", CQ32), new SqlParameter("@CQ33", CQ33), new SqlParameter("@CQ34", CQ34), new SqlParameter("@CQ35", CQ35), new SqlParameter("@CQ36", CQ36), new SqlParameter("@CQ37", CQ37), new SqlParameter("@CQ38", CQ38), new SqlParameter("@CQ39", CQ39), new SqlParameter("@CQ40", CQ40), new SqlParameter("@CQ41", CQ41), new SqlParameter("@CQ42", CQ42), new SqlParameter("@CQ43", CQ43), new SqlParameter("@CQ44", CQ44), new SqlParameter("@CQ45", CQ45), new SqlParameter("@CQ46", CQ46), new SqlParameter("@CQ47", CQ47), new SqlParameter("@CQ48", CQ48), new SqlParameter("@CQ49", CQ49), new SqlParameter("@CQ50", CQ50), new SqlParameter("@CQ51", CQ51), new SqlParameter("@CQ52", CQ52), new SqlParameter("@CQ53", CQ53), new SqlParameter("@CQ54", CQ54), new SqlParameter("@CQ55", CQ55), new SqlParameter("@CQ56", CQ56), new SqlParameter("@CQ57", CQ57), new SqlParameter("@CQ58", CQ58), new SqlParameter("@CQ59", CQ59), new SqlParameter("@CQ60", CQ60), new SqlParameter("@CQ61", CQ61), new SqlParameter("@CQ62", CQ62), new SqlParameter("@CQ63", CQ63), new SqlParameter("@CQ64", CQ64), new SqlParameter("@CQ65", CQ65), new SqlParameter("@CQ66", CQ66)/*, new SqlParameter("@CQ67", CQ67), new SqlParameter("@CQ68", CQ68), new SqlParameter("@CQ69", CQ69), new SqlParameter("@CQ70", CQ70), new SqlParameter("@CQ71", CQ71), new SqlParameter("@CQ72", CQ72), new SqlParameter("@CQ73", CQ73), new SqlParameter("@CQ74", CQ74), new SqlParameter("@CQ75", CQ75), new SqlParameter("@CQ76", CQ76), new SqlParameter("@CQ77", CQ77)*/, new SqlParameter("@CQ78", CQ78), new SqlParameter("@CQ79", CQ79), new SqlParameter("@CQ80", CQ80), new SqlParameter("@CQ81", CQ81), new SqlParameter("@CQ82", CQ82), new SqlParameter("@CQ83", CQ83), new SqlParameter("@CQ84", CQ84), new SqlParameter("@CQ85", CQ85), new SqlParameter("@CQ86", CQ86), new SqlParameter("@CQ87", CQ87), new SqlParameter("@CQ88", CQ88), new SqlParameter("@CQ89", CQ89), new SqlParameter("@CQ90", CQ90), new SqlParameter("@CQ91", CQ91), new SqlParameter("@CQ92", CQ92), new SqlParameter("@CQ93", CQ93), new SqlParameter("@CQ94", CQ94), new SqlParameter("@CQ95", CQ95), new SqlParameter("@CQ96", CQ96), new SqlParameter("@CQ97", CQ97), new SqlParameter("@CQ98", CQ98), new SqlParameter("@CQ99", CQ99), new SqlParameter("@CQ100", CQ100));
                if (count < 0)
                {
                    MessageBox.Show("更改数据失败");
                }
                else
                {
                    MessageBox.Show("更改数据成功");
                }
            }
        }
        //送审
        string reve = "";
        private void toolReview_Click( object sender, EventArgs e )
        {
            //int count = ReviewES.Revie(this,reve, Logins.number);
            //if (count < 0)
            //{
            //    MessageBox.Show("送审失败");
            //}
            //else
            //{
            //    MessageBox.Show("送审成功");
            //}
        }
        int a = 0, b = 0;
        private void textBox29_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox29.Text, out a);
            textBox51.Text = (b - a).ToString();
        }
        private void textBox40_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox40.Text, out b);
            textBox51.Text = (b - a).ToString();
        }
        int c = 0, d = 0;
        private void textBox30_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox30.Text, out c);
            textBox52.Text = (d - c).ToString();
        }
        private void textBox41_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox41.Text, out d);
            textBox52.Text = (d - c).ToString();
        }
        int g = 0, f = 0;
        private void textBox31_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox31.Text, out g);
            textBox53.Text = (f-g).ToString();
        }
        private void textBox42_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox42.Text, out f);
            textBox53.Text = (f-g).ToString();
        }
        int h = 0, i = 0;
        private void textBox43_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox43.Text, out h);
            textBox54.Text = (h - i).ToString();
        }
        private void textBox32_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox32.Text, out i);
            textBox54.Text = (h - i).ToString();
        }
        int j = 0, k = 0;
        private void textBox44_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox44.Text, out j);
            textBox55.Text = (j-k).ToString();
        }
        private void textBox33_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox33.Text, out k);
            textBox55.Text = (j-k).ToString();
        }
        int l = 0, m = 0;
        private void textBox45_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox45.Text, out l);
            textBox56.Text = (l - m).ToString();
        }
        private void textBox34_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox34.Text, out m);
            textBox56.Text = (l - m).ToString();
        }
        int n = 0, o = 0;
        private void textBox46_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox46.Text, out n);
            textBox57.Text = (n - o).ToString();
        }
        private void textBox35_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox35.Text, out o);
            textBox57.Text = (n - o).ToString();
        }
        int p = 0, q = 0;
        private void textBox47_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox47.Text, out p);
            textBox58.Text = (p - q).ToString();
        }
        private void textBox36_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox36.Text, out q);
            textBox58.Text = (p - q).ToString();
        }
        int r = 0, s = 0;
        private void textBox48_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox48.Text, out r);
            textBox59.Text = (r - s).ToString();
        }
        private void textBox37_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox37.Text, out s);
            textBox59.Text = (r - s).ToString();
        }
        int t = 0, u = 0;
        private void textBox49_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox49.Text, out t);
            textBox60.Text = (t - u).ToString();
        }
        private void textBox38_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox38.Text, out u);
            textBox60.Text = (t - u).ToString();
        }
        int v = 0, w = 0;
        private void textBox50_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox50.Text, out v);
            textBox61.Text = (v - w).ToString();
        }
        private void textBox39_TextChanged( object sender, EventArgs e )
        {
            int.TryParse(textBox39.Text, out w);
            textBox61.Text = (v - w).ToString();
        }
    }
}
