using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishVocabulary
{
    public partial class EnglishVocabulary : Form
    {
        private List<En_to_Vi> listWord;
        private En_to_Vi word;
        public EnglishVocabulary()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckAnswer();
        }

        private void CheckAnswer()
        {
            if (txtOutput.Text.Trim().ToUpper() == word.en.Trim().ToUpper())
            {
                ShowWord();
                lblResult.Visible = false;
            }
            else
            {
                lblResult.Text = "Sai!";
                lblResult.Visible = true;
            }
        }

        private void EnglishVocabulary_Load(object sender, EventArgs e)
        {
            EnglishVocabularyEntities1 db = new EnglishVocabularyEntities1();
            cbUnit.DisplayMember = "name";
            cbUnit.ValueMember = "id";
            cbUnit.DataSource = (from x in db.Units select x).ToList<Unit>();

            int unitid = Convert.ToInt32(cbUnit.SelectedValue);
            listWord = (from x in db.En_to_Vi where x.unit == unitid select x).ToList<En_to_Vi>();
            ShowWord();
        }

        private void RandomWord()
        {
            if (listWord.Count == 0)
            {
                return;
            }
            Random rand = new Random();
            int index = rand.Next() % (listWord.Count);
            word = listWord[index];
        }

        private void ShowWord()
        {
            RandomWord();
            txtOutput.Text = "";
            txtOutput.Focus();
            lblInput.Text = word.vi;
        }

        private void btnShowAnswer_Click(object sender, EventArgs e)
        {
            lblResult.Text = word.en;
            lblResult.Visible = true;
        }

        private void txtOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckAnswer();
            }
        }
    }
}
