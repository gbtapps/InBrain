using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class Page130ManagerScript : MonoBehaviour
{

    //左グラフのカラム
    public GameObject leftColumn1;
    public GameObject leftColumn2;
    public GameObject leftColumn3;
    public GameObject leftColumn4;
    public GameObject leftColumn5;
    public GameObject leftColumn6;
    public GameObject leftColumn7;
    public GameObject leftColumn8;
    public GameObject leftColumn9;
    public GameObject leftColumn10;

    //右グラフのカラム
    public GameObject rightColumn1;
    public GameObject rightColumn2;
    public GameObject rightColumn3;
    public GameObject rightColumn4;
    public GameObject rightColumn5;
    public GameObject rightColumn6;
    public GameObject rightColumn7;
    public GameObject rightColumn8;
    public GameObject rightColumn9;
    public GameObject rightColumn10;


    //アニメーション用変数初期化
    float leftColumn1Value = 0f;
    float leftColumn2Value = 0f;
    float leftColumn3Value = 0f;
    float leftColumn4Value = 0f;
    float leftColumn5Value = 0f;
    float leftColumn6Value = 0f;
    float leftColumn7Value = 0f;
    float leftColumn8Value = 0f;
    float leftColumn9Value = 0f;
    float leftColumn10Value = 0f;
    float rightColumn1Value = 0f;
    float rightColumn2Value = 0f;
    float rightColumn3Value = 0f;
    float rightColumn4Value = 0f;
    float rightColumn5Value = 0f;
    float rightColumn6Value = 0f;
    float rightColumn7Value = 0f;
    float rightColumn8Value = 0f;
    float rightColumn9Value = 0f;
    float rightColumn10Value = 0f;

    //アニメーション速度変数
    float spanTime = 2.0f;

    //アニメーション用テンポラリ変数
    float rcol1temp = 0f;
    float rcol2temp = 0f;
    float rcol3temp = 0f;
    float rcol4temp = 0f;
    float rcol5temp = 0f;
    float rcol6temp = 0f;
    float rcol7temp = 0f;
    float rcol8temp = 0f;
    float rcol9temp = 0f;
    float rcol10temp = 0f;
    float lcol1temp = 0f;
    float lcol2temp = 0f;
    float lcol3temp = 0f;
    float lcol4temp = 0f;
    float lcol5temp = 0f;
    float lcol6temp = 0f;
    float lcol7temp = 0f;
    float lcol8temp = 0f;
    float lcol9temp = 0f;
    float lcol10temp = 0f;






    public GameObject explanationPanelPage130;

    public GameObject textScoreAttention;
    public GameObject textAgeAttention;

    Text Score;
    Text Age;

    int scoreAttention = Page110ManagerScript.scoreAttention;
    int ageAttention = Page110ManagerScript.ageAttention;
//    string classAttention = Page110ManagerScript.classAttention;


    // Start is called before the first frame update
    void Start()
    {


        //左グラフ各カラムにセットしたい値を格納する変数
        leftColumn1Value = 30.0f;
        leftColumn2Value = 40.0f;
        leftColumn3Value = 50.0f;
        leftColumn4Value = 60.0f;
        leftColumn5Value = 70.0f;
        leftColumn6Value = 60.0f;
        leftColumn7Value = 50.0f;
        leftColumn8Value = 40.0f;
        leftColumn9Value = 30.0f;
        leftColumn10Value = 20.0f;

        //右グラフ各カラムにセットしたい値を格納する変数
        rightColumn1Value = 90.0f;
        rightColumn2Value = 80.0f;
        rightColumn3Value = 70.0f;
        rightColumn4Value = 60.0f;
        rightColumn5Value = 50.0f;
        rightColumn6Value = 40.0f;
        rightColumn7Value = 30.0f;
        rightColumn8Value = 20.0f;
        rightColumn9Value = 10.0f;
        rightColumn10Value = 5.0f;






        //===== 右バーチャートにおける対象のスライダーの色を変える =====//

        //対象となる適切なスライダーをセット
        GameObject targetRightColumn = rightColumn4;


        //スライダーの対象要素を検索し色を変えるロジック
        Slider targetRightslider = targetRightColumn.GetComponent<Slider>();
        foreach (Transform childTransform in targetRightslider.gameObject.transform)
        {
            foreach (Transform grandChildTransform in childTransform)
            {
                if (grandChildTransform.gameObject.name == "Fill")
                {
                    grandChildTransform.gameObject.GetComponent<Image>().color = Color.yellow;
                }
            }
        }

        //===== 左バーチャートにおける対象のスライダーの色を変える =====//

        //対象となる適切なスライダーをセット
        GameObject targetLeftColumn = leftColumn4;


        //スライダーの対象要素を検索し色を変えるロジック
        Slider targetLeftslider = targetLeftColumn.GetComponent<Slider>();
        foreach (Transform childTransform in targetLeftslider.gameObject.transform)
        {
            foreach (Transform grandChildTransform in childTransform)
            {
                if (grandChildTransform.gameObject.name == "Fill")
                {
                    grandChildTransform.gameObject.GetComponent<Image>().color = Color.yellow;
                }
            }
        }




        //入力した年齢を取得
        int getInputAge = InputManagerScript.GetInputAge();
        string currentAge = "（" + getInputAge.ToString() + "歳）";

        Score = textScoreAttention.GetComponent<Text>();
        Age = textAgeAttention.GetComponent<Text>();

        Score.text = scoreAttention.ToString() + "点";
        Age.text = ageAttention.ToString() + "歳";


        //現在年齢を付加
        Age.text = Age.text + currentAge;




    }



    // Update is called once per frame
    void Update()
    {

        if (rcol1temp <= rightColumn1Value)
        {
            rcol1temp += spanTime;
            rightColumn1.GetComponent<Slider>().value = rcol1temp;
        }

        if (rcol2temp <= rightColumn2Value)
        {
            rcol2temp += spanTime;
            rightColumn2.GetComponent<Slider>().value = rcol2temp;
        }

        if (rcol3temp <= rightColumn3Value)
        {
            rcol3temp += spanTime;
            rightColumn3.GetComponent<Slider>().value = rcol3temp;
        }

        if (rcol4temp <= rightColumn4Value)
        {
            rcol4temp += spanTime;
            rightColumn4.GetComponent<Slider>().value = rcol4temp;
        }

        if (rcol5temp <= rightColumn5Value)
        {
            rcol5temp += spanTime;
            rightColumn5.GetComponent<Slider>().value = rcol5temp;
        }

        if (rcol6temp <= rightColumn6Value)
        {
            rcol6temp += spanTime;
            rightColumn6.GetComponent<Slider>().value = rcol6temp;
        }

        if (rcol7temp <= rightColumn7Value)
        {
            rcol7temp += spanTime;
            rightColumn7.GetComponent<Slider>().value = rcol7temp;
        }

        if (rcol8temp <= rightColumn8Value)
        {
            rcol8temp += spanTime;
            rightColumn8.GetComponent<Slider>().value = rcol8temp;
        }

        if (rcol9temp <= rightColumn9Value)
        {
            rcol9temp += spanTime;
            rightColumn9.GetComponent<Slider>().value = rcol9temp;
        }

        if (rcol10temp <= rightColumn10Value)
        {
            rcol10temp += spanTime;
            rightColumn10.GetComponent<Slider>().value = rcol10temp;
        }

        if (lcol1temp <= leftColumn1Value)
        {
            lcol1temp += spanTime;
            leftColumn1.GetComponent<Slider>().value = lcol1temp;
        }

        if (lcol2temp <= leftColumn2Value)
        {
            lcol2temp += spanTime;
            leftColumn2.GetComponent<Slider>().value = lcol2temp;
        }

        if (lcol3temp <= leftColumn3Value)
        {
            lcol3temp += spanTime;
            leftColumn3.GetComponent<Slider>().value = lcol3temp;
        }

        if (lcol4temp <= leftColumn4Value)
        {
            lcol4temp += spanTime;
            leftColumn4.GetComponent<Slider>().value = lcol4temp;
        }

        if (lcol5temp <= leftColumn5Value)
        {
            lcol5temp += spanTime;
            leftColumn5.GetComponent<Slider>().value = lcol5temp;
        }

        if (lcol6temp <= leftColumn6Value)
        {
            lcol6temp += spanTime;
            leftColumn6.GetComponent<Slider>().value = lcol6temp;
        }

        if (lcol7temp <= leftColumn7Value)
        {
            lcol7temp += spanTime;
            leftColumn7.GetComponent<Slider>().value = lcol7temp;
        }

        if (lcol8temp <= leftColumn8Value)
        {
            lcol8temp += spanTime;
            leftColumn8.GetComponent<Slider>().value = lcol8temp;
        }

        if (lcol9temp <= leftColumn9Value)
        {
            lcol9temp += spanTime;
            leftColumn9.GetComponent<Slider>().value = lcol9temp;
        }

        if (lcol10temp <= leftColumn10Value)
        {
            lcol10temp += spanTime;
            leftColumn10.GetComponent<Slider>().value = lcol10temp;
        }



    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("140.詳細3－脳活動");
    }

    public void ChangeBackScene()
    {
        SceneManager.LoadScene("120.詳細1－認知速度");
    }


    public void OpenExplanationPanel()
    {
        explanationPanelPage130.SetActive(true);
        //        Debug.Log("setActive(true)");
    }

    public void CloseExplanationPanel()
    {
        explanationPanelPage130.SetActive(false);
        //        Debug.Log("setActive(false)");
    }



}
