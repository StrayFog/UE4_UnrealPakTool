using System.Diagnostics;
using System.IO;
namespace StrayFog_Framework_Pak
{
    /// <summary>
    /// Cmd工具
    /// </summary>
    public sealed class CMDTool
    {
        #region ExecuteCmd 执行Cmd命令
        /// <summary>
        /// 执行Cmd命令
        /// </summary>
        /// <param name="_cmd">Cmd命令</param>
        public static void ExecuteCmd(string _cmd)
        {
            string batPath = Path.GetFullPath("temp.bat");
            File.WriteAllText(batPath, _cmd);
            using (Process myPro = new Process())
            {
                //指定启动进程是调用的应用程序和命令行参数
                ProcessStartInfo psi = new ProcessStartInfo(batPath);        
                myPro.StartInfo = psi;
                myPro.Start();
                myPro.WaitForExit();
            }
            File.Delete(batPath);
        }
        #endregion

        #region 删除目录
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="_directory">目录</param>
        public static void DeleteDirectory(string _directory)
        {
            if (Directory.Exists(_directory))
            {
                ExecuteCmd("rd /s /q \"" + _directory + "\" \r\n ping 127.0.0.1 -n 5>nul \r\n exit");
            }
        }
        #endregion
    }
}
