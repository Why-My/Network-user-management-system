using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 网络用户管理系统
{
    public partial class Validdateimage : System.Web.UI.Page
    {
        private readonly string ImagePath = "Resources/image1.jpg";
        private string sValidator = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Validator"] != null)
               {
                   sValidator = Session["Validator"].ToString();
                  

               }
             
               Bitmap bitMapImage = new Bitmap(Server.MapPath(ImagePath));//创建BMP位图
             
               Graphics graphicImage = Graphics.FromImage(bitMapImage);//创建画板
               graphicImage.SmoothingMode = SmoothingMode.AntiAlias;//指定画笔输出模式/抗锯齿
               Font font = new Font("Arial", 180, (FontStyle)(QFontStye()));//设置画笔样式
           
               SolidBrush brush = new SolidBrush(Color.Red);//设置画笔颜色
               graphicImage.DrawString(sValidator, font, brush, 0, 0);//绘制验证码
              
               Response.ContentType = "image/jpeg";//设置图像输出格式
               bitMapImage.Save(Response.OutputStream, ImageFormat.Jpeg);//将图像以jpeg的格式保存到数据流中
               //释放资源
               graphicImage.Dispose();
               bitMapImage.Dispose();
               Response.End();


           
        }
        private int QFontStye()//确定文本样式
        {
            int[] intFontStye = {0,1,2,4,8 };
            Random random2 = new Random();
            int index2 = random2.Next(5);
            return index2;
        }
    }
}