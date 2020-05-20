using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTopCanvasScript : MonoBehaviour
{
    public GameObject DifficultyPanel;


    public void CloseDifficultyPanel()
    {
        DifficultyPanel.SetActive(false);
    }



    public void OpenDifficultyPanel()
    {
        DifficultyPanel.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        //開発中の不注意でパネルがでているとマズイので非表示に
        DifficultyPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
