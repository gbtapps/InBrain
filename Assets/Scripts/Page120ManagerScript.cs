using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class Page120ManagerScript : MonoBehaviour
{

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
