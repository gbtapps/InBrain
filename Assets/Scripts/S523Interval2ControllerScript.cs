using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S523Interval2ControllerScript : MonoBehaviour
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
                MoveToS524Test2();
            }

            //1秒たったのでカウントをダウンする
            CountdownInt--;

        }

    }


    public void MoveToS524Test2()
    {
        SceneManager.LoadScene("S524Test2");
    }



}
