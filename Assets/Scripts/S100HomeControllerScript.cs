using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class S100HomeControllerScript : MonoBehaviour
{


    //デルタタイムカウント
    public float DeltaTimeCount;

    //デバッグテキスト文字列
    string DebugStr = "";
    //画面表示テキスト
    public Text DebugText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //経過時間カウンター
        DeltaTimeCount += Time.deltaTime;
        int i =0;

        if (DeltaTimeCount >= 0.1f)
        {
            DeltaTimeCount = 0.0f;
            Debug.Log("0.1秒おきに処理");
            i++;
            DebugText.text += i.ToString()+"> ";

        }


    }


}
