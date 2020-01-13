using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加


public class GenderManagerScript : MonoBehaviour
{


    public GameObject gender_object = null; // Textオブジェクト

    public GameObject maleBtn;
    public GameObject femaleBtn;
    

    //ボタン色変更メソッド用変数
    public Image image;
    private Sprite sprite;


    // Start is called before the first frame update
    void Start()
    {
        //変数を見てボタンの色を変える
        //そのうち処理を入れる

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectGender()
    {
        if (this.name == "maleBtn")
        {
            Debug.Log("maleBtn");
            //男性＝１を代入
            Page20ManagerScript.SetGenderInt(1);


            //色を変える処理
            sprite = Resources.Load<Sprite>("male-on");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
            
            //色を変える処理
            sprite = Resources.Load<Sprite>("female-off");
            image = femaleBtn.GetComponent<Image>();
            image.sprite = sprite;


        }
        else if(this.name =="femaleBtn")
        {
            Debug.Log("femaleBtn");
            //女性＝２を代入
            Page20ManagerScript.SetGenderInt(2);

            //色を変える処理
            sprite = Resources.Load<Sprite>("famale-on");
            image = this.GetComponent<Image>();
            image.sprite = sprite;

            //色を変える処理
            sprite = Resources.Load<Sprite>("male-off");
            image = maleBtn.GetComponent<Image>();
            image.sprite = sprite;

        }

    }


    //コンポーネントから呼び出すとデバッグログを出せる
    public void ChangeToggle()
    {
        /*
        Debug.Log("Toggleが変更されました");
        Debug.Log("toggle.name=" + toggle.name);
        Debug.Log("this.name=" + toggle.name);
        */

        // オブジェクトからTextコンポーネントを取得
        Text gender_text = gender_object.GetComponent<Text>();
//        Text gender_text = gender_object.GetComponent<>();

        /*
        if (toggle.name == "Toggle") gender_text.text = "male";
        else if (toggle.name == "Toggle (1)") gender_text.text = "female";
 */

    }

}
