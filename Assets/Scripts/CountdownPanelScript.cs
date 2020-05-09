using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownPanelScript : MonoBehaviour
{

    [SerializeField] GameObject CountdownPanelImage;
    public float DeltaTimeCount = 0f;
    public Text CountdownText;
    public int CountdownInt;


    // Start is called before the first frame update
    void Start()
    {
        CountdownPanelImage.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {

        DeltaTimeCount += Time.deltaTime;


        if (DeltaTimeCount >= 1.0f)
        {

            DeltaTimeCount = 0.0f;


            if (CountdownInt > 0)
            {
                //カウントダウン表示
                CountdownText.text = CountdownInt.ToString();

            }
            else
            {

                CountdownPanelImage.SetActive(false);



            }

            //1秒たったのでカウントをダウンする
            CountdownInt--;

        }

    }





}
