using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S521Interval1ControllerScript : MonoBehaviour
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
                MoveToS522Test1();
            }

            //1秒たったのでカウントをダウンする
            CountdownInt--;

        }

    }


    public void MoveToS522Test1()
    {
        SceneManager.LoadScene("S522Test1");
    }



}
