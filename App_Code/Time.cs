using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Time 的摘要说明
/// </summary>
public class Time
{
	public Time()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static String getDataTime()
    {
        return DateTime.Now.ToString();
    }

}