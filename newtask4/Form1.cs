using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtask4
{
    public partial class Form1 : Form
    {
        int sualIndex = 0;
        int bal = 0;

        
        string[] suallar = {
    "1. FİFA Dünya Çempionatını ən çox (5 dəfə) qazanan milli komanda hansıdır?",
    "2. 'Qızıl Top' (Ballon d'Or) mükafatını tarixdə ən çox qazanan futbolçu kimdir?",
    "3. UEFA Çempionlar Liqası tarixində ən çox qol vuran futbolçu kimdir?",
    "4. Bir matçda rəqib qapısına ən çox qol vuran (1 matçda 5 qol) Azərbaycanlı hücumçu kimdir?",
    "5. Futbol matçında əsas vaxt neçə dəqiqə davam edir?"
};

       
        string[,] variantlar = {
    { "Almaniya", "Argentina", "Braziliya", "İtaliya" },
    { "Cristiano Ronaldo", "Lionel Messi", "Pelé", "Diego Maradona" },
    { "Lionel Messi", "Cristiano Ronaldo", "Robert Lewandowski", "Karim Benzema" },
    { "Nazim Süleymanov", "Vəli Qasımov", "Qurban Qurbanov", "Anatoliy Banişevski" },
    { "80 dəqiqə", "90 dəqiqə", "100 dəqiqə", "120 dəqiqə" }
};

        
        int[] dogruCavablar = { 2, 1, 1, 0, 1 };
        public Form1()
        {
            InitializeComponent();
        }
        private void SualiGoster()
        {
            lblSual.Text = suallar[sualIndex];

            
            rbA.Text = variantlar[sualIndex, 0];
            rbB.Text = variantlar[sualIndex, 1];
            rbC.Text = variantlar[sualIndex, 2];
            rbD.Text = variantlar[sualIndex, 3];

            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            rbD.Checked = false;

            
            progressBar1.Value = (sualIndex + 1) * 20;
        }

        private void btnNovbeti_Click(object sender, EventArgs e)
        {
            
            if (rbA.Checked == false && rbB.Checked == false && rbC.Checked == false && rbD.Checked == false)
            {
                MessageBox.Show("Zəhmət olmasa bir variant seçin!", "Xəbərdarlıq");
                return; 
            }


            int secilenIndeks = -1;
            if (rbA.Checked) secilenIndeks = 0;
            if (rbB.Checked) secilenIndeks = 1;
            if (rbC.Checked) secilenIndeks = 2;
            if (rbD.Checked) secilenIndeks = 3;

            if (secilenIndeks == dogruCavablar[sualIndex])
            {
                bal++; 
            }


            sualIndex++;

            if (sualIndex < 5) 
            {
                SualiGoster(); 
            }
            else 
            {
                DialogResult cavab = MessageBox.Show($"Test bitdi! Topladığınız bal: {bal}\nYenidən başlamaq istəyirsiniz?", "Nəticə", MessageBoxButtons.YesNo);

                if (cavab == DialogResult.Yes)
                {
                    sualIndex = 0;
                    bal = 0;
                    SualiGoster();
                }
                else
                {
                    
                    Application.Exit();
                }
            }
        }
    }
}
