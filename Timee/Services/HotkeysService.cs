using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.Services.Hotkeys;

namespace Timee.Services
{
    public class HotkeysService
    {
        private static HotkeysService _instance;
        //public Dictionary<KeyValuePair<string, int>,KeyValuePair<string, string>> KeysMap { get; set; }
        //Keep HotKeys information
        public List<HotKeys> KeysMap = new List<HotKeys>();
        private HotkeysService()
        {
            _instance = this;

        }
        public static HotkeysService Instance
        {
            get
            {
                return _instance == null ? new HotkeysService() : _instance;
            }
        }
        /// <summary>
        /// Returns key (keyboard) representing given row number.
        /// </summary>
        /// <param name="rowNumber">Row index.</param>
        /// <returns>Keys.</returns>
        public Keys GetKeyByRowNumber(int rowNumber)
        {
            Keys key = Keys.None;
            //switch (rowNumber)
            //{
            //    case 0:
            //        key = Keys.F1;
            //        break;
            //    case 1:
            //        key = Keys.F2;
            //        break;
            //    case 2:
            //        key = Keys.F3;
            //        break;
            //    case 3:
            //        key = Keys.F4;
            //        break;
            //    case 4:
            //        key = Keys.F5;
            //        break;
            //    case 5:
            //        key = Keys.F6;
            //        break;
            //    case 6:
            //        key = Keys.F7;
            //        break;
            //    case 7:
            //        key = Keys.F8;
            //        break;
            //    case 8:
            //        key = Keys.F9;
            //        break;
            //    case 9:
            //        key = Keys.F10;
            //        break;
            //    default:
            //        break;
            //}
            string keyName = this.KeysMap.Where(k => k.Action == "Switch")
                .Where(v => v.RowId == rowNumber)
                .Select(k => k.KeyName).First();
                key = (Keys)Enum.Parse(typeof(Keys), keyName,true);
            return key;
        }
        public void RegisterKey(KeyboardHook hook, int index)
        {
            Keys keyToRegister = HotkeysService.Instance.GetKeyByRowNumber(index);
            string test = this.KeysMap
                    .Where(k => (Keys)Enum.Parse(typeof(Keys),k.KeyName) == keyToRegister)
                    .Select(k=>k.ModifierKey).FirstOrDefault();

            Timee.Services.Hotkeys.ModifierKeys modifier = (Timee.Services.Hotkeys.ModifierKeys)
                    Enum.Parse(typeof(Timee.Services.Hotkeys.ModifierKeys), test);


            if (keyToRegister != Keys.None)
            {
                hook.RegisterHotKey(modifier, keyToRegister);
            }
        }
        /// <summary>
        /// InitializeHotKeys
        /// </summary>
        public void InitializeKeys()
        {
            //this.KeysMap = new Dictionary<KeyValuePair<string, int>, KeyValuePair<string, string>>();
            this.KeysMap = new List<HotKeys>();
            if (!(Properties.Settings.Default.HotKeys.Length == 0))
            {
                StringReader hotKeysXml = new StringReader(Properties.Settings.Default.HotKeys);
                HotkeysService.Instance.KeysMap.Clear();
                HotkeysService.Instance.KeysMap = Extensions.DeserializeObject(HotkeysService.Instance.KeysMap, hotKeysXml);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    HotKeys item = new HotKeys();
                    item.Action = "Switch";
                    item.RowId = i;
                    item.ModifierKey = "Control";
                    item.KeyName = string.Format("F{0}", i + 1);
                    //this.KeysMap.Add(new KeyValuePair<string, int>("Switch", i),
                    //    new KeyValuePair<string,string>(string.Format("Control"),string.Format("F{0}",i+1)));
                    this.KeysMap.Add(item);
                }
                HotKeys tmpItemSummary = new HotKeys();
                tmpItemSummary.Action = "Show Summary";
                tmpItemSummary.RowId = 0;
                tmpItemSummary.ModifierKey = "Control";
                tmpItemSummary.KeyName = string.Format("F{0}", 11);
                this.KeysMap.Add(tmpItemSummary);
                HotKeys tmpItemRow = new HotKeys();
                tmpItemRow.Action = "Add new row";
                tmpItemRow.RowId = 0;
                tmpItemRow.ModifierKey = "Control";
                tmpItemRow.KeyName = string.Format("F{0}", 12);
                this.KeysMap.Add(tmpItemRow);
                //this.KeysMap.Add(new KeyValuePair<string, int>("Show Summary", 0),
                //            new KeyValuePair<string, string>(string.Format("Control"), string.Format("F{0}", 11)));
                //this.KeysMap.Add(new KeyValuePair<string, int>("Add new row", 0),
                //            new KeyValuePair<string, string>(string.Format("Control"), string.Format("F{0}", 12)));
            }

        }
    }
    /// <summary>
    /// Class for holding Hotkeys information
    /// </summary>
    public class HotKeys
    {
        public string Action { get; set; }
        public int RowId { get; set; }
        public string ModifierKey { get; set; }
        public string KeyName { get; set; }
        public HotKeys() { }
    }
}
