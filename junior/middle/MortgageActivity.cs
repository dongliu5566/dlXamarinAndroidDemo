using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using middle.bean;
using static Android.Views.View;
using static Android.Widget.CompoundButton;
using static Android.Widget.TextView;

namespace middle 
{
    [Activity(Label = "MortgageActivity")]
    public class MortgageActivity : Activity ,IOnClickListener,
        RadioGroup.IOnCheckedChangeListener, IOnCheckedChangeListener
    {
        private EditText et_price; // 声明一个编辑框对象
        private EditText et_loan; // 声明一个编辑框对象
        private TextView tv_loan; // 声明一个文本视图对象
        private RadioGroup rg_payment; // 声明一个单选组对象
        private CheckBox ck_business; // 声明一个复选框对象
        private EditText et_business; // 声明一个编辑框对象
        private CheckBox ck_accumulation; // 声明一个复选框对象
        private EditText et_accumulation; // 声明一个编辑框对象
        private TextView tv_payment; // 声明一个文本视图对象

        private bool isInterest = true; // 是否为等额本息
        private bool hasBusiness = true; // 是否存在商业贷款
        private bool hasAccumulation = false; // 是否存在公积金贷款
        private int mYear; // 还款年限
        private double mBusinessRatio; // 商业贷款的利率
        private double mAccumulationRatio; // 公积金贷款的利率


        public void OnCheckedChanged(RadioGroup group, int checkedId)
        {
            if (checkedId == Resource .Id.rb_interest)
            { // 选择了等额本息方式
                isInterest = true;
            }
            else if (checkedId == Resource.Id.rb_principal)
            { // 选择了等额本金方式
                isInterest = false;
            }
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            if (buttonView.Id == Resource.Id.ck_business)
            { // 勾选了商业贷款
                hasBusiness = isChecked;
            }
            else if (buttonView.Id == Resource.Id.ck_accumulation)
            { // 勾选了公积金贷款
                hasAccumulation = isChecked;
            }
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_loan)
            { // 点击了按钮“计算贷款总额”
                if (TextUtils.IsEmpty(et_price.Text))
                {
                    Toast.MakeText(this, "购房总价不能为空", ToastLength.Long).Show();
                    return;
                }
                if (TextUtils.IsEmpty(et_loan.Text))
                {
                    Toast.MakeText(this, "按揭部分不能为空",ToastLength.Short).Show();
                    return;
                }
                showLoan(); // 显示计算好的贷款总额
            }
            else if (v.Id == Resource.Id.btn_calculate)
            { // 点击了按钮“计算还款明细”
                if (hasBusiness && TextUtils.IsEmpty(et_business.Text))
                {
                    Toast.MakeText(this, "商业贷款总额不能为空", ToastLength.Short).Show();
                    return;
                }
                if (hasAccumulation && TextUtils.IsEmpty(et_accumulation.Text))
                {
                    Toast.MakeText(this, "公积金贷款总额不能为空",ToastLength.Short).Show();
                    return;
                }
                if (!hasBusiness && !hasAccumulation)
                {
                    Toast.MakeText(this, "请选择商业贷款或者公积金贷款", ToastLength.Short).Show();
                    return;
                }
                showRepayment(); // 显示计算好的还款明细
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_mortgage);
            tv_loan = FindViewById<TextView>(Resource.Id.tv_loan);
            et_price = FindViewById<EditText>(Resource.Id.et_price);
            et_loan = FindViewById<EditText>(Resource.Id.et_loan);
          
            rg_payment = FindViewById<RadioGroup>(Resource.Id.rg_payment);
            rg_payment.SetOnCheckedChangeListener(this);
            ck_business = FindViewById<CheckBox>(Resource.Id.ck_business);
            ck_business.SetOnCheckedChangeListener(this);
            et_business = FindViewById<EditText>(Resource.Id.et_business);
            ck_accumulation = FindViewById<CheckBox>(Resource.Id.ck_accumulation);
            ck_accumulation.SetOnCheckedChangeListener(this);
            et_accumulation = FindViewById<EditText>(Resource.Id.et_accumulation);
            tv_payment = FindViewById<TextView>(Resource.Id.tv_payment);
            FindViewById(Resource.Id.btn_loan).SetOnClickListener(this);
            FindViewById(Resource.Id.btn_calculate).SetOnClickListener(this);
            initYearSpinner();
            initRatioSpinner();
            // Create your application here
        }

        private void initRatioSpinner()
        {
            ArrayAdapter<String> ratioAdapter = new ArrayAdapter<String>(this,
             Resource.Layout.item_select, ratioDescArray);
            ratioAdapter.SetDropDownViewResource(Resource.Layout.item_dropdown) ;
            Spinner sp_ratio = FindViewById<Spinner>(Resource.Id.sp_ratio);
            sp_ratio.Prompt="请选择基准利率";
            sp_ratio.Adapter=ratioAdapter;
            sp_ratio.SetSelection(0);
            //  sp_ratio.setOnItemSelectedListener(new RatioSelectedListener());
            sp_ratio.ItemSelected += (s, e) => {
                mBusinessRatio = businessArray[e.Id];
                mAccumulationRatio = accumulationArray[e.Id];
            };

        }
        private String[] yearDescArray = { "5年", "10年", "15年", "20年", "30年" };
        private int[] yearArray = { 5, 10, 15, 20, 30 };
        private void initYearSpinner()
        {
            ArrayAdapter<String> yearAdapter = new ArrayAdapter<String>(this,
              Resource.Layout.item_select, yearDescArray);
            yearAdapter.SetDropDownViewResource(Resource.Layout.item_dropdown);
            Spinner sp_year = FindViewById<Spinner>(Resource.Id.sp_year);
            sp_year.Prompt = "请选择贷款年限";
            sp_year.Adapter = yearAdapter;
            sp_year.SetSelection(0);
            // sp_year.setOnItemSelectedListener(new YearSelectedListener());
            sp_year.ItemSelected += (s, e) => {
                mYear = yearArray[e.Id];
            };

        }

        private String[] ratioDescArray = {
            "2015年10月24日 五年期商贷利率 4.90%　公积金利率 3.25%",
            "2015年08月26日 五年期商贷利率 5.15%　公积金利率 3.25%",
            "2015年06月28日 五年期商贷利率 5.40%　公积金利率 3.50%",
            "2015年05月11日 五年期商贷利率 5.65%　公积金利率 3.75%",
            "2015年03月01日 五年期商贷利率 5.90%　公积金利率 4.00%",
            "2014年11月22日 五年期商贷利率 6.15%　公积金利率 4.25%",
            "2012年07月06日 五年期商贷利率 6.55%　公积金利率 4.50%",
    };
        private double[] businessArray = { 4.90, 5.15, 5.40, 5.65, 5.90, 6.15, 6.55 };
        private double[] accumulationArray = { 3.25, 3.25, 3.50, 3.75, 4.00, 4.25, 4.50 };

        // 根据购房总价和按揭比例，计算贷款总额
        private void showLoan()
        {
            double total = Double.Parse(et_price.Text);
            double rate = Double.Parse(et_loan.Text) / 100;
            String desc = String.Format("您的贷款总额为{0}万元", Convert.ToDecimal(total * rate));
            tv_loan.Text=desc;
        }

        // 根据贷款的相关条件，计算还款总额、利息总额，以及月供
        private void showRepayment()
        {
            Repayment businessResult = new Repayment();
            Repayment accumulationResult = new Repayment();
            if (hasBusiness)
            { // 申请了商业贷款
                double businessLoad = Double.Parse(et_business.Text) * 10000;
                double businessTime = mYear * 12;
                double businessRate = mBusinessRatio / 100;
                // 计算商业贷款部分的还款明细
                businessResult = calMortgage(businessLoad, businessTime, businessRate, isInterest);
            }
            if (hasAccumulation)
            { // 申请了公积金贷款
                double accumulationLoad = Double.Parse(et_accumulation.Text) * 10000;
                double accumulationTime = mYear * 12;
                double accumulationRate = mAccumulationRatio / 100;
                // 计算公积金贷款部分的还款明细
                accumulationResult = calMortgage(accumulationLoad, accumulationTime, accumulationRate, isInterest);
            }
            String desc = String.Format("您的贷款总额为{0}万元", formatDecimal(
                    (businessResult.mTotal + accumulationResult.mTotal) / 10000, 2));
            desc = String.Format("{0}\n　　还款总额为%s万元", desc, formatDecimal(
                    (businessResult.mTotal + businessResult.mTotalInterest +
                            accumulationResult.mTotal + accumulationResult.mTotalInterest) / 10000, 2));
            desc = String.Format("{0}\n其中利息总额为%s万元", desc, formatDecimal(
                    (businessResult.mTotalInterest + accumulationResult.mTotalInterest) / 10000, 2));
            desc = String.Format("{0}\n　　还款总时间为%d月", desc, mYear * 12);
            if (isInterest)
            { // 如果是等额本息方式
                desc = String.Format("{0}\n每月还款金额为%s元", desc, formatDecimal(
                        businessResult.mMonthRepayment + accumulationResult.mMonthRepayment, 2));
            }
            else
            { // 如果是等额本金方式
                desc = String.Format("{0}\n首月还款金额为%s元，其后每月递减%s元", desc, formatDecimal(
                        businessResult.mMonthRepayment + accumulationResult.mMonthRepayment, 2),
                        formatDecimal(businessResult.mMonthMinus + accumulationResult.mMonthMinus, 2));
            }
            tv_payment.SetText(desc, BufferType.Normal);
        }


        // 精确到小数点后第几位
        private String formatDecimal(double value, int digit)
        {
            Decimal bd = new Decimal(value);
            //  bd = bd.setScale(digit, RoundingMode.HALF_UP);
           
            return bd.ToString("0.00"); ;
        }
        // 根据贷款金额、还款年限、基准利率，计算还款信息
        private Repayment calMortgage(double ze, double nx, double rate, bool bInterest)
        {
          //  double zem = (ze * rate / 12 * Math.pow((1 + rate / 12), nx))
              double zem = (ze * rate / 12 * Math.Pow((1 + rate / 12), nx))
                    / (Math.Pow((1 + rate / 12), nx) - 1);
            double amount = zem * nx;
            double rateAmount = amount - ze;

            double benjinm = ze / nx;
            double lixim = ze * (rate / 12);
            double diff = benjinm * (rate / 12);
            double huankuanm = benjinm + lixim;
            double zuihoukuan = diff + benjinm;
            double av = (huankuanm + zuihoukuan) / 2;
            double zong = av * nx;
            double zongli = zong - ze;

            Repayment result = new Repayment();
            result.mTotal = ze;
            if (bInterest)
            {
                result.mMonthRepayment = zem;
                result.mTotalInterest = rateAmount;
            }
            else
            {
                result.mMonthRepayment = huankuanm;
                result.mMonthMinus = diff;
                result.mTotalInterest = zongli;
            }
            return result;
        }

    }
}