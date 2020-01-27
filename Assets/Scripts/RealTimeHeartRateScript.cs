using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class RealTimeHeartRateScript : MonoBehaviour
{

    public GameObject heartRateValue1;
    public GameObject heartRateValue2;
    public GameObject heartRateValue3;
    public GameObject heartRateValue4;
    public GameObject heartRateValue5;
    public GameObject heartRateValue6;
    public GameObject heartRateValue7;
    public GameObject heartRateValue8;
    public GameObject heartRateValue9;
    public GameObject heartRateValue10;
    public GameObject heartRateValue11;
    public GameObject heartRateValue12;
    public GameObject heartRateValue13;
    public GameObject heartRateValue14;
    public GameObject heartRateValue15;
    public GameObject heartRateValue16;
    public GameObject heartRateValue17;
    public GameObject heartRateValue18;
    public GameObject heartRateValue19;
    public GameObject heartRateValue20;
    public GameObject heartRateValue21;
    public GameObject heartRateValue22;
    public GameObject heartRateValue23;
    public GameObject heartRateValue24;
    public GameObject heartRateValue25;
    public GameObject heartRateValue26;


    // Start is called before the first frame update
    void Start()
    {
        float iniValue = 5f;
        heartRateValue1.GetComponent<Slider>().value = iniValue;
        heartRateValue2.GetComponent<Slider>().value = iniValue;
        heartRateValue3.GetComponent<Slider>().value = iniValue;
        heartRateValue4.GetComponent<Slider>().value = iniValue;
        heartRateValue5.GetComponent<Slider>().value = iniValue;
        heartRateValue6.GetComponent<Slider>().value = iniValue;
        heartRateValue7.GetComponent<Slider>().value = iniValue;
        heartRateValue8.GetComponent<Slider>().value = iniValue;
        heartRateValue9.GetComponent<Slider>().value = iniValue;
        heartRateValue10.GetComponent<Slider>().value = iniValue;
        heartRateValue11.GetComponent<Slider>().value = iniValue;
        heartRateValue12.GetComponent<Slider>().value = iniValue;
        heartRateValue13.GetComponent<Slider>().value = iniValue;
        heartRateValue14.GetComponent<Slider>().value = iniValue;
        heartRateValue15.GetComponent<Slider>().value = iniValue;
        heartRateValue16.GetComponent<Slider>().value = iniValue;
        heartRateValue17.GetComponent<Slider>().value = iniValue;
        heartRateValue18.GetComponent<Slider>().value = iniValue;
        heartRateValue19.GetComponent<Slider>().value = iniValue;
        heartRateValue20.GetComponent<Slider>().value = iniValue;
        heartRateValue21.GetComponent<Slider>().value = iniValue;
        heartRateValue22.GetComponent<Slider>().value = iniValue;
        heartRateValue23.GetComponent<Slider>().value = iniValue;
        heartRateValue24.GetComponent<Slider>().value = iniValue;
        heartRateValue25.GetComponent<Slider>().value = iniValue;
        heartRateValue26.GetComponent<Slider>().value = iniValue;




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

            float currentheartRateValue = 0f;


            //float cos = Mathf.Cos(Time.time);
            //currentheartRateValue = (cos + 1.0f) * 50;


            if (Hot2gApplication.Instance.datastore.heartRate.Count > 10)
            {
                currentheartRateValue = (float)Hot2gApplication.Instance.datastore.
                    heartRate.GetRange(Hot2gApplication.Instance.datastore.heartRate.Count - 10, 10).Average();
            }

//            Debug.Log("currentheartRateValue" + currentheartRateValue);

            heartRateValue1.GetComponent<Slider>().value = heartRateValue2.GetComponent<Slider>().value;
            heartRateValue2.GetComponent<Slider>().value = heartRateValue3.GetComponent<Slider>().value;
            heartRateValue3.GetComponent<Slider>().value = heartRateValue4.GetComponent<Slider>().value;
            heartRateValue4.GetComponent<Slider>().value = heartRateValue5.GetComponent<Slider>().value;
            heartRateValue5.GetComponent<Slider>().value = heartRateValue6.GetComponent<Slider>().value;
            heartRateValue6.GetComponent<Slider>().value = heartRateValue7.GetComponent<Slider>().value;
            heartRateValue7.GetComponent<Slider>().value = heartRateValue8.GetComponent<Slider>().value;
            heartRateValue8.GetComponent<Slider>().value = heartRateValue9.GetComponent<Slider>().value;
            heartRateValue9.GetComponent<Slider>().value = heartRateValue10.GetComponent<Slider>().value;
            heartRateValue10.GetComponent<Slider>().value = heartRateValue11.GetComponent<Slider>().value;
            heartRateValue11.GetComponent<Slider>().value = heartRateValue12.GetComponent<Slider>().value;
            heartRateValue12.GetComponent<Slider>().value = heartRateValue13.GetComponent<Slider>().value;
            heartRateValue13.GetComponent<Slider>().value = heartRateValue14.GetComponent<Slider>().value;
            heartRateValue14.GetComponent<Slider>().value = heartRateValue15.GetComponent<Slider>().value;
            heartRateValue15.GetComponent<Slider>().value = heartRateValue16.GetComponent<Slider>().value;
            heartRateValue16.GetComponent<Slider>().value = heartRateValue17.GetComponent<Slider>().value;
            heartRateValue17.GetComponent<Slider>().value = heartRateValue18.GetComponent<Slider>().value;
            heartRateValue18.GetComponent<Slider>().value = heartRateValue19.GetComponent<Slider>().value;
            heartRateValue19.GetComponent<Slider>().value = heartRateValue20.GetComponent<Slider>().value;
            heartRateValue20.GetComponent<Slider>().value = heartRateValue21.GetComponent<Slider>().value;
            heartRateValue21.GetComponent<Slider>().value = heartRateValue22.GetComponent<Slider>().value;
            heartRateValue22.GetComponent<Slider>().value = heartRateValue23.GetComponent<Slider>().value;
            heartRateValue23.GetComponent<Slider>().value = heartRateValue24.GetComponent<Slider>().value;
            heartRateValue24.GetComponent<Slider>().value = heartRateValue25.GetComponent<Slider>().value;
            heartRateValue25.GetComponent<Slider>().value = heartRateValue26.GetComponent<Slider>().value;
            heartRateValue26.GetComponent<Slider>().value = currentheartRateValue;


                timer = 0;

            }




        }
    }
