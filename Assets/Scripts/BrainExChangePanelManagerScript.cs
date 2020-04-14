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

    //複製したButton
    private GameObject Button;


    float position1x = -80f;
    float position1y = 107f;

    /*
1btn -80 107
2btn 0 107
3btn 80 107
4btn -80 44
5btn 0 44
6btn 80 44
7btn -80 19
8btn 0 19
9btn 80 19
0btn 0 -82
*/

    int[] BtnOrder = new int[10];
    bool duplicated = false;


    void ChangeBtnPositionFunc()
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

        foreach(object obj in ary)
        {
            Debug.Log(obj); 
        }


        /*
        Transform myTransform = ary[0].transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x = -80f;    // x座標へ0.01加算
        pos.y = 107f;    // y座標へ0.01加算
        pos.z = 0f;    // z座標へ0.01加算
        myTransform.position = pos;
        */


//        ary[0].transform.position = new Vector3(0.0f, 0f, 0f);

//        ary[0].transform.Translate(new Vector2(0f, 0f));
//        ary[0].transform.position = new Vector2(0f, 0f);

        /*
        GameObject.Destroy(Btn1);
        GameObject.Destroy(Btn2);
        GameObject.Destroy(Btn3);
        GameObject.Destroy(Btn4);
        GameObject.Destroy(Btn5);
        GameObject.Destroy(Btn6);
        GameObject.Destroy(Btn7);
        GameObject.Destroy(Btn8);
        GameObject.Destroy(Btn9);
        GameObject.Destroy(Btn0);
        */


        Button = Instantiate(ary[0], new Vector3(-80f, 107f, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[1], new Vector3(0, 107, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[2], new Vector3(80, 107, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[3], new Vector3(-80, 44, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[4], new Vector3(0, 44, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[5], new Vector3(80, 44, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[6], new Vector3(-80, 19, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[7], new Vector3(0, 19, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[8], new Vector3(80, 19, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);

        Button = Instantiate(ary[9], new Vector3(0, -82, 0), Quaternion.identity);
        Button.transform.SetParent(drawArea.transform, false);




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
