using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.EventSystems;



public class Page211BrainExST1ControllerScript : MonoBehaviour
{
    public PageTransitionControllerScript bbbbb;
    GameObject PageController;

    //複製対象オリジナルButton
    public GameObject OriginalButton;

    //Button作成エリア
    public GameObject drawArea;

    //複製したButton
    private GameObject Button;

    //Button作成数
    public int NumberOfButtons;

    //タッチボタンカウント用
    public int CountButtonTouch = 0;

    //正答ボタン番号
    public int TargetId = 1;

    //正答数、誤答数
    public int CorrectAnswerCount = 0;
    public int WrongAnswerCount = 0;

    //ボタン再生成カウント
    public int CountForReCreateButtons = 0;


    //制限時間
    public double LimitTimeSeconds;

    //開始時刻
    public DateTime StartDateTime;

    //終了時刻
    public DateTime LimitDateTime;

    //タッチ時刻
    public static DateTime[] TouchButtonTime = new DateTime[500];

    //正答タッチ時刻
    public static DateTime[] CorrectTouchButtonTime = new DateTime[500];

    //誤答タッチ時刻
    public static DateTime[] WrongTouchButtonTime = new DateTime[500];

    //回答平均タイム
    public static double AverageTimeTouch;

    //正答平均タイム
    public static double AverageTimeCorrectTouch;

    //誤答平均タイム（＝集中力？）
    public static double AverageTimeWrongTouch;

    //終了時リザルト表示エリア
    public GameObject ResultArea;

    //残り時間表示
    public Text RestTime;

    //得点表示
    public Text Score;

    //得点
    private int ScoreInt;

    //結果コメント
    private string ResultCommentText = "Good!";

    //カウントダウンパネル
    public GameObject CountdownPanel;

    //カウントダウンテキスト
    public GameObject Countdown1;
    public GameObject Countdown2;
    public GameObject Countdown3;


    public bool TouchButton( string id )
    {


        //タッチした時刻の記録
        TouchButtonTime[CountButtonTouch] = DateTime.Now;

        //回答数カウントアップ
        CountButtonTouch++;


        //正否判定
        if ( TargetId.ToString() == id)
        {
            //あっていたら

            //正答時刻の記録
            CorrectTouchButtonTime[CountButtonTouch] = DateTime.Now;

            //平均正答時間の更新
            //ゲーム終了時に時間をタッチボタン数で割ってやれば良いので
            //ここでは記載しない


            //正解カウントアップ
            CorrectAnswerCount++;

            //ボタン再生成管理カウントアップ
            CountForReCreateButtons++;

            //正答ボタン番号更新（+1）
            TargetId++;

            //Trueを返却して呼び出し元でボタン消す
            return true;

        }
        else
        {
            //間違っていたら
            //誤答時間の記録
            WrongTouchButtonTime[CountButtonTouch] = DateTime.Now;

            //不正解カウントアップ
            WrongAnswerCount++;

            //Falseを返却して呼び出し元では何もしない
            return false;

        }



    }





    // Start is called before the first frame update
    void Start()
    {

        //カウントダウン用に3秒追加
        LimitTimeSeconds += 3;

        Debug.Log("LimitTimeSecondsに3秒追加したはず："+ LimitTimeSeconds);

        //NGと注意がでている
        //AddComponentならOKとでていたので調べる
        bbbbb = new PageTransitionControllerScript();

        //スタート時のボタン生成
        CreateButtons();

        //スタート時間の記録
        StartDateTime = DateTime.Now;

        //ページ遷移オブジェクトを読込み
//        PageController = GameObject.Find("PageTransitionController");


    }


    // Update is called once per frame
    void Update()
    {
        //ボタン全消えで再度ボタンを生成
        if (NumberOfButtons == CountForReCreateButtons) 
        {
            CreateButtons();
            CountForReCreateButtons = 0;
            TargetId = 1;
        }

        //ゲーム画面起動から経過時間
        TimeSpan ElapsedTime = DateTime.Now - StartDateTime;
        //        Debug.Log(ElapsedTime.Seconds);


        //初回ボタンの作成

        if (ElapsedTime.Seconds == 0)
        {
            //画面に３を出す
            Countdown3.SetActive(true);
        }
        if (ElapsedTime.Seconds == 1)
        {
            //画面に２を出す
            Countdown3.SetActive(false);
            Countdown2.SetActive(true);

        }
        if (ElapsedTime.Seconds == 2)
        {
            Countdown2.SetActive(false);
            Countdown1.SetActive(true);
        }
        if (ElapsedTime.Seconds == 3)
        {
            Countdown1.SetActive(false);
            CountdownPanel.SetActive(false);
        }

        if (ElapsedTime.Seconds < 3)
        {
            RestTime.text = "残り時間：";
        }
        else
        {
            //残り時間の表示
            RestTime.text = "残り時間：" + (LimitTimeSeconds - ElapsedTime.Seconds).ToString();
        }

        //経過時間が指定時間の３秒前でカウントダウン
        if (ElapsedTime.Seconds > LimitTimeSeconds - 3)
        {
            //音を出す
        }

        //経過時間が指定時間の３秒前でカウントダウン
        if (ElapsedTime.Seconds > LimitTimeSeconds - 2)
        {
            //音を出す
        }

        //経過時間が指定時間の３秒前でカウントダウン
        if (ElapsedTime.Seconds > LimitTimeSeconds - 1)
        {
            //音を出す

        }


        //経過時間が指定時間を超過していたら終了し、結果画面を表示
        if (ElapsedTime.Seconds > LimitTimeSeconds)
        {
            //終了時時間の記録
            LimitDateTime = DateTime.Now;

            //スコアの計算
            ScoreInt = CountButtonTouch * 200;

            //コメントの選択
            if( WrongAnswerCount == 0)
            {
                ResultCommentText = "Great! No Mistake!\n";
            }

            if ( CountButtonTouch == 0)
            {
                ResultCommentText = "No Touch, No Gain!\nTry Again!\n";

            }


            //結果画面のテキストを表示
            Score.text = ResultCommentText+ScoreInt +"pt!";
            

            //結果画面を表示
            ResultArea.SetActive(true);

            //残り時間をゼロ表示
            RestTime.text = "残り時間：0";
        }
    

        //結果画面の表出後に5秒たったら難易度選択画面に戻る
        if (ElapsedTime.Seconds > LimitTimeSeconds + 5)
        {

            bbbbb.MoveToBrainExMenu();

        }



    }



    void CreateButtons()
    {

        //画面サイズ
        float DrawAreaSizeX = 360.0f;
        float DrawAreaSizeY = 460.0f;

        //ボタンサイズ
        // 幅
        float ButtonWidth = OriginalButton.GetComponent<RectTransform>().sizeDelta.x;
        // 高さ
        float ButtonHeight = OriginalButton.GetComponent<RectTransform>().sizeDelta.y;

        //タップしやすいようにマージン
        float MarginX = 10f;
        float MarginY = 10f;

        //画面からはみ出さないように
        //ボタンの半分のサイズおよび
        //マージンを両側から除いた描写エリア
        float DrawTargetAreaSizeX = DrawAreaSizeX - ButtonWidth  - MarginX;
        float DrawTargetAreaSizeY = DrawAreaSizeY - ButtonHeight - MarginY;


        //        float x = 0f;
        //        float y = 0f;

        float[] x = new float[NumberOfButtons];
        float[] y = new float[NumberOfButtons];

        int j = 0;
        while (j < NumberOfButtons)
        {
            Debug.Log("j: "+j);
            
            x[j] = UnityEngine.Random.Range(-DrawTargetAreaSizeX / 2, DrawTargetAreaSizeX / 2);
            y[j] = UnityEngine.Random.Range(-DrawTargetAreaSizeY / 2, DrawTargetAreaSizeY / 2);


            //            Debug.Log(x[j]+" , "+y[j]);

            //
            //  もし二点間の距離がボタンサイズ＋α以下なら再度作る
            //


            //初回ボタンは他のボタンと距離を比較する必要がないので以降処理をスキップ
            if (j == 0)
            {
                j++;
                continue;
            }

            int p = 0;
            for (int k = 1; k < (j+1); k++)
            {
                //各軸の差分を取得
                float defx = x[j] - x[j - k];
                float defy = y[j] - y[j - k];

                //2点間の距離を取得
                float distance = Mathf.Sqrt(defx * defx + defy * defy);

//                Debug.Log("distance: " + distance);


                //2点間の距離が指定より短い組合せをpでカウント
                if (distance < 55f)
                {
//                    Debug.Log("distance<30");
                    p++;
                }

            }

            //pが1以上ならjをカウントしない
            if (p > 0) {
                continue;
            }

            //j番目のボタン位置を算出できたのでj+1のボタンへ
            j++;

        }


        for (int i = 0; i < NumberOfButtons; i++)
        {

            //ボタンを新規作成し、以降で扱い易いようにオブジェクトに代入
            Button = Instantiate(OriginalButton, new Vector3(x[i], y[i], 0), Quaternion.identity);

            //新規作成したボタンに紐づく子要素を取得
            foreach (Transform child in Button.transform)
            {
                //子要素はテキストオブジェクトなのでテキストコンポーネントを取得
                Text ButtonNumber = child.GetComponent<Text>();
                ButtonNumber.text = (i + 1).ToString();
            }

            Button.transform.SetParent(drawArea.transform, false);

        }



    }






}
