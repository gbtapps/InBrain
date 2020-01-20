﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataStore
{
    /** カウンタ：オフセット計算用 */
    List<int> counts;
    /** 測定開始時刻 */
    //List<LocalDateTime> time;
    /** オフセット時間 */
    List<float> tick;
    /** L3用AC値 */
    public List<double> l3Ac;
    /** L1用AC値 */
    public List<double> l1Ac;
    /** L3 -L1 */
    public List<double> left;
    /** R3用AC値 */
    public List<double> r3Ac;
    /** R1用AC値 */
    public List<double> r1Ac;
    /** R3 - R1 AC */
    public List<double> right ;
    /** L1用AC内飽和データ個数 */
    List<int> l1Sa;
    /** L3用AC内飽和データ個数 */
    List<int> l3Sa;
    /** R1用AC内飽和データ個数 */
    List<int> r1Sa;
    /** R3用AC内飽和データ個数 */
    List<int> r3Sa;
    /** 心拍bpm */
    List<double> heartRate;
	/** 心拍 脈波振幅関連係数 */
	List<Hot2gMeasDataHRElement> pulseAmplitudeCoeff;
	List<double> pulseAmplitudeCoeffIndex1;
    List<Hot2gMeasDataHR> pulseRates;
	/** 角速度X軸 */
	List<double> gyroX;
    /** 角速度Y軸 */
    List<double> gyroY;
    /** 角速度Z軸 */
    public List<double> gyroZ;
    /** 加速度X軸 */
    List<double> accelX;
    /** 加速度Y軸 */
    List<double> accelY;
    /** 加速度Z軸 */
    List<double> accelZ;
    /** マーカー */
    public List<string> mark;
    /** 反応 */
    List<string> reaction;
    /** 安定性 */
    public List<GyroScope.Stability> stability;
    public List<GyroScope.Stability> stabilityCheckBuffer;

    /** 安定性測定器 */
    GyroScope gyroScope;

    /** バッテリー情報*/
    public double batteryPercentage;

	/** MGCパラメータ */
	List<byte> mgcParameter_L1;
	List<byte> mgcParameter_L3;
	List<byte> mgcParameter_R1;
	List<byte> mgcParameter_R3;

	/** データ蓄積数の最大値 */
	const int maxDataSize = 100;


    public DataStore()
    {
        /** カウンタ：オフセット計算用 */
        counts = new List<int>();
        tick = new List<float>();
        l3Ac = new List<double>();
        l1Ac = new List<double>();
        left = new List<double>();
        r3Ac = new List<double>();
        r1Ac = new List<double>();
        right = new List<double>();
        l1Sa = new List<int>();
        l3Sa = new List<int>();
        r1Sa = new List<int>();
        r3Sa = new List<int>();
        heartRate = new List<double>();
        gyroX = new List<double>();
        gyroY = new List<double>();
        gyroZ = new List<double>();
        accelX = new List<double>();
        accelY = new List<double>();
        accelZ = new List<double>();
        mark = new List<string>();
        reaction = new List<string>();

        stability = new List<GyroScope.Stability>();
        stability.Add(GyroScope.Stability.Stabled);
        stabilityCheckBuffer = new List<GyroScope.Stability>();

        gyroScope = new GyroScope();

		pulseAmplitudeCoeff = new List<Hot2gMeasDataHRElement>();
		pulseAmplitudeCoeffIndex1 = new List<double>();
        //pulseAmplitudeCoeff = new List<double>();
        pulseRates = new List<Hot2gMeasDataHR>();

		mgcParameter_L1 = new List<byte>();
		mgcParameter_L3 = new List<byte>();
		mgcParameter_R1 = new List<byte>();
		mgcParameter_R3 = new List<byte>();


	}


    //var device:Device = Device.HOT2000;

    /** 2chデバイスのかどうか、Hot-xxxx */
    public bool has2Channels
    {
        get
        {
            return false;
        }
    }
#if false
    /** [Handler] ACデータ追加 */
    var onAcAdded: (Int) -> Unit = { count->
        0.0
    }
/** [Handler] Saturationデータ追加 */
var onHrAdded: (Int) -> Unit = { count->
        0.0
    }
#endif

    /** 5秒分のデータが蓄えられたかどうか */
    bool isBuffered
    {
        get
        {
            return counts.Count / 10 >= 5;
        }
    }

    bool isSecond
    {
        get
        {
            return 0 < this.counts.Count && this.counts[this.counts.Count - 1] % 10 == 0;
        }
    }

#if false
/**
 * 両側AC計測データ追加
 * @param data 両側AC
 */
fun add(data: Hot2gMeasData2chAc): Hot2000data {
        this.counts.add(data.valResultCount)
        val tick = calcTick(data.valResultCount)
        this.tick.add(tick)
        this.l1Ac.add(data.valBloodDensities[0])
        this.l3Ac.add(data.valBloodDensities[1])
        this.left.add(data.valBloodDensities[1]-data.valBloodDensities[0])
        this.r1Ac.add(data.valBloodDensities[2])
        this.r3Ac.add(data.valBloodDensities[3])
        this.right.add(data.valBloodDensities[3] - data.valBloodDensities[2])
        this.l1Sa.add(data.valSaturations[0])
        this.l3Sa.add(data.valSaturations[1])
        this.r1Sa.add(data.valSaturations[2])
        this.r3Sa.add(data.valSaturations[3])
        this.heartRate.add(this.currentHr)
        if (this.currentMark.isNullOrEmpty())
    this.mark.add(null)
        else
    this.currentMark = null
        this.onAcAdded(this.counts.size)
        return Hot2000data(
            tick = tick,
            l1 = data.valBloodDensities[0],
            l3 = data.valBloodDensities[1],
            r1 = data.valBloodDensities[2],
            r3 = data.valBloodDensities[3],
            l1sa = data.valSaturations[0],
            l3sa = data.valSaturations[1],
            r1sa = data.valSaturations[2],
            r3sa = data.valSaturations[3],
            heartRate = this.heartRate.last(),
            mark = this.mark.last(),
            reaction = ""
        )
    }
#endif
    /**
     * 片側AC計測データ追加
     * @param data 片側AC
     */
    public Xb01data add(Hot2gMeasData1chAc data, double color)
    {
        this.counts.Add(data.valResultCount);
        float tick = calcTick(data.valResultCount);
        this.tick.Add(tick);

        this.l1Ac.Add(data.valBloodDensities[0]);
        this.l3Ac.Add(data.valBloodDensities[1]);
        this.left.Add(data.valBloodDensities[1] - data.valBloodDensities[0]);
        this.l1Sa.Add(data.valSaturations[0]);
        this.l3Sa.Add(data.valSaturations[1]);
        this.heartRate.Add(this.currentHr);
		//this.pulseAmplitudeCoeff.Add(currentPulseCoeff);
		//            if (this.currentMark.isNullOrEmpty())
		//                this.mark.add(null)
		//            else {
		//                this.mark.add(this.currentMark)
		//                this.currentMark = null
		//            }
		if (this.currentReaction == null)
        {
            this.reaction.Add(null);
        }
        else
        {
            this.reaction.Add(this.currentReaction);
            this.currentReaction = null;
        }

        //this.onAcAdded(this.counts.size);

        Xb01data d = new Xb01data();


        d.tick = tick;
        d.l1 = data.valBloodDensities[0];
        d.l3 = data.valBloodDensities[1];
        d.l1sa = data.valSaturations[0];
        d.l3sa = data.valSaturations[1];
        d.heartRate = this.currentHr;
		if (0 < this.mark.Count)
		{
			d.mark = this.mark[this.mark.Count - 1];
		}
		if (0 < this.reaction.Count)
		{
			d.reaction = this.reaction[this.reaction.Count - 1];
		}
        d.color = color;

		if (0 < this.accelX.Count)
		{
			d.accelX = this.accelX[this.accelX.Count - 1];
			d.accelY = this.accelY[this.accelY.Count - 1];
			d.accelZ = this.accelZ[this.accelZ.Count - 1];
			d.gyroX = this.gyroX[this.gyroX.Count - 1];
			d.gyroY = this.gyroY[this.gyroY.Count - 1];
			d.gyroZ = this.gyroZ[this.gyroZ.Count - 1];
			d.stability = this.stability[this.stability.Count - 1];
		}
        //for debug
        d.x0 = this.x0;
        d.y0 = this.y0;
        d.z0 = this.z0;

        if (0 < this.pulseRates.Count)
        {
            int l = this.pulseAmplitudeCoeff.Count - 1;
            d.pulseRateC1L1 = this.pulseRates[l].valConvHR_L[0];
            d.pulseRateC2L1 = this.pulseRates[l].valConvHR_L[1];
            d.pulseRateC3L1 = this.pulseRates[l].valConvHR_L[2];
            d.pulseRateC1L3 = this.pulseRates[l].valConvHR_L[3];
            d.pulseRateC2L3 = this.pulseRates[l].valConvHR_L[4];
            d.pulseRateC3L3 = this.pulseRates[l].valConvHR_L[5];
        }


        if (0 < this.pulseAmplitudeCoeff.Count)
        {
            int l = this.pulseAmplitudeCoeff.Count - 1;
            d.pulseCoeff1L1 = this.pulseAmplitudeCoeff[l].valConvElements[0];
            d.pulseCoeff2L1 = this.pulseAmplitudeCoeff[l].valConvElements[1];
            d.pulseCoeff3L1 = this.pulseAmplitudeCoeff[l].valConvElements[2];
            d.pulseCoeff1L3 = this.pulseAmplitudeCoeff[l].valConvElements[3];
            d.pulseCoeff2L3 = this.pulseAmplitudeCoeff[l].valConvElements[4];
            d.pulseCoeff3L3 = this.pulseAmplitudeCoeff[l].valConvElements[5];
        }
        d.ac1 = data.valAcValues[0];
		d.ac3 = data.valAcValues[1];



		return d;
    }

	private double currentPulseCoeff = 0.0;

    /**
     * 脈波振幅関連係数データ列追加
     * @param data 心拍数
     */
    public void add(Hot2gMeasDataHRElement data)
	{
		//this.currentPulseCoeff = System.Math.Abs(data.valConvElements[0]) + System.Math.Abs(data.valConvElements[1]);

		this.pulseAmplitudeCoeff.Add((data));
		this.pulseAmplitudeCoeffIndex1.Add(Math.Abs(data.valConvElements[0]) + Math.Abs(data.valConvElements[1]));

	}

	private double currentHr = 0.0;

    /**
     * 心拍数計測データ追加
     * @param data 心拍数
     */
    public void add(Hot2gMeasDataHR data)
    {
        //        this.addCounter(data.valResultCount)
        //        this.counts.add(data.valResultCount)
        //        this.tick.add(this.calcTick(data.valResultCount))
        this.currentHr = data.valConvHR;
        //this.onHrAdded(this.counts.size)
        this.pulseRates.Add(data);
    }

    /**
     * オフセット時間の計算
     * 0.0からHzずつ加算される
     * @param count 結果カウンタ
     */
    float calcTick( int count )
    {
        //TODO: Hzの取得
        if (this.tick.Count < 1)
            return 0.0f;





        
        return this.tick[this.tick.Count - 1] + 0.1f;
    }

    const double ABSORPTION_COEFFICIENT = 0.2;
    /** A/Dコンバータ max value (12bit) */
    const double V_MAX = 1 << 12;
    /**
     * calculate Hemoglobin density in blood
     * @param data output of A/D converter
     * @return Hemoglobin density in mMol*mm
     */
    double bloodDensity(int data)
    {
        if (data == 0)
            return 0.0;

        return -System.Math.Log(((double)data) / V_MAX) / ABSORPTION_COEFFICIENT;
    }

    private double x0 = 0.0;
    private double y0 = 0.0;
    private double z0 = 0.0;
    /**
     * モーション計測データの追加 (at 10Hz)
     * カウントの追加はしません。
     * @param data モーション計測データ
     * @return オフセット時間
     */
    public GyroScope.Stability add(Hot2gMeasDataMotBatt data)
    {
        this.gyroX.Add(data.valConvGyros[0]);
        this.gyroY.Add(data.valConvGyros[1]);
        this.gyroZ.Add(data.valConvGyros[2]);
        this.accelX.Add(data.valConvAccels[0]);
        this.accelY.Add(data.valConvAccels[1]);
        this.accelZ.Add(data.valConvAccels[2]);
        //        val s = this.gyroScope.calcStatability(data.valConvGyros[0],data.valConvGyros[1],data.valConvGyros[2])
        GyroScope.Stability s = this.gyroScope.calcStatability(
                data.valConvAccels[0], data.valConvAccels[1], data.valConvAccels[2]);
        //data.valConvGyros[0], data.valConvGyros[1], data.valConvGyros[2]);

        this.stability.Add(s);

        //this.stabilityCheckBuffer.Add(s);
        
        //this.stability.Add(checkPostureChange());

        //        this.mark.add("%.8f".format(this.gyroScope.debugM.toString()))
        //this.mark.Add(this.gyroScope.debugM.ToString());
        this.mark.Add(this.gyroScope.debugM.ToString("N3"));
        //for debug
        this.x0 = this.gyroScope.debugX0;
        this.y0 = this.gyroScope.debugY0;
        this.z0 = this.gyroScope.debugZ0;

        batteryPercentage = data.valGauge;

        return s;
    }

    /*
    int PostureCheckTimeWindow = 10;
    GyroScope.Stability checkPostureChange()
    {
        if (this.stabilityCheckBuffer.Count < PostureCheckTimeWindow) return GyroScope.Stability.Stabled;

        //- check
        Debug.Log("Motions: ??");
        int n = 0;
        for (int i = 0; i < PostureCheckTimeWindow - 1; i++)
        {
            //- Stabledが一つでもあれば姿勢変化ではないので戻る。
            if (
            Hot2gApplication.Instance.datastore.stabilityCheckBuffer[Hot2gApplication.Instance.datastore.stabilityCheckBuffer.Count - 1 - i]
                == GyroScope.Stability.Stabled) return GyroScope.Stability.Stabled;
            n++;
        }
        Debug.Log("Motions: " + n);

        return 
    }*/


    int _lastStatablityChangedIndex = 0;

    int _movedCount = 0;
    /** 一秒間安定し続けたか */
    bool isOneSecondStabled(bool isStable)
    {
        if(!isStable)
        {
            _movedCount = 0;
            return false;
        }

        if (_movedCount < 10)
            _movedCount++;

        return (_movedCount >= 10);
    }



    private string currentMark = null;
    /**
     * 外部からマーカーを追加します。
     * 任意の文字列を設定できます。
     */
    public void addMark(string mark)
    {
        this.mark.Add(mark);
        this.currentMark = mark;
    }

    private string currentReaction = null;
    /**
     * 外部からマーカーを追加します。
     * 任意の文字列を設定できます。
     */
    public void addReaction( string mark)
    {
        this.currentReaction = mark;
    }

	public void add(Hot2gGainData.ParamGain data)
	{
		mgcParameter_L1.Add(data.ch0_L_AmpGain);

		mgcParameter_L3.Add(data.ch1_L_AmpGain);

		mgcParameter_R1.Add(data.ch0_R_AmpGain);

		mgcParameter_R3.Add(data.ch1_R_AmpGain);

	}

}
