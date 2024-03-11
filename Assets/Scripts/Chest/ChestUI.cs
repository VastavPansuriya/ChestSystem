using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//view
public class ChestUI : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] private Button chestButton;
    [SerializeField] private Button purchaseButton;

    [Space()]
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_Text priceText;


    [Space()]
    [SerializeField] private GameObject emptyObject;
    [SerializeField] private GameObject chestObject;

    [Space()]
    [SerializeField] private ChestDataListSO chestDataListSO;

    private ChestController chestController;

    private void Awake()
    {
        chestController = new ChestController(this, chestDataListSO);
        chestButton.onClick.AddListener(() =>
        {
            chestController.OnChestClick();
        });

        purchaseButton.onClick.AddListener(() => {
            chestController.OnPurchse();
        });
    }

    public void SetImage(Sprite sprite)
    {
        chestImage.sprite = sprite;
    }

    public void SetInfo(string val)
    {
        infoText.text = val;
    }

    public void SetPrice(string price)
    {
        priceText.text = price.ToString();
    }

    public void SetEmpty()
    {
        emptyObject.SetActive(true);
        chestObject.SetActive(false);
    }

    public void SetActive()
    {
        emptyObject.SetActive(false);
        chestObject.SetActive(true);
    }

    private void Update()
    {
        chestController.StateUpdate();
    }

    public bool IsChestEmpty()
    {
        return emptyObject.activeSelf;
    }

    public ChestController GetController()
    {
        return chestController;
    }

    public void PurchaseButtonToggle(bool v)
    {
        purchaseButton.gameObject.SetActive(v);
    }
}
