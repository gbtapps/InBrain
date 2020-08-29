using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using System.IO;
using System;


using UnityEngine.SceneManagement;



//脳血流測定
//指定時間の脳血流を測定する




public class Tr_TrainingNeuro : SceneBase
{

    //    const float AIR_PLANE_HEIGHT = 100;
    //    const float AREA_HEIGHT = 1920 - AIR_PLANE_HEIGHT;

    //    const float SCREEN_EDGE_DISTANCE = 0.2f; //画面端の位置 脳活動値での距離
    //    const float RING_DISTANCE = 0.05f; //リングの位置 脳活動値での距離(要らないかも)

    enum STATE
    {
        START,
        ADD,
        MOVE,
        FIN
    }
    

    STATE state;


    /*
    Timer timer;
    */



    int level = 0;
    bool firstStart = true;


    //--------------------------------------------------------
    //脳波関連
    float debugXbValue = 0.2f; //よくわからんので仮脳波
    float avgXbValue = 0.2f;



    /************************************************************************************/
    //added by moritomi from here

    //現在脳血流
    float xbValue;
    //現在脳血流と平均との差分
    float _length;

    //test code
    string TestCode = "";

    //test on/off
    string OnTest = "0";


    //タイムマネジメント
    float cnt = 0;
    [SerializeField] Text SpentTime;
    [SerializeField] Text cntValue;

    //取得データマネジメント
    List<string> Xb01ValueList = new List<string>();
    public string EsThreeParaName = "";


    //Debug text for Demo
    [SerializeField] Text DataCount;
    [SerializeField] Text BrainFlow;
    [SerializeField] Text XbValue;
    [SerializeField] Text AvgXbValue;


    // Chart making
    // CHART_LEFT_MARGIN x2 + BRAIN_VALUES_COUNT = 360
    const int CHART_LEFT_MARGIN = 10;
    const int BRAIN_VALUES_COUNT = 340;
    [SerializeField] GameObject BrainValueBackgroudImage;
    [SerializeField] GameObject target;
    GameObject[] BrainValueColumnArray = new GameObject[BRAIN_VALUES_COUNT];
    int p = 0;


    float PreviousXbValue = 0;
    float ColumnValue = 100;


    //Values
    List<float> BrainValueList = new List<float>();


    // Time controll for Demo
    float SumDeltatime;

    // Debug-demo
    [SerializeField] Text AdjustBrainValueText;
    [SerializeField] Text BrainValueText;
    [SerializeField] Text TestValueText;
    int DEBUGSTRINGLIMIT = 100;

    // Status
    [SerializeField] Text EstateText;
    [SerializeField] Text EmodeText;
    [SerializeField] Text StateText;


    // log
    //    public int[] logData; // Logデータの宣言 テスト
    //public float[] logData; // Logデータの宣言 テスト
    public string[] logData; // Logデータの宣言 テスト


    [SerializeField] Text ParmPathText;
    [SerializeField] Text TempPathText;

    // finish process
    float SumDeltaTimeScene;

    [SerializeField] int DemoTime;
    [SerializeField] int DemoCountdown;


    // Countdown
    [SerializeField] GameObject CountdownPanelImage;
    [SerializeField] float DeltaTimeCount = 0f;
    [SerializeField] Text CountdownText;
    [SerializeField] int CountdownInt;

    // whole scene controll
    [SerializeField] float SumDeltaTimeWholeScene;
    int SumTimeWholeScene;
    [SerializeField] int IntervalTime;
    [SerializeField] int TestTime;

    int Interval1StartTime;
    int Test1StartTime;
    int Interval2StartTime;
    int Test2StartTime;
    int Interval3StartTime;
    int FinishProcessStartTime;

    // Active scene name 
    [SerializeField] string ActiveSceneName;

    // Test Controll
    [SerializeField] GameObject Test1Area;
    [SerializeField] GameObject Test2Area;


    // Status
    public string SceneStatus;


    // Start Date&Time;
    string StartDateAndTime;


    //
    //外部クラスの関数や変数を使う
    //

    private GameObject S522Test1GameManager;
    private S522Test1GameManagerScript InstanseS522Test1GameManagerScript;

    private GameObject S524Test2GameManager;
    private S524Test2GameManagerScript InstanseS524Test2GameManagerScript;

    List<string> TestLogSaveNameList = new List<string>();
    string EsThreeTestLogSaveName = "Es3TestLogSaveNameList";

    private bool WithXb01flg;



    //added by moritomi until here
    /**********************************************************************/




    void Start()
    {

        //Set using xb01 flg from another scene
        WithXb01flg = S510ConnectingSensorControllerScript.WithXb01;

        WithXb01flg = true;

        StartDateAndTime = DateTime.Now.ToString("yyyyMMddHHmmss");


        //Get active scene name
        ActiveSceneName = SceneManager.GetActiveScene().name;


        if (ActiveSceneName == "Tr_TrainingNeuro")
        {

            //TestArea(included the target buttons of test) hides;
            Test1Area.SetActive(false);
            Test2Area.SetActive(false);


            //S522Test1GameManagerの機能と変数を使う
            S522Test1GameManager = GameObject.Find("S522Test1GameManager");
            InstanseS522Test1GameManagerScript = S522Test1GameManager.GetComponent<S522Test1GameManagerScript>();

            //S524Test2GameManagerの機能と変数を使う
            S524Test2GameManager = GameObject.Find("S524Test2GameManager");
            InstanseS524Test2GameManagerScript = S524Test2GameManager.GetComponent<S524Test2GameManagerScript>();

            // Make ES3 save point name
            EsThreeParaName = "Xb01ValueList" + StartDateAndTime;

            //
            TestCode = "TMT";

            //Set count for countdown
            CountdownInt = IntervalTime;



            //Time Controll
            Interval1StartTime = 0;
            Test1StartTime = IntervalTime;
            Interval2StartTime = IntervalTime + TestTime;
            Test2StartTime = IntervalTime + TestTime + IntervalTime;
            Interval3StartTime = IntervalTime + TestTime + IntervalTime + TestTime;
            FinishProcessStartTime = IntervalTime + TestTime + IntervalTime + TestTime + IntervalTime;


            /*
            Debug.Log("Interval1StartTime: "+ Interval1StartTime);
            Debug.Log("Test1StartTime: " + Test1StartTime);
            Debug.Log("Interval2StartTime: " + Interval2StartTime);
            Debug.Log("Test2StartTime: " + Test2StartTime);
            Debug.Log("Interval3StartTime: " + Interval3StartTime);
            Debug.Log("FinishProcessStartTime: " + FinishProcessStartTime);
            */


        }
        else
        {
            CountdownInt = DemoCountdown;
            TestCode = "DEMO";

            //Start countdown
            CountdownStart();
            DemoTime += DemoCountdown;


        }








        CommonHeaderMfn.Instance.SetView(false);

#if !BLUE_DEBUG
        BrainDataMgr.Start(BrainDataFeedbacker.Type.NEURO);
#endif

        level = 9;


        //-------------------------------------
        //開始！
        state = STATE.START;


        firstStart = true;



    }

    private void Update()
    {


        // if test mode
        // 5 seconds of first interval and 30 seconds of demonstration.
        // if check mode
        // 10 secondes of first inteval and 50 secondes of test, which go twice and 10 seconds of last interval.



        SumDeltaTimeWholeScene += Time.deltaTime;

        if (SumDeltaTimeWholeScene > 1.0f)
        {
            SumTimeWholeScene++;
            CountdownInt--;
//            Debug.Log("SumTimeWholeScene: " + SumTimeWholeScene);
            SumDeltaTimeWholeScene = 0;
        }



        if (ActiveSceneName == "Tr_TrainingNeuro")
        {

            //Inverval1 Start
            if (SumTimeWholeScene >= Interval1StartTime && SumTimeWholeScene < Test1StartTime)
            {
                SceneStatus = "Interval1";
                TestCode = "Interval1";

                //                Debug.Log("Interval1StartTime");
                CountdownPanelImage.SetActive(true);
                CountdownText.text = CountdownInt.ToString() + "\nInterval1";

                //Test On/Off
                OnTest = "0";


            }

            //Test1 Start
            else if (SumTimeWholeScene >= Test1StartTime && SumTimeWholeScene < Interval2StartTime)
            {
                //                Debug.Log("Test1StartTime");
                SceneStatus = "Test1";
                TestCode = "Test1";
                CountdownPanelImage.SetActive(false);
                Test1Area.SetActive(true);
                CountdownInt = IntervalTime+1;
            
                //Test On/Off
                OnTest = "1";

            }

            //Inverval2 Start
            else if (SumTimeWholeScene >= Interval2StartTime && SumTimeWholeScene < Test2StartTime)
            {
                //                Debug.Log("Interval2StartTime");


                SceneStatus = "Interval2";
                TestCode = "Interval2";

                //Hide Test1 area 
                Test1Area.SetActive(false);
                CountdownPanelImage.SetActive(true);
                CountdownText.text = CountdownInt.ToString() + "\nInterval2";

                //Test On/Off
                OnTest = "0";

            }

            //Test2 Start
            else if (SumTimeWholeScene >= Test2StartTime && SumTimeWholeScene < Interval3StartTime)
            {
                //               Debug.Log("Test2StartTime");
                SceneStatus = "Test2";
                TestCode = "Test2";

                CountdownPanelImage.SetActive(false);
                Test2Area.SetActive(true);
                CountdownInt = IntervalTime+1;

                //Test On/Off
                OnTest = "1";

            }

            //Inverval3 Start
            else if (SumTimeWholeScene >= Interval3StartTime && SumTimeWholeScene < FinishProcessStartTime)
            {
                //                Debug.Log("Interval3StartTime");
                SceneStatus = "Interval3";
                TestCode = "Interval3";

                Test2Area.SetActive(false);
                CountdownPanelImage.SetActive(true);
                CountdownText.text = CountdownInt.ToString() + "\nInterval3";

                //Test On/Off
                OnTest = "0";

            }

            //Finish Process Start
            else if (SumTimeWholeScene == FinishProcessStartTime)
            {


                SceneStatus = "FinishProcess";


                //Save logs on each test and xb01
                InstanseS522Test1GameManagerScript.SaveT1UserAnswerList(StartDateAndTime);
                InstanseS524Test2GameManagerScript.SaveT2UserAnswerList(StartDateAndTime);


                //Call save parameter name
                string name1 = InstanseS522Test1GameManagerScript.EsThreeParaName;
                string name2 = InstanseS524Test2GameManagerScript.EsThreeParaName;


                //Check exist of save parameter to save new data after previous data
                bool existsKey = ES3.KeyExists(EsThreeTestLogSaveName);
                if (existsKey == true)
                {
                    //Load save parameter name list
                    TestLogSaveNameList = ES3.Load<List<string>>(EsThreeTestLogSaveName);
                }

                
                string tmpstr = StartDateAndTime +"," + name1 + "," + name2;
                Debug.Log("tmpstr: " + tmpstr);


                // Process when with xb01
                if (WithXb01flg == true)
                {

                    // Save Xb01 value to es3 on function
                    SaveXb01ValueList();

                    // Save xb01 value to csv file
                    logData = Xb01ValueList.ToArray();
                    LogSave(logData, "DebugTestLogData");

                    // Set name of xb01 data on save string
                    string name3 = EsThreeParaName;
                    tmpstr += "," + name3;

                }


                //Add current save parameter name to list
                TestLogSaveNameList.Add(tmpstr);


                //Save list(controll list name, answer list name)
                ES3.Save<List<string>>(EsThreeTestLogSaveName, TestLogSaveNameList);



                //debug for 
                List<string> temp = new List<string>();
                temp = ES3.Load<List<string>>(EsThreeTestLogSaveName);

                foreach(string str in temp)
                {
                    Debug.Log(str);
                }

                Debug.Log("FinishProcessStartTime");

                //Change scene
                SceneManager.LoadScene("S526TestResultSummary");



            }

        }



        else if (ActiveSceneName == "Tr_TrainingNeuroTest")
        {

//            Debug.Log("ActiveSceneName: " + ActiveSceneName);

            //Show countdown
            CountdownUpdate();

            //Finish process
            FinishProcess();

            StateText.text = "Status: " + state;

        }


        //Measure Process starts from beginning
        switch (state)
        {
            case STATE.START:
                UpdateStart();
                break;
            case STATE.ADD:
                //                ringMgr.AddOneSet(level);
                state = STATE.MOVE;
                break;
            case STATE.MOVE:

                //Measuring
                UpdateMove();

                //Drawing chart
                UpdateChart();

                break;

            case STATE.FIN:
                break;
        }


        
        // To try to draw chart instead of removing sensor
//        UpdateChart();






    }



    //指定秒間の脳血流の平均値を取得したら準備時間完了
    void UpdateStart()
    {


        //OnHead状態で5秒間に変更
        if (Hot2gApplication.Instance.state2 == Hot2gApplication.eState.OnHead)
        {

            //added by moritomi
            //eStateOnHead
            EstateText.text = "Onhead: Yes";

            if (Hot2gApplication.Instance.mode == Hot2gApplication.eMode.RecieveData)//- Measureing data in stable status
            {
                cnt += Time.deltaTime;

                SpentTime.text = cnt.ToString();

                //added by moritomi
                //eModeRecieveData
                EmodeText.text = "RecieveData: Yes";



                //ここにデータ取得ロジックを入れるとギャップがない





            }
            else
            {
                cnt = 0;//- counter reset because of unstable situation

                
                //added by moritomi
                //eModeRecieveData
                EmodeText.text = "RecieveData: No";
                //ColumnNumberReset

            }


        }
        else//- NOT On the head
        {


            cnt = 0;//- counter reset because of unstable situation

            //added by moritomi
            //eStateOnHead
            EstateText.text = "Onhead: No";
            //ColumnNumberReset

        }


        //デルタタイムで5秒経過　
        //        if (cnt >= 1)


        //5秒経過は飛行機が出てくるまでの溜め
        //タメがないなら1秒でOK、1秒でavgXBvalue obtainしている
        if (cnt >= 1)
        {
            cntValue.text = cnt.ToString();

            //前の1秒で平均値をとってる
            //avgXbValue = GetXBValue();//- Average from 4sec to 5sec in buffer
            avgXbValue = (float)Hot2gApplication.Instance.m_nfb.calcActivenessFromBufferedUsingLastData(10);//- ave last 1 sec (10points)


            //
            cnt = 0;
            state = STATE.ADD;//- 



        }


    }


    

    void UpdateMove()
    {


        //- Height of the air plane
        cnt += Time.deltaTime;
        if (cnt > 0.01f)
        {
            cnt = 0;

            //他の関数で変数値を使用したいためフィールド変数にした
            //            float xbValue = GetXBValue();
            //            float _length = xbValue - avgXbValue;

            //実測値
            xbValue = GetXBValue();

            //Add measured values to List
//            Xb01ValueList.Add(xbValue);

            Xb01ValueList.Add(DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "," + xbValue.ToString()+","+OnTest+","+ TestCode);



            //偏差
            _length = xbValue - avgXbValue;




            // for debug from here **************************************************************

            //見せ方変更
            XbValue.text = xbValue.ToString() + "\n"+ XbValue.text;
            AvgXbValue.text = avgXbValue.ToString() + "\n"+ AvgXbValue.text;
            BrainFlow.text = _length + "\n"+ BrainFlow.text;


            if (XbValue.text.Length > DEBUGSTRINGLIMIT)
            {
                XbValue.text = XbValue.text.Substring(0, DEBUGSTRINGLIMIT);
                AvgXbValue.text = AvgXbValue.text.Substring(0, DEBUGSTRINGLIMIT);
                BrainFlow.text = BrainFlow.text.Substring(0, DEBUGSTRINGLIMIT);
            }

            
            
            DataCount.text = Xb01ValueList.Count.ToString();

            // for debug from here **************************************************************





            if (xbValue == 0.0f)
            {
                //実測値がゼロのためセンサー外れとみなし繋ぐところから
                state = STATE.START;

                //Show Error dialog and return to Previous scence.



            }




        }

        /*
        if (timer.time <= 0)
        {
            BrainDataMgr.End();


        }
        */


    }





    float GetXBValue()
    {
#if !BLUE_DEBUG

        float _value = BrainDataMgr.GetValue();
#else
        float _value = debugXbValue;
#endif

        return _value;
    }


    float GetXBValue(int startIdx)
    {
#if !BLUE_DEBUG

        float _value = BrainDataMgr.GetValue(startIdx);
#else
        float _value = debugXbValue;
#endif

        return _value;
    }



    void UpdateChart()
    {
        // It only acts on STATE.MOVE to be synced getting values and chart action.


        // Do once a second
        SumDeltatime += Time.deltaTime;
        if (SumDeltatime > 0.1f)
        {



            float sin = Mathf.Sin(Time.time);


            TestValueText.text = sin.ToString() + "\n" + TestValueText.text;            
            BrainValueText.text = xbValue.ToString() + "\n" + BrainValueText.text;
            if (TestValueText.text.Length > DEBUGSTRINGLIMIT)
            {
                TestValueText.text = TestValueText.text.Substring(0, DEBUGSTRINGLIMIT);
            }
            if (BrainValueText.text.Length > DEBUGSTRINGLIMIT)
            {
                BrainValueText.text = BrainValueText.text.Substring(0, DEBUGSTRINGLIMIT);
            }




            //show chart

            //set size value


            if (PreviousXbValue < xbValue)
            {
                ColumnValue += 1.0f;
                if (ColumnValue > 200f)
                {
                    ColumnValue = 200;
                }
            }
            else if (PreviousXbValue > xbValue)
            {
                ColumnValue -= 1.0f;
                if(ColumnValue < 0f)
                {
                    ColumnValue = 0;
                }
            }

            PreviousXbValue = xbValue;


            //create, give position, give size, attach parent
            if (p < BRAIN_VALUES_COUNT)
            {
                // comment out for y-axis from 0 to -100 
                //                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + 30, 0, 0), Quaternion.identity);
                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + CHART_LEFT_MARGIN, -100, 0), Quaternion.identity);

                //                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, ColumnValue);
                BrainValueColumnArray[p].transform.SetParent(BrainValueBackgroudImage.transform, false);
            }
            else
            {
                //Move chart from right to left
                for (int i = 0; i < BRAIN_VALUES_COUNT - 1; i++)
                {
                    BrainValueColumnArray[i].GetComponent<RectTransform>().sizeDelta = BrainValueColumnArray[i + 1].GetComponent<RectTransform>().sizeDelta;
                }
//                BrainValueColumnArray[BRAIN_VALUES_COUNT - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[BRAIN_VALUES_COUNT - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, ColumnValue);

                //  Debug.Log(BrainValueArray);


            }




            SumDeltatime = 0;
            p++;

            Debug.Log(p + " :p");


        }


    }


    void CountdownStart()
    {
        CountdownPanelImage.SetActive(true);
    }



    // Update is called once per frame
    void CountdownUpdate()
    {

        Debug.Log("CountdownUpdate");

        DeltaTimeCount += Time.deltaTime;
        


        if (DeltaTimeCount >= 1.0f)
        {

            DeltaTimeCount = 0.0f;



            //CountdownInt value is different among Test and Demo.
            if (CountdownInt > 0)
            {
                //カウントダウン表示
                CountdownText.text = CountdownInt.ToString();
                Debug.Log("CountdownText.text: "+ CountdownText.text);

            }
            else
            {
                CountdownPanelImage.SetActive(false);

            }

            //Update()で実装したのでこちらは消す
            //1秒たったのでカウントをダウンする
//            CountdownInt--;

        }

    }






//    public void LogSave(int[] x, string fileName)

//    public void LogSave(float[] x, string fileName)
    public void LogSave(string[] x, string fileName)
    {
        StreamWriter sw; // これがキモらしい
        FileInfo fi;

        //日付をYYYYMMDD24hmmssで表示する文字列作成 
        DateTime now = DateTime.Now;
        string tempdatestring = now.Year.ToString() + now.Month.ToString() + now.Day.ToString()
            + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString();
        //        Debug.Log(tempdatestring);


        //ファイルを出力するパス
//        string temppathstring = Application.dataPath + "/Resources/";
        string temppathstring = UnityEngine.Application.persistentDataPath;


        //出力先ファイルパス
        // Aplication.dataPath で プロジェクトファイルがある絶対パスが取り込める
        //        fi = new FileInfo(Application.dataPath + "/Resources/" + fileName +tempdatestring+ ".csv");

        fi = new FileInfo(temppathstring + fileName + tempdatestring + ".csv");

        
  
        //パス情報
        //        UnityEngine.Application.persistentDataPath(永続性のある情報向け)
        //        UnityEngine.Application.temporaryCachePath(一時的な情報向け)


        Debug.Log("UnityEngine.Application.persistentDataPath: " + UnityEngine.Application.persistentDataPath);
        Debug.Log("UnityEngine.Application.temporaryCachePath: " + UnityEngine.Application.temporaryCachePath);
        ParmPathText.text = UnityEngine.Application.persistentDataPath;
        TempPathText.text = UnityEngine.Application.temporaryCachePath;

        sw = fi.AppendText();
        for (int i = 0; i < x.Length; i++)
        {
            sw.WriteLine(x[i].ToString());
        }
        sw.Flush();
        sw.Close();

    }


    // Update is called once per frame
    void FinishProcess()
    {

        ////////////////////////////
        //1秒毎に処理させるここから
        //
        SumDeltaTimeScene += Time.deltaTime;
        //        Debug.Log(DeltaTimeCount + " =DeltaTimeCount");

        if (SumDeltaTimeScene >= 1.0f)
        {

            SumDeltaTimeScene = 0.0f;

            //1秒たったのでカウントをダウンする
            DemoTime--;

            if (DemoTime == 0)
            {


                //                logData = new float[] { 1.2f, 3.1f, 5.6f, 7.2f, 9.9f }; // 仮のLogデータ

//                logData = Xb01ValueList.ToArray();
                logData = Xb01ValueList.ToArray();
                LogSave(logData, "DemoLogData"); // Logデータをcsv形式で書き出す
//                LogSave(Xb01ValueList, "logDataList"); // Logデータをcsv形式で書き出す

               




                Debug.Log(DemoTime + " :DemoTime");


                if (ActiveSceneName == "Tr_TrainingNeuro")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting2nd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuro2nd")
                {
                    Debug.Log("SceneManager.LoadScene>Tr_TraningSetting2nd");
                    SceneManager.LoadScene("Tr_TraningSetting3rd");

                }
                else if (ActiveSceneName == "Tr_TrainingNeuroTest")
                {
                    Debug.Log("SceneManager.LoadScene>T_TitleSelect");
                    SceneManager.LoadScene("T_TitleSelect");

                }
                else
                {
                    SceneManager.LoadScene("T_TitleSelect");

                }



            }


        }
        //
        //1秒毎に処理させるここまで
        ///////////////////////////////////

    }


    public void SaveXb01ValueList()
    {

        Debug.Log("SaveXb01ValueList Start");
        ES3.Save<List<string>>(EsThreeParaName, Xb01ValueList);

        //保存確認
        List<string> temp = new List<string>();
        temp = ES3.Load<List<string>>(EsThreeParaName);
        foreach (string str in temp)
        {
            Debug.Log(str);
        }


    }



}
