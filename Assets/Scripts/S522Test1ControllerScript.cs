using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S522Test1ControllerScript : MonoBehaviour
{

    /*
    public float DeltaTimeCount = 0f;
    [SerializeField] int CountdownInt;
    [SerializeField] string ActiveSceneName;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NeuroExecTest:Start()");
        ActiveSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(ActiveSceneName+ " :ActiveSceneName");

    }



    // Update is called once per frame
    void Update()
    {

//        Debug.Log("NeuroExecTest:Update()");
        //        Debug.Log(ActiveSceneName+" Update()");
        //        Debug.Log(CountdownInt + " =CountDownInt");


        ////////////////////////////
        //1秒毎に処理させるここから
        //
        DeltaTimeCount += Time.deltaTime;
//        Debug.Log(DeltaTimeCount + " =DeltaTimeCount");

        if (DeltaTimeCount >= 1.0f)
        {

            DeltaTimeCount = 0.0f;

            //1秒たったのでカウントをダウンする
            CountdownInt--;

            if (CountdownInt == 0)
            {

                Debug.Log(CountdownInt + " :CountdownInt");


                if (ActiveSceneName == "Tr_TrainingNeuro")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting2nd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuro2nd")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting3rd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuroTest")
                {
                    Debug.Log("SceneManager.LoadScene>T_TitleSelect");
                    SceneManager.LoadScene("T_TitleSelect");

                }
                else
                {
                    SceneManager.LoadScene("T_TitleSelect");

                }



            }


        }
        //
        //1秒毎に処理させるここまで
        ///////////////////////////////////

    }


    public void MoveToS523Interval2()
    {
        SceneManager.LoadScene("S523Interval2");
    }
    */



}
