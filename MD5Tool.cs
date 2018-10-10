
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace StrayFog_Framework_Pak
{
    /// <summary>
    /// MD5工具
    /// </summary>
    public sealed class MD5Tool
    {
        /// <summary>
        /// 获得文件md5校验码
        /// </summary>
        /// <param name="_fileName">文件</param>
        /// <returns>校验码</returns>
        public static string GetFileMd5Chunk(string _fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = new FileStream(_fileName, FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fs);
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
            }            
            return sb.ToString();
        }
    }
}
