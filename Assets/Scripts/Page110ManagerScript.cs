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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("=====   page110 start() start   =====================");


        /*広域変数に変更
        Text ResultSpeed = textResultSpeed.GetComponent<Text>();
        Text ResultAttention = textResultAttention.GetComponent<Text>();
        Text ResultBrain = textResultBrain.GetComponent<Text>();
        Text ResultDeclines = textResultDeclines.GetComponent<Text>();
        */
        ResultSpeed = textResultSpeed.GetComponent<Text>();
        ResultAttention = textResultAttention.GetComponent<Text>();
        ResultBrain = textResultBrain.GetComponent<Text>();
        ResultDeclines = textResultDeclines.GetComponent<Text>();


        //初期化処理
        //Start()の中で計算して描画関数で値を更新
        ResultSpeed.text = "計算中. . .";
        ResultAttention.text = "計算中. . .";
        ResultBrain.text = "計算中. . .";
        ResultDeclines.text = "調査中. . .";


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

        result_speed.Append( str_calc_ten_speed + "点　");
        result_speed.Append( str_calc_age_speed + "歳　");
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

        result_attention.Append(str_calc_ten_attention + "点　");
        result_attention.Append(str_calc_age_attention + "歳　");
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

        result_brain.Append(str_calc_ten_brain + "点　");
        result_brain.Append(str_calc_age_brain + "歳　");
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




        Debug.Log("=====   page110 start() end   =====================");

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
        int tmtA_TouchCount = Page70GameManagerScript.GetPushDownTask1();

        //TMT-Bタッチ総数
        int tmtB_TouchCount = Page90GameManagerScript.GetPushDownTask1();

        //TMT-A正答タッチ数
        int tmtA_rightPushTask1 = Page70GameManagerScript.GetRightPushTask1();


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
