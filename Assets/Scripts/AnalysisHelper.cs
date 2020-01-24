using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.Interpolation;
using ChartAndGraph;

public class AnalysisHelper
{
    public List<List<double>> brainWave_modeled_coeff = new List<List<double>>();
    public List<int> brainScore = new List<int>();
    public List<List<double>> wave = new List<List<double>>();
    

    #region Analysis functions
    public static int AgeCalc(int score)
    {
        return Mathf.FloorToInt(108 - 1.33f * score);
    }
    public float ConvertScoreToRate(int scene, int score)
    {
        float ret;
        if (scene == 0)
        {
            ret = score / 25f;
        }
        else if (scene == 1)
        {
            ret = score / 20f;
        }
        else
        {
            ret = score / 15f;
        }
        return Mathf.Clamp(ret, 0, 1f);
    }    
    double[][] Transpose2DMatrix(double[][] x)
    {
        double[][] xt = new double[x[0].Length][];

        for (int i = 0; i < x[0].Length; i++)
        {
            xt[i] = new double[x.Length];
            for (int j = 0; j < x.Length; j++)
            {
                xt[i][j] = x[j][i];
            }
        }
        return xt;
    }
    double[] DCLevelCorrection(double[] y)
    {
        double[] y2 = new double[y.Length];
        for (int i = 1; i < y.Length; i++)
        {
            y2[i] = y[i] - y[0];
        }
        y2[0] = 0;
        return y2;
    }
    double[] LinearBaselineCorrection(double[] y, int preIDX, int postIDX)
    {
        double[] y2 = new double[y.Length];        

        double[] preV = new double[preIDX];
        double[] postV = new double[postIDX];
        Array.Copy(y, 0, preV, 0, preV.Length);
        Array.Copy(y, y.Length-postIDX-1, postV, 0, postV.Length);

        List<double> preL = new List<double>(preV);
        List<double> postL = new List<double>(postV);

        double v1 = preL.Average();
        double v2 = postL.Average();

        double a = (v2 - v1) / (y.Length-postIDX - preIDX);
        double b = v1;

        for (int i = 0; i < y.Length; i++)
        {
            y2[i] = y[i] - b - a * i;
        }       

        return y2;
    }
    List<Vector2> interporation_linear(double[] x, double[] y, double step)
    {
        int L = (int)(x.Max() - x.Min());
        if (x.Min() == 0) L++;

        List<Vector2> p = new List<Vector2>();
        
        IInterpolation interp = LinearSpline.Interpolate(x, y);

        for (double i = x.Min(); i <= x.Max(); i+=step)
        {
            p.Add(new Vector2((float)i, (float)interp.Interpolate(i)));
        }
        return p;
    }
    double[][] LoadBaseFunction()
    {
        double[][] b = new double[segmentDuration][];
        for (int i = 0; i < segmentDuration; i++) b[i] = new double[baseFuncNumber];

        //string filePath = Application.dataPath + @"\Script\basefunc.csv";
        //string filePath = Application.dataPath + @"\Script\basefunc2.csv";
        //string filePath = Application.dataPath + @"\Script\basefunc3.csv";
        //System.IO.StreamReader sr = new System.IO.StreamReader(filePath);        
        //string s = sr.ReadToEnd();        
        //sr.Close();

        //var encoding = System.Text.Encoding.GetEncoding("shift_jis");

        TextAsset ta = Resources.Load<TextAsset>("basefunc3");
        string[] lines = ta.text.Split(new char[] { '\n', '\r' });
        //string[] lines = File.ReadAllLines(filePath);        
            
        for (int i = 0; i < segmentDuration; i+=2)
        {
            string[] s = lines[i].Split(',');
            for (int j = 0; j < baseFuncNumber; j++)
            {
                b[i][j] = double.Parse(s[j]);
            }            
        }
        return b;
    }
    List<Vector2> LoadMeasuredBrainActivity(string filePath)
    {
        //Debug.Log("TKTKTK1"+filePath.ToString());
        //Debug.Log("TKTKTK2" + Hot2gApplication.Instance.ToString());
        //Debug.Log("TKTKTK3" + Hot2gApplication.Instance.m_Logger.ToString());
        //var encoding = System.Text.Encoding.GetEncoding("shift_jis");

        if (filePath == null)
        {
            Debug.Log("File Save: m_Logger is NULL, return lenght one array.");
            //return new double[0];
            return new List<Vector2>();
        }

        string[] lines = File.ReadAllLines(filePath);

        Debug.Log("File Save: filePath = "+filePath);
        Debug.Log("File Save: loaded length = "+lines.Length.ToString());
        
        double[] y1 = new double[lines.Length];
        double[] y3 = new double[lines.Length];
        double[] y = new double[lines.Length];
        double[] x = new double[lines.Length];

        //- check MGC
        List<int> tg = new List<int>();
        for (int i = 0; i < y.Length; i++)
        {
            string[] s = lines[i].Split(',');
            if (s.Length>=7)
                if (s[7] != "") tg.Add(i);
        }

        //- set startTG
        int startTg = 0;
        for (int i = 0; i < tg.Count; i++)
        {
            if (y.Length - tg[i] >= 1800 + 150)
            {
                startTg = tg[i];
            }
        }

        //- load to variable 
        for (int i = startTg; i < y.Length; i++)
        {
            string[] s = lines[i].Split(',');
            if (s.Length == 33)
            {
                x[i - startTg] = double.Parse(s[0]);
                y1[i - startTg] = double.Parse(s[2]);
                y3[i - startTg] = double.Parse(s[3]);
                y[i - startTg] = y3[i - startTg] - y1[i - startTg];
            }
        }

        List<Vector2> p = interporation_linear(x, y, 0.1);
        return p;

        //Debug.Log("File Save: return length = " + y.Length);
        //return y3;
        //return y;
    }
    double[] vector2list2array_x(List<Vector2> p)
    {
        double[] x = new double[p.Count];
        for (int i = 0; i < p.Count; i++) x[i] = p[i].x;
        return x;
    }
    double[] vector2list2array_y(List<Vector2> p)
    {
        double[] y = new double[p.Count];
        for (int i = 0; i < p.Count; i++) y[i] = p[i].y;
        return y;
    }
    double[][] SegmentationThreeBlocks(double[] y, int preIDX, int postIDX)
    {
        double[][] suby = new double[3][];

        for (int rep = 0; rep < 3; rep++)
        {
            //suby[rep] = new double[segmentDuration];
            suby[rep] = new double[segmentDuration + preIDX + postIDX];
            Array.Copy(y, y.Length - blockDuration * (3 - rep) - preIDX, suby[rep], 0, segmentDuration + preIDX + postIDX);
        }
        //- DC level correction        
        for (int j = 0; j < 3; j++)
        {
            for (int i = 1; i < suby[0].Length; i++)
            {
                suby[j][i] -= suby[j][0];
            }
            suby[j][0] = 0;
        }

        return suby;
    }
    double[][] doLinearRegression(double[][] x, double[][] suby, bool addIntercept)
    {
        double[][] a = new double[3][];        

        for (int rep = 0; rep < 3; rep++)
        {
            a[rep] = MultipleRegression.Svd(x, suby[rep], addIntercept);
        }
        return a;
    }
    double[] reconstructWaveform(double[][] baseWaves, double[] coeff)
    {
        double[] wave = new double[baseWaves.Length];

        for (int i = 0; i < baseWaves[0].Length; i++)
        {
            for (int j = 0; j < baseWaves.Length; j++)
            {
                wave[j] += baseWaves[j][i] * coeff[i];
            }            
        }
        //-       

        wave = DCLevelCorrection(wave);
        wave = Smoothing(wave, 50);

        return wave;
    }
    double[] Smoothing(double[] y, int ws)
    {
        double[] y2 = new double[y.Length];
        int w = ws / 2;
        for (int i = 0; i < y.Length - ws - 1; i++)
        {
            List<double> l = new List<double>();
            for (int j = 0; j < ws; j++)
            {
                l.Add(y[i + j]);
            }            
            y2[i + w-1] = l.Average();
        }

        for (int i = 0; i < w-1; i++)
        {
            List<double> l = new List<double>();
            for (int j = 0; j < i*2+1; j++)
            {
                l.Add(y[j]);
            }
            y2[i] = l.Average();
        }
        for (int i = y.Length - w-2; i < y.Length; i++)
        {
            List<double> l = new List<double>();
            for (int j = i - (y.Length - i); j < i + (y.Length - i); j++)
            {
                l.Add(y[j]);    
            }
            y2[i] = l.Average();
        }

        return y2;
    }
    int BrainScore(List<double> l)
    {        
        List<double> l1 = l.FindAll(n => n > 0);
        return (int)(l1.Sum() * 20);
    }
    #endregion

    void AnalyzeWave(double[][] x, double[] y)
    {
        Debug.Log("File Save: Start Drawing.");

        double[][] suby = SegmentationThreeBlocks(y, preIDX, postIDX);
        
        //- Modeling
        double[][] a = doLinearRegression(x, suby, false);
 
        //- 表示用の波形データを作る
        List<List<double>> wave = new List<List<double>>();
        List<double> v = new List<double>();
        for (int i = 0; i < 3; i++)
        {
            wave.Add(new List<double>(reconstructWaveform(x, a[i])));
            v.Add(wave[i].Max());
            v.Add(wave[i].Min());
        }

        Debug.Log("File Save: v-prepare done.");

        Debug.Log("File Save: Brain score start.");
                
        List<int> sc = new List<int>();
        for (int i = 0; i < 3; i++) brainScore.Add(BrainScore(wave[i]));

        for (int i = 0; i < 3; i++)
        {
            List<double> tmp = new List<double>();
            for (int j = 0; j < a[i].Length; j++)
            {
                tmp.Add(a[i][j]);
            }
            brainWave_modeled_coeff.Add(tmp);
        }        
    }

    // Start is called before the first frame update
    //- 脳活動ログファイル解析のメインルーチン
    int segmentDuration = 450, blockDuration = 600;
    int preIDX = 0, postIDX = 0;
    int baseFuncNumber = 10;    
    public void AnalyzeLastLogFile()
    {
        string filePath = null;        

        //- test
        //double[] xx = { 0, 1, 2, 3, 4, 5, 8,15 };
        //double[] yy = { 0, 1, 2, 3, 4, 5, 16,10 };
        //List<Vector2> p = interporation_linear(xx, yy, 1);
        //

#if UNITY_EDITOR
        //filePath = Application.dataPath + @"\Script\sample\xblog2019-06-19.07.23.47.csv";//- test data
        filePath = Application.dataPath + @"\Script\sample\xblog2019-09-07.22.44.21.csv";//- test data
                                                                                         //string filePath = Hot2gApplication.Instance.m_Logger.FilePath;
#else
        if (Hot2gApplication.Instance.m_Logger!=null)
        {
            filePath = Hot2gApplication.Instance.m_Logger.FilePath;
        }
        else
        {
            Debug.Log("File Save: m_Logger is NULL!");
            filePath =null;
        }
#endif
        //debug_txtbox.text = filePath;

        //filePath = Hot2gApplication.Instance.m_Logger.FilePath;

        BMBrainMgr.End(); //- Stop on the result scene.

        double[][] x = LoadBaseFunction();
        //double[] y = LoadMeasuredBrainActivity(filePath);
        List<Vector2> pvec = LoadMeasuredBrainActivity(filePath);
        double[] y = vector2list2array_y(pvec);
        Debug.Log("File Save: Data loaded. Size = " + y.Length.ToString());

        #region modeling test
        //- test------------------
        /*
        String[] fileList = System.IO.Directory.GetFiles(Application.dataPath + @"\Script\sample\", "*.csv");
        foreach (String fp in fileList) {
            pvec = LoadMeasuredBrainActivity(fp);
            y = vector2list2array_y(pvec);
            if (y.Length > 1800)
            {
                double[][] suby = SegmentationThreeBlocks(y, preIDX, postIDX);
                double[][] a = doLinearRegression(x, suby, false);
                SaveArrayToFile(Application.dataPath + @"\Script\sample\"+"res_model.txt", a);
                SaveArrayToFile(Application.dataPath + @"\Script\sample\" + "res_original.txt", suby);
                SaveStringToFile(Application.dataPath + @"\Script\sample\" + "res_filename.txt", fp);
            }
        }
        */
        //---------------- 
        #endregion

#if UNITY_EDITOR
#else
        SaveResultToFile();
#endif

    }


    #region Save functions
    public string ListToString<T>(List<T> list)
    {
        string log = "";

        if (list.Count == 0) return "Empty";

        for (int i=0;i<list.Count-1;i++)
        {
            log += list[i].ToString() + ",";
        }
        log += list[list.Count-1].ToString() + ",";
        return log;
    }

    void SaveResultToFile()
    {
        StreamWriter sw;
        //FileInfo fi = new FileInfo(Application.persistentDataPath + "/Res_"+DateTime.Now.ToString("yyyyMMddHHmmss") +".csv");
        FileInfo fi = new FileInfo(Hot2gApplication.Instance.m_Logger.StorePath + "/Res_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");
        sw = fi.AppendText();

        for (int i = 0; i < 3; i++)
        {
            sw.WriteLine(ListToString(brainWave_modeled_coeff[i]));
        }
        sw.WriteLine("Brain score:");
        sw.WriteLine(ListToString(brainScore));

        sw.Flush();
        sw.Close();
        
    }

    void SaveArrayToFile(String filename, double[][] a)
    {
        StreamWriter sw;

        FileInfo fi = new FileInfo(filename);
        sw = fi.AppendText();
        
        for (int i = 0; i < 3; i++)
        {
            String s = ArrayToString(a[i]);
            sw.WriteLine(s);
        }
        
        sw.Flush();
        sw.Close();            
        
    }
    String ArrayToString(double[] a)
    {
        String s = "";
        for (int j = 0; j < a.Length; j++)
        {
            s += a[j].ToString() + ",";
        }
        return s;
    }
    void SaveStringToFile(String filename, String s)
    {
        StreamWriter sw;
        FileInfo fi = new FileInfo(filename);
        sw = fi.AppendText();
        sw.WriteLine(s);
        sw.Flush();
        sw.Close();
    }
    #endregion
}
