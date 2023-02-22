﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class toggleContent : MonoBehaviour
{
    /// <summary>
    /// This is used on Dashboard and is used to switch the text between logged on and 
    /// non registered users. 
    /// Retrieving Riros from DB - do we need this? 
    /// When registered display the JC and Riros together with a tip or two 
    /// </summary>
    /// 

    public GameObject notloggedon;
    public GameObject loggedon;
    public Text earnRirosTxt;
    
    void Start()
    {
    
        registerCheck();

    }

    public void registerCheck()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
        {
            loggedon.SetActive(true);
            notloggedon.SetActive(false);
            earnRirosTxt.text = "Earn Riros";

       
        }
        else
        {
            notloggedon.SetActive(true);
            loggedon.SetActive(false);
            earnRirosTxt.text = "Register";

            //use playerprefs for riro amounts - these already exist (or not) so don't need to do anything
        }
    }
    // Update is called once per frame

    
}
