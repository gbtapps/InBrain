using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainExChangePanelManagerScript : MonoBehaviour
{


    [SerializeField] GameObject Btn1;
    [SerializeField] GameObject Btn2;
    [SerializeField] GameObject Btn3;
    [SerializeField] GameObject Btn4;
    [SerializeField] GameObject Btn5;
    [SerializeField] GameObject Btn6;
    [SerializeField] GameObject Btn7;
    [SerializeField] GameObject Btn8;
    [SerializeField] GameObject Btn9;
    [SerializeField] GameObject Btn0;

    //Button作成エリア
    [SerializeField] GameObject drawArea;


    float[,] BtnPos = new float[10,3]
        {
            { -80f, 107f, 0f }, //1st row 1st colomn //00,01,02
            {   0f, 107f, 0f }, //1st row 2nd colomn //10,11,12
            {  80f, 107f, 0f }, //1st row 3rd colomn 

            { -80f,  44f, 0f }, //2nd row 1st colomn 
            {   0f,  44f, 0f }, //2nd row 2nd colomn 
            {  80f,  44f, 0f }, //2nd row 3rd colomn 

            { -80f, -19f, 0f }, //3rd row 1st colomn 
            {   0f, -19f, 0f }, //3rd row 2nd colomn 
            {  80f, -19f, 0f }, //3rd row 3rd colomn 

            {   0f, -82f, 0f }  //4th row 2nd colomn 
        };
 

    public void ChangeBtnPositionFunc()
    {
        // This calls when answering in spite of correct or not 
        // if change panel flg on.

        // The order is made by Fisher-Yates algorism with an array.

        //シャッフルする配列
        GameObject[] ary = new GameObject[] { Btn1,Btn2, Btn3, Btn4, Btn5, Btn6, Btn7, Btn8, Btn9, Btn0 };

        //Fisher-Yatesアルゴリズムでシャッフルする
        System.Random rng = new System.Random();
        int n = ary.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject tmp = ary[k];
            ary[k] = ary[n];
            ary[n] = tmp;
        }

        /*
        foreach(object obj in ary)
        {
            Debug.Log(obj); 
        }
        */
        /*
        foreach (object obj in BtnPos)
        {
            Debug.Log(obj);
        }
        */

        RectTransform[] btnposition = new RectTransform[10];
        for(int i=0; i < 10; i++)
        {
            btnposition[i] = ary[i].GetComponent<RectTransform>();
            btnposition[i].localPosition = new Vector3(BtnPos[i, 0], BtnPos[i, 1], BtnPos[i, 2]);
        }

        /*
        // Object position can be changed by RectTransform.localPositon
        // 
        RectTransform btnpos1;
        btnpos1 = ary[0].GetComponent<RectTransform>();
        btnpos1.localPosition = new Vector3( BtnPos[0,0], BtnPos[0,1], BtnPos[0,2]);

        RectTransform btnpos2;
        btnpos2 = ary[1].GetComponent<RectTransform>();
        btnpos2.localPosition = new Vector3(BtnPos[1, 0], BtnPos[1, 1], BtnPos[1, 2]);

        RectTransform btnpos3;
        btnpos3 = ary[2].GetComponent<RectTransform>();
        btnpos3.localPosition = new Vector3(BtnPos[2, 0], BtnPos[2, 1], BtnPos[2, 2]);
        */        


    }


    // Start is called before the first frame update
    void Start()
    {
        //For debug.
        ChangeBtnPositionFunc();

    }

    // Update is called once per frame
    void Update()   
    {
        //For debug.

    }

}
