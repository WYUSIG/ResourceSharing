using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
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
    public static Boolean uploadFile(String categoryName, String uploader,String name,String descn,String fileName,String image)
    {
        String now = Time.getDataTime();
        String categoryId = getCategoryIdByName(categoryName);
        String insertsql = "INSERT INTO resource(categoryId,uploader,name,descn,codeFile,uploadTime) VALUES(" + categoryId + "," + uploader + ",'"+name+"','"+descn+"','"+fileName+"','"+now+"')";
        
        try
        {
            int flag = SqlHelp.ExecuteNonQueryCount(insertsql);
            if (flag > 0)
            {
                
                String resourceId = getResourceId(uploader,now);
                String insertsql1 = "INSERT INTO resourceImage(resourceId,image) VALUES("+resourceId+",'"+image+"')";
                int flag1 = SqlHelp.ExecuteNonQueryCount(insertsql1);
                if (flag1 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
                 

            }
            return false;
        }
        catch (System.InvalidCastException e)
        {
            return false;
        }
    }
    public static String getCategoryIdByName(String name)
    {
        String selectsql = "SELECT categoryId FROM category WHERE name='"+name+"'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String categoryId = reader.GetInt32(0).ToString();
                return categoryId;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    public static String getResourceId(String uploader,String time)
    {
        String selectsql = "SELECT resourceId FROM resource WHERE uploader="+uploader+" AND uploadTime='" + time + "'";
        try
        {
            SqlDataReader reader = SqlHelp.GetDataReaderValue(selectsql);
            if (reader.Read())
            {
                String resourceId = reader.GetInt32(0).ToString();
                return resourceId;
            }
            return null;
        }
        catch (System.InvalidCastException e)
        {
            return null;
        }
    }
    public static String FileSuffix(String fileName)
    {
        return Path.GetExtension(fileName);
    }
}