using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
/// <summary>
///FileUtil 的摘要说明
/// </summary>
public class FileUtil
{
	public FileUtil()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    
    public static String getUUID()
    {
        return System.Guid.NewGuid().ToString("N");
    }

    public static Boolean updateHeadImage(String id,String fileName)
    {
        String updatesql = "UPDATE user set headImage='"+fileName+"' WHERE id="+id;
        try
        {
            int flag = SqlHelp.ExecuteNonQueryCount(updatesql);
            if (flag > 0)
            {
                return true;
            }
            return false;
        }
        catch (System.InvalidCastException e)
        {
            return false;
        }
    }
    public static Boolean uploadFile(String categoryId, String uploader,String name,String descn,String fileName)
    {
        String now = Time.getDataTime();
        String insertsql = "INSERT INTO resource(categoryId,uploader,name,descn,codeFile,uploadTime) VALUES(" + categoryId + "'," + uploader + ",'"+name+"','"+descn+"','"+fileName+"','"+now+"')";
        try
        {
            int flag = SqlHelp.ExecuteNonQueryCount(insertsql);
            if (flag > 0)
            {
                return true;
            }
            return false;
        }
        catch (System.InvalidCastException e)
        {
            return false;
        }
    }
}