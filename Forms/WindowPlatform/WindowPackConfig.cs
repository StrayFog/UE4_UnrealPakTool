using System.Configuration;
namespace StrayFog_Framework_Pak.Forms.WindowPlatform
{
    /// <summary>
    /// Window包配置
    /// </summary>
    public class WindowPackConfig: ConfigurationSection
    {
        [ConfigurationProperty("OldUnrealPakExe")]
        public string oldUnrealPakExe { get { return this["OldUnrealPakExe"].ToString(); } }
        
        [ConfigurationProperty("OldVersionName")]
        public string oldVersionName { get { return this["OldVersionName"].ToString(); } }

        [ConfigurationProperty("OldProjectDir")]
        public string oldProjectDir { get { return this["OldProjectDir"].ToString(); } }

        [ConfigurationProperty("OldVersionDirectory")]
        public string oldVersionDirectory { get { return this["OldVersionDirectory"].ToString(); } }

        [ConfigurationProperty("NewUnrealPakExe")]
        public string newUnrealPakExe { get { return this["NewUnrealPakExe"].ToString(); } }

        [ConfigurationProperty("NewVersionName")]
        public string newVersionName { get { return this["NewVersionName"].ToString(); } }

        [ConfigurationProperty("NewProjectDir")]
        public string newProjectDir { get { return this["NewProjectDir"].ToString(); } }

        [ConfigurationProperty("NewVersionDirectory")]
        public string newVersionDirectory { get { return this["NewVersionDirectory"].ToString(); } }
    }
}
