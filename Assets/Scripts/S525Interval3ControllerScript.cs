using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S525Interval3ControllerScript : MonoBehaviour
{

    public float DeltaTimeCount = 0f;
    public Text CountdownText;
    public int CountdownInt;


    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        ////////////////////////////
        //1秒毎に処理させるここから
        //
        DeltaTimeCount += Time.deltaTime;

        if (DeltaTimeCount >= 1.0f)
        {

            DeltaTimeCount = 0.0f;


            if (CountdownInt > 0)
            {
                //カウントダウン表示
                CountdownText.text = CountdownInt.ToString();

            }
            else
            {
                MoveToS526TestResultSummary();
            }

            //1秒たったのでカウントをダウンする
            CountdownInt--;

        }
        //
        //1秒毎に処理させるここまで
        ///////////////////////////////////

    }


    public void MoveToS526TestResultSummary()
    {
        SceneManager.LoadScene("S526TestResultSummary");
    }

    


}
