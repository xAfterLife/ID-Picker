using System;
using System.Linq;
using System.Windows.Forms;

namespace ID_Picker
{
    public partial class Form1 : Form
    {
        private int currentList = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int curIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    curIndex = dataGridView1.SelectedRows[0].Index;
                }
                dataGridView1.ClearSelection();

                for (int i = curIndex + 1; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[comboBox2.Text, i].Value.ToString().ToUpper().Contains(textBox1.Text.ToUpper()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        return;
                    }
                }
                for (int i = 0; i < curIndex + 1; i++)
                {
                    if (dataGridView1[comboBox2.Text, i].Value.ToString().ToUpper().Contains(textBox1.Text.ToUpper()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "button1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentList = 2;
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = dataGridView1.Width - 100 - 60;

                comboBox2.Items.Clear();
                foreach (DataGridViewColumn dg in dataGridView1.Columns)
                {
                    comboBox2.Items.Add(dg.Name);
                }
                comboBox2.SelectedIndex = 1;

                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                {
                    foreach (string s in Properties.Resources.DE_monster.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                {
                    foreach (string s in Properties.Resources.EN_monster.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "button1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentList = 1;
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Level", "Level");
                dataGridView1.Columns.Add("Type", "Type");
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = dataGridView1.Width - 300 - 60;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;

                comboBox2.Items.Clear();
                foreach (DataGridViewColumn dg in dataGridView1.Columns)
                {
                    comboBox2.Items.Add(dg.Name);
                }
                comboBox2.SelectedIndex = 1;

                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                {
                    foreach (string s in Properties.Resources.DE_items.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                {
                    foreach (string s in Properties.Resources.EN_items.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "button1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentList = 3;
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = dataGridView1.Width - 100 - 60;

                comboBox2.Items.Clear();
                foreach (DataGridViewColumn dg in dataGridView1.Columns)
                {
                    comboBox2.Items.Add(dg.Name);
                }
                comboBox2.SelectedIndex = 1;

                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                {
                    foreach (string s in Properties.Resources.DE_maps.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                {
                    foreach (string s in Properties.Resources.EN_maps.Split('\n'))
                    {
                        dataGridView1.Rows.Add(s.Split('\t'));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "button1_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (currentList)
            {
                case 1:
                    button3_Click(sender, e);
                    break;
                case 2:
                    button2_Click(sender, e);
                    break;
                case 3:
                    button4_Click(sender, e);
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            switch (currentList)
            {
                case 1:
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                    {
                        foreach (string s in Properties.Resources.DE_items.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                    {
                        foreach (string s in Properties.Resources.EN_items.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    break;
                case 2:
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                    {
                        foreach (string s in Properties.Resources.DE_monster.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                    {
                        foreach (string s in Properties.Resources.EN_monster.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    break;
                case 3:
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Deutsch")
                    {
                        foreach (string s in Properties.Resources.DE_maps.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Englisch")
                    {
                        foreach (string s in Properties.Resources.EN_maps.Split('\n').Where(x => x.ToUpper().Contains(textBox1.Text.ToUpper())))
                        {
                            dataGridView1.Rows.Add(s.Split('\t'));
                        }
                    }
                    break;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button5_Click(sender, e);
            }
        }
    }
}
