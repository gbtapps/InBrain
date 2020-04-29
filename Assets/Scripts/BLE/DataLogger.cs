using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataLogger
{
    public string StorePath = null;
	public string FilePath = null;
    StreamWriter streamWriter = null;
	int Counter = 0;

	public DataLogger()
	{
        string path = "";
        using (AndroidJavaClass jcEnvironment = new AndroidJavaClass("android.os.Environment"))
        using (AndroidJavaObject joExDir = jcEnvironment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
        {
            path = joExDir.Call<string>("toString") + "/GBT_LOG";
        }
        //フォルダがなければ作成
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        StorePath = path;
        
        FilePath = path + "/xblog" + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss") + ".csv";
        //FilePath = Application.persistentDataPath + "/xblog" + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss") + ".csv";
        Debug.Log("Logger Init SavePath:"+ FilePath);
		streamWriter = File.AppendText(FilePath);        
	}

	/**
     * データ1件分＝1行分を書き込みます。ヘッダ書き込みもこれを利用してください。
     * @param data データ
     */
	public void write(string DataStr)
	{
		if(FilePath == null )
		{
			Debug.Log("Logger is not init");
			return;
		}
		//Debug.Log("Logger "+DataStr);

		//File.AppendAllText(FilePath, DataStr + Environment.NewLine);
		streamWriter.WriteLine(DataStr);
		Counter++;

		if(5 < Counter)
		{
			streamWriter.Flush();
			Counter = 0;
		}
	}

	public void close()
	{
		if(streamWriter ==null)
		{
			return;
		}
		streamWriter.Flush();
		streamWriter.Close();

		FilePath = null;
		streamWriter = null;
		Counter = 0;
	}

}
