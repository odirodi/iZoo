using System;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public float msToWait = 5000.0f;


    public static int TotalGold = 0;  //the users total gold ***very important value

    public int iGold = 0; //gold that the animal makes
    public Text tScore; //the score at the top of the screen
    

    private Text chestTimer;
    private Button chestButton;
    private ulong lastTimeOpen;


    private void Start()
    {
        chestButton = GetComponent<Button>();
        lastTimeOpen = ulong.Parse(PlayerPrefs.GetString("LastTimeOpened"));
        chestTimer = GetComponentInChildren<Text>();


        if (!IsChestReady())
            chestButton.interactable = false;
    }

    private void Update()
    {
        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
                chestTimer.text = "Harvest";
                return;
            }
            //set the timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (msToWait - m) / 1000;

            string r = "";
            //Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //Min
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            //Seconds
            r += (secondsLeft % 60).ToString("00") + "s "; ;
            chestTimer.text = r;
        }
       
    }
    public void CheckClick()
    {
        lastTimeOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastTimeOpened",DateTime.Now.Ticks.ToString());
        chestButton.interactable = false;

        TotalGold = TotalGold + iGold;
        tScore.text = TotalGold.ToString();
        //When clicked do your action here for your harvest animal. Is where you roll dice

    }

    private bool IsChestReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (msToWait - m) / 1000; // the equation esentially divides ms by 1000 to get result in Seconds

        if (secondsLeft <= 0)
        {
            chestTimer.text = "Harvest";
            return true;
        }

        return false;
    }
    
}
