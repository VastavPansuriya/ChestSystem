using System;
using TMPro;

public class GemService
{
    private TMP_Text gemText;
    private int totalCoinAmmount;

    public static Func<int,bool> OnChangeGems;

    public GemService(TMP_Text gemText)
    {
        this.gemText = gemText;
        OnChangeGems += CoinService_OnChangeGems;
        const int startingGemsAmount = 100;
        CoinService_OnChangeGems(startingGemsAmount);
    }

    private bool CoinService_OnChangeGems(int value)
    {
        totalCoinAmmount += value;
        if (totalCoinAmmount < 0)
        {
            totalCoinAmmount -= value;
            return false;
        }
        SetGemText();
        return true;
    }

    private void SetGemText()
    {
        gemText.text = totalCoinAmmount.ToString();
    }

    ~GemService()
    {
        OnChangeGems -= CoinService_OnChangeGems;
    }
}
