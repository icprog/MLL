using Mulaolao;
using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductCostSummaryBatch : Form
    {
        public ProductCostSummaryBatch()
        {
            InitializeComponent();
        }
        
        MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary();
        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll();
        public string strWhere = "";
        
        private void ProductCostSummaryBatch_Load(object sender, EventArgs e)
        {

        }
        //Sure
        private void button1_Click(object sender, EventArgs e)
        {
            model.AM017 = string.IsNullOrEmpty(textBox1.Text) == true ? 0 : Convert.ToDecimal(textBox1.Text);
            model.AM018 = string.IsNullOrEmpty(textBox2.Text) == true ? 0 : Convert.ToDecimal(textBox2.Text);
            bool result = bll.BatchEdit(strWhere, model.AM017, model.AM018);
            if (result == true)
            {
                MessageBox.Show("批量编辑成功,请刷新");
                this.Close();
            }
            else
                MessageBox.Show("批量编辑失败,请重试");
        }
        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DateDay.textChangeTb(textBox1);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateDay.fractionTb(e, textBox1);
        }
        private void textBox1_LostFocus(object sender,EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !DateDay. elevenSixNumber ( textBox1))
            {
                textBox1.Text = "";
                MessageBox.Show("只允许输入整数部分最多五位,小数部分最多六位,如99999.999999,请重新输入");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DateDay.textChangeTb(textBox2);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateDay.fractionTb(e, textBox2);
        }
        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !DateDay. elevenSixNumber ( textBox2))
            {
                textBox2.Text = "";
                MessageBox.Show("只允许输入整数部分最多五位,小数部分最多六位,如99999.999999,请重新输入");
            }
        }
    }
}
