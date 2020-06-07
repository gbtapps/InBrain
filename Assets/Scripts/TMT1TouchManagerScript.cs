using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System;





public class TMT1TouchManagerScript : MonoBehaviour
{

    
    //S522TestGameManagerの関数を使う
    private GameObject S522Test1GameManager;
    private S522Test1GameManagerScript InstanceS522Test1GameManagerScript;


    //複製対象ボタンテキスト
    public GameObject target_text = null; // Textオブジェクト

    //カウンタ上限（＝ボタン数）を設定
    int limitCount;

    //ボタン色変更メソッド用変数
    public Image image;
    private Sprite sprite;

    // T1テスト結果の記録（回答時刻、正否
//    List<string> T1UserAnswerList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {

        //S522Test1GameManagerの機能を使う
        S522Test1GameManager = GameObject.Find("S522Test1GameManager");
        InstanceS522Test1GameManagerScript = S522Test1GameManager.GetComponent<S522Test1GameManagerScript>();


        limitCount = InstanceS522Test1GameManagerScript.GetNumOfTargets();
 //       Debug.Log("limitCount= " + limitCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        //画面タッチ時間を記録
        InstanceS522Test1GameManagerScript.PushDown();



        //ボタンタップのカウンタbCountを作成
        int bCount;
        bCount = InstanceS522Test1GameManagerScript.GetButtonCount();
//        Debug.Log("bCount= " + bCount);

        //1から順ではないと押せない処理
        //テキストを受ける
        Text target_text_text = target_text.GetComponent<Text>();
        string touched_button_value = target_text_text.text;

        //        Debug.Log("target_text_text.text: " + target_text_text.text);
        //        Debug.Log("touched_button_value: " + touched_button_value);


        string truefalse = "";

        //タッチしたボタンと正解数字との比較し正解だったら
        if ( touched_button_value == bCount.ToString() )
        {
            //色を変える
            ChangeButtonColor();
//            Debug.Log("done ChangeButtonColor()" + touched_button_value);



            //正解したので正解数字をカウントアップ
            bCount++;
            //            Debug.Log("bCount++= " + bCount);
            //実際にカウントアップする関数
            InstanceS522Test1GameManagerScript.SetButtonCount(bCount);

            InstanceS522Test1GameManagerScript.RightPush();



//            truefalse = "1";



        }
        else
        {
            InstanceS522Test1GameManagerScript.WrongPush();
            truefalse = "0";


        }


//        T1UserAnswerList.Add(DateTime.Now.ToString("yyyyMMddHHmmss.fff")+","+truefalse);

//        Debug.Log(T1UserAnswerList.Count);



        /*
        for(int i=0; i<T1UserAnswerList.Count; i++)
        {
            if (T1UserAnswerList.Count == 1) continue;
//            string a = T1UserAnswerList[i].Substring(0, 18);
//            string b = T1UserAnswerList[i - 1].Substring(0, 18);

            float aaa = float.Parse(T1UserAnswerList[i].Substring(0, 18));
            float bbb = float.Parse(T1UserAnswerList[i - 1].Substring(0, 18));

            Debug.Log(aaa);
            Debug.Log(bbb);
            Debug.Log(bbb-aaa);


        }
        */



        /*
        string a = T1UserAnswerList[i].Substring(0, 18);
            string b = T1UserAnswerList[i - 1].Substring(0, 18);

        */

        /*
        foreach (string str in T1UserAnswerList)
        {

            Debug.Log(str);
            /*
            Debug.Log(str.Substring(0, 18));
            Debug.Log(float.Parse(str.Substring(0, 18)));
      
        }
    */




        //ボタンすべて押し切った
        if ( bCount-1 == limitCount )
        {
            //            Debug.Log("ボタンすべて押し切った");
            //            Debug.Log("limitCount= " + limitCount);
            //            Debug.Log("bCount++= " + bCount);

            //すべてのボタンを消す
            InstanceS522Test1GameManagerScript.DropButtons();
            //            Debug.Log("Done DropButtons()");

            //カウントアップ変数を1に戻す
            InstanceS522Test1GameManagerScript.SetButtonCount(1);


            //新しいセットを作成する
            InstanceS522Test1GameManagerScript.ReCreateTargets();
//            Debug.Log("CreateTargets(limitCount)");

        }

    }

    void ChangeButtonColor()
    {
        //色を変える処理
        sprite = Resources.Load<Sprite>("a_outline");
        image = this.GetComponent<Image>();
        image.sprite = sprite;
    }



}



