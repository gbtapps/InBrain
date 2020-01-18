using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarChartControllerScript : MonoBehaviour
{

    public GameObject column1;
    public GameObject column2;
    public GameObject column3;
    public GameObject column4;
    public GameObject column5;
    public GameObject column6;
    public GameObject column7;
    public GameObject column8;
    public GameObject column9;
    public GameObject column10;


    // Start is called before the first frame update
    void Start()
    {
        column1.GetComponent<Slider>().value = 0;
        column2.GetComponent<Slider>().value = 0;
        column3.GetComponent<Slider>().value = 0;
        column4.GetComponent<Slider>().value = 0;
        column5.GetComponent<Slider>().value = 0;
        column6.GetComponent<Slider>().value = 0;
        column7.GetComponent<Slider>().value = 0;
        column8.GetComponent<Slider>().value = 0;
        column9.GetComponent<Slider>().value = 0;
        column10.GetComponent<Slider>().value = 0;


        for (int i = 1; i < 91; i++) column1.GetComponent<Slider>().value = i;
        for (int i = 1; i < 81; i++) column2.GetComponent<Slider>().value = i;
        for (int i = 1; i < 71; i++) column3.GetComponent<Slider>().value = i;
        for (int i = 1; i < 61; i++) column4.GetComponent<Slider>().value = i;
        for (int i = 1; i < 51; i++) column5.GetComponent<Slider>().value = i;
        for (int i = 1; i < 41; i++) column6.GetComponent<Slider>().value = i;
        for (int i = 1; i < 31; i++) column7.GetComponent<Slider>().value = i;
        for (int i = 1; i < 21; i++) column8.GetComponent<Slider>().value = i;
        for (int i = 1; i < 11; i++) column9.GetComponent<Slider>().value = i;
        for (int i = 1; i < 11; i++) column10.GetComponent<Slider>().value = i;




    }

    // Update is called once per frame
    void Update()
    {

    }
}
