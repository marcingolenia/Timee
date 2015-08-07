using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.Services;

namespace Timee.Dialogs
{
    public partial class HotKeysDialog : Form
    {

        public HotKeysDialog()
        {
            InitializeComponent();
        }

        private void HotKeysDialog_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<KeyValuePair<string,int>,KeyValuePair<string,string>> item in HotkeysService.Instance.KeysMap)
            {
                if (item.Key.Key == "Switch")
                {
                    grdHotKeys.Rows.Add(String.Format("{0} to row {1}",item.Key.Key, item.Key.Value),
                        item.Value.Key,item.Value.Value);
                }
                else
                {
                    grdHotKeys.Rows.Add(item.Key.Key, item.Value.Key, item.Value.Value);
                }
            }
        }
        private void grdHotKeys_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string test = e.KeyValue.ToString();
            Services.Hotkeys.ModifierKeys modifier;
            if (grdHotKeys.CurrentCell.ColumnIndex ==2)
            {
                grdHotKeys.CurrentCell.Value = e.KeyCode;
            }
            
            else if (grdHotKeys.CurrentCell.ColumnIndex == 1 && Enum.TryParse(e.KeyCode.ToString(), out modifier))
            {
                grdHotKeys.CurrentCell.Value = e.KeyValue.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            HotkeysService.Instance.KeysMap.Clear();
            for (int i = 0; i < grdHotKeys.Rows.Count; i++)
            {
                if (i < 10)
                {
                    HotkeysService.Instance.KeysMap.Add(new KeyValuePair<string, int>("Switch", i),
                        new KeyValuePair<string,string>(grdHotKeys.Rows[i].Cells[1].Value.ToString(),
                            grdHotKeys.Rows[i].Cells[2].Value.ToString()));
                }
                else
                {
                    HotkeysService.Instance.KeysMap.Add(new KeyValuePair<string, int>
                        (grdHotKeys.Rows[i].Cells[0].Value.ToString(), 0),
                        new KeyValuePair<string, string>(grdHotKeys.Rows[i].Cells[1].Value.ToString(),
                                grdHotKeys.Rows[i].Cells[2].Value.ToString()));
                }

            }

            grdHotKeys.Rows.Clear();
            DialogResult = DialogResult.OK;
        }
    }
}
