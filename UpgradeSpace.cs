using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSpace : MonoBehaviour
{

    public int iCost;
    public Text tScore;
    public GameObject gGround;
    



    public void BuySpace()
    {
        if (Chest.TotalGold >= iCost) {
            Chest.TotalGold = Chest.TotalGold - iCost;
            tScore.text = Chest.TotalGold.ToString();
            gGround.gameObject.transform.localScale += new Vector3(1, 0, 1);
            
        }


    }
}
