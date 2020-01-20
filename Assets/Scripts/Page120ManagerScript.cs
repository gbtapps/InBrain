using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class Page120ManagerScript : MonoBehaviour
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


    public GameObject explanationPanelPage120;

    public GameObject textScoreSpeed;
    public GameObject textAgeSpeed;

    Text Score;
    Text Age;

    int scoreSpeed = Page110ManagerScript.scoreSpeed;
    int ageSpeed = Page110ManagerScript.ageSpeed;
//    string classSpeed = Page110ManagerScript.classSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("=====   page120 start() start   =====================");

        //左グラフ各カラムの値をセット
        leftColumn1.GetComponent<Slider>().value = 30.0f;
        leftColumn2.GetComponent<Slider>().value = 40.0f;
        leftColumn3.GetComponent<Slider>().value = 50.0f;
        leftColumn4.GetComponent<Slider>().value = 60.0f;
        leftColumn5.GetComponent<Slider>().value = 70.0f;
        leftColumn6.GetComponent<Slider>().value = 60.0f;
        leftColumn7.GetComponent<Slider>().value = 50.0f;
        leftColumn8.GetComponent<Slider>().value = 40.0f;
        leftColumn9.GetComponent<Slider>().value = 30.0f;
        leftColumn10.GetComponent<Slider>().value = 20.0f;


        //右グラフ各カラムの値をセット
        rightColumn1.GetComponent<Slider>().value = 90.0f;
        rightColumn2.GetComponent<Slider>().value = 80.0f;
        rightColumn3.GetComponent<Slider>().value = 70.0f;
        rightColumn4.GetComponent<Slider>().value = 60.0f;
        rightColumn5.GetComponent<Slider>().value = 50.0f;
        rightColumn6.GetComponent<Slider>().value = 40.0f;
        rightColumn7.GetComponent<Slider>().value = 30.0f;
        rightColumn8.GetComponent<Slider>().value = 20.0f;
        rightColumn9.GetComponent<Slider>().value = 10.0f;
        rightColumn10.GetComponent<Slider>().value = 10.0f;

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






        //===========  テキストエリア表示　============//

        //入力した年齢を取得
        int getInputAge = InputManagerScript.GetInputAge();
        string currentAge = "（" + getInputAge.ToString() + "歳）";

        Score = textScoreSpeed.GetComponent<Text>();
        Age = textAgeSpeed.GetComponent<Text>();

        Score.text = scoreSpeed.ToString() + "点";
        Age.text = ageSpeed.ToString() + "歳";

        
        //現在年齢を付加
        Age.text = Age.text + currentAge;

        





    }




    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("130.詳細2－注意力");
    }

    public void ChangeBackScene()
    {
        SceneManager.LoadScene("110.検査結果");
    }


    public void OpenExplanationPanel()
    {
        explanationPanelPage120.SetActive(true);
        //        Debug.Log("setActive(true)");
    }

    public void CloseExplanationPanel()
    {
        explanationPanelPage120.SetActive(false);
        //        Debug.Log("setActive(false)");
    }



}
