using System;
using TMPro;
using UnityEngine;

public class CoinService
{
    private TMP_Text coinText;
    private int totalCoinAmmount;

    public static Func<int,bool> OnChangeCoins;

    public CoinService(TMP_Text coinText)
    {
        this.coinText = coinText;
        OnChangeCoins += CoinService_OnChangeCoins;

        const int startingCoinAmount = 100;
        CoinService_OnChangeCoins(startingCoinAmount);
    }

    private bool CoinService_OnChangeCoins(int value)
    {
        totalCoinAmmount += value;
        if (totalCoinAmmount < 0)
        {
            totalCoinAmmount -= value;
            return false;
        }
        SetCoinText();
        return true;
    }


    private void SetCoinText()
    {
        coinText.text = totalCoinAmmount.ToString();
    }

    ~CoinService()
    {
        OnChangeCoins -= CoinService_OnChangeCoins;
    }
}