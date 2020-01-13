using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加


public class InputManagerScript : MonoBehaviour
{


    public GameObject input_object = null; // Textオブジェクト

    public static int age_num = 0;
    public string num_button;

    public static int GetInputAge()
    {
        return age_num;
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }



    public void OnClick()
    {

        // オブジェクトからTextコンポーネントを取得
        Text age_text = input_object.GetComponent<Text>();


        if (this.name == "Btn1") num_button = "1";
        else if (this.name == "Btn2") num_button = "2";
        else if (this.name == "Btn3") num_button = "3";
        else if (this.name == "Btn4") num_button = "4";
        else if (this.name == "Btn5") num_button = "5";
        else if (this.name == "Btn6") num_button = "6";
        else if (this.name == "Btn7") num_button = "7";
        else if (this.name == "Btn8") num_button = "8";
        else if (this.name == "Btn9") num_button = "9";
        else if (this.name == "Btn0")
        {
            //一桁目に0を入れない処理
            if (age_text.text.Length == 0) { return; }
            //一桁目以外は0を入れる
            num_button = "0";
        }
        //消ボタンは入力値すべて消す
        else if (this.name == "BtnDlt")
        {
            age_text.text = "";
            return;
        }

        //二桁を入力済みの場合はこの関数をキャンセル
        if (age_text.text.Length == 2) { return; }

        age_text.text = age_text.text + num_button;

        age_num = int.Parse(age_text.text);

    }




}
