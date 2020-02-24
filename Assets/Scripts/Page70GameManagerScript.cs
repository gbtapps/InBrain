using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//StringBuilder用
using System.Text;

public class Page70GameManagerScript : MonoBehaviour
{

    //デバッグ用スコア要素表示変数
    public GameObject spentTime = null;
    public GameObject touches = null;
    public GameObject corrects = null;
    public GameObject wrongs = null;


    //複製対象ボタン
    public GameObject target;

    //複製対象ボタンテキスト
    public GameObject target_text = null; // Textオブジェクト

    //対象ボタン数
    public int numOfTargets;

    //キャンパス
    public GameObject rootCanvas;

    //Button作成エリア
    public GameObject drawArea;

    //Buttonプレファブ
    public GameObject preFabs;

    //Buttonキャンバス
//    public GameObject buttonCanvas;

    //場所判定
    public float[,] posixy = new float[2, 25];

    //対象ボタンカウンタ
    private int buttonCount = 1;

    //成績
    //ループ回数
    //タッチタイミング（正・誤）
    //タッチ正答数
    //タッチ誤答数

    public int loopCount = 1;

    //開始時刻取得（1問目 i=0、2問目 i=1）
    public DateTime[] startDateTime = new DateTime[2];

    //タッチボタン数
    public static int pushDownTask1 = 0;
    public static int pdtTask1 = 0;
    public static DateTime[] pushDownTimeTask1 = new DateTime[500];
    public static TimeSpan totalTapTimePushDownTask1;
    public static double meanTimePushDownTask1;
    public static double maxTaptimePushDownTask1 = 0;
    public static double minTaptimePushDownTask1 = 0;
    //15秒で110回プッシュできたので45秒で330回
    //60秒までの拡張を見越して440回で500回に


    //タッチ正答数
    public static int rightPushTask1 = 0;
    public static int rptTask1 = 0;
    public static DateTime[] rightPushTimeTask1 = new DateTime[180];
    public static TimeSpan totalTapTimeRightPushTask1;
    public static double meanTimeRightPushTask1;
    public static double maxTaptimeRightPushTask1 = 0;
    public static double minTaptimeRightPushTask1 = 0;

    //タッチ誤答数
    public static int wrongPushTask1 = 0;
    public static int wptTask1 = 0;
    public static DateTime[] wrongPushTimeTask1 = new DateTime[500];
    public static TimeSpan totalTapTimeWrongPushTask1;
    public static double meanTimeWrongPushTask1;
    public static double maxTaptimeWrongPushTask1 = 0;
    public static double minTaptimeWrongPushTask1 = 0;
    //誤答ボタンの連打最多はプッシュ可能回数と一致するので
    //pushDownと同一の値を使う


    //プッシュしたボタン数と時刻を記録する関数
    public void PushDown()
    {

        //エディタでアタッチしたテキストを扱えるようにする
        Text touches_text = touches.GetComponent<Text>();

        pushDownTask1++;
        pushDownTimeTask1[pdtTask1] = DateTime.Now;
        //        Debug.Log("pushDownTime[pdt]" + pushDownTime[pdt]);

        //平均プッシュ時間、最大時間、最小時間等を計算する
        //最初のボタン（＝１）を探す箇所はスキップする
        if (pdtTask1 == 0)
        {
            //            Debug.Log("pdtTask1==0:" + pdtTask1);

            TimeSpan diff01 = pushDownTimeTask1[rptTask1] - startDateTime[0];
            //            Debug.Log("diff01" + diff01);

            meanTimePushDownTask1 = diff01.TotalSeconds;
            Debug.Log("meanTimePushDownTask1" + meanTimePushDownTask1);

            maxTaptimePushDownTask1 = diff01.TotalSeconds;
            //            Debug.Log("maxTaptimePushDownTask1" + maxTaptimePushDownTask1);

            minTaptimePushDownTask1 = diff01.TotalSeconds;
            //            Debug.Log("minTaptimePushDownTask1" + minTaptimePushDownTask1);

            ShowResultMonitorPushDownTask1();


            pdtTask1++;
            return;
        }

        //タップ時間を取得する（最大、最小、平均）
        //NとN-1プッシュ時刻の差分＝プッシュ時間を算出
        TimeSpan diff = pushDownTimeTask1[pdtTask1] - pushDownTimeTask1[pdtTask1 - 1];

        //        Debug.Log("diff:" + diff);
        //        Debug.Log("diff.TotalMilliseconds:" + diff.TotalMilliseconds);
        //        Debug.Log("diff.TotalSeconds:" + diff.TotalSeconds);
        //        Debug.Log("diff.TotalMinutes:" + diff.TotalMinutes);

        //平均プッシュ時間＝差分を全て都度合計して都度タップ数で割る
        totalTapTimePushDownTask1 = totalTapTimePushDownTask1 + diff;
//        Debug.Log("totalTapTimePushDownTask1: " + totalTapTimePushDownTask1 + " [" + pdtTask1 + "]");

        meanTimePushDownTask1 = totalTapTimePushDownTask1.TotalSeconds/ pdtTask1;
        //        Debug.Log("meanTimePushDownTask1: " + meanTimePushDownTask1);


        //最大プッシュ時間＝差分の最大値を更新しつづける

        if ( diff.TotalSeconds > maxTaptimePushDownTask1)
        {
            maxTaptimePushDownTask1 = diff.TotalSeconds;
        }
        //        Debug.Log("maxTaptimePushDownTask1: " + maxTaptimePushDownTask1);



        //最小プッシュ時間＝差分の最小値を更新しつづける

        if (diff.TotalSeconds < minTaptimePushDownTask1 || minTaptimePushDownTask1 == 0)
        {
            minTaptimePushDownTask1 = diff.TotalSeconds;
        }
        //        Debug.Log("minTaptimePushDownTask1: " + minTaptimePushDownTask1);

        ShowResultMonitorPushDownTask1();
            
        pdtTask1++;
        
    }



    public void ShowResultMonitorPushDownTask1()
    {
        //エディタでアタッチしたテキストを扱えるようにする
        Text touches_text = touches.GetComponent<Text>();

        //デバック用テキストに出力する
        StringBuilder result = new StringBuilder();
        string heikin = (Math.Truncate(meanTimePushDownTask1 * 100.0) / 100.0).ToString();
        string saisyo = (Math.Truncate(minTaptimePushDownTask1 * 100.0) / 100.0).ToString();
        string saidai = (Math.Truncate(maxTaptimePushDownTask1 * 100.0) / 100.0).ToString();

        result.Append("総タッチ数: " + pushDownTask1);
        result.Append(" 平均(s)=" + heikin);
        result.Append(" 最小(s)=" + saisyo);
        result.Append(" 最大(s)=" + saidai);

        touches_text.text = result.ToString();

    }


    //プッシュしたボタン全ての数のゲッター
    public static int GetPushDownTask1()
    {
        return pushDownTask1;
    }

    //プッシュしたボタン全ての時刻のゲッター
    public static DateTime[] GetPushDownTimeTask1()
    {
        return pushDownTimeTask1;
    }

    //プッシュしたボタン全ての数のゲッター
    public static double GetMeanTimePushDownTask1()
    {
        return meanTimePushDownTask1;
    }

    //プッシュの最大時間間隔
    public static double GetMaxTaptimePushDownTask1()
    {
        return maxTaptimePushDownTask1;
    }

    //プッシュの最小時間間隔
    public static double GetMinTaptimePushDownTask1()
    {
        return minTaptimePushDownTask1;
    }


    public void RightPush()
    {

        rightPushTask1++;
        rightPushTimeTask1[rptTask1] = DateTime.Now;
//        Debug.Log("rightPushTimeTask1[rptTask1]" + rightPushTimeTask1[rptTask1]);

        if (rptTask1 == 0)
        {
            //            Debug.Log("pdtTask1==0:" + pdtTask1);

            TimeSpan diff01 = rightPushTimeTask1[rptTask1] - startDateTime[0];
//            Debug.Log("diff01" + diff01);

            meanTimeRightPushTask1 = diff01.TotalSeconds;
//            Debug.Log("meanTimeRightPushTask1" + meanTimeRightPushTask1);

            maxTaptimeRightPushTask1 = diff01.TotalSeconds;
//            Debug.Log("maxTaptimeRightPushTask1" + maxTaptimeRightPushTask1);

            minTaptimeRightPushTask1 = diff01.TotalSeconds;
//            Debug.Log("minTaptimeRightPushTask1" + minTaptimeRightPushTask1);

            ShowResultMonitorRightPushTask1();

            rptTask1++;
            return;
        }

        //タップ時間を取得する（最大、最小、平均）
        //NとN-1タップ時刻の差分＝タップ時間を算出

        TimeSpan diff = rightPushTimeTask1[rptTask1] - rightPushTimeTask1[rptTask1 -1];

        //        Debug.Log("diff:" + diff);
        //        Debug.Log("diff.TotalMilliseconds:" + diff.TotalMilliseconds);
        //        Debug.Log("diff.TotalSeconds:" + diff.TotalSeconds);
        //        Debug.Log("diff.TotalMinutes:" + diff.TotalMinutes);

        //平均タップ時間＝差分を全て都度合計して都度タップ数で割る
        totalTapTimeRightPushTask1 = totalTapTimeRightPushTask1 + diff;
//                Debug.Log("totalTapTimeRightPushTask1: " + totalTapTimeRightPushTask1 +" ["+ rptTask1+"]");

        meanTimeRightPushTask1 = totalTapTimeRightPushTask1.TotalSeconds / rptTask1;
//                Debug.Log("meanTimeRightPushTask1: " + meanTimeRightPushTask1);


        //最大タップ時間＝差分の最大値を更新しつづける

        if (diff.TotalSeconds > maxTaptimeRightPushTask1)
        {
            maxTaptimeRightPushTask1 = diff.TotalSeconds;
        }
//        Debug.Log("maxTaptimeRightPushTask1: " + maxTaptimeRightPushTask1);



        //最小タップ時間＝差分の最小値を更新しつづける

        if (diff.TotalSeconds < minTaptimeRightPushTask1 || minTaptimeRightPushTask1 == 0)
        {
            minTaptimeRightPushTask1 = diff.TotalSeconds;
        }
        //        Debug.Log("minTaptimeRightPushTask1: " + minTaptimeRightPushTask1);

        ShowResultMonitorRightPushTask1();

        rptTask1++;

    }

    public void ShowResultMonitorRightPushTask1()
    {
        //エディタでアタッチしたテキストを扱えるようにする
        Text corrects_text = corrects.GetComponent<Text>();

        //デバック用テキストに出力する
        StringBuilder result = new StringBuilder();
        string heikin = (Math.Truncate(meanTimeRightPushTask1 * 100.0) / 100.0).ToString();
        string saisyo = (Math.Truncate(minTaptimeRightPushTask1 * 100.0) / 100.0).ToString();
        string saidai = (Math.Truncate(maxTaptimeRightPushTask1 * 100.0) / 100.0).ToString();

        result.Append("正答数: " + rightPushTask1);
        result.Append(" 平均(s)=" + heikin);
        result.Append(" 最小(s)=" + saisyo);
        result.Append(" 最大(s)=" + saidai);

        corrects_text.text = result.ToString();

    }

    //プッシュした正答ボタン全ての数のゲッター
    public static int GetRightPushTask1()
    {
        return rightPushTask1;
    }

    //プッシュした正答ボタン全ての時刻のゲッター
    public static DateTime[] GetRightPushTimeTask1()
    {
        return rightPushTimeTask1;
    }

    //プッシュした正答ボタンの平均時間間隔のゲッター
    public static double GetMeanTimeRightPushTask1()
    {
        return meanTimeRightPushTask1;
    }

    //プッシュした正答ボタンの最大時間間隔のゲッター
    public static double GetMaxTaptimeRightPushTask1()
    {
        return maxTaptimeRightPushTask1;
    }

    //プッシュした正答ボタンの最小時間間隔のゲッター
    public static double GetMinTaptimeRightPushTask1()
    {
        return minTaptimeRightPushTask1;
    }


    public void WrongPush()
    {
        //エディタでアタッチしたテキストを扱えるようにする
        Text wrongs_text = wrongs.GetComponent<Text>();

        wrongPushTask1++;
        wrongPushTimeTask1[wptTask1] = DateTime.Now;
        //        Debug.Log("wrongPushTime[wpt] " + wrongPushTime[wpt]);

        if (wptTask1 == 0)
        {
            //            Debug.Log("wdtTask1==0:" + wdtTask1);

            TimeSpan diff01 = wrongPushTimeTask1[wptTask1] - startDateTime[0];
            //            Debug.Log("diff01" + diff01);

            meanTimeWrongPushTask1 = diff01.TotalSeconds;
            //            Debug.Log("meanTimeWrongPushTask1" + meanTimeWrongPushTask1);

            maxTaptimeWrongPushTask1 = diff01.TotalSeconds;
            //            Debug.Log("maxTaptimeWrongPushTask1" + maxTaptimeWrongPushTask1);

            minTaptimeWrongPushTask1 = diff01.TotalSeconds;
            //            Debug.Log("minTaptimeWrongPushTask1" + minTaptimeWrongPushTask1);

            ShowResultMonitorWrongPushTask1();




            wptTask1++;
            return;
        }

        //タップ時間を取得する（最大、最小、平均）
        //NとN-1タップ時刻の差分＝タップ時間を算出

        TimeSpan diff = wrongPushTimeTask1[wptTask1] - wrongPushTimeTask1[wptTask1 - 1];

        //        Debug.Log("diff:" + diff);
        //        Debug.Log("diff.TotalMilliseconds:" + diff.TotalMilliseconds);
        //        Debug.Log("diff.TotalSeconds:" + diff.TotalSeconds);
        //        Debug.Log("diff.TotalMinutes:" + diff.TotalMinutes);

        //平均タップ時間＝差分を全て都度合計して都度タップ数で割る
        totalTapTimeWrongPushTask1 = totalTapTimeWrongPushTask1 + diff;
        //        Debug.Log("totalTapTimeWrongPushTask1: " + totalTapTimeWrongPushTask1 +" ["+ wptTask1+"]");

        meanTimeWrongPushTask1 = totalTapTimeWrongPushTask1.TotalSeconds / wptTask1;
        //        Debug.Log("meanTimeWrongPushTask1: " + meanTimeWrongPushTask1);


        //最大タップ時間＝差分の最大値を更新しつづける

        if (diff.TotalSeconds > maxTaptimeWrongPushTask1)
        {
            maxTaptimeWrongPushTask1 = diff.TotalSeconds;
        }
        //        Debug.Log("maxTaptimeWrongPushTask1: " + maxTaptimeWrongPushTask1);

        //最小タップ時間＝差分の最小値を更新しつづける

        if (diff.TotalSeconds < minTaptimeWrongPushTask1 || minTaptimeWrongPushTask1 == 0)
        {
            minTaptimeWrongPushTask1 = diff.TotalSeconds;
        }
        //        Debug.Log("minTaptimeWrongPushTask1: " + minTaptimeWrongPushTask1);

        ShowResultMonitorWrongPushTask1();

        wptTask1++;

    }

    public void ShowResultMonitorWrongPushTask1()
    {
        //エディタでアタッチしたテキストを扱えるようにする
        Text wrongs_text = wrongs.GetComponent<Text>();

        //デバック用テキストに出力する
        StringBuilder result = new StringBuilder();
        string heikin = (Math.Truncate(meanTimeWrongPushTask1 * 100.0) / 100.0).ToString();
        string saisyo = (Math.Truncate(minTaptimeWrongPushTask1 * 100.0) / 100.0).ToString();
        string saidai = (Math.Truncate(maxTaptimeWrongPushTask1 * 100.0) / 100.0).ToString();

        result.Append("誤答数: " + wrongPushTask1);
        result.Append(" 平均(s)=" + heikin);
        result.Append(" 最小(s)=" + saisyo);
        result.Append(" 最大(s)=" + saidai);

        wrongs_text.text = result.ToString();

    }



    //プッシュした正答ボタン全ての数のゲッター
    public static int GetWrongPushTask1()
    {
        return wrongPushTask1;
    }

    //プッシュした正答ボタン全ての時刻のゲッター
    public static DateTime[] GetWrongPushTimeTask1()
    {
        return wrongPushTimeTask1;
    }

    //プッシュした正答ボタンの平均時間間隔のゲッター
    public static double GetMeanTimeWrongPushTask1()
    {
        return meanTimeWrongPushTask1;
    }

    //プッシュした正答ボタンの最大時間間隔のゲッター
    public static double GetMaxTaptimeWrongPushTask1()
    {
        return maxTaptimeWrongPushTask1;
    }

    //プッシュした正答ボタンの最小時間間隔のゲッター
    public static double GetMinTaptimeWrongPushTask1()
    {
        return minTaptimeWrongPushTask1;
    }


    //対象ボタンカウンタ取得用関数
    public int GetNumOfTargets()
    {
//        Debug.Log("GetNumOfTargets()");
        return numOfTargets;
    }


    //対象ボタンカウンタ取得用関数
    public int GetButtonCount()
    {
//        Debug.Log("GetButtonCount()");
        return buttonCount;
    }

    //対象ボタンカウンタ設定用関数
    public void SetButtonCount( int seti )
    {
        buttonCount = seti;
//        Debug.Log("buttonCount：" + buttonCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        startDateTime[0] = DateTime.Now;
//        Debug.Log("startDateTime[0] ：" + startDateTime[0]);
        CreateTargets(numOfTargets);
    }

    public void ReCreateTargets()
    {
        //DropButtons()はここで実行してもよいし
        //ボタンタッチを処理する関数で実行してもよいし
        DropButtons();

        loopCount++;
        CreateTargets(numOfTargets);
    }

    // Update is called once per frame
    void Update()
    {
        Text spenttime = spentTime.GetComponent<Text>();
        TimeSpan difftime = DateTime.Now - startDateTime[0];
        Double difftimedouble = difftime.TotalSeconds;
        spenttime.text = "経過時間: " + difftimedouble.ToString();


    }


    public void DropButtons()
    {

        //ボタンをドロップする
        //子オブジェクトの名前を指定して削除する

        foreach (Transform child in drawArea.transform)
        {
            if (child.name == "Button(Clone)")
            {
                GameObject.Destroy(child.gameObject);
            }
        }


    }

    public void CreateTargets(int a)
    {


        //テキストオブジェクトを作成し
        //エディタでアタッチしたテキストを扱えるようにする
        Text target_text_text = target_text.GetComponent<Text>();

        /*
        float gamensizex = 1280.0f;
        float gamensizey = 800.0f;
        float hoseix = 640.0f;
        float hoseiy = 400.0f;

        float marginx = 150.0f;
        float marginy = 150.0f;
        */



        //画面サイズ
        float gamensizex = 360.0f;
        float gamensizey = 640.0f;


        float hoseix = 180.0f;
        float hoseiy = 320.0f;

        //上下左右のマージン
        float marginx = 50.0f;
        float marginy = 50.0f;




        //iはこれから作るボタンの番号

        int i = 0;
        while(i < a)
        {
 
            //オブジェクトの座標
            float x = UnityEngine.Random.Range(-hoseix + marginx, gamensizex - hoseix - marginx);
            float y = UnityEngine.Random.Range(-hoseiy + marginy, gamensizey - hoseiy - marginy - 100.0f);

            posixy[0, i] = x;
            posixy[1, i] = y;

            int p = 0;
            for (int k =0 ; k < i ;k++)
            {

                float defx = posixy[0, i] - posixy[0, k];
                float defy = posixy[1, i] - posixy[1, k];

                float squaredefx = defx * defx;
                float squaredefy = defy * defy;

                float kyorixy = Mathf.Sqrt(squaredefx + squaredefy);


                if (kyorixy < 60.0f)
                {
                    //200より近いものがあればフラグONしてブレイク
                    p++;
                    //直下のFor文から抜ける
                    break;
                }

            }

            //200より近いフラグONであれば以降の処理（i++を含む）をスキップ
            if(p >0)
            {
                //直下のFor文の以降の処理をスキップ
                continue;
            }


            //オブジェクトを生成してゲームオブジェクトインスタンスで受ける
            //エディタでボタンをアタッチする
            preFabs = Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);


            foreach (Transform child in preFabs.transform)
            {
                //テキストオブジェクトの名前は取得済み
                Text buttonNumText = child.GetComponent<Text>();
                buttonNumText.text = (i + 1).ToString();
            }

        
            //オブジェクトに親を設定する
            //エディタで親（drawArea）をアタッチする
            preFabs.transform.SetParent(drawArea.transform, false);

            //ボタンを作ったのでカウントアップ
            i++;

        }
    }
}

