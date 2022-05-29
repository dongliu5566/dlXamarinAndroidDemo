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
using Java.Lang;
using String = Java.Lang.String;

namespace junior.util
{
   public class Arith
    {
        private static  int DEF_DIV_SCALE = 10;
        /**
    * 提供精确的加法运算。
    *
    * @param v1 被加数
    * @param v2 加数
    * @return 两个参数的和
    */
        public static string add(double v1, double v2)
        {
            Decimal b1 = new Decimal(v1);
            Decimal b2 = new Decimal(v2);
            // return String.valueOf(b1.add(b2));
            return (b1 + b2).ToString();
        }

        /**
         * 提供精确的加法运算。
         *
         * @param v1 被加数
         * @param v2 加数
         * @return 两个参数的和
         */
        public static string add(String v1, String v2)
        {
            Decimal b1 =  Convert.ToDecimal(v1);
            Decimal b2 = Convert.ToDecimal(v2);
            return  decimal.Add(b1,b2).ToString();
        }

        ///**
        // * 提供精确的减法运算。
        // *
        // * @param v1 被减数
        // * @param v2 减数
        // * @return 两个参数的差
        // */
        public static string sub(double v1, double v2)
        {
            Decimal b1 = new Decimal(v1);
            Decimal b2 = new Decimal(v2);
            return decimal.Subtract(b1, b2).ToString();
        }

        /////**
        //// * 提供精确的减法运算。
        //// *
        //// * @param v1 被减数
        //// * @param v2 减数
        //// * @return 两个参数的差
        //// */
        public static string sub(String v1, String v2)
        {
            Decimal b1 = Convert.ToDecimal(v1);
            Decimal b2 = Convert.ToDecimal(v2);
            return decimal.Subtract(b1, b2).ToString();
        }

        /////**
        //// * 提供精确的乘法运算。
        //// *
        //// * @param v1 被乘数
        //// * @param v2 乘数
        //// * @return 两个参数的积
        //// */
        public static string mul(double v1, double v2)
        {
            Decimal b1 = new Decimal(v1);
            Decimal b2 = new Decimal(v2);
            return decimal.Multiply(b1, b2).ToString();
        }

        /////**
        //// * 提供精确的乘法运算。
        //// *
        //// * @param v1 被乘数
        //// * @param v2 乘数
        //// * @return 两个参数的积
        //// */
        public static string mul(String v1, String v2)
        {
            Decimal b1 = Convert.ToDecimal(v1);
            Decimal b2 = Convert.ToDecimal(v2);
            // return String.valueOf(b1.multiply(b2));
            return decimal.Multiply(b1, b2).ToString();
        }

        ///**
        // * 提供（相对）精确的除法运算，当发生除不尽的情况时，精确到 小数点以后10位，以后的数字四舍五入。
        // *
        // * @param v1 被除数
        // * @param v2 除数
        // * @return 两个参数的商
        // */
        public static string div(double v1, double v2)
        {
            return div(v1, v2, DEF_DIV_SCALE);
        }

        ///**
        // * 提供（相对）精确的除法运算，当发生除不尽的情况时，精确到 小数点以后10位，以后的数字四舍五入。
        // *
        // * @param v1 被除数
        // * @param v2 除数
        // * @return 两个参数的商
        // */
        //public static string div(string v1, string v2)
        //{
        //    return div(v1, v2, DEF_DIV_SCALE);
        //}

        ///**
        // * 提供（相对）精确的除法运算。当发生除不尽的情况时，由scale参数指 定精度，以后的数字四舍五入。
        // *
        // * @param v1    被除数
        // * @param v2    除数
        // * @param scale 表示表示需要精确到小数点以后几位。
        // * @return 两个参数的商
        // */
        public static string div(double v1, double v2, int scale)
        {
            if (scale < 0)
            {
                //   throw new IllegalArgumentException();
                throw new IllegalArgumentException(
                        "The scale must be a positive integer or zero");
            }
            Decimal b1 = new Decimal(v1);
            Decimal b2 = new Decimal(v2);
            //  return String.valueOf(b1.b2, scale, Decimal.ROUND_HALF_UP));
            return decimal.Divide(b1, b2).ToString();

        }

        ///**
        // * 提供（相对）精确的除法运算。当发生除不尽的情况时，由scale参数指 定精度，以后的数字四舍五入。
        // *
        // * @param v1    被除数
        // * @param v2    除数
        // * @param scale 表示表示需要精确到小数点以后几位。
        // * @return 两个参数的商
        // */
        //public static String div(String v1, String v2, int scale)
        //{
        //    if (scale < 0)
        //    {
        //        throw new IllegalArgumentException(
        //                "The scale must be a positive integer or zero");
        //    }
        //    BigDecimal b1 = new BigDecimal(v1);
        //    BigDecimal b2 = new BigDecimal(v2);

        //    BigDecimal result = null;
        //    try
        //    {
        //        result = b1.divide(b2);
        //    }
        //    catch (Exception e)
        //    {
        //        result = b1.divide(b2, scale, BigDecimal.ROUND_HALF_UP);
        //    }
        //    return String.valueOf(result);
        //}

        ///**
        // * 提供精确的小数位四舍五入处理。
        // *
        // * @param v     需要四舍五入的数字
        // * @param scale 小数点后保留几位
        // * @return 四舍五入后的结果
        // */
        //public static string round(double v, int scale)
        //{
        //    if (scale < 0)
        //    {
        //        throw new IllegalArgumentException(
        //                "The scale must be a positive integer or zero");
        //    }
        //    Decimal b = Convert.ToDecimal(v);
        //  Decimal one =Convert.ToDecimal("1");
        //    return  Convert.ToString(b.divide(one, scale, BigDecimal.ROUND_HALF_UP));
        //}
    }
}