using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

//StringBuilder用
using System.Text;



public class S526TestResultSummaryControllerScript : MonoBehaviour
{


    //グラフの表示非表示用
    public GameObject tmtA;
    public GameObject tmtB;
    public Toggle tmtAToggle;
    public Toggle tmtBToggle;



    //グラフ各カラムインスタンス
    public GameObject tmtA_1;
    public GameObject tmtA_2;
    public GameObject tmtA_3;
    public GameObject tmtA_4;
    public GameObject tmtA_5;
    public GameObject tmtA_6;
    public GameObject tmtA_7;
    public GameObject tmtA_8;
    public GameObject tmtA_9;
    public GameObject tmtA_10;
    public GameObject tmtA_11;
    public GameObject tmtA_12;
    public GameObject tmtA_13;
    public GameObject tmtA_14;
    public GameObject tmtA_15;
    public GameObject tmtA_16;
    public GameObject tmtA_17;
    public GameObject tmtA_18;
    public GameObject tmtA_19;
    public GameObject tmtA_20;
    public GameObject tmtA_21;
    public GameObject tmtA_22;
    public GameObject tmtA_23;

    public GameObject tmtB_1;
    public GameObject tmtB_2;
    public GameObject tmtB_3;
    public GameObject tmtB_4;
    public GameObject tmtB_5;
    public GameObject tmtB_6;
    public GameObject tmtB_7;
    public GameObject tmtB_8;
    public GameObject tmtB_9;
    public GameObject tmtB_10;
    public GameObject tmtB_11;
    public GameObject tmtB_12;
    public GameObject tmtB_13;
    public GameObject tmtB_14;
    public GameObject tmtB_15;
    public GameObject tmtB_16;
    public GameObject tmtB_17;
    public GameObject tmtB_18;
    public GameObject tmtB_19;
    public GameObject tmtB_20;
    public GameObject tmtB_21;
    public GameObject tmtB_22;
    public GameObject tmtB_23;

    //脳活動スコア格納変数の初期化
    float TmtaBrainAct1 = 0f;
    float TmtaBrainAct2 = 0f;
    float TmtaBrainAct3 = 0f;
    float TmtaBrainAct4 = 0f;
    float TmtaBrainAct5 = 0f;
    float TmtaBrainAct6 = 0f;
    float TmtaBrainAct7 = 0f;
    float TmtaBrainAct8 = 0f;
    float TmtaBrainAct9 = 0f;
    float TmtaBrainAct10 = 0f;
    float TmtaBrainAct11 = 0f;
    float TmtaBrainAct12 = 0f;
    float TmtaBrainAct13 = 0f;
    float TmtaBrainAct14 = 0f;
    float TmtaBrainAct15 = 0f;
    float TmtaBrainAct16 = 0f;
    float TmtaBrainAct17 = 0f;
    float TmtaBrainAct18 = 0f;
    float TmtaBrainAct19 = 0f;
    float TmtaBrainAct20 = 0f;
    float TmtaBrainAct21 = 0f;
    float TmtaBrainAct22 = 0f;
    float TmtaBrainAct23 = 0f;

    float TmtbBrainAct1 = 0f;
    float TmtbBrainAct2 = 0f;
    float TmtbBrainAct3 = 0f;
    float TmtbBrainAct4 = 0f;
    float TmtbBrainAct5 = 0f;
    float TmtbBrainAct6 = 0f;
    float TmtbBrainAct7 = 0f;
    float TmtbBrainAct8 = 0f;
    float TmtbBrainAct9 = 0f;
    float TmtbBrainAct10 = 0f;
    float TmtbBrainAct11 = 0f;
    float TmtbBrainAct12 = 0f;
    float TmtbBrainAct13 = 0f;
    float TmtbBrainAct14 = 0f;
    float TmtbBrainAct15 = 0f;
    float TmtbBrainAct16 = 0f;
    float TmtbBrainAct17 = 0f;
    float TmtbBrainAct18 = 0f;
    float TmtbBrainAct19 = 0f;
    float TmtbBrainAct20 = 0f;
    float TmtbBrainAct21 = 0f;
    float TmtbBrainAct22 = 0f;
    float TmtbBrainAct23 = 0f;


    //アニメーション速度変数
    float spanTime = 2.0f;

    //アニメーション用テンポラリ変数
    float tmta1temp = 0f;
    float tmta2temp = 0f;
    float tmta3temp = 0f;
    float tmta4temp = 0f;
    float tmta5temp = 0f;
    float tmta6temp = 0f;
    float tmta7temp = 0f;
    float tmta8temp = 0f;
    float tmta9temp = 0f;
    float tmta10temp = 0f;
    float tmta11temp = 0f;
    float tmta12temp = 0f;
    float tmta13temp = 0f;
    float tmta14temp = 0f;
    float tmta15temp = 0f;
    float tmta16temp = 0f;
    float tmta17temp = 0f;
    float tmta18temp = 0f;
    float tmta19temp = 0f;
    float tmta20temp = 0f;
    float tmta21temp = 0f;
    float tmta22temp = 0f;
    float tmta23temp = 0f;

//    float[] TmtAtmp = new float[23];


    float tmtb1temp = 0f;
    float tmtb2temp = 0f;
    float tmtb3temp = 0f;
    float tmtb4temp = 0f;
    float tmtb5temp = 0f;
    float tmtb6temp = 0f;
    float tmtb7temp = 0f;
    float tmtb8temp = 0f;
    float tmtb9temp = 0f;
    float tmtb10temp = 0f;
    float tmtb11temp = 0f;
    float tmtb12temp = 0f;
    float tmtb13temp = 0f;
    float tmtb14temp = 0f;
    float tmtb15temp = 0f;
    float tmtb16temp = 0f;
    float tmtb17temp = 0f;
    float tmtb18temp = 0f;
    float tmtb19temp = 0f;
    float tmtb20temp = 0f;
    float tmtb21temp = 0f;
    float tmtb22temp = 0f;
    float tmtb23temp = 0f;

//    float[] TmtBtmp = new float[23];


    public GameObject explanationPanelPage110;

    public GameObject textResultSpeed;
    public GameObject textResultAttention;
    public GameObject textResultBrain;
    public GameObject textResultDeclines;

    //各スコア、順位、○✕評価の他シーンへの引継ぎ
    //それぞれの計算結果は以下の静的変数に入れる
    //他シーンへの引継ぎ用として使うだけにする
    //本シーンの内部処理では使わない


    //処理速度
    public static int scoreSpeed;  //点
    public static int ageSpeed; //年齢
    public static string classSpeed; //◎○△
    //注意力
    public static int scoreAttention;  //点
    public static int ageAttention; //年齢
    public static string classAttention; //◎○△
    //脳活動
    public static int scoreBrain;  //点
    public static int ageBrain; //年齢
    public static string classBrain; //◎○△

    //引数を取れないInvokeで遅延表示をさせるために
    //メイン関数Start()と描画関数ShowResult()にまたがって使う
    Text ResultSpeed;
    Text ResultAttention;
    Text ResultBrain;
    Text ResultDeclines;
    String rSpeed;
    String rAttention;
    String rBrain;
    String rDeclines;


    // Show result values
    [SerializeField] Text SpeedScore;
    [SerializeField] Text SpeedAge;
    [SerializeField] Text SpeedStatus;

    [SerializeField] Text AttentionScore;
    [SerializeField] Text AttentionAge;
    [SerializeField] Text AttentionStatus;

    [SerializeField] Text BrainScore;
    [SerializeField] Text BrainAge;
    [SerializeField] Text BrainStatus;

    [SerializeField] GameObject NoMoreData1;
    [SerializeField] GameObject NoMoreData2;

    [SerializeField] GameObject NoDataMessagePanel;
    [SerializeField] Text NoDataMessageText;
    [SerializeField] Text TestDateAndTime;




    // User property
    private int MyAge; //real age



    // ES3セーブデータリストを操作
    List<string> TestLogSaveNameList = new List<string>();
    int SaveNumber = 0;

    // Manipulate Xb01 values
    List<string> Xb01ValueList = new List<string>();

    // Manipulate Test1 log
    List<string> T1LogList = new List<string>();

    // Manipulate Test2 log
    List<string> T2LogList = new List<string>();


    // For debug1
    [SerializeField] Text SaveList;
    [SerializeField] Text Chart1List;
    [SerializeField] Text Chart2List;

    // For debug2
    [SerializeField] Text Interval1DataOutline;
    [SerializeField] Text Interval2DataOutline;
    [SerializeField] Text Interval3DataOutline;
    [SerializeField] Text Test1DataOutline;
    [SerializeField] Text Test2DataOutline;

    // For debug3
    [SerializeField] Text CountPlusOverAve;


    public void TmtAOnOff()
    {
        if (tmtAToggle.isOn == false)
        {
            tmtA.SetActive(false);
        }

        if (tmtAToggle.isOn == true)
        {
            tmtA.SetActive(true);
        }
    }

    public void TmtBOnOff()
    {
        if (tmtBToggle.isOn == false)
        {
            tmtB.SetActive(false);
        }

        if (tmtBToggle.isOn == true)
        {
            tmtB.SetActive(true);
        }
    }

    private int GetRealAge()
    {
        int realage=40;

        //Get user age from ES3.userproperty
        //If it can't be got 


        return realage;

    }

    //
    private int CountCorrects(List<string> a)
    {
        int corrects = 0;
        for (int i = 0; i < a.Count; i++)
        {

            //Caution: Format is "Date&Time,1or0" that's why follow logic.
            string[] tmpArray = a[i].Split(',');
            if (tmpArray[1] == "1")
            {
                corrects++;
            }

        }
        return corrects;
    }


    public void ShowResultSummary(string a)
    {

        //For debug
        SaveList.text = a;
        Debug.Log(a);


        NoDataMessagePanel.SetActive(false);


        //Get save list name 
        string[] stringArray = a.Split(',');

        //        stringArray[0] TestDate&Time
        //        stringArray[1] test1
        //        stringArray[2] test2
        //        stringArray[3] xb01



        // Get Date&Time from stringArray[0]
        int tmpIndex = 0;
        int tmpLength = "YYYYMMDDhhmmss".Length;

        string tmpStr = stringArray[0];
        Debug.Log("tmpStr: "+tmpStr);

        tmpIndex = tmpStr.IndexOf("2020");
        Debug.Log("tmpIndex: " + tmpIndex);

        tmpStr = tmpStr.Substring(tmpIndex, tmpLength);
        Debug.Log(tmpStr);

        string tmpDate = tmpStr.Substring(0, 4)+"/"+ tmpStr.Substring(4, 2) + "/" + tmpStr.Substring(6, 2);
        Debug.Log("tmpDate: " + tmpDate);

        string tmpTime = tmpStr.Substring(8, 2) + ":" + tmpStr.Substring(10, 2) + ":" + tmpStr.Substring(12, 2);

        TestDateAndTime.text = "Date&Time: "+tmpDate+" "+tmpTime;



        // Change process each mode(with XB01 or not)
        int testtype = stringArray.Length;

        if (testtype == 3)
        {

            Debug.Log("testtype: " + testtype);
            //No XbValue because of 2 elemnets(=testtype 2)        
            //No chart of XbValue 

            BrainScore.text = "-";
            BrainAge.text = "-";
            BrainStatus.text = "-";


            NoDataMessagePanel.SetActive(true);
            NoDataMessageText.text = "THIS TEST NOT USE XB-01";

            // Clear chart
            ClearChart();



        }

        //        BrainScore.text = "-";


        if (testtype == 4)
        {


            // Exist XbValueList

            Xb01ValueList = ES3.Load<List<string>>(stringArray[3]);


            bool Xb01ValueListNotNull = false;

            if (Xb01ValueList.Count == 0)
            {

                NoDataMessagePanel.SetActive(true);
                NoDataMessageText.text = "THIS TEST NOT GET DATA \n FROM XB-01";

                // Clear chart in the reason of no data on list
                ClearChart();

                //                MakeDummyXb01Value();
            }
            else
            {
                Xb01ValueListNotNull = true;
            }



            if (Xb01ValueListNotNull == true)
            {

                // Make array for drawing chart

                // Make Low data list
                List<float> test1Xb01RowData = new List<float>();
                List<float> test2Xb01RowData = new List<float>();


                foreach (string str in Xb01ValueList)
                {

                    string[] eachXb01value = str.Split(',');


                    // 0:Date&Time, 1:data, 2:onoff, 3:testtype
                    if (eachXb01value[3] == "Test1")
                    {
                        //                    test1datacount++;
                        if (eachXb01value[2] == "1")
                        {
                            try
                            {
                                test1Xb01RowData.Add(float.Parse(eachXb01value[1]));

                            }
                            catch (FormatException)
                            {
                                Debug.Log("Unable to float.parse on ShowResultSummary(): " + eachXb01value[1]);

                            }

                        }

                    }


                    if (eachXb01value[3] == "Test2")
                    {
                        //                    test2datacount++;
                        if (eachXb01value[2] == "1")
                        {

                            try
                            {
                                test2Xb01RowData.Add(float.Parse(eachXb01value[1]));

                            }
                            catch (FormatException)
                            {
                                Debug.Log("Unable to float.parse on ShowResultSummary()" + eachXb01value[1]);

                            }



                        }

                    }

                }

                Debug.Log("test1Xb01RowData.Count: " + test1Xb01RowData.Count);
                Debug.Log("test2Xb01RowData.Count: " + test2Xb01RowData.Count);




                // Is it true to show deviation value on chart?

                // Deviation value <- Standerd Deviation <- Variance <- Deviation <- Average


                //----------- Average
                float test1sum = 0;
                for (int i = 0; i < test1Xb01RowData.Count; i++)
                {
                    test1sum += test1Xb01RowData[i];
                }
                float test1average = test1sum / test1Xb01RowData.Count;


                float test2sum = 0;
                for (int i = 0; i < test2Xb01RowData.Count; i++)
                {
                    test2sum += test2Xb01RowData[i];
                }
                float test2average = test2sum / test2Xb01RowData.Count;


                Debug.Log("test1average: " + test1average);
                Debug.Log("test2average: " + test2average);




                //---------- Deviation
                List<float> test1Xb01DataDeviation = new List<float>();
                List<float> test2Xb01DataDeviation = new List<float>();

                for (int i = 0; i < test1Xb01RowData.Count; i++)
                {
                    test1Xb01DataDeviation.Add(test1Xb01RowData[i] - test1average);

                }

                for (int i = 0; i < test2Xb01RowData.Count; i++)
                {
                    test2Xb01DataDeviation.Add(test2Xb01RowData[i] - test2average);

                }


                Debug.Log("test1Xb01DataDeviation.Count: " + test1Xb01DataDeviation.Count);
                Debug.Log("test2Xb01DataDeviation.Count: " + test2Xb01DataDeviation.Count);




                //---------- Variance

                float sumtest1devdev = 0;
                foreach (float tmp in test1Xb01DataDeviation)
                {
                    sumtest1devdev += tmp * tmp;
                }
                float test1variance = sumtest1devdev / test1Xb01DataDeviation.Count;


                float sumtest2devdev = 0;
                foreach (float tmp in test2Xb01DataDeviation)
                {
                    sumtest2devdev += tmp * tmp;
                }
                float test2variance = sumtest2devdev / test2Xb01DataDeviation.Count;

                Debug.Log("sumtest1devdev: " + sumtest1devdev);
                Debug.Log("sumtest2devdev: " + sumtest2devdev);

                Debug.Log("test1variance: " + test1variance);
                Debug.Log("test2variance: " + test2variance);


                //---------- Standard Deviation

                float test1StandardDeviation = Mathf.Sqrt(test1variance);
                float test2StandardDeviation = Mathf.Sqrt(test2variance);

                Debug.Log("test1StandardDeviation: " + test1StandardDeviation);
                Debug.Log("test2StandardDeviation: " + test2StandardDeviation);


                //---------- Deviation Value (means hensa-chi in Japanese)

                //自分の得点から平均値を引いた値を標準偏差（数値のばらつきの程度を示す値）で割って 10 倍し、それに 50 を加えます。

                List<float> test1DeviationValue = new List<float>();
                List<float> test2DeviationValue = new List<float>();


                for (int i = 0; i < test1Xb01RowData.Count; i++)
                {
                    float tmp = (test1Xb01RowData[i] - test1average) / test1StandardDeviation * 10 + 50;
                    test1DeviationValue.Add(tmp);
                }

                for (int i = 0; i < test2Xb01RowData.Count; i++)
                {
                    float tmp = (test2Xb01RowData[i] - test2average) / test2StandardDeviation * 10 + 50;
                    test2DeviationValue.Add(tmp);
                }


                Debug.Log("test1DeviationValue.Count: " + test1DeviationValue.Count);
                Debug.Log("test2DeviationValue.Count: " + test2DeviationValue.Count);


                /*
                foreach(float fl in test1DeviationValue)
                {
                    Debug.Log("test1DeviationValue: " + fl);
                }
                */



                //--------------------------------------------------------------------------------


                // List of Comparison with Intervals
                List<float> test1ListPlusValueCompareInterval = new List<float>();
                List<float> test2ListPlusValueCompareInterval = new List<float>();

                test1ListPlusValueCompareInterval = GetListPlusValueCompareInterval("Test1", Xb01ValueList);
                test2ListPlusValueCompareInterval = GetListPlusValueCompareInterval("Test2", Xb01ValueList);

                Debug.Log("test1ListPlusValueCompareInterval.Count: " + test1ListPlusValueCompareInterval.Count);
                Debug.Log("test2ListPlusValueCompareInterval.Count: " + test2ListPlusValueCompareInterval.Count);



                // Make Chart


                //common
                int test1GetDataInterval = 0;
                int test2GetDataInterval = 0;

                //common
                List<float> test1Xb01DataForChart = new List<float>();
                List<float> test2Xb01DataForChart = new List<float>();


                
                /*
                // Partten 1

                // 22 equals chart columns
                test1GetDataInterval = test1DeviationValue.Count / 22;
                test2GetDataInterval = test2DeviationValue.Count / 22;

                string test1StrP1 = "";
                string test2StrP1 = "";

                for (int i = 0; i < test1DeviationValue.Count; i++)
                {
                    if (i % test1GetDataInterval == 0)
                    {
                        test1Xb01DataForChart.Add(test1DeviationValue[i]);
                        test1StrP1 += test1DeviationValue[i]+",";
                    }
                }

                for (int i = 0; i < test2DeviationValue.Count; i++)
                {
                    if (i % test2GetDataInterval == 0)
                    {
                        test2Xb01DataForChart.Add(test2DeviationValue[i]);
                        test2StrP1 += test2DeviationValue[i] + ",";
                    }
                }
                */





                // Partten 2


                // 22 equals chart columns
                test1GetDataInterval = test1ListPlusValueCompareInterval.Count / 22;
                test2GetDataInterval = test2ListPlusValueCompareInterval.Count / 22;

                string test1StrP2 = "";
                string test2StrP2 = "";



                for (int i = 0; i < test1ListPlusValueCompareInterval.Count; i++)
                {
                    if (i % test1GetDataInterval == 0)
                    {
                        test1Xb01DataForChart.Add(test1ListPlusValueCompareInterval[i]);
                        test1StrP2 += test1ListPlusValueCompareInterval[i] + ",";
                    }
                }

                for (int i = 0; i < test2ListPlusValueCompareInterval.Count; i++)
                {
                    if (i % test2GetDataInterval == 0)
                    {
                        test2Xb01DataForChart.Add(test2ListPlusValueCompareInterval[i]);
                        test2StrP2 += test2ListPlusValueCompareInterval[i] + ",";
                    }
                }



                /*
                Debug.Log(test1StrP1);
                Debug.Log(test1StrP2);
                Debug.Log(test2StrP1);
                Debug.Log(test2StrP2);
                */






                //Draw chart of brain blood flow 
                //
                //Set 20 parameter A and B each to argument 

                DrawChartFloat(test1Xb01DataForChart, test2Xb01DataForChart);
                Debug.Log("Done DrawChart()");


            }




            //NOTICE
            //Date&Time,xbValue,Onoff,TestCode
            //Don't forget to do process only in case of Onoff=1


            // Get brain score as count plus of interval average 
//            int count2 = CountPlusValueCompareInterval(Xb01ValueList);
//            Debug.Log("CountPlusValueCompareInterval" + count2);

            /*
            List<float> test1ListPlusValueCompareInterval = new List<float>();
            List<float> test2ListPlusValueCompareInterval = new List<float>();

            test1ListPlusValueCompareInterval = GetListPlusValueCompareInterval("Test1", Xb01ValueList);
            test2ListPlusValueCompareInterval = GetListPlusValueCompareInterval("Test2", Xb01ValueList);

            Debug.Log("test1ListPlusValueCompareInterval.Count: " + test1ListPlusValueCompareInterval.Count);
            Debug.Log("test2ListPlusValueCompareInterval.Count: " + test2ListPlusValueCompareInterval.Count);
            */


            // Get brain score as deviation 
            int count = CountDeviationPlus(Xb01ValueList);

            BrainScore.text = count.ToString();

            string brainAge = GetCogAge("BrainActivity", count);
            BrainAge.text = brainAge;



            string brainStatus = GetCogStatus(brainAge, MyAge);
            BrainStatus.text = brainStatus;
       
            // Set special parameter in case of something error 
            if (count == 0)
            {
                BrainScore.text = "-";
                BrainAge.text = "-";
                BrainStatus.text = "-";



            }
            else
            {
                /*
                foreach(string str in Xb01ValueList)
                {
                    Debug.Log("count= " + count);
                    Debug.Log(str);
                }
                */

            }




        }




        //-----------------  Result Matrix on bellow area  ----------------


        //--------  Test1 resut from here  ---------

        // Test1 speed result
        T1LogList = ES3.Load<List<string>>(stringArray[1]);


        // Just count corrects only
        int t1corrects = CountCorrects(T1LogList);
        SpeedScore.text = t1corrects.ToString();
        //        Debug.Log("t1corrects: " + t1corrects);

        string speedAge = GetCogAge("Speed", t1corrects);
        SpeedAge.text = speedAge;


        string speedStatus = GetCogStatus(speedAge, MyAge);
        SpeedStatus.text = speedStatus;


        if (t1corrects == 0)
        {
            SpeedScore.text = "-";
            SpeedAge.text = "-";
            SpeedStatus.text = "-";

        }



        //--------  Test1 resut until here  ---------



        //--------  Test2 resut from here  ---------


        // Load T2 data
        T2LogList = ES3.Load<List<string>>(stringArray[2]);
        
        //Just count corrects only
        int t2corrects = CountCorrects(T2LogList);
        AttentionScore.text = t2corrects.ToString();
        //        Debug.Log("t2corrects: " + t2corrects);

        string attentionAge = GetCogAge("Attention", t2corrects);
        AttentionAge.text = attentionAge;

        string attentionStatus = GetCogStatus(attentionAge, MyAge);
        AttentionStatus.text = speedStatus;

        if (t2corrects == 0)
        {
            AttentionScore.text = "-";
            AttentionAge.text = "-";
            AttentionStatus.text = "-";

        }


        //--------  Test2 resut until here  ---------


    }


    private string GetCogStatus(string argcogage, int myage)
    {
        // myage is user property age.
        // cogage is calculated with score-age table each cognitive.

        string status = "";
        int cogage = 0;


        try
        {
            cogage = int.Parse(argcogage);

        }
        catch (FormatException)
        {
            Debug.Log("Unable to int.parse on GetCogStatus(): " + argcogage);

        }



        if ( cogage > myage + 10)
        {
            status = "△";

        }
        else if (cogage < myage - 10)
        {
            status = "◎";

        }
        else
        {
            status = "○";

        }

        Debug.Log(cogage);
        Debug.Log(status);

        return status;


    }


    private string GetCogAge(string cog, int score)
    {


        string targetCogAge = "";

        List<string> TargetCogAgeTbl = new List<string>();


        // Get table from web or local storage(userpref or es3) or hard cording

        // No table and make provisional table that string value to make easy by provider


        if(cog == "Speed")
        {

            /*
            for (int i = 0; i < 100; i++)
            {
                string tmp = (100 - i).ToString() + "," + i.ToString();

                // 26 buttons in 20 sec means 13 buttons in 10 sec means 65 buttons in 50 sec
                // 26 buttons in 30 sec means 9  buttons in 10 sec means 45 buttons in 50 sec
                // 26 buttons in 40 sec means 6  buttons in 10 sec means 30 buttons in 50 sec
                // 26 buttons in 60 sec means 4  buttons in 10 sec means 20 buttons in 50 sec

                TargetCogAgeTbl.Add(tmp);
                //            Debug.Log(tmp);

            }
            */


            TargetCogAgeTbl = GetSpeedAgeTable();



        }
        else if (cog == "Attention")
        {
            /*
            for (int i = 0; i < 100; i++)
            {
                string tmp = (100 - i).ToString() + "," + i.ToString();
                TargetCogAgeTbl.Add(tmp);
                //            Debug.Log(tmp);

            }
            */


            TargetCogAgeTbl = GetAttentionAgeTable();


        }
        else if (cog == "BrainActivity")
        {
            for (int i = 0; i < 100; i++)
            {
                string tmp = (100 - i).ToString() + "," + i.ToString();
                TargetCogAgeTbl.Add(tmp);
                //            Debug.Log(tmp);

            }

        }





        // Format is "score, age"


        // Fit and get age from table(array or list)
        for (int i = 0; i < TargetCogAgeTbl.Count; i++)
        {
            //Caution: Format is "Date&Time,1or0" that's why follow logic.
            string[] tmpArray = TargetCogAgeTbl[i].Split(',');

            if (tmpArray[0] == score.ToString())
            {


                    targetCogAge = tmpArray[1];





            }
        }

        return targetCogAge;


    }








    private List<float> GetListPlusValueCompareInterval(string str, List<string> a)
    {

        List<float> reTest1List = new List<float>();
        List<float> reTest2List = new List<float>();




        if (a.Count == 0)
        {
            //No data in the List indicated. 
            Debug.Log("No data");
        }



        // count each data
        int countDataTest1 = 0;
        int countDataTest2 = 0;
        int countDataInterval1 = 0;
        int countDataInterval2 = 0;
        int countDataInterval3 = 0;

        // summation of each data
        float sumDataTest1 = 0f;
        float sumDataTest2 = 0f;
        float sumDataInterval1 = 0f;
        float sumDataInterval2 = 0f;
        float sumDataInterval3 = 0f;

        // average of each data
        float aveDataTest1 = 0f;
        float aveDataTest2 = 0f;
        float aveDataInterval1 = 0f;
        float aveDataInterval2 = 0f;
        float aveDataInterval3 = 0f;


        // Summation of data
        for (int i = 0; i < a.Count; i++)
        {

            //Caution: Format is "Date&Time,data,1or0,testname" that's why follow logic.
            string[] tmpArray = a[i].Split(',');

            //tmpArray[0]: Data&Time
            //tmpArray[1]: data
            //tmpArray[2]: OnOff(1or0)
            //tmpArray[3]: testname

            if (tmpArray[3] == "Interval1")
            {
                countDataInterval1++;
                try
                {
                    sumDataInterval1 += float.Parse(tmpArray[1]);
                }
                catch { Debug.Log("CountPlusValueCompareInterval.error"); }
            }

            else if (tmpArray[3] == "Test1")
            {
                countDataTest1++;
                try
                {
                    sumDataTest1 += float.Parse(tmpArray[1]);
                }
                catch { Debug.Log("CountPlusValueCompareInterval.error"); }
            }

            else if (tmpArray[3] == "Interval2")
            {
                countDataInterval2++;
                try
                {
                    sumDataInterval2 += float.Parse(tmpArray[1]);
                }
                catch { Debug.Log("CountPlusValueCompareInterval.error"); }
            }

            else if (tmpArray[3] == "Test2")
            {
                countDataTest2++;
                try
                {
                    sumDataTest2 += float.Parse(tmpArray[1]);
                }
                catch { Debug.Log("CountPlusValueCompareInterval.error"); }
            }

            else if (tmpArray[3] == "Interval3")
            {
                countDataInterval3++;
                try
                {
                    sumDataInterval3 += float.Parse(tmpArray[1]);
                }
                catch { Debug.Log("CountPlusValueCompareInterval.error"); }
            }

        }


        aveDataTest1 = sumDataTest1 / countDataTest1;
        aveDataTest2 = sumDataTest2 / countDataTest2;
        aveDataInterval1 = sumDataInterval1 / countDataInterval1;
        aveDataInterval2 = sumDataInterval2 / countDataInterval2;
        aveDataInterval3 = sumDataInterval3 / countDataInterval3;

        float aveDataInterval1And2 = (sumDataInterval1 + sumDataInterval2) / (countDataInterval1 + countDataInterval2);
        float aveDataInterval2And3 = (sumDataInterval2 + sumDataInterval3) / (countDataInterval2 + countDataInterval3);


        Debug.Log("test1: " + countDataTest1 + ":" + sumDataTest1 + ":" + aveDataTest1);
        Debug.Log("test2: " + countDataTest2 + ":" + sumDataTest2 + ":" + aveDataTest2);
        Debug.Log("interval1: " + countDataInterval1 + ":" + sumDataInterval1 + ":" + aveDataInterval1);
        Debug.Log("interval2: " + countDataInterval2 + ":" + sumDataInterval2 + ":" + aveDataInterval2);
        Debug.Log("interval3: " + countDataInterval3 + ":" + sumDataInterval3 + ":" + aveDataInterval3);


        Interval1DataOutline.text = "interval1: " + countDataInterval1.ToString() + ":" + sumDataInterval1.ToString() + ":" + aveDataInterval1.ToString();
        Interval2DataOutline.text = "interval2: " + countDataInterval2.ToString() + ":" + sumDataInterval2.ToString() + ":" + aveDataInterval2.ToString();
        Interval3DataOutline.text = "interval3: " + countDataInterval3.ToString() + ":" + sumDataInterval3.ToString() + ":" + aveDataInterval3.ToString();
        Test1DataOutline.text = "test1: " + countDataTest1.ToString() + ":" + sumDataTest1.ToString() + ":" + aveDataTest1.ToString();
        Test2DataOutline.text = "test2: " + countDataTest2.ToString() + ":" + sumDataTest2.ToString() + ":" + aveDataTest2.ToString();


        for (int i = 0; i < a.Count; i++)
        {

            //Caution: Format is "Date&Time,data,1or0,testname" that's why follow logic.
            string[] tmpArray = a[i].Split(',');

            //tmpArray[0]: Data&Time
            //tmpArray[1]: data
            //tmpArray[2]: OnOff(1or0)
            //tmpArray[3]: testname

            if (tmpArray[3] == "Test1")
            {
                float test1Value = 0f;
                try
                {
                    test1Value = float.Parse(tmpArray[1]);
                }
                catch { Debug.Log(tmpArray[1]); }


                reTest1List.Add(test1Value - aveDataInterval1And2);
                

            }


            if (tmpArray[3] == "Test2")
            {
                float test2Value = 0f;
                try
                {
                    test2Value = float.Parse(tmpArray[1]);
                }
                catch { Debug.Log(tmpArray[1]); }


                reTest2List.Add(test2Value - aveDataInterval2And3);


            }


        }


        if(str == "Test1")
        {
            return reTest1List;

        }
        else if(str == "Test2")
        {
            return reTest2List;

        }
        else
        {
            return reTest1List;
        }



    }




        private int CountDeviationPlus(List<string> a)
    {

        // Be zoro to summation of all deviation because of difference from average.
        // Be half score as well as always 

        if (a.Count == 0)
        {
            //No data in the List indicated. 
            return 0;
        }

        int deviationpluscount = 0;
        float totalxbValue = 0f;
        int datacount = 0;
        float averagedata = 0f;

        // Summation of data
        for (int i = 0; i < a.Count; i++)
        {

            //Caution: Format is "Date&Time,data,1or0,testname" that's why follow logic.
            string[] tmpArray = a[i].Split(',');

            if (tmpArray[2] == "1")
            { 



                try
                {
                    //Date&Time,xbValue,OnTest,TestCode
                    totalxbValue += float.Parse(tmpArray[1]);

                }
                catch (FormatException)
                {
                    Debug.Log("Unable to float.parse on CountDeviationPlus(): " + tmpArray[1]);

                }






                //For calculating average to use as a denominator
                datacount++;

            }

        }

        // Average of data
        averagedata = totalxbValue / datacount;

        // count deviation pluse
        for (int i = 0; i < a.Count; i++)
        {

            //Caution: Format is "Date&Time,1or0" that's why follow logic.
            string[] tmpArray = a[i].Split(',');

            float tmpData = 0;


            try
            {
                tmpData = float.Parse(tmpArray[1]);

            }
            catch (FormatException)
            {
                Debug.Log("Unable to float.parse on CountDeviationPlus(): " + tmpArray[1]);

            }




            if ( tmpData - averagedata > 0)
            {
                deviationpluscount++;
            }

        }

        return deviationpluscount;

    }





    public void PreviousTestResult()
    {
        if (SaveNumber == 0)
        {
            Debug.Log("No more data.");
            NoMoreData1.SetActive(true);
            return;
        }

        //Clear chart before drawing new chart
        ClearChart();

        //Clear result matrix before recalling new data
        ClearResultMatrix();

        SaveNumber--;
        ShowResultSummary(TestLogSaveNameList[SaveNumber]);
        NoMoreData2.SetActive(false);


    }



    public void NextTestResult()
    {
        if(SaveNumber >= TestLogSaveNameList.Count - 1)
        {
            Debug.Log("No more data.");
            NoMoreData2.SetActive(true);
            return;
        }


        //Clear chart before drawing new chart
        ClearChart();

        //Clear result matrix before recalling new data
        ClearResultMatrix();

        SaveNumber++;
        ShowResultSummary(TestLogSaveNameList[SaveNumber]);
        NoMoreData1.SetActive(false);


    }


    void ClearResultMatrix()
    {

        SpeedScore.text="";
        SpeedAge.text = "";
        SpeedStatus.text = "";

        AttentionScore.text = "";
        AttentionAge.text = "";
        AttentionStatus.text = "";

        BrainScore.text = "";
        BrainAge.text = "";
        BrainStatus.text = "";

    }


    void ClearChart()
    {
        List<float> allzero1 = new List<float>();
        List<float> allzero2 = new List<float>();

        for(int i=0; i <21; i++)
        {
            allzero1.Add(0.0f);
            allzero2.Add(0.0f);

        }

        DrawChartFloat(allzero1, allzero2);
        ClearValue();

    }

    void ClearValue()
    {

        tmta1temp = 0f;
        tmta2temp = 0f;
        tmta3temp = 0f;
        tmta4temp = 0f;
        tmta5temp = 0f;
        tmta6temp = 0f;
        tmta7temp = 0f;
        tmta8temp = 0f;
        tmta9temp = 0f;
        tmta10temp = 0f;
        tmta11temp = 0f;
        tmta12temp = 0f;
        tmta13temp = 0f;
        tmta14temp = 0f;
        tmta15temp = 0f;
        tmta16temp = 0f;
        tmta17temp = 0f;
        tmta18temp = 0f;
        tmta19temp = 0f;
        tmta20temp = 0f;
        tmta21temp = 0f;

        tmtb1temp = 0f;
        tmtb2temp = 0f;
        tmtb3temp = 0f;
        tmtb4temp = 0f;
        tmtb5temp = 0f;
        tmtb6temp = 0f;
        tmtb7temp = 0f;
        tmtb8temp = 0f;
        tmtb9temp = 0f;
        tmtb10temp = 0f;
        tmtb11temp = 0f;
        tmtb12temp = 0f;
        tmtb13temp = 0f;
        tmtb14temp = 0f;
        tmtb15temp = 0f;
        tmtb16temp = 0f;
        tmtb17temp = 0f;
        tmtb18temp = 0f;
        tmtb19temp = 0f;
        tmtb20temp = 0f;
        tmtb21temp = 0f;

    }





    void DrawChartFloat(List<float> a, List<float> b)
    {


        // For debug /////////////////////////////
        Chart1List.text = "";
        Chart2List.text = "";
        for (int i= 0; i < a.Count; i++){

            Chart1List.text += "a["+i+"]="+a[i].ToString()+" ";
            Chart2List.text += "a[" + i + "]=" + b[i].ToString() + " ";
            if (i % 2 == 1)
            {
                Chart1List.text += "\n";
                Chart2List.text += "\n";

            }
        }
        //////////////////////////////////////////

        TmtaBrainAct1 = a[0];
        TmtaBrainAct2 = a[1];
        TmtaBrainAct3 = a[2];
        TmtaBrainAct4 = a[3];
        TmtaBrainAct5 = a[4];
        TmtaBrainAct6 = a[5];
        TmtaBrainAct7 = a[6];
        TmtaBrainAct8 = a[7];
        TmtaBrainAct9 = a[8];
        TmtaBrainAct10 = a[9];
        TmtaBrainAct11 = a[10];
        TmtaBrainAct12 = a[11];
        TmtaBrainAct13 = a[12];
        TmtaBrainAct14 = a[13];
        TmtaBrainAct15 = a[14];
        TmtaBrainAct16 = a[15];
        TmtaBrainAct17 = a[16];
        TmtaBrainAct18 = a[17];
        TmtaBrainAct19 = a[18];
        TmtaBrainAct20 = a[19];
        TmtaBrainAct21 = a[20];

        TmtbBrainAct1 = b[0];
        TmtbBrainAct2 = b[1];
        TmtbBrainAct3 = b[2];
        TmtbBrainAct4 = b[3];
        TmtbBrainAct5 = b[4];
        TmtbBrainAct6 = b[5];
        TmtbBrainAct7 = b[6];
        TmtbBrainAct8 = b[7];
        TmtbBrainAct9 = b[8];
        TmtbBrainAct10 = b[9];
        TmtbBrainAct11 = b[10];
        TmtbBrainAct12 = b[11];
        TmtbBrainAct13 = b[12];
        TmtbBrainAct14 = b[13];
        TmtbBrainAct15 = b[14];
        TmtbBrainAct16 = b[15];
        TmtbBrainAct17 = b[16];
        TmtbBrainAct18 = b[17];
        TmtbBrainAct19 = b[18];
        TmtbBrainAct20 = b[19];
        TmtbBrainAct21 = b[20];


    }





    void DrawChartStr(List<string> a, List<string> b)
    {



        //左グラフ各カラムにセットしたい値を格納する変数
        TmtaBrainAct1 = float.Parse(a[0]);
        TmtaBrainAct2 = float.Parse(a[1]);
        TmtaBrainAct3 = float.Parse(a[2]);
        TmtaBrainAct4 = float.Parse(a[3]);
        TmtaBrainAct5 = float.Parse(a[4]);
        TmtaBrainAct6 = float.Parse(a[5]);
        TmtaBrainAct7 = float.Parse(a[6]);
        TmtaBrainAct8 = float.Parse(a[7]);
        TmtaBrainAct9 = float.Parse(a[8]);
        TmtaBrainAct10 = float.Parse(a[9]);
        TmtaBrainAct11 = float.Parse(a[10]);
        TmtaBrainAct12 = float.Parse(a[11]);
        TmtaBrainAct13 = float.Parse(a[12]);
        TmtaBrainAct14 = float.Parse(a[13]);
        TmtaBrainAct15 = float.Parse(a[14]);
        TmtaBrainAct16 = float.Parse(a[15]);
        TmtaBrainAct17 = float.Parse(a[16]);
        TmtaBrainAct18 = float.Parse(a[17]);
        TmtaBrainAct19 = float.Parse(a[18]);
        TmtaBrainAct20 = float.Parse(a[19]);
        TmtaBrainAct21 = float.Parse(a[20]);



        TmtbBrainAct1 = float.Parse(b[0]);
        TmtbBrainAct2 = float.Parse(b[1]);
        TmtbBrainAct3 = float.Parse(b[2]);
        TmtbBrainAct4 = float.Parse(b[3]);
        TmtbBrainAct5 = float.Parse(b[4]);
        TmtbBrainAct6 = float.Parse(b[5]);
        TmtbBrainAct7 = float.Parse(b[6]);
        TmtbBrainAct8 = float.Parse(b[7]);
        TmtbBrainAct9 = float.Parse(b[8]);
        TmtbBrainAct10 = float.Parse(b[9]);
        TmtbBrainAct11 = float.Parse(b[10]);
        TmtbBrainAct12 = float.Parse(b[11]);
        TmtbBrainAct13 = float.Parse(b[12]);
        TmtbBrainAct14 = float.Parse(b[13]);
        TmtbBrainAct15 = float.Parse(b[14]);
        TmtbBrainAct16 = float.Parse(b[15]);
        TmtbBrainAct17 = float.Parse(b[16]);
        TmtbBrainAct18 = float.Parse(b[17]);
        TmtbBrainAct19 = float.Parse(b[18]);
        TmtbBrainAct20 = float.Parse(b[19]);
        TmtbBrainAct21 = float.Parse(b[20]);


    }


    // Start is called before the first frame update
    void Start()
    {



        //Get user real age
        MyAge = GetRealAge();

        //Load a save name list
        TestLogSaveNameList = ES3.Load<List<string>>("Es3TestLogSaveNameList");

        //Substitute the latest save number
        SaveNumber = TestLogSaveNameList.Count - 1;

        //Show latest save data
        ShowResultSummary(TestLogSaveNameList[SaveNumber]);


        foreach (var key in TestLogSaveNameList)
        {
            Debug.Log("Save keyname list: " + key);
        }



        /*
        // Es3TestLogSaveNameList
        foreach (var key in ES3.GetKeys())
        {
            Debug.Log("Show all es3 keys: "+ key);
        }
        */




    }
        




    // Update is called once per frame
    void Update()
    {


        if (tmta1temp <= TmtaBrainAct1)
        {
            tmta1temp += spanTime;
            tmtA_1.GetComponent<Slider>().value = tmta1temp;
        }

        if (tmta2temp <= TmtaBrainAct2)
        {
            tmta2temp += spanTime;
            tmtA_2.GetComponent<Slider>().value = tmta2temp;
        }

        if (tmta3temp <= TmtaBrainAct3)
        {
            tmta3temp += spanTime;
            tmtA_3.GetComponent<Slider>().value = tmta3temp;
        }

        if (tmta4temp <= TmtaBrainAct4)
        {
            tmta4temp += spanTime;
            tmtA_4.GetComponent<Slider>().value = tmta4temp;
        }


        if (tmta5temp <= TmtaBrainAct5)
        {
            tmta5temp += spanTime;
            tmtA_5.GetComponent<Slider>().value = tmta5temp;
        }

        if (tmta6temp <= TmtaBrainAct6)
        {
            tmta6temp += spanTime;
            tmtA_6.GetComponent<Slider>().value = tmta6temp;
        }


        if (tmta7temp <= TmtaBrainAct7)
        {
            tmta7temp += spanTime;
            tmtA_7.GetComponent<Slider>().value = tmta7temp;
        }

        if (tmta8temp <= TmtaBrainAct8)
        {
            tmta8temp += spanTime;
            tmtA_8.GetComponent<Slider>().value = tmta1temp;
        }

        if (tmta9temp <= TmtaBrainAct9)
        {
            tmta9temp += spanTime;
            tmtA_9.GetComponent<Slider>().value = tmta1temp;
        }


        if (tmta10temp <= TmtaBrainAct10)
        {
            tmta10temp += spanTime;
            tmtA_10.GetComponent<Slider>().value = tmta10temp;
        }

        if (tmta11temp <= TmtaBrainAct11)
        {
            tmta11temp += spanTime;
            tmtA_11.GetComponent<Slider>().value = tmta11temp;
        }

        if (tmta12temp <= TmtaBrainAct12)
        {
            tmta12temp += spanTime;
            tmtA_12.GetComponent<Slider>().value = tmta12temp;
        }

        if (tmta13temp <= TmtaBrainAct13)
        {
            tmta13temp += spanTime;
            tmtA_13.GetComponent<Slider>().value = tmta13temp;
        }

        if (tmta14temp <= TmtaBrainAct14)
        {
            tmta14temp += spanTime;
            tmtA_14.GetComponent<Slider>().value = tmta14temp;
        }

        if (tmta15temp <= TmtaBrainAct15)
        {
            tmta15temp += spanTime;
            tmtA_15.GetComponent<Slider>().value = tmta15temp;
        }

        if (tmta16temp <= TmtaBrainAct16)
        {
            tmta16temp += spanTime;
            tmtA_16.GetComponent<Slider>().value = tmta16temp;
        }

        if (tmta17temp <= TmtaBrainAct17)
        {
            tmta17temp += spanTime;
            tmtA_17.GetComponent<Slider>().value = tmta17temp;
        }

        if (tmta18temp <= TmtaBrainAct18)
        {
            tmta18temp += spanTime;
            tmtA_18.GetComponent<Slider>().value = tmta18temp;
        }

        if (tmta19temp <= TmtaBrainAct19)
        {
            tmta19temp += spanTime;
            tmtA_19.GetComponent<Slider>().value = tmta19temp;
        }

        if (tmta20temp <= TmtaBrainAct20)
        {
            tmta20temp += spanTime;
            tmtA_20.GetComponent<Slider>().value = tmta20temp;
        }

        if (tmta21temp <= TmtaBrainAct21)
        {
            tmta21temp += spanTime;
            tmtA_21.GetComponent<Slider>().value = tmta21temp;
        }

        if (tmta22temp <= TmtaBrainAct22)
        {
            tmta22temp += spanTime;
            tmtA_22.GetComponent<Slider>().value = tmta22temp;
        }

        if (tmta23temp <= TmtaBrainAct23)
        {
            tmta23temp += spanTime;
            tmtA_23.GetComponent<Slider>().value = tmta23temp;
        }





        if (tmtb1temp <= TmtbBrainAct1)
        {
            tmtb1temp += spanTime;
            tmtB_1.GetComponent<Slider>().value = tmtb1temp;
        }


        if (tmtb2temp <= TmtbBrainAct2)
        {
            tmtb2temp += spanTime;
            tmtB_2.GetComponent<Slider>().value = tmtb2temp;
        }

        if (tmtb3temp <= TmtbBrainAct3)
        {
            tmtb3temp += spanTime;
            tmtB_3.GetComponent<Slider>().value = tmtb3temp;
        }

        if (tmtb4temp <= TmtbBrainAct4)
        {
            tmtb4temp += spanTime;
            tmtB_4.GetComponent<Slider>().value = tmtb4temp;
        }

        if (tmtb5temp <= TmtbBrainAct5)
        {
            tmtb5temp += spanTime;
            tmtB_5.GetComponent<Slider>().value = tmtb5temp;
        }

        if (tmtb6temp <= TmtbBrainAct6)
        {
            tmtb6temp += spanTime;
            tmtB_6.GetComponent<Slider>().value = tmtb6temp;
        }

        if (tmtb7temp <= TmtbBrainAct7)
        {
            tmtb7temp += spanTime;
            tmtB_7.GetComponent<Slider>().value = tmtb7temp;
        }

        if (tmtb8temp <= TmtbBrainAct8)
        {
            tmtb8temp += spanTime;
            tmtB_8.GetComponent<Slider>().value = tmtb8temp;
        }

        if (tmtb9temp <= TmtbBrainAct9)
        {
            tmtb9temp += spanTime;
            tmtB_9.GetComponent<Slider>().value = tmtb9temp;
        }

        if (tmtb10temp <= TmtbBrainAct10)
        {
            tmtb10temp += spanTime;
            tmtB_10.GetComponent<Slider>().value = tmtb10temp;
        }

        if (tmtb11temp <= TmtbBrainAct11)
        {
            tmtb11temp += spanTime;
            tmtB_11.GetComponent<Slider>().value = tmtb11temp;
        }

        if (tmtb12temp <= TmtbBrainAct12)
        {
            tmtb12temp += spanTime;
            tmtB_12.GetComponent<Slider>().value = tmtb12temp;
        }

        if (tmtb13temp <= TmtbBrainAct13)
        {
            tmtb13temp += spanTime;
            tmtB_13.GetComponent<Slider>().value = tmtb13temp;
        }

        if (tmtb14temp <= TmtbBrainAct14)
        {
            tmtb14temp += spanTime;
            tmtB_14.GetComponent<Slider>().value = tmtb14temp;
        }

        if (tmtb15temp <= TmtbBrainAct15)
        {
            tmtb15temp += spanTime;
            tmtB_15.GetComponent<Slider>().value = tmtb15temp;
        }

        if (tmtb16temp <= TmtbBrainAct16)
        {
            tmtb16temp += spanTime;
            tmtB_16.GetComponent<Slider>().value = tmtb16temp;
        }

        if (tmtb17temp <= TmtbBrainAct17)
        {
            tmtb17temp += spanTime;
            tmtB_17.GetComponent<Slider>().value = tmtb17temp;
        }

        if (tmtb18temp <= TmtbBrainAct18)
        {
            tmtb18temp += spanTime;
            tmtB_18.GetComponent<Slider>().value = tmtb18temp;
        }

        if (tmtb19temp <= TmtbBrainAct19)
        {
            tmtb19temp += spanTime;
            tmtB_19.GetComponent<Slider>().value = tmtb19temp;
        }

        if (tmtb20temp <= TmtbBrainAct20)
        {
            tmtb20temp += spanTime;
            tmtB_20.GetComponent<Slider>().value = tmtb20temp;
        }

        if (tmtb21temp <= TmtbBrainAct21)
        {
            tmtb21temp += spanTime;
            tmtB_21.GetComponent<Slider>().value = tmtb21temp;
        }

        if (tmtb22temp <= TmtbBrainAct22)
        {
            tmtb22temp += spanTime;
            tmtB_22.GetComponent<Slider>().value = tmtb22temp;
        }

        if (tmtb23temp <= TmtbBrainAct23)
        {
            tmtb23temp += spanTime;
            tmtB_23.GetComponent<Slider>().value = tmtb23temp;
        }
        


    }


    public void OpenExplanationPanel()
    {
        explanationPanelPage110.SetActive(true);
//        Debug.Log("setActive(true)");
    }

    public void CloseExplanationPanel()
    {
        explanationPanelPage110.SetActive(false);
//        Debug.Log("setActive(false)");
    }


    void MakeDummyXb01Value()
    {

        //Xb01ValueList format is
        // Date&Time, data, onoff, testtype

        // 10sec equals 100records
        // 45sec equals 450records
        // 10sec equals 100records
        // 45sec equals 450records
        // 10sec equals 100records
        // 90+30=120sec 1200records

        //                UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < 100; i++)
        {
            string str;
            string dateandtimestr = "20200101" + "010101";
            string datastr = UnityEngine.Random.Range(1, 100).ToString();
            string onoff = "0";
            string ttype = "Interval1";

            str = dateandtimestr + "," + datastr + "," + onoff + "," + ttype;
            Xb01ValueList.Add(str);

        }

        for (int i = 0; i < 450; i++)
        {
            string str;
            string dateandtimestr = "20200101" + "010101";
            string datastr = UnityEngine.Random.Range(1, 100).ToString();
            string onoff = "1";
            string ttype = "Test1";

            str = dateandtimestr + "," + datastr + "," + onoff + "," + ttype;
            Xb01ValueList.Add(str);

        }
        for (int i = 0; i < 100; i++)
        {
            string str;
            string dateandtimestr = "20200101" + "010101";
            string datastr = UnityEngine.Random.Range(1, 100).ToString();
            string onoff = "0";
            string ttype = "Interva2";

            str = dateandtimestr + "," + datastr + "," + onoff + "," + ttype;
            Xb01ValueList.Add(str);

        }

        for (int i = 0; i < 450; i++)
        {
            string str;
            string dateandtimestr = "20200101" + "010101";
            string datastr = UnityEngine.Random.Range(1, 100).ToString();
            string onoff = "1";
            string ttype = "Test2";

            str = dateandtimestr + "," + datastr + "," + onoff + "," + ttype;
            Xb01ValueList.Add(str);

        }

        for (int i = 0; i < 100; i++)
        {
            string str;
            string dateandtimestr = "20200101" + "010101";
            string datastr = UnityEngine.Random.Range(1, 100).ToString();
            string onoff = "0";
            string ttype = "Interval3";

            str = dateandtimestr + "," + datastr + "," + onoff + "," + ttype;
            Xb01ValueList.Add(str);

        }



    }




    private List<string> GetSpeedAgeTable()
    {
        List<string> retList = new List<string>();

        string[] provisionalSpeedTable = 
        {
            "65,20",
            "64,21",
            "63,22",
            "62,23",
            "61,24",
            "60,25",
            "59,26",
            "58,27",
            "57,28",
            "56,29",
            "55,30",
            "54,31",
            "53,32",
            "52,33",
            "51,34",
            "50,35",
            "49,36",
            "48,37",
            "47,38",
            "46,39",
            "45,40",
            "44,41",
            "43,42",
            "42,43",
            "41,44",
            "40,45",
            "39,46",
            "38,47",
            "37,48",
            "36,49",
            "35,50",
            "34,51",
            "33,52",
            "32,53",
            "31,54",
            "30,55",
            "29,56",
            "28,57",
            "27,58",
            "26,59",
            "25,60",
            "24,61",
            "23,62",
            "22,63",
            "21,64",
            "20,65",
            "19,66",
            "18,67",
            "17,68",
            "16,69",
            "15,70",
            "14,71",
            "13,72",
            "12,73",
            "11,74",
            "10,75",
            "9,76",
            "8,77",
            "7,78",
            "6,79",
            "5,80",
            "4,81",
            "3,82",
            "2,83",
            "1,84",
            "0,85"
        };

        retList.AddRange(provisionalSpeedTable);

        return retList;


    }




    private List<string> GetAttentionAgeTable()
    {
        List<string> retList = new List<string>();

        string[] provisionalAttentionTable =
        {

            "65,20",
            "64,20",
            "63,20",
            "62,21",
            "61,21",
            "60,21",
            "59,22",
            "58,22",
            "57,22",
            "56,23",
            "55,23",
            "54,23",
            "53,24",
            "52,24",
            "51,24",
            "50,25",
            "49,25",
            "48,25",
            "47,26",
            "46,26",
            "45,26",
            "44,27",
            "43,27",
            "42,27",
            "41,28",
            "40,28",
            "39,29",
            "38,29",
            "37,30",
            "36,30",
            "35,31",
            "34,32",
            "33,33",
            "32,34",
            "31,35",
            "30,36",
            "29,37",
            "28,38",
            "27,39",
            "26,40",
            "25,41",
            "24,42",
            "23,43",
            "22,44",
            "21,45",
            "20,46",
            "19,47",
            "18,48",
            "17,49",
            "16,50",
            "15,51",
            "14,52",
            "13,53",
            "12,54",
            "11,55",
            "10,56",
            "9,57",
            "8,58",
            "7,59",
            "6,60",
            "5,61",
            "4,62",
            "3,63",
            "2,64",
            "1,65",
            "0,66"

        };

        retList.AddRange(provisionalAttentionTable);

        return retList;


    }



}
