using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace storage.util
{
    public class FileUtil
    {
        // 把字符串保存到指定路径的文本文件
        public static void saveText(String path, String txt)
        {
            try
            {
                // 根据指定文件路径构建文件输出流对象
                FileOutputStream fos = new FileOutputStream(path);
                // 把字符串写入文件输出流
              //  fos.write(txt.getBytes());
                fos.Write(txt.Length);
                // 关闭文件输出流
                fos.Close();
            }
            catch (Exception e)
            {
                //   e.printStackTrace();
                System.Console.WriteLine(e.StackTrace);
            }
        }

        // 从指定路径的文本文件中读取内容字符串
        public static String openText(String path)
        {
            String readStr = "";
            try
            {
                // 根据指定文件路径构建文件输入流对象
                FileInputStream fis = new FileInputStream(path);
             //   byte[] b = new byte[fis.available()];
                byte[] b = new byte[fis.Available()];
                // 从文件输入流读取字节数组
                fis.Read(b);
                // 把字节数组转换为字符串
             //   readStr = new String(b);
                readStr = Convert.ToBase64String(b);
                // 关闭文件输入流
                fis.Close();
            }
            catch (Exception e)
            {
            //    e.printStackTrace();
                System.Console.WriteLine(e.StackTrace);
            }
            // 返回文本文件中的文本字符串
            return readStr;
        }

    }
}