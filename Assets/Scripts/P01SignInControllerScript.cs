﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P01SignInControllerScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSignUp()
    {

        SceneManager.LoadScene("02.SignUp");
    }

    public void SignIn()
    {

        SceneManager.LoadScene("05.NoticeBrainAnalysis");
    }



}
