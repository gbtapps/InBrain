using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;




public class TMT1TouchManagerScript : MonoBehaviour
{

    //タッチカウンタ
    public Page70GameManagerScript InstancePage70GameManagerScript;

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
        limitCount = InstancePage70GameManagerScript.GetNumOfTargets();
 //       Debug.Log("limitCount= " + limitCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

        InstancePage70GameManagerScript.PushDown();

        //ボタンタップのカウンタbCountを作成
        int bCount;
        bCount = InstancePage70GameManagerScript.GetButtonCount();
//        Debug.Log("bCount= " + bCount);

        //1から順ではないと押せない処理
        //テキストを受ける
        Text target_text_text = target_text.GetComponent<Text>();
        string touched_button_value = target_text_text.text;

//        Debug.Log("target_text_text.text: " + target_text_text.text);
//        Debug.Log("touched_button_value: " + touched_button_value);


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
            InstancePage70GameManagerScript.SetButtonCount(bCount);

            InstancePage70GameManagerScript.RightPush();

        }
        else
        {
            InstancePage70GameManagerScript.WrongPush();
        }


        //ボタンすべて押し切った
        if ( bCount-1 == limitCount )
        {
//            Debug.Log("ボタンすべて押し切った");
//            Debug.Log("limitCount= " + limitCount);
//            Debug.Log("bCount++= " + bCount);

            //すべてのボタンを消す
            InstancePage70GameManagerScript.DropButtons();
//            Debug.Log("Done DropButtons()");

            //カウントアップ変数を1に戻す
            InstancePage70GameManagerScript.SetButtonCount(1);


            //新しいセットを作成する
            InstancePage70GameManagerScript.ReCreateTargets();
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



