using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : Singleton<GameMaster>
{
    public int collectedCoins;

    public int coinsRequiredToWin = 5;

    public TMP_Text uiCollected;

    public TMP_Text uiWinAmount;

    public GameObject mainCamera;
    public GameObject winCamera;
    // Start is called before the first frame update
    void Start()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        int countValue =0;
        foreach (var coin in coins)
        {
            countValue += coin.value;
        }

        coinsRequiredToWin = countValue;
        uiCollected.text = collectedCoins.ToString();
        uiWinAmount.text = coinsRequiredToWin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinCollected(int value = 1)
    {
        collectedCoins += value;
        uiCollected.text = collectedCoins.ToString();
        HasEnoughCoins();
    }

    private void HasEnoughCoins()
    {
        if (collectedCoins >= coinsRequiredToWin)
        {
            mainCamera.SetActive(false);
            winCamera.SetActive(true);
        }
    }
}
