using System.Windows.Forms;

namespace StrayFog_Framework_Pak.Forms
{
    /// <summary>
    /// 基础平台窗口
    /// </summary>
    public interface IPlatformWindow
    {
        /// <summary>
        /// 平台类别
        /// </summary>
        enPlatform platform { get; }
    }
}
