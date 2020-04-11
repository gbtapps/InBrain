using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTouchButtonScript : MonoBehaviour
{

    public GameObject ThisButton;
    Text ButtonNumber;

    GameObject GameController1;
    GameObject GameController2;
    GameObject GameController3;
    GameObject GameController4;

    S211BexSpeedTouchId1ControllerScript GameControllerScript1;
    S212BexSpeedTouchId2ControllerScript GameControllerScript2;
    S213BexSpeedTouchId3ControllerScript GameControllerScript3;
    S214BexSpeedTouchId4ControllerScript GameControllerScript4;

    bool Yn1;
    bool Yn2;
    bool Yn3;


    // Start is called before the first frame update
    void Start()
    {
        GameController1 = GameObject.Find("S211BexSpeedTouchId1Controller");
        GameController2 = GameObject.Find("S212BexSpeedTouchId2Controller");
        GameController3 = GameObject.Find("S213BexSpeedTouchId3Controller");
        GameController4 = GameObject.Find("S214BexSpeedTouchId4Controller");


        Debug.Log(GameController1);
        Debug.Log(GameController2);
        Debug.Log(GameController3);
        Debug.Log(GameController4);



    }





    public void OnClickButton()
    {

        Debug.Log("OnClickButton");


        //新規作成したボタンに紐づく子要素を取得
        foreach (Transform child in this.transform)
        {
            //子要素はテキストオブジェクトなのでテキストコンポーネントを取得
            ButtonNumber = child.GetComponent<Text>();
            Debug.Log("ButtonNumber:" + ButtonNumber.text);
        }

        // 別のオブジェクト(Sphere)のスクリプトを参照する場合
        if (GameController1 != null)
        {
            GameControllerScript1 = GameController1.GetComponent<S211BexSpeedTouchId1ControllerScript>();
            string StrNumber = ButtonNumber.text;
            bool Yn1 = false;
            Yn1 = GameControllerScript1.TouchButton(StrNumber);
            if (Yn1 == true)
            {
                //ボタンの色を変える場合はスプライトを変更する処理

                //ボタンを消す１
                //            ThisButton.SetActive(false);
                //ボタンを消す２
                GameObject.Destroy(this.gameObject);
            }

        }
        if (GameController2 != null)
        {
            GameControllerScript2 = GameController2.GetComponent<S212BexSpeedTouchId2ControllerScript>();
            string StrNumber = ButtonNumber.text;
            bool Yn2 = false;
            Yn2 = GameControllerScript2.TouchButton(StrNumber);
            if (Yn2 == true)
            {
                //ボタンの色を変える場合はスプライトを変更する処理

                //ボタンを消す１
                //            ThisButton.SetActive(false);
                //ボタンを消す２
                GameObject.Destroy(this.gameObject);
            }

        }
        if (GameController3 != null)
        {
            GameControllerScript3 = GameController3.GetComponent<S213BexSpeedTouchId3ControllerScript>();
            string StrNumber = ButtonNumber.text;
            bool Yn3 = false;
            Yn3 = GameControllerScript3.TouchButton(StrNumber);
            if (Yn3 == true)
            {
                //ボタンの色を変える場合はスプライトを変更する処理

                //ボタンを消す１
                //            ThisButton.SetActive(false);
                //ボタンを消す２
                GameObject.Destroy(this.gameObject);
            }

        }
        if (GameController4 != null)
        {
            GameControllerScript4 = GameController4.GetComponent<S214BexSpeedTouchId4ControllerScript>();
            string StrNumber = ButtonNumber.text;
            bool Yn4 = false;
            Yn4 = GameControllerScript4.TouchButton(StrNumber);
            if (Yn4 == true)
            {
                //ボタンの色を変える場合はスプライトを変更する処理

                //ボタンを消す１
                //            ThisButton.SetActive(false);
                //ボタンを消す２
                GameObject.Destroy(this.gameObject);
            }

        }











    }




    // Update is called once per frame
    void Update()
    {

    }
}
