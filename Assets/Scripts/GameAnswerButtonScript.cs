using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

        while (Answer > 9 || Answer < 1)
        {
            FirstMember = Random.Range(0, 10);
            SecondMember = Random.Range(0, 10);

            if(Random.Range(0,1) == 0)
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
    }

    void CheckCorrectAnswer()
    {
    }


    public void AnswerOnClickButton()
    {
        string BtnName = AnswerByButton.currentSelectedGameObject.gameObject.name;

        //回答桁数


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
            /*
                        string FormulaString = FormulaText.text.ToString();
                        string AnswerString = AnswerText.text.ToString();
                        Debug.Log("FormulaString: "+FormulaString);
                        Debug.Log("AnswerString: " + AnswerString);
                        */
            //            if (FormulaString == AnswerString)



            if (Answer.ToString() == AnswerText.text)
            {

                //○を表示
                CorrectAnswerMark.SetActive(true);

                //0.2秒たったら○を消して次の問題を生成

                //次の設問を生成
                MakeOneDigitNumericalQuestion();


                //○を消す
//                CorrectAnswerMark.SetActive(false);
            }
            else
            {
                //×を表示
                WrongAnswerMark.SetActive(true);


                //解答欄をクリア
//                AnswerText.text = "";
                //×を消す
//                WrongAnswerMark.SetActive(false);


            }
        }



    }






}
