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
            //Fill grdHotKeys with KeyMap List
            foreach (var item in HotkeysService.Instance.KeysMap)
            {
                if (item.Action == "Switch")
                {
                   grdHotKeys.Rows.Add(String.Format("{0} to row {1}",item.Action, item.RowId),
                        item.ModifierKey,item.KeyName);
                }
                else
                {
                    grdHotKeys.Rows.Add(item.Action, item.ModifierKey, item.KeyName);
                }
            }
        }
        /// <summary>
        /// Write pressed Key information into grdHotKeys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdHotKeys_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string test = e.KeyValue.ToString();
            Services.Hotkeys.ModifierKeys modifier;
            if (grdHotKeys.CurrentCell.ColumnIndex ==2)
            {
                grdHotKeys.CurrentCell.Value = e.KeyCode;
            }
        }
        /// <summary>
        /// Save grdHotKeys information to KeyMap List, and saved changed hotkeys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            HotkeysService.Instance.KeysMap.Clear();
            for (int i = 0; i < grdHotKeys.Rows.Count; i++)
            {
                HotKeys item = new HotKeys();

                if (i < 10)
                {
                    item.Action = "Switch";
                    item.RowId = i;
                    item.ModifierKey = grdHotKeys.Rows[i].Cells[1].Value.ToString();
                    item.KeyName = grdHotKeys.Rows[i].Cells[2].Value.ToString();
                    HotkeysService.Instance.KeysMap.Add(item);
                    //HotkeysService.Instance.KeysMap.Add(new KeyValuePair<string, int>("Switch", i),
                    //    new KeyValuePair<string,string>(grdHotKeys.Rows[i].Cells[1].Value.ToString(),
                    //        grdHotKeys.Rows[i].Cells[2].Value.ToString()));
                }
                else
                {
                    item.Action = grdHotKeys.Rows[i].Cells[0].Value.ToString();
                    item.RowId = 0;
                    item.ModifierKey = grdHotKeys.Rows[i].Cells[1].Value.ToString();
                    item.KeyName = grdHotKeys.Rows[i].Cells[2].Value.ToString();
                    HotkeysService.Instance.KeysMap.Add(item);
                    //HotkeysService.Instance.KeysMap.Add(new KeyValuePair<string, int>
                    //    (grdHotKeys.Rows[i].Cells[0].Value.ToString(), 0),
                    //    new KeyValuePair<string, string>(grdHotKeys.Rows[i].Cells[1].Value.ToString(),
                    //            grdHotKeys.Rows[i].Cells[2].Value.ToString()));
                }

            }

            grdHotKeys.Rows.Clear();
            Properties.Settings.Default.HotKeys = Extensions.SerializeObject(HotkeysService.Instance.KeysMap);
            DialogResult = DialogResult.OK;
        }
    }
}
