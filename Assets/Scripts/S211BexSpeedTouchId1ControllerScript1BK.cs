using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.EventSystems;



public class S211BexSpeedTouchId1ControllerScript1BK : MonoBehaviour
{

    //ゲームタイトル
    private string GameTitleString = "Speed Touch";

    //ゲーム説明
    private string GameDescription = 
        "【Speed Touch】You just only tap the buttons in numeral order as quick as you can within the time limit.";
    
        //スコアキー
    private string ScoreKeyName = "SpeedTouch"; 


    //画面遷移
    public PageTransitionControllerScript InstancePageTransitionControllerScript;

    //複製対象オリジナルButton
    public GameObject OriginalButton;

    //Button作成エリア
    public GameObject drawArea;

    //複製したButton
    private GameObject Button;

    //Button作成数
    public int NumberOfButtons;

    //タッチボタンカウント用
    private int CountButtonTouch = 0;

    //正答ボタン番号
    private int TargetId = 1;

    //ボタン再生成カウント
    private int CountForReCreateButtons = 0;



    //
    // スコア
    //


    //正答数、誤答数
    private int CorrectAnswerCount = 0;
    private int WrongAnswerCount = 0;

    //連続正答数
    private int ConsectiveCorrectAnswers = 0;

    //ボーナスポイントカウント
    private int BonusPointCount = 0;



    /* 旧ロジック
     * 
    //過去スコアランク
    //    private int[] PreviousGameScore;
    //過去スコア一覧
    //    private int[] PreviousGameScoreList;
    //新スコアランク
    //    private int[] NewGameScore = new int[5];
    */



    //スコアランキング一覧
    private List<int> ScoreRankingList = new List<int>();

    


    //スコアデータカウント、ES3変数名のサフィックス（keyname0が1つ目のデータ）としても使う
    int ScoreDataCount = 0;

    //新スコアデータインデックス
    int NewScoreDataIndex = 0;

    //新スコア格納キー
    string NewScoreDataKey = "";

    //新スコアデータ保存済フラグ
    bool NewScoreDataSavedFlg = false;


    //ランク（10は初期値でランク外）
    private int RankInt = 10;

    //得点
    private int ScoreInt;

    //コメント1
    private string ResultCommentText1 = "Good!";

    //コメント2
    private string ResultCommentText2 = "Good!";


    //
    //共通ゲームキャンバスの関数を使う
    //

    private GameObject CommonGameCanvasManager;
    private CommonGameCanvasManagerScript InstanceCommonGameCanvasManagerScript;


    //
    //ゲーム個別の時間管理
    //

    //回答時刻
    public static DateTime[] TouchButtonTime = new DateTime[500];

    //正答時刻
    public static DateTime[] CorrectTouchButtonTime = new DateTime[500];

    //誤答時刻
    public static DateTime[] WrongTouchButtonTime = new DateTime[500];

    //回答平均タイム
    private static double AverageTimeTouch;

    //正答平均タイム
    private static double AverageTimeCorrectTouch;

    //誤答平均タイム（＝集中力？）
    private static double AverageTimeWrongTouch;





    public bool TouchButton( string id )
    {

        //デバッグ用に画面にログを出す
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("TouchButtonIn");


        //タッチした時刻の記録
        TouchButtonTime[CountButtonTouch] = DateTime.Now;


        //回答数カウントアップ
        CountButtonTouch++;


        //正否判定
        if ( TargetId.ToString() == id)
        {
            //あっていたら
            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("TouchButtonCorrect");

            //正解音を出す
            InstanceCommonGameCanvasManagerScript.DoSoundCorrectAnswer();

            //正答時刻の記録
            CorrectTouchButtonTime[CountButtonTouch] = DateTime.Now;

            //平均正答時間の更新
            //ゲーム終了時に時間をタッチボタン数で割ってやれば良いので
            //ここでは記載しない

            //正解カウントアップ
            CorrectAnswerCount++;

            //連続正答数カウントアップ
            ConsectiveCorrectAnswers++;

            //スコア加算１（単純累積）
            ScoreInt += 200;
            InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
            InstanceCommonGameCanvasManagerScript.SetAddRealTimeScore(200);

            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("スコア１加算済み");

            //スコア加算２（ボーナス１：10連続ミスなし）
            if (ConsectiveCorrectAnswers == 10)
            {
                ScoreInt += 400;
                ConsectiveCorrectAnswers = 0;
                BonusPointCount++;
                InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(400);

            }

            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("ボーナス１設定済み");


            //スコア加算３（ボーナス２：即反応0.5秒以内）
            TimeSpan ElapsedTime = CorrectTouchButtonTime[CountButtonTouch] - CorrectTouchButtonTime[CountButtonTouch - 1];
            Debug.Log("ElapsedTime.Milliseconds: " + ElapsedTime.Milliseconds);


            if (ElapsedTime.Milliseconds < 300)
            {
                ScoreInt += 300;
                ConsectiveCorrectAnswers = 0;
                BonusPointCount++;
                InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(300);
            }

            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("ボーナス２設定済み");



            //コメントプレフィックス１
            string comment1 = "Great Responce!";

            //コメントサフィックス２
            string comment2 = "You Can Do Better Next Time!";


            //リザルトをテキストに変換
            string ScoreText = ScoreInt.ToString()+"pt!";

            string ResultText = comment1+"\n"+ScoreText+"\n"+comment2;


            //リザルトへ書込み
            InstanceCommonGameCanvasManagerScript.SetResultText(ResultText);

            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("リザルト書込み済み");


            //過去スコアリストに今回スコアを追加するため過去スコア要素数＋１のインデックスを
            //Start()で準備して使う
            ScoreRankingList[NewScoreDataIndex] = ScoreInt;



            //スコアリストに今回スコアを入れてもすぐにソートはしない
            //本クラスで終了判定を行っていないため
            //どの時点のスコアが最終スコアとなるか不明なため
            //ただし今回スコアは得点が伸びるたびに当該変数を
            //過去スコアと比較してランキングに反映する
            //ソートは次回呼出し時に行う

            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("ランキング設定前");


            //ランキングへの書込み            
            if (ScoreInt < ScoreRankingList[4])
            {
                Debug.Log("５位以下");
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[3]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[4]);
            }
            if (ScoreInt > ScoreRankingList[4])
            {
                Debug.Log("５位");
                RankInt = 5;
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[3]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreInt);

            }
            if (ScoreInt > ScoreRankingList[3])
            {
                Debug.Log("４位");

                RankInt = 4;
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreInt);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[3]);

            }
            if (ScoreInt > ScoreRankingList[2])
            {
                Debug.Log("３位");
                RankInt = 3;
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreInt);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[3]);

            }
            if (ScoreInt > ScoreRankingList[1])
            {
                Debug.Log("２位");

                RankInt = 2;
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreInt);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[3]);

            }
            if (ScoreInt > ScoreRankingList[0])
            {
                Debug.Log("１位");

                RankInt = 1;
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreInt);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[3]);

            }

            


            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("ランキング設定済み");


            //ランクに入っていればハイライト
            InstanceCommonGameCanvasManagerScript.SetHighlightRank(RankInt);
//            Debug.Log("ハイライト済み");


            //今回スコアをランキング画面にセット
            InstanceCommonGameCanvasManagerScript.SetThisTimeScoreText(ScoreInt.ToString());
//            Debug.Log("スコアセット済み");


            //今回スコアに資したアクションをセット
            InstanceCommonGameCanvasManagerScript.SetThisTimeScoreMainActionText(CorrectAnswerCount.ToString());
//            Debug.Log("アクションセット済み");


            //ボーナスポイント回数をセット
            InstanceCommonGameCanvasManagerScript.SetThisTimeBonusCountText(BonusPointCount.ToString());
//            Debug.Log("ボーナスポイントセット済み");


            //ボタン再生成管理カウントアップ
            CountForReCreateButtons++;


            //正答ボタン番号更新（+1）
            TargetId++;


            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("TouchButtonOut");

            //Trueを返却して呼び出し元でボタン消す
            return true;

        }
        else
        {
            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("MisTouchButtonIn");

            //間違っていたら

            //不正解音を出す
            InstanceCommonGameCanvasManagerScript.DoSoundWrongAnswer();


            //誤答時間の記録
            WrongTouchButtonTime[CountButtonTouch] = DateTime.Now;


            //不正解カウントアップ
            WrongAnswerCount++;


            //連続正答数リセット
            ConsectiveCorrectAnswers = 0;


            //Falseを返却して呼び出し元では何もしない
            return false;

        }



    }





    // Start is called before the first frame update
    void Start()
    {

        //画面遷移用にオブジェクト

        //共通ゲームキャンバスオブジェクト＆インスタンス取得
        CommonGameCanvasManager = GameObject.Find("CommonGameCanvasManager");
        InstanceCommonGameCanvasManagerScript = CommonGameCanvasManager.GetComponent<CommonGameCanvasManagerScript>();

        //ゲームタイトルをランキングにセット
        InstanceCommonGameCanvasManagerScript.SetThisGameTitleText(GameTitleString);

        //ゲーム説明をセット
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(GameDescription);

        //デバッグ用に画面にログを出す
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("Start");


        //スコアリストをロードする

        
        //過去データをあるだけ抽出してリストに保存するループ
        while (true)
        {
            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(ScoreDataCount.ToString());

            //ScoreKeyNameはグローバル変数でスコア番号サフィックス(scoreDataCount)をつけて配列管理
            string keyname = ScoreKeyName + ScoreDataCount;

            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(keyname);

            //存在チェック関数KeyExists
            bool existsKeyFlg = ES3.KeyExists(keyname);
            int existsKey = ES3.Load<int>(keyname, defaultValue: 404);

//            existsKey = ScoreRankingList.Add(PlayerPrefs.GetInt(keyname, 404));


            //デバッグ用に画面にログを出す
            InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("nothing");


            //存在なし=falseでデータ抜出しループブレイク
            if (existsKey == 404) { break; }
            if (existsKeyFlg == false) { break; }


            //存在ありでリストに保存
            ScoreRankingList.Add(ES3.Load<int>(keyname));
 //           ScoreRankingList.Add(PlayerPrefs.GetInt(keyname, 404));







            //デバッグ用に画面にログを出す
            //InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(ES3.Load<int>(keyname).ToString());


            //次のデータ抽出のためカウントアップ値＝データ件数
            ScoreDataCount++;
        }



        //デバッグ用に画面にログを出す
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("過去データ抽出完了");


        //得られた過去データを昇順にソートしておく
        ScoreRankingList.Sort();

        //過去データリストを配列順に得点の高い順に逆ソートしておく
        ScoreRankingList.Reverse();

        //ダミーデータを追加して新規スコア追加用の要素を用意する
        ScoreRankingList.Add(99999);
        NewScoreDataIndex = ScoreRankingList.IndexOf(99999);
        ScoreRankingList[NewScoreDataIndex]  = 0;



        //新規スコア追加用のセーブキーを用意しておく
        NewScoreDataKey = ScoreKeyName + NewScoreDataIndex;
        Debug.Log("NewScoreDataKey: " + NewScoreDataKey);

        //デバッグ用に画面にログを出す
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("新規スコア追加用キー完了");


        //何もボタンを押さなかった場合の処理として過去データをランキングに入れておく
        //過去データは昇順に並べているので最後の要素が最大値＝ランキング１
        if (ScoreRankingList.Count > 5)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[3]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(ScoreRankingList[4]);
        }
        else if (ScoreRankingList.Count == 4)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(ScoreRankingList[3]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(0);
        }
        else if (ScoreRankingList.Count == 3)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(ScoreRankingList[2]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(0);
        }
        else if (ScoreRankingList.Count == 2)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(ScoreRankingList[1]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(0);
        }
        else if (ScoreRankingList.Count == 1)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(ScoreRankingList[0]);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(0);
        }
        else if (ScoreRankingList.Count == 0)
        {
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(0);
            InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(0);
        }


        //スタート時のボタン生成
        CreateButtons();


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


        if (InstanceCommonGameCanvasManagerScript.GetTotalRestSeconds() < 0f)
        {

            if (NewScoreDataSavedFlg == false)
            {

                //今回スコアをデータセーブ
                ES3.Save<int>(NewScoreDataKey, ScoreInt);
                Debug.Log("データセーブ");

//                PlayerPrefs.SetInt(NewScoreDataKey, ScoreInt);


                NewScoreDataSavedFlg = true;

                /*
                //キーを取得
                foreach (var key in ES3.GetKeys())
                {
                    //
                    Debug.Log("key: " + key);
                    //バリューを取得しログに表示
                }
                */

            }

        }






    }



    void CreateButtons()
    {

        //デバッグ用に画面にログを出す
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText("CreateButtons");


        //ボタン生成音
        InstanceCommonGameCanvasManagerScript.DoSoundSetQuestions();

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
//            Debug.Log("j: "+j);
            
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
