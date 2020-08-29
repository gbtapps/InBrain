using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

using System.IO;



public class TestWebRequestScript : MonoBehaviour
{

    public List<string> csvDatas = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()");

        TextAsset csv = Resources.Load("samplefile") as TextAsset;


        StringReader reader = new StringReader(csv.text);


        while (reader.Peek() > -1)
        {
            // Put data into List each line
            string line = reader.ReadLine();
            csvDatas.Add(line);

        }

        /*
        foreach(object str in csvDatas)
        {
            Debug.Log("csvDatas: " + str);

        }
        */


                StartCoroutine(APIExample());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class PostData
    {
        public string userid;
        public string timestamp;
//        public List<string> brainlist;
        public string[] brainlist;

    }

    IEnumerator APIExample()
    {
        
        string url = "https://bf882fxfw1.execute-api.ap-northeast-1.amazonaws.com/post/";

        /*
        string[] tempa = {
            "20200613151413,-8.24,1,Tmt",
            "20200613151414,-8.24,1,Tmt",
            "20200613151415,-8.24,1,Tmt",
            "20200613151416,-8.24,1,Tmt"
        };
        */

        string[] tempa = csvDatas.ToArray();




        // JSONのデータをBodyに入れてPOSTする
        PostData postData = new PostData();
        postData.userid = "ogihara";
        postData.timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        postData.brainlist = tempa;

        Debug.Log("json set on");

        string myJson = JsonUtility.ToJson(postData);
        byte[] byteData = System.Text.Encoding.UTF8.GetBytes(myJson);
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("header set on");

        yield return request.SendWebRequest();

        Debug.Log("return request");

        Debug.Log("Status Code: " + request.responseCode);


        // 通信エラーチェック
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                string text = request.downloadHandler.text;
                Debug.Log("utf-8: "+text);

                // バイナリデータとして取得する
                byte[] results = request.downloadHandler.data;
                Debug.Log("binary: " + results);

//                Debug.Log(Json.Deserialize(text));

            }
        }

    }


}