using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class GameAnswerButtonScript : MonoBehaviour
{


    /*
    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;
    public GameObject Btn4;
    public GameObject Btn5;
    public GameObject Btn6;
    public GameObject Btn7;
    public GameObject Btn8;
    public GameObject Btn9;
    public GameObject Btn0;
    public GameObject BtnDlt;
    public GameObject BtnOk;
    */

    //回答
    public Text AnswerText;

    //数式
    public Text FormulaText;

    public int Answerdigit = 1;

    //タッチしたボタンの名称をイベントシステムで取得
    [SerializeField] EventSystem AnswerByButton;

    //設問
    int FirstMember = 0;
    int SecondMember = 0;
    int Answer = 10;

    //正誤エフェクト○×
    public GameObject CorrectAnswerMark;
    public GameObject WrongAnswerMark;
    private float Count;



    // Start is called before the first frame update
    void Start()
    {
        //Textオブジェクトテスト＠Stringのように扱えるか→以下はOK
        //AnswerText.text = "test";
        //AnswerText.text += "1";
        //Debug.Log(AnswerText.text);


        //回答結果パネルの初期化
        AnswerText.text = null;

        //最初の設問提示
        MakeOneDigitNumericalQuestion();

    }

    // 答えが一桁になる設問提示
    void MakeOneDigitNumericalQuestion()
    {


        Answerdigit = 1;


        //10以下＝1桁に答えを調整
        Answer = 10;

        while (Answer > 9 || Answer < 0 )
        {
            FirstMember = UnityEngine.Random.Range(0, 10);
            SecondMember = UnityEngine.Random.Range(0, 10);

            if(UnityEngine.Random.Range(0,1) == 0)
            {
                //引算
                FormulaText.text = FirstMember + " - " + SecondMember + " = □";                
                Answer = FirstMember - SecondMember;
            }
            else
            {
                //足し算
                FormulaText.text = FirstMember + " + " + SecondMember + " = □";
                Answer = FirstMember + SecondMember;
            }

        }



        Debug.Log("FirstMember: " + FirstMember);
        Debug.Log("SecondMember: " + SecondMember);
        Debug.Log("FormulaText.text: " + FormulaText.text);
        Debug.Log("Answer: " + Answer);



    }



    // Update is called once per frame
    void Update()
    {

        if (CorrectAnswerMark.activeSelf || WrongAnswerMark.activeSelf)
        {
            //○秒でマークの色と回答文字を消し新しい設問

            Count += Time.deltaTime;
            if (Count >= 0.5f)
            {
                Count = 0.0f;
                CorrectAnswerMark.SetActive(false);
                WrongAnswerMark.SetActive(false);
                AnswerText.text = "";
                MakeOneDigitNumericalQuestion();
            }



        }


    }

    void CheckCorrectAnswer()
    {
    }


    public void AnswerOnClickButton()
    {
        string BtnName = AnswerByButton.currentSelectedGameObject.gameObject.name;


        //解答欄クリア
        AnswerText.text = null;
        CorrectAnswerMark.SetActive(false);
        WrongAnswerMark.SetActive(false);

        //ボタン押下
        if (BtnName == "Btn1") AnswerText.text += "1";
        else if (BtnName == "Btn2") AnswerText.text += "2";
        else if (BtnName == "Btn3") AnswerText.text += "3";
        else if (BtnName == "Btn4") AnswerText.text += "4";
        else if (BtnName == "Btn5") AnswerText.text += "5";
        else if (BtnName == "Btn6") AnswerText.text += "6";
        else if (BtnName == "Btn7") AnswerText.text += "7";
        else if (BtnName == "Btn8") AnswerText.text += "8";
        else if (BtnName == "Btn9") AnswerText.text += "9";
        else if (BtnName == "Btn0") AnswerText.text += "0";
        if (BtnName == "BtnDlt") AnswerText.text = "";

        Debug.Log("AnswerText.text: " + AnswerText.text);

//        Debug.Log("Answerdigit: "+Answerdigit);
//        Debug.Log("(AnswerText.text).Length: " + (AnswerText.text).Length);

  
        if (Answerdigit == (AnswerText.text).Length)
        {

            if (Answer.ToString() == AnswerText.text)
            {
                //○を表示
                CorrectAnswerMark.SetActive(true);

            }
            else
            {
                //×を表示
                WrongAnswerMark.SetActive(true);

            }
        }



    }






}
