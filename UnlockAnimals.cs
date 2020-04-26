using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockAnimals : MonoBehaviour
{

    public int iCost;
    public Text tScore;
    public GameObject gAnimal;
    public Button bPurchase;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Buy()
    {
        if (Chest.TotalGold >= iCost) {
            Chest.TotalGold = Chest.TotalGold - iCost;
            tScore.text = Chest.TotalGold.ToString();
            gAnimal.SetActive(true);
            bPurchase.gameObject.SetActive(false);
        }


    }
}
