﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class paidOut : MonoBehaviour
{
    /// <summary>
    /// Single script to get riros
    /// </summary>
    /// 

    private int DBuser;
    public string category;
    private Button theButton;
    private ColorBlock theColor;
    public Text payout; 
    public Text explanation;
    string posturl = "http://masterchange.today/php_scripts/paidout.php";

    void Awake()
    {
        theButton = GetComponent<Button>();
        theColor = GetComponent<Button>().colors;

    }
    // Start is called before the first frame update
    void Start()
    {
        checkPayment();
    }

    public void checkPayment()
    {
        DBuser = PlayerPrefs.GetInt("dbuserid");
             StartCoroutine(getRirosDB());

 
    }
    // Update is called once per frame


    IEnumerator getRirosDB()
    {

        WWWForm form = new WWWForm();

         form.AddField("userid", DBuser);
        form.AddField("description", category);

        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
         //   Debug.Log("there was a yyy" + www.error);
            //errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

        }
        else
        {
            //update the player prefs
            string json = www.downloadHandler.text;
         //   Debug.Log("json for paid out: " + json);
            riros riros = JsonUtility.FromJson<riros>(json);
        //     //Debug.Log("ocming back: " + json);
          riros loadedresults = JsonUtility.FromJson<riros>(json);
            if (loadedresults.Paid == "0")
            {
                explanation.text = "\t\u2022 Green buttons indicate you are yet to provide information and can earn riros" + '\n' + " \t\u2022 *Are mandatory to start the quit smoking experience" + '\n' + "\t\u2022 The rest will result in a more personalised experience";
                 theColor.normalColor = new Color32(72, 173, 66, 255);
            
                theButton.colors = theColor;
             //    payout.text = "Ro$"; 
            }
        }
    }

    //public class payout
    //{
    //    public int paythem;
    //}
    private class riros
    {
        public string Paid;

    }
}
