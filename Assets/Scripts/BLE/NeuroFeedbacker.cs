using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuroFeedbacker
{
    const int moving_average_size = 30;

    // ABC app
    const int sz_firstBuffer = 30;
    const int sz_secondBuffer = 30;
    const float th_changeDetectionCount = 6.0f;
    const float th_changeDetectionLevel = 0.005f;        
    const int sampleLength = 30;    

    const int counter_autoReset = 5;
    const float dValDefault = 0.0f;
    const float dValPosi = 0.5f;
    const float dValNega = -0.5f;

    /*
    //- base
    const int sz_firstBuffer = 10;
    const int sz_secondBuffer = 20;
    const float th_changeDetectionCount = 4.0f;
    const float th_changeDetectionLevel = 0.00f;
    const int counter_autoReset = 20;
    const float dValDefault = 0.01f;
    const float dValPosi = 0.5f;
    const float dValNega = -0.5f;
    */


    //- long   
    /*
    const int sz_firstBuffer = 20;
    const int sz_secondBuffer = 40;
    const float th_changeDetectionCount = 4.0f;
    const float th_changeDetectionLevel = 0.005f;
    const int counter_autoReset = int.MaxValue;
    const float dValDefault = 0.01f;
    const float dValPosi = 0.5f;
    const float dValNega = -0.5f;
    */

    /*
    //- adjust 2
    const int sz_firstBuffer = 15;
    const int sz_secondBuffer = 30;
    const float th_changeDetectionCount = 5.0f;
    const float th_changeDetectionLevel = 0.005f;
    const int counter_autoReset = 50;
    const float dValDefault = 0.0f;
    const float dValPosi = 0.35f;
    const float dValNega = -0.35f;
    */

    List<double> activenesses;

    DataStore store;

    private float[] resultBuffer;
    private float calcBrainValue = 0.0f;
    bool isNegVal1 = false;
    bool isNegVal2 = false;
    bool isPosVal1 = false;
    bool isPosVal2 = false;
    int analysisCounterNeg = 0;
    int analysisCounterPos = 0;
    double[] filteredL;//: DoubleArray = DoubleArray(sz_firstBuffer)
    double[] filteredR;//DoubleArray = DoubleArray(sz_firstBuffer)
    
    public NeuroFeedbacker(DataStore s)
    {
        activenesses = new List<double>();
        store = s;

        resultBuffer = new float[sz_secondBuffer];

        filteredL = new double[sz_firstBuffer];
        filteredR = new double[sz_firstBuffer];

    }

    
    public void bufferActiveness()
    {
        //脳活動の解析結果＝指標(tmp)を結果バッファーに追加
        System.Array.Copy(resultBuffer, 1, resultBuffer, 0, resultBuffer.Length - 1);

        //        if(this.store.stability.isNotEmpty() && this.store.stability.last().isNotStable) {
        //            /* 安定していない場合はスキップデータ */
        //            resultBuffer[resultBuffer.size - 1] = -1.0f
        //            return
        //        }
        //データの平滑化：データバッファの中央値を代表値にする＝平滑化。代表値をフィルタデータバッファに追加
        int len = this.store.l3Ac.Count;
        if (len < 12)
            return;

        double l3AcM = AnalyseHelper.median(sliceArray(this.store.l3Ac, len - sampleLength -1, len - 1));
        double l1AcM = AnalyseHelper.median(sliceArray(this.store.l1Ac, len - sampleLength -1, len - 1));
        //double l3AcM = AnalyseHelper.Average(this.store.l3Ac, len - 11, len - 1);
        //double l1AcM = AnalyseHelper.Average(this.store.l1Ac, len - 11, len - 1);

        filteredL[filteredL.Length - 1] = l3AcM - l1AcM;
        /*if (this.store.has2Channels)
        {
            filteredR[filteredL.size - 1] =
                median(this.store.r3Ac.toDoubleArray().sliceArray(len - 11..len - 1)) -
                median(this.store.r1Ac.toDoubleArray().sliceArray(len - 11..len - 1))
        }*/

        //フィルタデータバッファをもとに、
        //変化の方向（増加、減少）が何回連続しているかを、微分値の符号の累積和として算出
        double signL = 0.0;
        //double signR = 0.0
        for (int i = 0; i < filteredL.Length - 1; i++)
        {
            if (!double.IsNaN(filteredL[i + 1]) && !double.IsNaN(filteredL[i]))
            {
                double diff = filteredL[i + 1] - filteredL[i];
                if (System.Math.Abs(diff) > filteredL[i + 1] * th_changeDetectionLevel)
                {
                    signL += System.Math.Sign(diff);//Left
                }                
                                                                           //if (this.store.has2Channels)
                                                                           //    signR += Math.signum(filteredR[i + 1] - filteredR[i])//Right
            }
        }

        //変化の連続が閾値以上続いていたら、変化準備値（val）を増減させる
        //連続が終わった時に、変化準備値をほぼゼロにリセットする。
        //＊わずかにプラスなのは、色が赤くなる方向への少しのさじ加減。
                
        float prepare = dValDefault;

        if (signL > th_changeDetectionCount )
        {
            prepare = dValPosi;
        }
        else if(signL < -th_changeDetectionCount )
        {
            prepare = dValNega;
        }

        //変化準備値を使い、脳活動値を変更
        float scale1 = 1f;
        calcBrainValue += prepare / 5.0f;

        //脳活動値のクランプ
        if (calcBrainValue < -1.0 * scale1)
        {
            calcBrainValue = -1.0f * scale1;
        }

        if (calcBrainValue > 1.5 * scale1)
        {
            calcBrainValue = 1.5f * scale1;
        }

        if (isNegVal1 && isNegVal2) analysisCounterNeg++;        
        else analysisCounterNeg = 0;
        if (isPosVal1 && isPosVal2) analysisCounterPos++;
        else analysisCounterPos = 0;


        //脳活動を色に変換する指標（tmp）のクランプ時に
        //isPosValまたはisNegValが更新される。
        //指標が上限を超え続ける状態を検出するカウンタがanalysisCounterPosで
        //このバージョンでは、上がりすぎた際には、脳活動を*0.9に設定（リセット）する。
        //TODO:上がりすぎ時のリセット方法の改良
        
        if (analysisCounterPos > counter_autoReset)
        {
            //- calBrainValue > 1
            calcBrainValue = 0.9f;
            analysisCounterPos = 0;
        }
        else if (analysisCounterNeg > counter_autoReset)
        {
            //- calBrainValue == -1
            calcBrainValue = 1f/5f;
            analysisCounterNeg = 0;
        }

        //脳活動の値から指標（tmp）を計算。
        //isNegValはこのバージョンでは不使用。TODO：下がりすぎ時のリセット
        float value = (calcBrainValue * 5.0f);
        
        isNegVal2 = isNegVal1;
        isPosVal2 = isPosVal1;

        if (value < 1.0)
        {
            value = 1.0f;
            isPosVal1 = false;
            isNegVal1 = true;            
        }
        else if (value > 5.0)
        {
            value = 5.0f;
            isPosVal1 = true;
            isNegVal1 = false;
        }
        else
        {
            isPosVal1 = false;
            isNegVal1 = false;
        }

        //Update filtereddata　フィルタデータバッファの循環
        System.Array.Copy(filteredL, 1, filteredL, 0, filteredL.Length - 1);

        resultBuffer[resultBuffer.Length - 1] = value;
        Debug.Log("BrainAct 1: " + calcBrainValue + "(d: " + prepare + ") (SignSum: " + signL + ")");
        Debug.Log("BrainAct buffer all" + resultBuffer.ToString());
    }


	private bool isstoredActiveness = false;

	public System.DateTime startTime;
	public System.DateTime endTime;

#if true
	/** 脳活性度の蓄積を開始します */
	public void start()
	{
		startTime = System.DateTime.Now;
		isstoredActiveness = true;
	}

	/** 脳活性度の蓄積を終了します */
	public void stop()
	{
		endTime = System.DateTime.Now;
		isstoredActiveness = false;
	}
#endif

	public double calcActivenessFromBuffered()
    {
        //        return resultBuffer.average()/5
        for( int i=0; i<resultBuffer.Length; i++ )
        {
            if( resultBuffer[i] == -1.0f )
            {
                return -1.0;
            }
        }

        //double activeness = AnalyseHelper.Average(resultBuffer, 0, resultBuffer.Length) / 5.0;
        double activeness = AnalyseHelper.median(resultBuffer) / 5.0;
        Debug.Log("BrainAct buffered ave. " + activeness);

        if (!isstoredActiveness)
            return activeness;

        activenesses.Add(activeness);// 呼び出し毎にログ取ってるけどいいのかなぁ…         

        return activeness;
    }

    /**　脳活性度積算の平均値 */
    public double activenessAverage
    {
        get
        {
            return AnalyseHelper.Average(activenesses, 0, activenesses.Count);
        }
    }

    public double activenessAverage2
    {
        get
        {
            return AnalyseHelper.Average2(activenesses, 0, activenesses.Count);
        }
    }

    public double[] activenessLog
	{
		get
		{
			return activenesses.ToArray();
		}
	}

    public void resetBrainCals()
    {
        //        filteredData = arrayOf(DoubleArray(10),DoubleArray(10))
        filteredL = new double[sz_firstBuffer];
        filteredR = new double[sz_firstBuffer];
        resultBuffer = new float[30];
        calcBrainValue = 0f;
    }
    public void bufferUnstable()
    {
        System.Array.Copy(resultBuffer, 1, resultBuffer, 0, resultBuffer.Length - 1);
        resultBuffer[resultBuffer.Length - 1] = -1.0f;
    }


    public static double[] sliceArray(List<double> dList, int start, int end)
    {
        List<double> d = new List<double>();
        for (int i = start; i <= end; i++)
        {
            d.Add(dList[i]);
        }


        return d.ToArray();
    }


    /**
     * 脳活性度計算
     * 0~1の値で算出されます。
     * 出力値に範囲の最大値をかけて利用してください。
     * 例）12color => calcActiveness() * 12
     */
    /*
   public double calcActiveness()
   {
       // ノイズ除去 

       // 移動平均 
       double[] ml = AnalyseHelper.movingAverage(store.left.ToArray(), moving_average_size);
       double[] mr = AnalyseHelper.movingAverage(store.right.ToArray(), moving_average_size);

       // ベースライン補正 
       double[] bl = AnalyseHelper.baselineFitting(ml, 0, 50, ml.Length, ml.Length);
       double[] br = AnalyseHelper.baselineFitting(mr, 0, 50, mr.Length, mr.Length);

       double[] bases = null;



       if (br.Length > 1)
       {
           bases = new double[br.Length];
           for( int i=0; i<br.Length; i++ )
           {
               bases[i] = (br[i] + bl[i]) / 2;
           }
       }
       else
       {
           bases = bl;
       }

       double average = 0;
       int c = 0;
       for( int i=0; i<bases.Length; i++ )
       {
           if( 0 < bases[i] )
           {
               average += bases[i];
               c++;
           }
       }

       if( 0 < c )
       {
           average /= c;
       }


       double ranged = average;
       if (average > activeness_max)
           ranged = activeness_max;

       double activeness = ranged / activeness_max;

       if (!isstoredActiveness)
           return activeness;

       activenesses.Add(activeness);

       return activeness;
   }*/

}
