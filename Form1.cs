namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double afp = 0.0287, sfs = 0.03004, ISR = 0.15;
            double salarioneto;
            double sueldobruto = double.Parse(txtsueldobruto.Text);
            double salarioAfp, SalarioSfs, SalarioIsr;
            salarioAfp = sueldobruto * afp;
            SalarioSfs = sueldobruto * sfs;

            if (sueldobruto>34600)
            {
                SalarioIsr = sueldobruto * ISR;
                salarioneto = sueldobruto - salarioAfp - SalarioIsr - SalarioSfs;
                LBLIRS.Text = "-" + SalarioIsr.ToString();
            }
            else
            {
                salarioneto= sueldobruto - salarioAfp - SalarioSfs;
            }
            lblsueldoneto.Text = salarioneto.ToString();
            LBLAFP.Text ="-"+ salarioAfp.ToString();
            LBLSFS.Text= "-" + SalarioSfs.ToString();
            
        }
        

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}    