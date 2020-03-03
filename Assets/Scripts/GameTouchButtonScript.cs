using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTouchButtonScript : MonoBehaviour
{

    public GameObject ThisButton;
    Text ButtonNumber;

//    public Page211BrainExST1ControllerScript _GetPage211BrainExST1ControllerScript;

    GameObject GameController;


    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("Page211BrainExST1Controller");
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
        Page211BrainExST1ControllerScript GameControllerScript = GameController.GetComponent<Page211BrainExST1ControllerScript>();

        string StrNumber = ButtonNumber.text;
        bool Yn = false;
        Yn = GameControllerScript.TouchButton( StrNumber);

        Debug.Log(Yn);


        if(Yn == true)
        {
            //ボタンの色を変える場合はスプライトを変更する処理

            //ボタンを消す１
            //            ThisButton.SetActive(false);

            //ボタンを消す２
            GameObject.Destroy(this.gameObject);
        }



    }
    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
