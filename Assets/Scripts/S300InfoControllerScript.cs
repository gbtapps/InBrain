using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;


public class S300InfoControllerScript : MonoBehaviour
{

    [SerializeField] GameObject ContentsArea;

    [SerializeField] GameObject InformationColumn;
    [SerializeField] GameObject ClockImg;
    [SerializeField] string DateString;
    [SerializeField] Text InformationString;
    [SerializeField] Button MoveToDetailBtn;

    private GameObject TempColumn;

    List<string> InformaitonList = new List<string>();

    float ColumnHeight = 140f;
    float ColumnYaxisPosition = 50f;


    // Start is called before the first frame update
    void Start()
    {

        // It gets Information List.

        string[] testString =
        {
            "[Added New Title] New brain exercise games have added on Brain Go (Brain Ex tab) !",
            "[Maintainance] will goes from 2am to 3am at 4th April.",
            "[Information] Campaign goes to introduce your friends from 1st April to the last date May.",
            "[New version release] InBrain ver0.61 released. Please update through App store.",
            "[Attention] Scam calls are increasing. Nothing to call you from InBrain or Good Brain Technologies."
        };


        InformaitonList.Add(testString[0]);
        InformaitonList.Add(testString[1]);
        InformaitonList.Add(testString[2]);
        InformaitonList.Add(testString[3]);

        InformaitonList.Add(testString[0]);
        InformaitonList.Add(testString[1]);
        InformaitonList.Add(testString[2]);
        InformaitonList.Add(testString[3]);

        InformaitonList.Add(testString[0]);
        InformaitonList.Add(testString[1]);
        InformaitonList.Add(testString[2]);
        InformaitonList.Add(testString[3]);

        List<float> y = new List<float>();


        for (int i=0; i < InformaitonList.Count; i++)
        {

            //ボタンを新規作成し、以降で扱い易いようにオブジェクトに代入
            //            TempColumn = Instantiate(InformationColumn, new Vector3(0, y[i], 0), Quaternion.identity);

            TempColumn = Instantiate(InformationColumn, new Vector3(0, -ColumnYaxisPosition, 0), Quaternion.identity);

            GameObject obj = TempColumn.transform.Find("InformationText").gameObject;
            InformationString = TempColumn.transform.Find("InformationText").GetComponent<Text>(); ;
            InformationString.text = InformaitonList[i];





//            hoge = TempColumn.GetComponent<RectTransform>();

//            hoge.sizeDeslta = new Vector2(x, y);　//サイズが変更できる　





            //            TempColumn.RectTransform.sizeDelta.y = ColumnHeight;



            TempColumn.transform.SetParent(ContentsArea.transform, false);


            ColumnYaxisPosition += ColumnHeight;
            TempColumn.GetComponent<RectTransform>().sizeDelta = new Vector2(360, ColumnHeight);




            


            /*
            //新規作成したボタンに紐づく子要素を取得
            foreach (Transform child in Button.transform)
            {
                //子要素はテキストオブジェクトなのでテキストコンポーネントを取得
                Text ButtonNumber = child.GetComponent<Text>();
                ButtonNumber.text = (i + 1).ToString();
            }

            TempColumn.transform.SetParent(ContentsArea.transform, false);
            */



        }


        /*
        foreach(object obj in testString)
        {
            Debug.Log(obj);
        }
        */




        // It makes Information Panels.

        // Within 40 Charactors needs 2 records, which needs 100px of height of column.
        // Over 40 Charactors needs 3 records, which needs 120px of height of column.



        // It calculates the summation height size of height of panels.


        // It sets the summation height size to the height size of Contents Area.

        ContentsArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0, ColumnYaxisPosition + ColumnHeight);
        ContentsArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0, ColumnYaxisPosition -50);



        //        Debug.Log(ContentsArea.GetComponent<RectTransform>().sizeDelta);



    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
