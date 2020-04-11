using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;


public class S213BexSpeedTouchId3ControllerScript : MonoBehaviour
{

    //ES3デバッグ
    public Text S212ES3Test;

    //
    //デバッグ
    //

    //デバッグテキスト文字列
    string DebugStr = "";
    //画面表示テキスト
    public Text DebugText;




    //
    //ゲーム情報
    //

    //ゲームタイトル
    private string GameTitleString = "Speed Touch 3";

    //ゲーム説明
    private string GameDescription =
    "【Speed Touch】You just only tap the buttons in numerical order as quick as you can within the time limit.";

    //スコアキー
    private string ScoreKeyName = "SpeedTouchId3";


    //ゲームグループ（リザルト画面バックボタン遷移先で使う等）
    private string GameGroupName = "S210BrainExSpeedTouch";



    //
    //ボタン生成関連変数
    //

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
    //セーブ＆ロード＆ランキング
    //

    //保存スコアリスト
    List<int> SaveScoreList;


    //保存スコアロードリスト
    private List<int> ScoreList;


    //旧トップ５
    private int[] OldScoreRanking = new int[5];

    //新トップ５
    private int[] NewScoreRanking = new int[5];

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




    public bool TouchButton(string id)
    {

        DebugText.text = ">TouchButtonCorrect";


        //タッチした時刻の記録
        TouchButtonTime[CountButtonTouch] = DateTime.Now;


        //回答数カウントアップ
        CountButtonTouch++;


        //正否判定
        if (TargetId.ToString() == id)
        {
            //あっていたら
            //デバッグ用に画面にログを出す
            DebugText.text += ">TouchButtonCorrect";

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

            DebugText.text += ">SetScore1";

            //スコア加算２（ボーナス１：10連続ミスなし）
            if (ConsectiveCorrectAnswers == 10)
            {
                ScoreInt += 400;
                ConsectiveCorrectAnswers = 0;
                BonusPointCount++;
                InstanceCommonGameCanvasManagerScript.SetRealTimeScore(ScoreInt.ToString());
                InstanceCommonGameCanvasManagerScript.SetAddRealTimeBonusScore(400);

            }

            DebugText.text += ">SetBonus1";



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

            DebugText.text += ">SetBonus2";



            //コメントプレフィックス１
            string comment1 = "Great Responce!";

            //コメントサフィックス２
            string comment2 = "You Can Do Better Next Time!";


            //リザルトをテキストに変換
            string ScoreText = ScoreInt.ToString() + "pt!";
            string ResultText = comment1 + "\n" + ScoreText + "\n" + comment2;


            //リザルトへ書込み
            InstanceCommonGameCanvasManagerScript.SetResultText(ResultText);

            DebugText.text += ">SetResult";



            //過去スコアリストに今回スコアを追加するため過去スコア要素数＋１のインデックスを
            //Start()で準備して使う
            ScoreList[NewScoreDataIndex] = ScoreInt;






            //ボタン再生成管理カウントアップ
            CountForReCreateButtons++;


            //正答ボタン番号更新（+1）
            TargetId++;


            //デバッグ用に画面にログを出す
            DebugText.text += ">TouchButtonOut";


            //Trueを返却して呼び出し元でボタン消す
            return true;

        }
        else
        {

            //デバッグ用に画面にログを出す
            DebugText.text += ">MisTouchButtonIn";


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

        //共通ゲームキャンバスオブジェクト＆インスタンス取得
        CommonGameCanvasManager = GameObject.Find("CommonGameCanvasManager");
        InstanceCommonGameCanvasManagerScript = CommonGameCanvasManager.GetComponent<CommonGameCanvasManagerScript>();

        DebugText.text = ">Start";


        /*test
        ES3.Save<int>("ES3Test1", 100);
        DebugText.text += ">Save";
        int ES3Test = ES3.Load<int>("ES3Test1");
        DebugText.text += ">Load";
        DebugStr += ES3Test.ToString();
        DebugText.text += DebugStr;
        */



        //ゲームタイトルをランキングにセット
        InstanceCommonGameCanvasManagerScript.SetThisGameTitleText(GameTitleString);


        //ゲーム説明をセット
        InstanceCommonGameCanvasManagerScript.SetGameDescriptionText(GameDescription);


        //過去データのロードと過去データによるランキング初期化
        LoadSavedScoreToMakeRankAndNewScoreIndex();


        DebugText.text += ">NewScoreDataIndex Added";

        //スタート時のボタン生成
        CreateButtons();


    }


    void LoadSavedScoreToMakeRankAndNewScoreIndex()
    {

        bool existsKey = ES3.KeyExists(ScoreKeyName);
        Debug.Log("existsKey: " + existsKey);

        if (existsKey == true)
        {
            DebugText.text += ">Exists:True";
            Debug.Log(DebugText.text);
            SaveScoreList = ES3.Load<List<int>>(ScoreKeyName);

        }
        else
        {
            DebugText.text += ">Exists:false";
            Debug.Log(DebugText.text);
            SaveScoreList = new List<int> { };
        }


        Debug.Log("ScoreList =　SaveScoreList");
        DebugText.text += ">ScoreList =　SaveScoreList";


        //セーブスコアを呼出し
        ScoreList = SaveScoreList;

        Debug.Log("ScoreList.Sort()");
        DebugText.text += ">ScoreList.Sort()";

        //セーブスコアを昇順にソートしておく
        ScoreList.Sort();

        //セーブスコアを得点の高い順に逆ソートしておく
        ScoreList.Reverse();


        //セーブスコアトップ5をランキングしておく（データない場合は-1）
        if (ScoreList.Count > 4)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = ScoreList[3];
            OldScoreRanking[4] = ScoreList[4];

        }
        else if (ScoreList.Count == 4)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = ScoreList[3];
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 3)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = ScoreList[2];
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 2)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = ScoreList[1];
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 1)
        {
            OldScoreRanking[0] = ScoreList[0];
            OldScoreRanking[1] = -1;
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }
        else if (ScoreList.Count == 0)
        {
            OldScoreRanking[0] = -1;
            OldScoreRanking[1] = -1;
            OldScoreRanking[2] = -1;
            OldScoreRanking[3] = -1;
            OldScoreRanking[4] = -1;

        }



        //新規スコア追加用の要素を用意する
        ScoreList.Add(99999);
        NewScoreDataIndex = ScoreList.IndexOf(99999);
        ScoreList[NewScoreDataIndex] = 0;

    }


    void MakeRankAndHighlight()
    {

        if (InstanceCommonGameCanvasManagerScript.GetTotalRestSeconds() < 0f)
        {

            if (NewScoreDataSavedFlg == false)
            {

                //ランキングを計算

                if (ScoreInt < OldScoreRanking[4])
                {
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = OldScoreRanking[3];
                    NewScoreRanking[4] = OldScoreRanking[4];

                }

                if (ScoreInt > OldScoreRanking[4])
                {
                    RankInt = 5;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = OldScoreRanking[3];
                    NewScoreRanking[4] = ScoreInt;
                }

                if (ScoreInt > OldScoreRanking[3])
                {
                    RankInt = 4;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = OldScoreRanking[2];
                    NewScoreRanking[3] = ScoreInt;
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[2])
                {
                    RankInt = 3;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = OldScoreRanking[1];
                    NewScoreRanking[2] = ScoreInt;
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[1])
                {
                    RankInt = 2;
                    NewScoreRanking[0] = OldScoreRanking[0];
                    NewScoreRanking[1] = ScoreInt;
                    NewScoreRanking[2] = OldScoreRanking[1];
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                if (ScoreInt > OldScoreRanking[0])
                {
                    RankInt = 1;
                    NewScoreRanking[0] = ScoreInt;
                    NewScoreRanking[1] = OldScoreRanking[0];
                    NewScoreRanking[2] = OldScoreRanking[1];
                    NewScoreRanking[3] = OldScoreRanking[2];
                    NewScoreRanking[4] = OldScoreRanking[3];
                }

                //ランキングへの書込み（-1で書き込むとランキング表示なし）
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank1(NewScoreRanking[0]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank2(NewScoreRanking[1]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank3(NewScoreRanking[2]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank4(NewScoreRanking[3]);
                InstanceCommonGameCanvasManagerScript.SetGameScoreRank5(NewScoreRanking[4]);





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


                //バックボタンの遷移先を設定
                InstanceCommonGameCanvasManagerScript.SetBackSceneName(GameGroupName);



                //今回スコアをデータセーブ
                ES3.Save<List<int>>(ScoreKeyName, ScoreList);
                NewScoreDataSavedFlg = true;


            }

        }



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


        MakeRankAndHighlight();


    }



    void CreateButtons()
    {




        //ボタン生成音
//        InstanceCommonGameCanvasManagerScript.DoSoundSetQuestions();

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
        float DrawTargetAreaSizeX = DrawAreaSizeX - ButtonWidth - MarginX;
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
            for (int k = 1; k < (j + 1); k++)
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
            if (p > 0)
            {
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
