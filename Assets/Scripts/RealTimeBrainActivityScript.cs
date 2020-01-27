using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class RealTimeBrainActivityScript : MonoBehaviour
{

    public GameObject brainActivityValue1;
    public GameObject brainActivityValue2;
    public GameObject brainActivityValue3;
    public GameObject brainActivityValue4;
    public GameObject brainActivityValue5;
    public GameObject brainActivityValue6;
    public GameObject brainActivityValue7;
    public GameObject brainActivityValue8;
    public GameObject brainActivityValue9;
    public GameObject brainActivityValue10;
    public GameObject brainActivityValue11;
    public GameObject brainActivityValue12;
    public GameObject brainActivityValue13;
    public GameObject brainActivityValue14;
    public GameObject brainActivityValue15;
    public GameObject brainActivityValue16;
    public GameObject brainActivityValue17;
    public GameObject brainActivityValue18;
    public GameObject brainActivityValue19;
    public GameObject brainActivityValue20;
    public GameObject brainActivityValue21;
    public GameObject brainActivityValue22;
    public GameObject brainActivityValue23;
    public GameObject brainActivityValue24;
    public GameObject brainActivityValue25;
    public GameObject brainActivityValue26;


    // Start is called before the first frame update
    void Start()
    {
        float iniValue = 5f;
        brainActivityValue1.GetComponent<Slider>().value = iniValue;
        brainActivityValue2.GetComponent<Slider>().value = iniValue;
        brainActivityValue3.GetComponent<Slider>().value = iniValue;
        brainActivityValue4.GetComponent<Slider>().value = iniValue;
        brainActivityValue5.GetComponent<Slider>().value = iniValue;
        brainActivityValue6.GetComponent<Slider>().value = iniValue;
        brainActivityValue7.GetComponent<Slider>().value = iniValue;
        brainActivityValue8.GetComponent<Slider>().value = iniValue;
        brainActivityValue9.GetComponent<Slider>().value = iniValue;
        brainActivityValue10.GetComponent<Slider>().value = iniValue;
        brainActivityValue11.GetComponent<Slider>().value = iniValue;
        brainActivityValue12.GetComponent<Slider>().value = iniValue;
        brainActivityValue13.GetComponent<Slider>().value = iniValue;
        brainActivityValue14.GetComponent<Slider>().value = iniValue;
        brainActivityValue15.GetComponent<Slider>().value = iniValue;
        brainActivityValue16.GetComponent<Slider>().value = iniValue;
        brainActivityValue17.GetComponent<Slider>().value = iniValue;
        brainActivityValue18.GetComponent<Slider>().value = iniValue;
        brainActivityValue19.GetComponent<Slider>().value = iniValue;
        brainActivityValue20.GetComponent<Slider>().value = iniValue;
        brainActivityValue21.GetComponent<Slider>().value = iniValue;
        brainActivityValue22.GetComponent<Slider>().value = iniValue;
        brainActivityValue23.GetComponent<Slider>().value = iniValue;
        brainActivityValue24.GetComponent<Slider>().value = iniValue;
        brainActivityValue25.GetComponent<Slider>().value = iniValue;
        brainActivityValue26.GetComponent<Slider>().value = iniValue;




    }


    int timer;


    // Update is called once per frame
    void Update()
    {

        timer++;

        //60フレーム毎に動く処理
        //Updateのたびに変数を加算して変数が○のときに処理を実行する。
        //その際は変数をゼロにする。


        if (timer > 60)
        {

//            Debug.Log("time:" + DateTime.Now);

            //この値を更新すればグラフが約1秒ごとに書き換わる
            float currentBrainActivityValue = 0f;


            //float sin = Mathf.Sin(Time.time);
            //currentBrainActivityValue = (sin + 1.0f) * 50;


            if (Hot2gApplication.Instance.datastore.left.Count > 10)
            {
                currentBrainActivityValue = 
                    (float)Hot2gApplication.Instance.datastore.left.GetRange(Hot2gApplication.Instance.datastore.left.Count,10).Average();
            }
            

//            Debug.Log("currentBrainActivityValue" + currentBrainActivityValue);

            brainActivityValue1.GetComponent<Slider>().value = brainActivityValue2.GetComponent<Slider>().value;
            brainActivityValue2.GetComponent<Slider>().value = brainActivityValue3.GetComponent<Slider>().value;
            brainActivityValue3.GetComponent<Slider>().value = brainActivityValue4.GetComponent<Slider>().value;
            brainActivityValue4.GetComponent<Slider>().value = brainActivityValue5.GetComponent<Slider>().value;
            brainActivityValue5.GetComponent<Slider>().value = brainActivityValue6.GetComponent<Slider>().value;
            brainActivityValue6.GetComponent<Slider>().value = brainActivityValue7.GetComponent<Slider>().value;
            brainActivityValue7.GetComponent<Slider>().value = brainActivityValue8.GetComponent<Slider>().value;
            brainActivityValue8.GetComponent<Slider>().value = brainActivityValue9.GetComponent<Slider>().value;
            brainActivityValue9.GetComponent<Slider>().value = brainActivityValue10.GetComponent<Slider>().value;
            brainActivityValue10.GetComponent<Slider>().value = brainActivityValue11.GetComponent<Slider>().value;
            brainActivityValue11.GetComponent<Slider>().value = brainActivityValue12.GetComponent<Slider>().value;
            brainActivityValue12.GetComponent<Slider>().value = brainActivityValue13.GetComponent<Slider>().value;
            brainActivityValue13.GetComponent<Slider>().value = brainActivityValue14.GetComponent<Slider>().value;
            brainActivityValue14.GetComponent<Slider>().value = brainActivityValue15.GetComponent<Slider>().value;
            brainActivityValue15.GetComponent<Slider>().value = brainActivityValue16.GetComponent<Slider>().value;
            brainActivityValue16.GetComponent<Slider>().value = brainActivityValue17.GetComponent<Slider>().value;
            brainActivityValue17.GetComponent<Slider>().value = brainActivityValue18.GetComponent<Slider>().value;
            brainActivityValue18.GetComponent<Slider>().value = brainActivityValue19.GetComponent<Slider>().value;
            brainActivityValue19.GetComponent<Slider>().value = brainActivityValue20.GetComponent<Slider>().value;
            brainActivityValue20.GetComponent<Slider>().value = brainActivityValue21.GetComponent<Slider>().value;
            brainActivityValue21.GetComponent<Slider>().value = brainActivityValue22.GetComponent<Slider>().value;
            brainActivityValue22.GetComponent<Slider>().value = brainActivityValue23.GetComponent<Slider>().value;
            brainActivityValue23.GetComponent<Slider>().value = brainActivityValue24.GetComponent<Slider>().value;
            brainActivityValue24.GetComponent<Slider>().value = brainActivityValue25.GetComponent<Slider>().value;
            brainActivityValue25.GetComponent<Slider>().value = brainActivityValue26.GetComponent<Slider>().value;
            brainActivityValue26.GetComponent<Slider>().value = currentBrainActivityValue;


                timer = 0;

            }




        }
    }
