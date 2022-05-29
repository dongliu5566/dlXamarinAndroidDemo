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

namespace middle.bean 
{
  public  class Repayment
    {
        public double mTotal;
        public double mMonthRepayment;
        public double mMonthMinus;
        public double mTotalInterest;

        public Repayment()
        {
            mTotal = 0;
            mMonthRepayment = 0;
            mMonthMinus = 0;
            mTotalInterest = 0;
        }
    }
}