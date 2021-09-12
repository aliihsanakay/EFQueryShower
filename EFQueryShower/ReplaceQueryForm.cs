using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EFQueryShower
{
    public partial class ReplaceQueryForm : Form
    {
        public ReplaceQueryForm()
        {
            InitializeComponent();
        }



        private void btnChange_Click(object sender, EventArgs e)
        {
            var inputStr = txtInput.Text;
            if (string.IsNullOrEmpty(txtInput.Text))
                MessageBox.Show("Girdi Alanı Boş");
            else
            {
                var rows = inputStr.Split('\n');
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (var row in rows)
                {
                    if (row.Length > 2 && row.TrimStart().Substring(0, 2) == "--")
                    {
                        var paramValueStart = row.IndexOf('\'') + 1;
                        var paramValueEnd = row.LastIndexOf('\'');
                        var value = row.Substring(paramValueStart, paramValueEnd - paramValueStart);
                        parameters.Add(row, value);
                    }
                }
                foreach (var item in parameters)
                {
                    inputStr = inputStr.Replace(item.Key, "");
                    var paramStart = item.Key.IndexOf('@');
                    var paramEnd = item.Key.IndexOf('=');
                    var replacedParamKey = item.Key.Substring(paramStart, paramEnd - paramStart);
                    inputStr = inputStr.Replace(replacedParamKey, '\'' + item.Value + '\'');

                }
                txtOutput.Text = inputStr.Replace("\n", "");
            }



        }
    }
}
