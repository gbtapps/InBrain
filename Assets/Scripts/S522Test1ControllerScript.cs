﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S522Test1ControllerScript : MonoBehaviour
{

    public float DeltaTimeCount = 0f;
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

            //1秒たったのでカウントをダウンする
            CountdownInt--;

            if (CountdownInt == 0)
            {
                MoveToS523Interval2();
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





}
