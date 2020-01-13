using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Page140ManagerScript : MonoBehaviour
{

    public GameObject explanationPanelPage140;

    public GameObject textScoreBrain;
    public GameObject textAgeBrain;

    Text Score;
    Text Age;

    int scoreBrain = Page110ManagerScript.scoreBrain;
    int ageBrain = Page110ManagerScript.ageBrain;
//    string classBrain = Page110ManagerScript.classBrain;


    // Start is called before the first frame update
    void Start()
    {

        //入力した年齢を取得
        int getInputAge = InputManagerScript.GetInputAge();
        string currentAge = "（" + getInputAge.ToString() + "歳）";

        Score = textScoreBrain.GetComponent<Text>();
        Age = textAgeBrain.GetComponent<Text>();

        Score.text = scoreBrain.ToString() + "点";
        Age.text = ageBrain.ToString() + "歳";


        //現在年齢を付加
        Age.text = Age.text + currentAge;


    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("150.対策案");
    }

    public void ChangeBackScene()
    {
        SceneManager.LoadScene("130.詳細2－注意力");
    }


    public void OpenExplanationPanel()
    {
        explanationPanelPage140.SetActive(true);
        //        Debug.Log("setActive(true)");
    }

    public void CloseExplanationPanel()
    {
        explanationPanelPage140.SetActive(false);
        //        Debug.Log("setActive(false)");
    }



}
