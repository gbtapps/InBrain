using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnalyseHelper
{
    public static float Average(float[] data, int start, int end)
    {
        float Ret = data[start];
        int c = 0;
        for (int i = start; i < end && i < data.Length ; i++)
        {
            if (c == 0)
            {
                Ret = 0;
            }

            Ret += data[i];
            c++;
        }

        if (0 < c)
        {
            Ret = Ret / c;
        }

        return Ret;
    }


    public static double Average( double[] data, int start, int end )
    {
        if(data.Length <=start)
        {
            return 0;
        }

        double Ret = data[start];
        int c = 0;
        for( int i=start; i<end && i<data.Length; i++ )
        {
            if (c == 0)
            {
                Ret = 0;
            }

            Ret += data[i];
            c++;
        }

        if( 0 < c )
        {
            Ret = Ret / c;
        }

        return Ret;
    }

	public static double Average(List<double> data, int start, int end)
	{
		if( start < 0 )
		{
			start = 0;
		}

		if (data.Count <= start)
		{
			return 0;
		}

		double Ret = data[start];
		int c = 0;
		for (int i = start; i < end && i < data.Count; i++)
		{
			if (c == 0)
			{
				Ret = 0;
			}

			Ret += data[i];
			c++;
		}

		if (0 < c)
		{
			Ret = Ret / c;
		}

		return Ret;
	}

    public static double Average2(List<double> data, int start, int end)
    {
        var sz = data.Count;
        var ave = data.Average();
        double Ret = 0.0;

        int count = 0;
        foreach (var d in data)
        {
            if(d == 0)count++;
        }
        if(count/sz > 0.95)
        {
            Ret = 0;
        }
        else
        {
            if(ave < 0.25)
            {
                Ret = 0.2 + Random.Range(0.0f, 1.0f);
            }
            else
            {
                Ret = ave;
            }
        }

        return Ret;
    }

    /**
     * 移動平均
     * @param data
     * @param width サイズ(秒x10)
     * @return 処理済みデータ
     */
    public static double[] movingAverage( double[] data, int width)
    {
        double[] proceed = new double[data.Length];
        System.Array.Copy(data, proceed, data.Length);


        for (int i = width / 2; i <= data.Length - width / 2 - 1; i++ )
        {
            proceed[i] = Average(data, i - width / 2, i + width / 2);
        }

        return proceed;
    }

    /**
     * ベースライン補正
     * @param data データ配列
     * @param startRange
     * @param endRange
     * @return 処理済みデータ
     */
    public static double[] baselineFitting( double[] data, int ss, int se, int es, int ee )
    {
        if (ee > data.Length)
            return data;

        double startAve = Average(data, ss, se);
        double endAve = Average(data, es, ee);

        double b = (startAve + endAve) / 2;

        for( var i=0; i<data.Length; i++ )
        {
            data[i] = data[i] - b;
        }

        return data;
    }

    /**
     * 中央値
     * 長さが偶数の場合は中央２値の平均値
     * @param data データ配列
     * @return 中央値
     */
    public static double median(double[] data)
    {
        List<double> l = new List<double>(data);
        l.Sort();

        return (l[l.Count / 2] + l[(l.Count - 1) / 2]) / 2.0;
    }
    public static float median(float[] data)
    {
        List<float> l = new List<float>(data);
        l.Sort();

        return (l[l.Count / 2] + l[(l.Count - 1) / 2]) / 2.0f;
    }


}
