using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 网络用户管理系统
{
    interface IDefault
    {   //创建验证码
        string CreatValidateString(int nLen);
        //初始化验证码所需数据
        void InitLetterList();
        //获取随机值
        int GetRandomInt(int max,int min);

    }
}
