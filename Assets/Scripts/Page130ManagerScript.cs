using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class Page130ManagerScript : MonoBehaviour
{

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
