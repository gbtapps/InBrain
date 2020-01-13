using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;




public class TMT2TouchManagerScript : MonoBehaviour
{

    //タッチカウンタ
    public Page90GameManagerScript InstancePage90GameManagerScript;

    //複製対象ボタンテキスト
    public GameObject target_text = null; // Textオブジェクト

    //カウンタ上限（＝ボタン数）を設定
    int limitCount;

    //ボタン色変更メソッド用変数
    public Image image;
    private Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        limitCount = InstancePage90GameManagerScript.GetNumOfTargets();
 //       Debug.Log("limitCount= " + limitCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        InstancePage90GameManagerScript.PushDown();

        //ボタンタップのカウンタbCountを作成
        int bCount;
        bCount = InstancePage90GameManagerScript.GetButtonCount();
        Debug.Log("bCount= " + bCount);

        //1から順ではないと押せない処理
        //テキストを受ける
        Text target_text_text = target_text.GetComponent<Text>();
        string touched_button_value = target_text_text.text;

//        Debug.Log("target_text_text.text: " + target_text_text.text);
        Debug.Log("touched_button_value: " + touched_button_value);

        //タッチしたボタンと正解数字との比較し正解だったら

        string buttonSymbol = "";
        switch (bCount-1) {
            case 0: buttonSymbol = "1"; break;
            case 1: buttonSymbol = "A"; break;
            case 2: buttonSymbol = "2"; break;
            case 3: buttonSymbol = "B"; break;
            case 4: buttonSymbol = "3"; break;
            case 5: buttonSymbol = "C"; break;
            case 6: buttonSymbol = "4"; break;
            case 7: buttonSymbol = "D"; break;
            case 8: buttonSymbol = "5"; break;
            case 9: buttonSymbol = "E"; break;
            case 10: buttonSymbol = "6"; break;
            case 11: buttonSymbol = "F"; break;
            case 12: buttonSymbol = "7"; break;
            case 13: buttonSymbol = "G"; break;
            case 14: buttonSymbol = "8"; break;
            case 15: buttonSymbol = "H"; break;
            case 16: buttonSymbol = "9"; break;
            case 17: buttonSymbol = "I"; break;
            case 18: buttonSymbol = "10"; break;
            case 19: buttonSymbol = "J"; break;
            case 20: buttonSymbol = "11"; break;
            case 21: buttonSymbol = "K"; break;
            case 22: buttonSymbol = "12"; break;
            case 23: buttonSymbol = "L"; break;
            case 24: buttonSymbol = "13"; break;
            case 25: buttonSymbol = "M"; break;
            case 26: buttonSymbol = "14"; break;
        }

            Debug.Log("buttonSymbol:" + buttonSymbol);


        //        if ( touched_button_value == bCount.ToString() )
        if (touched_button_value == buttonSymbol)
            {
                //色を変える
                ChangeButtonColor();
//            Debug.Log("done ChangeButtonColor()" + touched_button_value);


            //正解したので正解数字をカウントアップ
            bCount++;
//            Debug.Log("bCount++= " + bCount);
            //実際にカウントアップする関数
            InstancePage90GameManagerScript.SetButtonCount(bCount);

            InstancePage90GameManagerScript.RightPush();

        }
        else
        {
            InstancePage90GameManagerScript.WrongPush();
        }


        //ボタンすべて押し切った
        if ( bCount-1 == limitCount )
        {
//            Debug.Log("ボタンすべて押し切った");
//            Debug.Log("limitCount= " + limitCount);
//            Debug.Log("bCount++= " + bCount);

            //すべてのボタンを消す
            InstancePage90GameManagerScript.DropButtons();
//            Debug.Log("Done DropButtons()");

            //カウントアップ変数を1に戻す
            InstancePage90GameManagerScript.SetButtonCount(1);


            //新しいセットを作成する
            InstancePage90GameManagerScript.ReCreateTargets();
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



