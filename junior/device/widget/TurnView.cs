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

using static Android.Annotation.SuppressLint;
using static Android.Content.Context;
using static Android.Graphics.Canvas;
using static Android.Graphics.Color;
using static Android.Graphics.Paint;
using static Android.Graphics.RectF;
using static Android.Graphics.Paint.Style;
using static Android.OS.Handler;
using Android.Util;
using Android.Graphics;
using Android.Icu.Util;
using Java.Lang;
using System.Threading.Tasks;
using System.Threading;
//using static Android.Util;
//using static Android.View;


namespace device.widget
{
    public class TurnView : View
    {
        private Paint mPaint; // 声明一个画笔对象
        private RectF mRectF; // 矩形边界
        private int mBeginAngle = 0; // 起始角度
        private bool isRunning = false; // 是否正在转动
        private Handler mHandler = new Handler(); // 声明一个处理器对象
        //public TurnView(Context context, IAttributeSet attrs) : base(context, attrs)
        //{
        //    // this(context, null);
        //}
        public TurnView(Context context) : base(context, null)
        {
            // this(context, null);
        }


        // public View(Context context, IAttributeSet attrs);
        //     public View(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes);
        public TurnView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            //super(context, attrs);
            mPaint = new Paint(); // 创建新画笔
            //mPaint.setAntiAlias(true); // 设置画笔为无锯齿
            //mPaint.setColor(Color.RED); // 设置画笔的颜色
            //mPaint.setStrokeWidth(10); // 设置画笔的线宽
            //mPaint.setStyle(Style.FILL); // 设置画笔的类型。STROK表示空心，FILL表示实心

            mPaint.AntiAlias = true; // 设置画笔为无锯齿
            mPaint.Color = Color.Red; // 设置画笔的颜色
            mPaint.StrokeWidth = 10; // 设置画笔的线宽
                                     //    mPaint.Style(=Style.Fill); // 设置画笔的类型。STROK表示空心，FILL表示实心
            mPaint.SetStyle(Style.Fill);


        }

        //protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec):base Measure
        //{
        //   // super.onMeasure(widthMeasureSpec, heightMeasureSpec);
        //    // 计算转动圆圈的直径
        //    int diameter = getMeasuredWidth() - getPaddingLeft() - getPaddingRight();
        //    //// 根据圆圈直径创建转动区域的矩形边界
        //    //mRectF = new RectF(getPaddingLeft(), getPaddingTop(),
        //    //        getPaddingLeft() + diameter, getPaddingTop() + diameter);
        //}


        //protected override  void OnDraw(Canvas canvas):base
        //{
        //    super.onDraw(canvas);
        //    // 在画布上绘制扇形。第四个参数为true表示绘制扇形，为false表示绘制圆弧
        //    canvas.drawArc(mRectF, mBeginAngle, 30, true, mPaint);
        //}

        // 开始转动
        public void Start()
        {
            isRunning = true;
            // 立即启动绘制任务
            mHandler.Post(() =>
            {
               
            }
            ); ;
            //方法二
            Task.Factory.StartNew(()=> { 

            });

        }

        //public void Start1()
        //{
        //    isRunning = true;

        //    //方法一
        //    //  if (work==null||!worker.IsAlive) 
        //   / /{
        //      //  System.Threading.Thread worker = new System.Threading.Thread(new ThreadStart());
        //      //  worker.Start();
        //   // }

        //    //方法三
                  //    IntentService Intent
        //    //  if (work==null||!worker.IsAlive) 
        //   / /{
        //      //  System.Threading.Thread worker = new System.Threading.Thread(new ThreadStart());
        //      //  worker.Start();
        //   // }

        //}

        // 停止转动
        public void stop()
        {
            isRunning = false;
        }

        // 定义一个绘制任务，通过持续绘制实现转动效果
        public class drawRunnable1 : Java.Lang.Object, IRunnable
        {
            public void Run()
            {
             
            }
        }


    }

}
