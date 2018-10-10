using System;
using System.Reflection;
using System.Windows.Forms;
using StrayFog_Framework_Pak.Forms;
using System.Collections.Generic;
using StrayFog_Framework_Pak.Forms.WindowPlatform;

namespace StrayFog_Framework_Pak
{
    public partial class StartRisePackBuilderForm : Form
    {
        public StartRisePackBuilderForm()
        {
            InitializeComponent();
            InitializeConfig();
        }

        /// <summary>
        /// 平台窗口映射
        /// </summary>
        Dictionary<int, Form> mPlatformWindowMaping = new Dictionary<int, Form>() {
            { (int)enPlatform.Windows,new WindowPlatform(enPlatform.Windows)},
            //{ (int)enPlatform.PS4,new WindowPlatform(enPlatform.PS4)},
        };
        /// <summary>
        /// 初始化配置
        /// </summary>
        void InitializeConfig()
        {
            string[] platforms = Enum.GetNames(typeof(enPlatform));
            if (platforms != null && platforms.Length > 0)
            {                
                foreach(string p in platforms)
                {
                    cbbPlatform.Items.Add(p);
                }
                cbbPlatform.SelectedIndex = 0;
                if (platforms.Length == 1)
                {
                    OpenForm();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OpenForm();
        }

        void OpenForm()
        {
            enPlatform platform = (enPlatform)Enum.Parse(typeof(enPlatform), cbbPlatform.SelectedItem.ToString());
            mPlatformWindowMaping[(int)platform].ShowDialog(this);            
        }
    }
}
