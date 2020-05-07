using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tr_TrainingNeuroTestCanvasScript : MonoBehaviour
{


    // Chart making
    const int BRAIN_VALUES_COUNT = 300;
    [SerializeField] GameObject BrainValueBackgroudImage;
    [SerializeField] GameObject target;
    GameObject[] BrainValueColumnArray = new GameObject[BRAIN_VALUES_COUNT];


    //Values
    List<float> BrainValueList = new List<float>();


    // Time controll
    float SumDeltatime;
    int p=0;

    // GetBrainFlowData
    public Tr_TrainingNeuro _Tr_TrainingNeuro;



    // Debug
    [SerializeField] Text BrainValueText;
    [SerializeField] Text TestValueText;




    // Start is called before the first frame update
    void Start()
    {


    }




    // Update is called once per frame
    void Update()
    {

//        if (p < BRAIN_VALUES_COUNT*200)
//        {
            UpdateChart();
        //        }




    }



    void UpdateChart()
    {


        //        BrainValueText.text = bvalue.ToString()+"\n"+BrainValueText.text;




        // Do once a second
        SumDeltatime += Time.deltaTime;
        if (SumDeltatime > 0.1f)
        {

//            float bvalue = _Tr_TrainingNeuro._length;
//            BrainValueText.text = bvalue.ToString() + "\n" + BrainValueText.text;

            float sin = Mathf.Sin(Time.time);
            BrainValueList.Add(sin * 50 + 50);
            TestValueText.text = (sin * 50 + 50).ToString() + "\n" + TestValueText.text;




            if (p < BRAIN_VALUES_COUNT)
            {

                BrainValueColumnArray[p] = Instantiate(target, new Vector3(p + 30, 0, 0), Quaternion.identity);
                BrainValueColumnArray[p].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);
                BrainValueColumnArray[p].transform.SetParent(BrainValueBackgroudImage.transform, false);
            }
            else
            {

                for(int i=0; i < BRAIN_VALUES_COUNT-1; i++)
                {
                    BrainValueColumnArray[i].GetComponent<RectTransform>().sizeDelta = BrainValueColumnArray[i+1].GetComponent<RectTransform>().sizeDelta;
                }
                BrainValueColumnArray[BRAIN_VALUES_COUNT-1].GetComponent<RectTransform>().sizeDelta = new Vector2(1, BrainValueList[p]);

                //                Debug.Log(BrainValueArray);


            }




            SumDeltatime = 0;
            p++;

            Debug.Log(p + " :p");

        }






}






}
