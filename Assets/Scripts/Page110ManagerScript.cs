using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

//StringBuilder用
using System.Text;



public class Page110ManagerScript : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {


        //左グラフ各カラムにセットしたい値を格納する変数
        TmtaBrainAct1 = 10f;
        TmtaBrainAct2 = 20f;
        TmtaBrainAct3 = 30f;
        TmtaBrainAct4 = 40f;
        TmtaBrainAct5 = 50f;
        TmtaBrainAct6 = 60f;
        TmtaBrainAct7 = 70f;
        TmtaBrainAct8 = 60f;
        TmtaBrainAct9 = 50f;
        TmtaBrainAct10 = 50f;
        TmtaBrainAct11 = 60f;
        TmtaBrainAct12 = 40f;
        TmtaBrainAct13 = 30f;
        TmtaBrainAct14 = 20f;
        TmtaBrainAct15 = 20f;
        TmtaBrainAct16 = 30f;
        TmtaBrainAct17 = 40f;
        TmtaBrainAct18 = 50f;
        TmtaBrainAct19 = 60f;
        TmtaBrainAct20 = 60f;
        TmtaBrainAct21 = 70f;
        TmtaBrainAct22 = 70f;
        TmtaBrainAct23 = 60f;

        TmtbBrainAct1 = 30f;
        TmtbBrainAct2 = 40f;
        TmtbBrainAct3 = 50f;
        TmtbBrainAct4 = 60f;
        TmtbBrainAct5 = 80f;
        TmtbBrainAct6 = 90f;
        TmtbBrainAct7 = 90f;
        TmtbBrainAct8 = 70f;
        TmtbBrainAct9 = 50f;
        TmtbBrainAct10 = 50f;
        TmtbBrainAct11 = 40f;
        TmtbBrainAct12 = 30f;
        TmtbBrainAct13 = 40f;
        TmtbBrainAct14 = 40f;
        TmtbBrainAct15 = 30f;
        TmtbBrainAct16 = 30f;
        TmtbBrainAct17 = 40f;
        TmtbBrainAct18 = 50f;
        TmtbBrainAct19 = 60f;
        TmtbBrainAct20 = 70f;
        TmtbBrainAct21 = 70f;
        TmtbBrainAct22 = 80f;
        TmtbBrainAct23 = 90f;



        ResultSpeed = textResultSpeed.GetComponent<Text>();
        ResultAttention = textResultAttention.GetComponent<Text>();
        ResultBrain = textResultBrain.GetComponent<Text>();
        ResultDeclines = textResultDeclines.GetComponent<Text>();


        //初期化処理
        //Start()の中で計算して描画関数で値を更新
        ResultSpeed.text = "Calculating. . .";
        ResultAttention.text = "Calculating. . .";
        ResultBrain.text = "Calculating. . .";
        ResultDeclines.text = "Calculating. . .";


        /*  
          *  
          *  TMT1
          *  
          *  プレフィックス＝　TMT1_
          *  
          *  
          */

        /*
        //全タッチ関連静的変数
        public static int pushDownTask1 = 0;
        public static int pdtTask1 = 0;
        public static DateTime[] pushDownTimeTask1 = new DateTime[500];
        public static TimeSpan totalTapTimePushDownTask1;
        public static double meanTimePushDownTask1;
        public static double maxTaptimePushDownTask1 = 0;
        public static double minTaptimePushDownTask1 = 0;
        //15秒で110回プッシュできたので45秒で330回
        //60秒までの拡張を見越して440回で500回に
        */

        //総タッチ数
        int tmt1_pushDownTask1 = Page70GameManagerScript.GetPushDownTask1();
        //総タッチ各タッチ時刻
        DateTime[] tmt1_pushDownTimeTask1 = Page70GameManagerScript.GetPushDownTimeTask1();
        //総タッチ平均タッチ時間
        double tmt1_meanTimePushDownTask1 = Page70GameManagerScript.GetMeanTimePushDownTask1();
        //総タッチ最大（最遅）タッチ時間
        double tmt1_maxTaptimePushDownTask1 = Page70GameManagerScript.GetMaxTaptimePushDownTask1();
        //総タッチ最小（最速）タッチ時間
        double tmt1_minTaptimePushDownTask1 = Page70GameManagerScript.GetMinTaptimePushDownTask1();

//        Debug.Log("Page70GameManagerScript.tmt1__pushDownTask1" + tmt1_pushDownTask1);
        Debug.Log("Page70GameManagerScript.tmt1__meanTimePushDownTask1" + tmt1_meanTimePushDownTask1);
//        Debug.Log("Page70GameManagerScript.tmt1__maxTaptimePushDownTask1" + tmt1_maxTaptimePushDownTask1);
//        Debug.Log("Page70GameManagerScript.tmt1__minTaptimePushDownTask1" + tmt1_minTaptimePushDownTask1);
    
        /*
        //正答タッチ数関連静的変数
        public static int rightPushTask1 = 0;
        public static int rptTask1 = 0;
        public static DateTime[] rightPushTimeTask1 = new DateTime[180];
        public static TimeSpan totalTapTimeRightPushTask1;
        public static double meanTimeRightPushTask1;
        public static double maxTaptimeRightPushTask1 = 0;
        public static double minTaptimeRightPushTask1 = 0;
        */

        //正答タッチ数
        int tmt1_rightPushTask1 = Page70GameManagerScript.GetRightPushTask1();
        //正答タッチ各タッチ時刻
        DateTime[] tmt1_rightPushTimeTask1 = Page70GameManagerScript.GetRightPushTimeTask1();
        //正答タッチ平均タッチ時間
        double tmt1_meanTimeRightPushTask1 = Page70GameManagerScript.GetMeanTimeRightPushTask1();
        //正答タッチ最大（最遅）タッチ時間
        double tmt1_maxTaptimeRightPushTask1 = Page70GameManagerScript.GetMaxTaptimeRightPushTask1();
        //正答タッチ最小（最速）タッチ時間
        double tmt1_minTaptimeRightPushTask1 = Page70GameManagerScript.GetMinTaptimeRightPushTask1();

        /*
        Debug.Log("Page70GameManagerScript.rightPushTask1" + tmt1_rightPushTask1);
        Debug.Log("Page70GameManagerScript.meanTimeRightPushTask1" + tmt1_meanTimeRightPushTask1);
        Debug.Log("Page70GameManagerScript.maxTaptimeRightPushTask1" + tmt1_maxTaptimeRightPushTask1);
        Debug.Log("Page70GameManagerScript.minTaptimeRightPushTask1" + tmt1_minTaptimeRightPushTask1);
        */

        /*
        //誤答タッチ数関連静的変数
        public static int wrongPushTask1 = 0;
        public static int wptTask1 = 0;
        public static DateTime[] wrongPushTimeTask1 = new DateTime[500];
        public static TimeSpan totalTapTimeWrongPushTask1;
        public static double meanTimeWrongPushTask1;
        public static double maxTaptimeWrongPushTask1 = 0;
        public static double minTaptimeWrongPushTask1 = 0;
        */

        //誤答タッチ数
        int tmt1_wrongPushTask1 = Page70GameManagerScript.GetWrongPushTask1();
        //誤答タッチ各タッチ時刻
        DateTime[] tmt1_wrongPushTimeTask = Page70GameManagerScript.GetWrongPushTimeTask1();
        //誤答タッチ平均タッチ時間
        double tmt1_meanTimeWrongPushTask1 = Page70GameManagerScript.GetMeanTimeWrongPushTask1();
        //誤答タッチ最大（最遅）時間
        double tmt1_maxTaptimeWrongPushTask1 = Page70GameManagerScript.GetMaxTaptimeWrongPushTask1();
        //誤答タッチ最小（最速）時間    
        double tmt1_minTaptimeWrongPushTask1 = Page70GameManagerScript.GetMinTaptimeWrongPushTask1();

        /*
        Debug.Log("Page70GameManagerScript.wrongPushTask1" + tmt1_wrongPushTask1);
        Debug.Log("Page70GameManagerScript.meanTimeWrongPushTask1" + tmt1_meanTimeWrongPushTask1);
        Debug.Log("Page70GameManagerScript.maxTaptimeWrongPushTask1" + tmt1_maxTaptimeWrongPushTask1);
        Debug.Log("Page70GameManagerScript.minTaptimeWrongPushTask1" + tmt1_minTaptimeWrongPushTask1);
        */

        /*  
         *  
         *  TMT2
         *  
         *  プレフィックス＝　TMT2_
         *  
         *  
         */

        /*
        //全タッチ関連静的変数のグローバル変数（別クラスで宣言）
        public static int pushDownTask1 = 0;
        public static int pdtTask1 = 0;
        public static DateTime[] pushDownTimeTask1 = new DateTime[500];
        public static TimeSpan totalTapTimePushDownTask1;
        public static double meanTimePushDownTask1;
        public static double maxTaptimePushDownTask1 = 0;
        public static double minTaptimePushDownTask1 = 0;
        //15秒で110回プッシュできたので45秒で330回
        //60秒までの拡張を見越して440回で500回に
        */
        //
        int tmt2_pushDownTask1 = Page90GameManagerScript.GetPushDownTask1();
        DateTime[] tmt2_pushDownTimeTask1 = Page90GameManagerScript.GetPushDownTimeTask1();
        double tmt2_meanTimePushDownTask1 = Page90GameManagerScript.GetMeanTimePushDownTask1();
        double tmt2_maxTaptimePushDownTask1 = Page90GameManagerScript.GetMaxTaptimePushDownTask1();
        double tmt2_minTaptimePushDownTask1 = Page90GameManagerScript.GetMinTaptimePushDownTask1();

        /*
        Debug.Log("Page90GameManagerScript.pushDownTask1" + tmt2_pushDownTask1);
        Debug.Log("Page90GameManagerScript.meanTimePushDownTask1" + tmt2_meanTimePushDownTask1);
        Debug.Log("Page90GameManagerScript.maxTaptimePushDownTask1" + tmt2_maxTaptimePushDownTask1);
        Debug.Log("Page90GameManagerScript.minTaptimePushDownTask1" + tmt2_minTaptimePushDownTask1);
        */

        //タッチ正答数関連静的変数
        /*
        //タッチ正答数のグローバル変数（別クラスで宣言）
        public static int rightPushTask1 = 0;
        public static int rptTask1 = 0;
        public static DateTime[] rightPushTimeTask1 = new DateTime[180];
        public static TimeSpan totalTapTimeRightPushTask1;
        public static double meanTimeRightPushTask1;
        public static double maxTaptimeRightPushTask1 = 0;
        public static double minTaptimeRightPushTask1 = 0;
        */

        //タッチ正答数
        int tmt2_rightPushTask1 = Page90GameManagerScript.GetRightPushTask1();
        DateTime[] tmt2_rightPushTimeTask1 = Page90GameManagerScript.GetRightPushTimeTask1();
        double tmt2_meanTimeRightPushTask1 = Page90GameManagerScript.GetMeanTimeRightPushTask1();
        double tmt2_maxTaptimeRightPushTask1 = Page90GameManagerScript.GetMaxTaptimeRightPushTask1();
        double tmt2_minTaptimeRightPushTask1 = Page90GameManagerScript.GetMinTaptimeRightPushTask1();

        /*
        Debug.Log("Page90GameManagerScript.rightPushTask1" + tmt2_rightPushTask1);
        Debug.Log("Page90GameManagerScript.meanTimeRightPushTask1" + tmt2_meanTimeRightPushTask1);
        Debug.Log("Page90GameManagerScript.maxTaptimeRightPushTask1" + tmt2_maxTaptimeRightPushTask1);
        Debug.Log("Page90GameManagerScript.minTaptimeRightPushTask1" + tmt2_minTaptimeRightPushTask1);
        */

        /*
        //タッチ誤答数のグローバル変数（別クラスで宣言）
        public static int wrongPushTask1 = 0;
        public static int wptTask1 = 0;
        public static DateTime[] wrongPushTimeTask1 = new DateTime[500];
        public static TimeSpan totalTapTimeWrongPushTask1;
        public static double meanTimeWrongPushTask1;
        public static double maxTaptimeWrongPushTask1 = 0;
        public static double minTaptimeWrongPushTask1 = 0;
        */

        int tmt2_wrongPushTask1 = Page90GameManagerScript.GetWrongPushTask1();
        DateTime[] tmt2_wrongPushTimeTask = Page90GameManagerScript.GetWrongPushTimeTask1();
        double tmt2_meanTimeWrongPushTask1 = Page90GameManagerScript.GetMeanTimeWrongPushTask1();
        double tmt2_maxTaptimeWrongPushTask1 = Page90GameManagerScript.GetMaxTaptimeWrongPushTask1();
        double tmt2_minTaptimeWrongPushTask1 = Page90GameManagerScript.GetMinTaptimeWrongPushTask1();

        /*
        Debug.Log("Page90GameManagerScript.wrongPushTask1" + tmt2_wrongPushTask1);
        Debug.Log("Page90GameManagerScript.meanTimeWrongPushTask1" + tmt2_meanTimeWrongPushTask1);
        Debug.Log("Page90GameManagerScript.maxTaptimeWrongPushTask1" + tmt2_maxTaptimeWrongPushTask1);
        Debug.Log("Page90GameManagerScript.minTaptimeWrongPushTask1" + tmt2_minTaptimeWrongPushTask1);
        */



        /***************      リザルトの計算         ************/

        //入力した年齢を取得
        int getInputAge = InputManagerScript.GetInputAge();

        //低下している認知機能リスト出力用オブジェクト
        StringBuilder resultDeclines = new StringBuilder();
        string resultDecline;


        //
        //平均処理速度
        //処理速度のスコア、順位など
        //TMT1のみ利用する（TMT2は注意力や作動記憶を必要とするため）
        //または誤答は勘案せずにTMT1とTMT2を使うか
        //TMT2は悩むのでタッチ数が少なくなるがそれがスコアに
        //反映されると納得感があるかもしれない
        //0.5歩先で難易度が高い状態にしておく
        //


        //処理速度スコアを計算する
        //この関数Start()で宣言した変数でグローバル変数を取得している

        //
        //若者は4周できるとするとタッチ個数＝点数
        //

        //int calc_ten_speed = tmt1_pushDownTask1;

        //暫定で一律62点
        //        int calc_ten_speed = 62;

        int calc_ten_speed = CalcScoreSpeed();

        if (calc_ten_speed > 99)
        {
            calc_ten_speed = 100;
        }

        //処理速度年齢を取得する
        int calc_age_speed = CalcAgeSpeed(calc_ten_speed);


        /*
         *○✕評価
         * 自分の年齢+-10歳は○
         * 自分の年齢+11歳以上は◎
         * 自分の年齢-11歳以上は△
         */

        string str_hantei_speed = "";
        if ( getInputAge - calc_age_speed > 11)
        {
            str_hantei_speed = "◎";
        }
        else if( getInputAge - calc_age_speed <  - 11)
        {
            str_hantei_speed = "△";
            resultDecline = "処理速度　";
            resultDeclines.Append(resultDecline);

        }
        else
        {
            str_hantei_speed = "○";
        }


        StringBuilder result_speed = new StringBuilder();
        string str_calc_ten_speed = calc_ten_speed.ToString();
        string str_calc_age_speed = calc_age_speed.ToString();

//        result_speed.Append( str_calc_ten_speed + "点　");
//        result_speed.Append( str_calc_age_speed + "歳　");
        result_speed.Append(str_calc_ten_speed + "　　　");
        result_speed.Append(str_calc_age_speed + "　　　");
        result_speed.Append( str_hantei_speed);

        //以下の結果をInvokeで描画関数で実行してタメをもたせる
        //ResultSpeed.text = result_speed.ToString();
        rSpeed = result_speed.ToString();

        //
        //注意力
        //注意力のスコア、順位など
        //TMT1、TMT2を利用する
        //回答総数に対する誤答数の数か
        //回答総数が少ないかつ誤答数が少ない場合の扱いを考える
        //TMT2の回答総数はTMT1の○％減まで認める
        //それ以下だと注意力は低いとみなす
        //ゆっくりの場合は注意力を発揮していないとと考える
        //
        //注意力は注意する対象を定義する必要があるため
        //それが今提示のものであっても過去の経験記憶のものであっても
        //作動記憶が必要となる
        //

        //注意力スコアを計算する
        //この関数Start()で宣言した変数でグローバル変数を取得している

        //暫定で72点を表示する
        //      int calc_ten_attention = 72;

        int calc_ten_attention = CalcScoreAttention();

        if (calc_ten_attention > 99)
        {
            calc_ten_attention = 100;
        }

        //注意力年齢を取得する
        int calc_age_attention = CalcAgeAttention(calc_ten_attention);

        /*
         *○✕評価
         * 自分の年齢+-10歳は○
         * 自分の年齢+11歳以上は◎
         * 自分の年齢-11歳以上は△
         */

        string str_hantei_attention = "";
        if (getInputAge - calc_age_attention > 11)
        {
            str_hantei_attention = "◎";
        }
        else if (getInputAge - calc_age_attention < - 11)
        {
            str_hantei_attention = "△";
            resultDecline = "注意力　";
            resultDeclines.Append(resultDecline);
        }
        else
        {
            str_hantei_attention = "○";
        }


        StringBuilder result_attention = new StringBuilder();
        string str_calc_ten_attention = calc_ten_attention.ToString();
        string str_calc_age_attention = calc_age_attention.ToString();

//        result_attention.Append(str_calc_ten_attention + "点　");
//        result_attention.Append(str_calc_age_attention + "歳　");
        result_attention.Append(str_calc_ten_attention + "　　　");
        result_attention.Append(str_calc_age_attention + "　　　");
        result_attention.Append(str_hantei_attention);

        //以下の結果をInvokeで描画関数で実行してタメをもたせる
        //ResultAttention.text = result_attention.ToString();
        rAttention = result_attention.ToString();


        //
        //脳活動
        //脳活動のスコア、順位など
        //

        //脳活動スコアを計算する
        //この関数Start()で宣言した変数でグローバル変数を取得している

        //暫定で39点を表示する
        int calc_ten_brain = 39;
        if (calc_ten_brain > 99)
        {
            calc_ten_brain = 100;
        }

        //脳活動年齢を取得する
        int calc_age_brain = CalcAgeBrain(calc_ten_brain);

        /*
         *○✕評価
         * 自分の年齢+-10歳は○
         * 自分の年齢+11歳以上は◎
         * 自分の年齢-11歳以上は△
         * 実年齢　- 計算年齢　＝　11以上なら若い
         * 実年齢 - 計算年齢＝　－11以下なら老いてる
         */


        string str_hantei_brain = "";
        if ( getInputAge - calc_age_brain > 11)
        {
            str_hantei_brain = "◎";
        }
        else if ( getInputAge - calc_age_brain < -11)
        {
            str_hantei_brain = "△";
            resultDecline = "脳活動";
            resultDeclines.Append(resultDecline);
        }
        else
        {
            str_hantei_brain = "○";
        }


        StringBuilder result_brain = new StringBuilder();
        string str_calc_ten_brain = calc_ten_brain.ToString();
        string str_calc_age_brain = calc_age_brain.ToString();

//        result_brain.Append(str_calc_ten_brain + "点　");
//        result_brain.Append(str_calc_age_brain + "歳　");
        result_brain.Append(str_calc_ten_brain + "　　　");
        result_brain.Append(str_calc_age_brain + "　　　");
        result_brain.Append(str_hantei_brain);

        //以下の結果をInvokeで描画関数で実行してタメをもたせる
        //ResultBrainActivity.text = result_brain.ToString();
        rBrain = result_brain.ToString();


        /***************      リザルト表示前にもったいぶる         ************/

        //別スレッドで○秒後に実施する
        //Invokeで呼ばれる関数で後続処理を記載すればよい
        //例えば画面描画とか
        //○f秒後に実行される

        Invoke("ShowResultSpeed", 3.5f);
        Invoke("ShowResultAttention", 4.5f);
        Invoke("ShowResultBrain", 5.5f);

        //低下機能リストはここで文字列化
        rDeclines = resultDeclines.ToString();
        Invoke("ShowResultDeclines", 6.5f);

        /***************      他シーン連携用         ************/

        /*
        //処理速度
        public static int scoreSpeed;  //点
        public static int ageSpeed; //年齢
        public static string classSpeed; //◎○△
        */

        scoreSpeed = calc_ten_speed;
        ageSpeed = calc_age_speed;
        classSpeed = str_hantei_speed;

        /*
        //注意力
        public static int scoreAttention;  //点
        public static int ageAttention; //年齢
        public static string classAttention; //◎○△
        */

        scoreAttention = calc_ten_attention;
        ageAttention = calc_age_attention;
        classAttention = str_hantei_attention;

        /*
        //脳活動
        public static int scoreBrainActivity;  //点
        public static int ageBrainActivity; //年齢
        public static string classBrainActivity; //◎○△
        */

        scoreBrain = calc_ten_brain;
        ageBrain = calc_age_brain;
        classBrain = str_hantei_brain;

        
    }


    int CalcScoreSpeed()
    {
        //返り値の宣言かつ初期化
        int css = 0;

        //速度スコアは　（TMT-Aタッチ総数＋TMT-Bタッチ総数）＊係数SP
        //係数SPは既存データから最小値最大値を0-100に調整する

        //TMT-Aタッチ総数
        int tmtA_TouchCount = Page70GameManagerScript.GetPushDownTask1();

        //TMT-Bタッチ総数
        int tmtB_TouchCount = Page90GameManagerScript.GetPushDownTask1();

        //係数SP
        int sp = 1;

        css = (tmtA_TouchCount + tmtB_TouchCount) * sp;

        if (css > 100) css = 100;

        return css;

    }

    int CalcScoreAttention()
    {
        //返り値の宣言かつ初期化
        int csa = 0;

        //注意力スコアは　（TMT-Bタッチ総数／TMT-Aタッチ総数）＊TMT-A正答数＊係数AT
        //係数アルファは既存データから最小値最大値を0-100に調整する

        //TMT-Aタッチ総数
        int tmtA_TouchCount = 0;
        tmtA_TouchCount = Page70GameManagerScript.GetPushDownTask1();
        if (tmtA_TouchCount == 0)
        {
            csa = 0;
            return csa;
        }



        //TMT-Bタッチ総数
        int tmtB_TouchCount = 0;
        tmtB_TouchCount = Page90GameManagerScript.GetPushDownTask1();
        if (tmtB_TouchCount==0)
        {
            csa = 0;
            return csa;
        }

        //TMT-A正答タッチ数
        int tmtA_rightPushTask1 = 0;
        tmtA_rightPushTask1 = Page70GameManagerScript.GetRightPushTask1();
        if (tmtA_rightPushTask1==0)
        {
            csa = 0;
            return csa;
        }

        //係数AT
        int sp = 1;


        csa = (tmtB_TouchCount / tmtA_TouchCount) * tmtA_rightPushTask1 * sp;
        if (csa > 100) csa = 100;

        return csa;

    }

    void ShowResultDeclines()
    {
        if (rDeclines == "") rDeclines = "特にありません";
        ResultDeclines.text = rDeclines;
        return;
    }


    void ShowResultSpeed()
    {
        ResultSpeed.text = rSpeed;
        return;
    }

    void ShowResultAttention()
    {
        ResultAttention.text = rAttention;
        return;
    }

    void ShowResultBrain()
    {
        ResultBrain.text = rBrain;
        return;
    }


    int CalcAgeSpeed(int a)
    {
        //ここに年齢テーブル
        //点数を入れたらその点を平均点にもつ
        //年齢を返す

        int calc_age;
        calc_age = 50;
        return calc_age;
    }

    int CalcAgeAttention(int a)
    {
        //ここに年齢テーブル
        //点数を入れたらその点を平均点にもつ
        //年齢を返す

        int calc_age;
        calc_age = 30;
        return calc_age;
    }

    int CalcAgeBrain(int a)
    {
        //ここに年齢テーブル
        //点数を入れたらその点を平均点にもつ
        //年齢を返す

        int calc_age;
        calc_age = 25;
        return calc_age;
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


    public void ChangeScene()
    {
        SceneManager.LoadScene("120.詳細1－認知速度");
    }



}
