using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace StrayFog_Framework_Pak.Forms.WindowPlatform
{
    public partial class WindowPlatform : Form
    {
        /// <summary>
        /// 平台类别
        /// </summary>
        public enPlatform platform { get; private set; }

        public WindowPlatform(enPlatform _platform)
        {
            InitializeComponent();
            platform = _platform;
            InitializeConfig();
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        void InitializeConfig()
        {
            this.Text = string.Format("Platform 【{0}】", platform);
            lbPlatform.Text = platform.ToString();

            WindowPackConfig config = (WindowPackConfig)ConfigurationManager.GetSection("BuildPackConfig/WindowPackConfig");
            
            lbOldEngineDir.Text =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(config.oldUnrealPakExe)
                        )
                    );
            tbOldUnrealPakExe.Text = config.oldUnrealPakExe;
            tbOldVersionName.Text = config.oldVersionName;
            tbOldProjectDir.Text = config.oldProjectDir;            
            tbOldVersionDirectory.Text = config.oldVersionDirectory;
            

            lbNewEngineDir.Text =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(config.newUnrealPakExe)
                        )
                    );
            tbNewUnrealPakExe.Text = config.newUnrealPakExe;
            tbNewVersionName.Text = config.newVersionName;
            tbNewProjectDir.Text = config.newProjectDir;
            tbNewVersionDirectory.Text = config.newVersionDirectory;

            pbProgressBar.Value = 0;
            lbProgressValue.Text = 0.ToString("P2");
            tbProgressTip.Text = string.Empty;
        }

        #region AppendLog 添加日志
        /// <summary>
        /// 日志文件路径
        /// </summary>
        string mLogFilePath = string.Empty;

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_format">格式化字符</param>
        /// <param name="_args">参数</param>
        void AppendLog(string _format, params object[] _args)
        {
            AppendLog(true, _format, _args);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_isShowInLogBox">是否显示在日志框</param>
        /// <param name="_format">格式化字符</param>
        /// <param name="_args">参数</param>
        void AppendLog(bool _isShowInLogBox,string _format, params object[] _args)
        {
            AppendLog(_isShowInLogBox,1, string.Format(_format, _args));
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_progress">进度</param>
        /// <param name="_format">格式化字符</param>
        /// <param name="_args">参数</param>
        void AppendLog(float _progress, string _format, params object[] _args)
        {
            AppendLog(true, _progress, _format, _args);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_isShowInLogBox">是否显示在日志框</param>
        /// <param name="_progress">进度</param>
        /// <param name="_format">格式化字符</param>
        /// <param name="_args">参数</param>
        void AppendLog(bool _isShowInLogBox, float _progress, string _format, params object[] _args)
        {
            AppendLog(_progress, string.Format(_format,_args), _isShowInLogBox);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_log">日志</param>
        void AppendLog(string _log)
        {
            AppendLog(1, _log, true);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_log">日志</param>
        /// <param name="_isShowInLogBox">是否显示在日志框</param>
        void AppendLog( string _log, bool _isShowInLogBox)
        {
            AppendLog(1, _log, _isShowInLogBox);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_progress">进度</param>
        /// <param name="_log">日志</param>
        void AppendLog(float _progress, string _log)
        {
            AppendLog(_progress, _log, true);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="_progress">进度</param>
        /// <param name="_log">日志</param>
        /// <param name="_isShowInLogBox">是否显示在日志框</param>
        void AppendLog(float _progress,string _log,bool _isShowInLogBox)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                if (_isShowInLogBox)
                {
                    tbLog.AppendText(string.Format("【{0}】{1}{2}{2}",DateTime.Now, _log, Environment.NewLine));
                }
                pbProgressBar.Value = Math.Min((int)(_progress * 100), 100);
                lbProgressValue.Text = _progress.ToString("P2");
                tbProgressTip.Text = _log;
                if (!string.IsNullOrEmpty(mLogFilePath))
                {
                    File.AppendAllText(mLogFilePath, _log + Environment.NewLine);
                }
            });
        }
        #endregion

        #region 切换Building状态
        /// <summary>
        /// 是否生成状态
        /// </summary>
        bool mIsBuildingState = false;
        /// <summary>
        /// 切换Building状态
        /// </summary>
        /// <param name="_isBuilding">是否生成</param>
        void SwitchBuildState(bool _isBuilding)
        {
            BeginInvoke((MethodInvoker)delegate
            {                
                tbOldUnrealPakExe.Enabled = !_isBuilding;
                tbOldProjectDir.Enabled = !_isBuilding;
                tbOldVersionName.Enabled = tbOldVersionDirectory.Enabled = !_isBuilding;
                tbNewVersionName.Enabled = tbNewVersionDirectory.Enabled = !_isBuilding;
                if (_isBuilding)
                {
                    btnBuilding.Text = "取消";
                }
                else
                {
                    btnBuilding.Text = "生成更新包";
                    tbProgressTip.Text = "取消生成更新包";
                    AppendLog(tbProgressTip.Text);
                    lbProgressValue.Text = 0.ToString("P2");
                    pbProgressBar.Value = 0;
                }
                mIsBuildingState = _isBuilding;
            });
        }
        #endregion

        #region 生成更新包       
        /// <summary>
        /// 线程
        /// </summary>
        Thread mThread;
        /// <summary>
        /// 生成更新包
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnBuilding_Click(object sender, EventArgs e)
        {
            if (!mIsBuildingState)
            {                
                mThread = new Thread(StartBuildPack);
                mThread.Start();
            }
            else
            {
                if (mThread != null)
                {
                    mThread.Abort();
                    mThread = null;
                }
                CancelBuildPack();
            } 
        }
        #endregion

        #region StartBuildPack 开始生成包
        /// <summary>
        /// 开始生成包
        /// </summary>
        void StartBuildPack()
        {
            SwitchBuildState(true);
            if (ValidateInputInfo())
            {
                try
                {                    
                    CollectDifferentFiles();
                }
                catch (Exception ep)
                {
                    AppendLog("执行错误 =>{0}",ep.Message);
                    if (File.Exists(mLogFilePath))
                    {
                        AppendLog("请查看日志 =>{0}", mLogFilePath);
                    }
                }
            }
            else
            {
                CancelBuildPack();
            }
        }

        /// <summary>
        /// 验证输入信息
        /// </summary>
        bool ValidateInputInfo()
        {
            bool isValidate = true;
            string regex = @"[^\w\.]+";
            ////Old
            if (!(isValidate = File.Exists(tbOldUnrealPakExe.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbOldUnrealPakExe.Text, tbOldUnrealPakExe.Text);
            }
            else if (!(isValidate = Directory.Exists(tbOldProjectDir.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbOldProjectDir.Text, tbOldProjectDir.Text);
            }
            else if (!(isValidate = !string.IsNullOrEmpty(tbOldVersionName.Text)))
            {
                AppendLog("请输入【{0}】", lbOldVersionName.Text);
            }
            else if (!(isValidate = !Regex.IsMatch(tbOldVersionName.Text, regex)))
            {
                AppendLog("【{0}{1}】不合法只能是符号点.、字母、下划线。", lbOldVersionName.Text, tbOldVersionName.Text);
            }
            else if (!(isValidate = Directory.Exists(tbOldVersionDirectory.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbOldVersionDirectory.Text, tbOldVersionDirectory.Text);
            }
            ////New
            else if (!(isValidate = File.Exists(tbNewUnrealPakExe.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbNewUnrealPakExe.Text, tbNewUnrealPakExe.Text);
            }
            else if (!(isValidate = Directory.Exists(tbNewProjectDir.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbNewProjectDir.Text, tbNewProjectDir.Text);
            }
            else if (!(isValidate = !string.IsNullOrEmpty(tbNewVersionName.Text)))
            {
                AppendLog("请输入【{0}】", lbNewVersionName.Text);
            }
            else if (!(isValidate = !Regex.IsMatch(tbNewVersionName.Text, regex)))
            {
                AppendLog("【{0}{1}】不合法只能是符号点.、字母、下划线。", lbNewVersionName.Text, tbNewVersionName.Text);
            }
            else if (!(isValidate = Directory.Exists(tbNewVersionDirectory.Text)))
            {
                AppendLog("未能找到【{0}】=>{1}", lbNewVersionDirectory.Text, tbNewVersionDirectory.Text);
            }
            /////
            else if (!(isValidate = !tbOldVersionName.Text.Trim().Equals(tbNewVersionName.Text.Trim())))
            {
                AppendLog("【{0}{1}】不能与【{2}{3}】一致",
                    lbOldVersionName.Text, tbOldVersionName.Text, lbNewVersionName.Text, tbNewVersionName.Text);
            }
            return isValidate;
        }

        /// <summary>
        /// 等待Chunk的Pak文件
        /// </summary>
        class WaitChunkPak
        {
            /// <summary>
            /// 要比对的pak文件
            /// </summary>
            public string oldPak;
            /// <summary>
            /// 目标Pak文件
            /// </summary>
            public string newPak;
            /// <summary>
            /// pak包目录
            /// </summary>
            public string pakDirectory;
        }
        /// <summary>
        /// 等待复制的文件
        /// </summary>
        class WaitCopyFile
        {
            /// <summary>
            /// 源路径
            /// </summary>
            public string source;
            /// <summary>
            /// 目标路径
            /// </summary>
            public string target;
            /// <summary>
            /// 相对路径
            /// </summary>
            public string relative;
            /// <summary>
            /// 目录
            /// </summary>
            public string directory;
        }

        /// <summary>
        /// 等待检测文件
        /// </summary>
        class WaitChunkFile
        {
            /// <summary>
            /// 路径
            /// </summary>
            public string path;
            /// <summary>
            /// md5校验码
            /// </summary>
            public string md5;
        }

        /// <summary>
        /// 收集不同的文件
        /// </summary>
        void CollectDifferentFiles()
        {
            string packRootDirectory = Path.GetFullPath(string.Format("{0}_to_{1}", tbOldVersionName.Text.Trim(), tbNewVersionName.Text));

            string tempLogRootDirectory = packRootDirectory + "_Log";
            string tempRisePakRootDirectory = packRootDirectory + "_RisePak";

            mLogFilePath = Path.Combine(tempLogRootDirectory, "log.log");

            CMDTool.DeleteDirectory(packRootDirectory);
            CMDTool.DeleteDirectory(tempRisePakRootDirectory);
            CMDTool.DeleteDirectory(tempLogRootDirectory);

            Directory.CreateDirectory(tempLogRootDirectory);

            AppendLog(lbOldVersionName.Text + tbOldVersionDirectory.Text);
            AppendLog(lbNewVersionName.Text + tbNewVersionDirectory.Text);
            AppendLog("更新包目录：{0}", packRootDirectory);
            AppendLog("开始收集差异文件");


            List<WaitChunkPak> waitPaks = new List<WaitChunkPak>();
            List<WaitCopyFile> copyFiles = new List<WaitCopyFile>();
            List<WaitChunkFile> waitChunkFiles = new List<WaitChunkFile>();
            CompareFile(tbOldVersionDirectory.Text, tbNewVersionDirectory.Text,
                packRootDirectory, waitPaks, copyFiles);
            AppendLog("完成收集差异文件");

            float p = 0;
            int c = 0;
            string bat = string.Empty;
            string batFile = string.Empty;

            #region 复制差异文件            
            if (copyFiles != null && copyFiles.Count > 0)
            {
                AppendLog("开始复制差异文件=>文件数：{0}", copyFiles.Count);
                p = 0;
                c = copyFiles.Count;
                for (int i = 0; i < copyFiles.Count; i++)
                {
                    if (!Directory.Exists(copyFiles[i].directory))
                    {
                        Directory.CreateDirectory(copyFiles[i].directory);
                    }
                    File.Copy(copyFiles[i].source, copyFiles[i].target);
                    p = i / c;
                    AppendLog(false, p, "复制文件【{0}】到【{1}】", copyFiles[i].source, copyFiles[i].target);
                }
                AppendLog(1, "完成复制差异文件");
            }
            #endregion

            #region 比对Pak文件
            if (waitPaks != null && waitPaks.Count > 0)
            {
                AppendLog(0, "开始比对Pak文件");
                WaitChunkPak pak;
                p = 0;
                c = waitPaks.Count;
                string tn = string.Empty;
                for (int i = 0; i < waitPaks.Count; i++)
                {
                    pak = waitPaks[i];
                    p = i / c;
                    AppendLog(p, "比对包=>{0}", pak.newPak);

                    tn = Path.GetFileName(pak.newPak);
                    string tempRCP =
                        Path.Combine(tempRisePakRootDirectory, tn + "_RiseCompressPak");

                    string tempOldPak = Path.Combine(tempRisePakRootDirectory, tn + "_TempOldPak");
                    string tempNewPak = Path.Combine(tempRisePakRootDirectory, tn + "_TempNewPak");

                    string tempChunkFile = Path.Combine(tempRCP, "chunk.txt");
                    CMDTool.DeleteDirectory(tempRCP);
                    CMDTool.DeleteDirectory(tempOldPak);
                    CMDTool.DeleteDirectory(tempNewPak);

                    #region 解压Pak包
                    AppendLog(p, string.Format("解压旧Pak包=>{0}", pak.oldPak));
                    bat = Resx.ResPakBat.Pak_Extract
                        .Replace("$platform$", platform.ToString())
                        .Replace("$engineDir$", lbOldEngineDir.Text)
                        .Replace("$projectDir$", tbOldProjectDir.Text)
                        .Replace("$unrealPakExe$", tbOldUnrealPakExe.Text)
                        .Replace("$extractPak$", pak.oldPak)
                        .Replace("$extractPath$", tempOldPak);
                    AppendLog(p, string.Format("执行Bat=>{0}", bat));
                    batFile = Path.Combine(tempLogRootDirectory, Path.GetFileName(pak.oldPak)+"_Old.log");
                    File.WriteAllText(batFile,bat);
                    CMDTool.ExecuteCmd(bat);

                    AppendLog(p, string.Format("解压新Pak包=>{0}", pak.newPak));
                    bat = Resx.ResPakBat.Pak_Extract
                        .Replace("$platform$", platform.ToString())
                        .Replace("$engineDir$", lbNewEngineDir.Text)
                        .Replace("$projectDir$", tbNewProjectDir.Text)
                        .Replace("$unrealPakExe$", tbNewUnrealPakExe.Text)
                        .Replace("$extractPak$", pak.newPak)
                        .Replace("$extractPath$", tempNewPak);
                    AppendLog(p, string.Format("执行Bat=>{0}", bat));
                    batFile = Path.Combine(tempLogRootDirectory, Path.GetFileName(pak.newPak) + "_New.log");
                    File.WriteAllText(batFile,bat);
                    CMDTool.ExecuteCmd(bat);
                    #endregion

                    #region 比对Pak包                    
                    List<WaitChunkPak> tempWaitPaks = new List<WaitChunkPak>();
                    List<WaitCopyFile> tempCopyFiles = new List<WaitCopyFile>();
                    CompareFile(tempOldPak, tempNewPak, tempRCP, tempWaitPaks, tempCopyFiles);
                    float pp = 0;
                    float tt = 0;
                    string pakLog = Path.Combine(tempLogRootDirectory, Path.GetFileName(pak.newPak) + ".log");
                    string tempTxt = string.Empty;
                    string tempExt = string.Empty;
                    float ct = 0.1f;
                    //比对要复制的文件
                    if (tempCopyFiles != null && tempCopyFiles.Count > 0)
                    {
                        AppendLog("生成Pak.log文件");
                        tt = tempCopyFiles.Count;
                        for (int k = 0; k < tempCopyFiles.Count; k++)
                        {
                            pp = k / tt;                            
                            tempTxt = string.Format("\"{0}\" \"../../../{1}\" -compress", tempCopyFiles[k].target, tempCopyFiles[k].relative);
                            AppendLog(pp, tempTxt);
                            File.AppendAllText(pakLog, tempTxt);
                            File.AppendAllText(pakLog, Environment.NewLine);
                            if (!Directory.Exists(tempCopyFiles[k].directory))
                            {
                                Directory.CreateDirectory(tempCopyFiles[k].directory);
                            }
                            File.Copy(tempCopyFiles[k].source, tempCopyFiles[k].target);
                            //waitChunkFiles
                            tempExt = Path.GetExtension(tempCopyFiles[k].relative).ToLower();
                            if (tempExt == ".exe" || tempExt == ".bin" || pp >= ct)
                            {
                                waitChunkFiles.Add(new WaitChunkFile() { path = tempCopyFiles[k].relative, md5 = MD5Tool.GetFileMd5Chunk(tempCopyFiles[k].target) });
                                ct += 0.1f;
                            }
                        }
                    }

                    //加入chunk校验文件
                    tempTxt = string.Format("\"{0}\" \"../../../{1}\" -compress", tempChunkFile, Path.GetFileName(tempChunkFile));
                    File.AppendAllText(pakLog, tempTxt);
                    File.AppendAllText(pakLog, Environment.NewLine);                    
                    foreach (WaitChunkFile f in waitChunkFiles)
                    {
                        File.AppendAllText(tempChunkFile, string.Format("{0}={1}", f.path, f.md5));
                        File.AppendAllText(tempChunkFile, Environment.NewLine);
                    }
                    #endregion

                    #region 生成pak包
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    string pakFilePath = Path.Combine(pak.pakDirectory,
                        Convert.ToInt64(ts.TotalSeconds).ToString() + "_p.pak");
                    AppendLog("生成Pak包=>{0}", pakFilePath);
                    batFile = Path.Combine(tempLogRootDirectory, Path.GetFileName(pakFilePath) + "_Create.log");                    
                    bat = Resx.ResPakBat.Pak_Create
                        .Replace("$platform$", platform.ToString())
                        .Replace("$engineDir$", lbNewEngineDir.Text)
                        .Replace("$projectDir$", tbNewProjectDir.Text)
                        .Replace("$unrealPakExe$", tbNewUnrealPakExe.Text)
                        .Replace("$createPakFile$", pakFilePath)
                        .Replace("$createFileName$", pakLog);
                    File.WriteAllText(batFile, bat);
                    AppendLog(bat);
                    CMDTool.ExecuteCmd(bat);
                    #endregion
                }

                AppendLog("完成比对Pak文件");
            }
            #endregion

            #region 压缩差异包
            string zipPath = packRootDirectory + ".zip";
            AppendLog("压缩差异包=>{0}", zipPath);
            FastZip zip = new FastZip();
            zip.CreateZip(zipPath, packRootDirectory, true, null);
            #endregion

            AppendLog(1, "【生成更新包完成】");
            AppendLog(1, "【更新包文件】=>【{0}】", zipPath);
        }

        /// <summary>
        /// 比较文件
        /// </summary>
        /// <param name="_oldDir">旧版本目录</param>
        /// <param name="_newDir">新版本目录</param>
        /// <param name="_ristDir">更新包目录</param>
        void CompareFile(string _oldDir, string _newDir, string _ristDir, List<WaitChunkPak> _waitChunkPaks, List<WaitCopyFile> _waitCopeFiles)
        {
            string[] files = Directory.GetFiles(_newDir, "*", SearchOption.AllDirectories);
            if (files != null && files.Length > 0)
            {
                float totalFileCount = files.Length;
                AppendLog("待比对文件数：{0}", totalFileCount);
                string f = string.Empty;
                float p = 0;
                for (int i = 0; i < files.Length; i++)
                {
                    f = files[i];
                    p = i / totalFileCount;
                    string ext = Path.GetExtension(f);
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string newFilePath = f;
                        string relativePath = f.Replace(_newDir, "").Remove(0, 1);
                        string oldFilePath = Path.Combine(_oldDir, relativePath);
                        bool isModify = false;
                        if (File.Exists(oldFilePath))
                        {//检查文件是否变更
                            #region 比对CRC                         
                            AppendLog(false, p, "计算CRC=>{0}", oldFilePath);
                            string oldCRC = CRC.GetFileCRC32(oldFilePath);
                            AppendLog(false, p, "获取CRC【{0}】=>{1}", oldCRC, oldFilePath);
                            Thread.Sleep(10);
                            AppendLog(false, p, "计算CRC=>{0}", newFilePath);
                            string newCRC = CRC.GetFileCRC32(newFilePath);
                            AppendLog(false, p, "获取CRC【{0}】=>{1}", newCRC, newFilePath);
                            if (!oldCRC.Equals(newCRC))
                            {
                                isModify = true;
                            }
                            #endregion
                        }
                        else
                        {//新增的文件
                            isModify = true;
                        }

                        if (isModify)
                        {//如果文件变更则放到增量包文件夹
                            #region 缓存已变更的文件
                            string tempPath = Path.Combine(_ristDir, relativePath);
                            string tempDir = Path.GetDirectoryName(tempPath);
                            if (ext.Equals(".pak"))
                            {
                                _waitChunkPaks.Add(new WaitChunkPak() {
                                    oldPak = oldFilePath, newPak = newFilePath,pakDirectory = tempDir });
                            }
                            else
                            {//放入增量包                                
                                _waitCopeFiles.Add(new WaitCopyFile()
                                {
                                    source = f,
                                    target = tempPath,
                                    relative = relativePath,
                                    directory = tempDir
                                });
                            }
                            #endregion
                        }
                    }
                }
                AppendLog("比对文件完成");
                CancelBuildPack();
            }
        }
        #endregion

        #region CancelBuildPack 取消生成包
        /// <summary>
        /// 取消生成包
        /// </summary>
        void CancelBuildPack()
        {
            SwitchBuildState(false);
        }
        #endregion

        private void tbOldUnrealPakExe_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(tbOldUnrealPakExe.Text))
            {
                lbOldEngineDir.Text =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(tbOldUnrealPakExe.Text)
                        )
                    );
            }            
        }

        private void tbNewUnrealPakExe_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(tbNewUnrealPakExe.Text))
            {
                lbNewEngineDir.Text =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(tbNewUnrealPakExe.Text)
                        )
                    );
            }
        }
    }
}
