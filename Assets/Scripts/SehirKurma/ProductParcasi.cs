using System.Collections;
using System.Collections.Generic;
using GameVanilla.Game.Common;
using UnityEngine;
using UnityEngine.UI;


public class ProductParcasi : MonoBehaviour
{
    [SerializeField] ProductMenusu _productMenusu;
    [SerializeField] int _productNo,_openingLevel;
    [SerializeField] private GameObject _lockedGroup, _openingGroup, _openedGroup;
    [SerializeField] private Slider _productLevelSlideri;
    [SerializeField] private Text _idleRevenueText,_levelText,_purchaseAmountText;
    [SerializeField] private Image _upgradeButtonImg;
    [SerializeField] private Sprite _maxLevelImg;
    private int _idleCoinAmount,_upgradeAmount, _productLevel;

    void Start()
    {
        //PlayerPrefs.SetInt("ProductLevel"+ _productMenusu._haritaNo + _productMenusu._panelNo + _productNo,1);
        //PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo);

        //PlayerPrefs.SetInt("ProductIdleRevenue" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, 1);
        //PlayerPrefs.GetInt("ProductIdleRevenue" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo);

        //PlayerPrefs.SetInt("GeneralIdleRevenue", 1);
        //PlayerPrefs.GetInt("GeneralIdleRevenue");


        //PlayerPrefs.SetInt("UpgradeBedel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, 1);
        //PlayerPrefs.GetInt("UpgradeBedel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo);
        if (_openingLevel>=PlayerPrefs.GetInt("MevcutLevel"))
        {
            _lockedGroup.SetActive(true);
            _openingGroup.SetActive(false);
            _openedGroup.SetActive(false);
            Debug.Log("locked ekranı");
        }
        else
        {
            Debug.Log("locked ekranı değil");
            if (PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo) == 0)
            {
                _lockedGroup.SetActive(false);
                _openingGroup.SetActive(true);
                _openedGroup.SetActive(false);
                Debug.Log("opening ekranı");
            }
            else
            {
                _lockedGroup.SetActive(false);
                _openingGroup.SetActive(false);
                _openedGroup.SetActive(true);
                Debug.Log("opened ekranı");
            }
        }

        GameObject.Find("UIKontrolcu").GetComponent<UIKontrolcu>().IdleCoinTextGuncelleme();
        ProductSliderGuncelleme();

    }

    public void OpenLockButton()
    {
        if (PlayerPrefs.GetInt("HomeSceneToplamYildiz")>=3)
        {
            _lockedGroup.SetActive(false);
            _openingGroup.SetActive(false);
            _openedGroup.SetActive(true);
            _productLevel = 1;
            _levelText.text = "Level 1";
            PlayerPrefs.SetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, 1);
            PurchaseGuncelle(_productLevel);

            PlayerPrefs.SetInt("OpenedProductAmount" + _productMenusu._haritaNo + _productMenusu._panelNo, PlayerPrefs.GetInt("OpenedProductAmount" + _productMenusu._haritaNo + _productMenusu._panelNo) + 1);

            _productMenusu.UpgradeOpenedProductAmount();

            GameObject.Find("UIKontrolcu").GetComponent<UIKontrolcu>().YildizGuncelle(3);

        }
    }

    public void UpgradeButton()
    {
        if (PlayerPrefs.GetInt("ProductCost" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo)< PlayerPrefs.GetInt("num_coins"))
        {
            if (PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo) < 20)
            {
                PuzzleMatchManager.instance.coinsSystem.SpendCoins(PlayerPrefs.GetInt("ProductCost" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo));
                _productLevel = PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo) + 1;
                PlayerPrefs.SetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, _productLevel);
                PlayerPrefs.SetInt("ProductSpendCoinForUpgrade" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo,
                    PlayerPrefs.GetInt("ProductSpendCoinForUpgrade" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo) + int.Parse(_purchaseAmountText.text));
                ProductSliderGuncelleme();
            }
            else
            {

            }

        }
        else
        {

        }

    }

    private void ProductSliderGuncelleme()
    {
        if (PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo)>=20)
        {
            _productLevel = PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo);
            _productLevelSlideri.value = _productLevel;
            _levelText.text = "Level" + _productLevelSlideri.value;
            _upgradeButtonImg.sprite = _maxLevelImg;
            _purchaseAmountText.text = "Max Level";
            _purchaseAmountText.transform.parent.GetComponent<Button>().interactable = false;
        }
        else
        {
            _productLevel = PlayerPrefs.GetInt("ProductLevel" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo);
            _productLevelSlideri.value = _productLevel;
            _levelText.text = "Level" + _productLevelSlideri.value;
            PurchaseGuncelle(_productLevel);
        }
    }

    private void PurchaseGuncelle(int _productSeviyesi)
    {
        

        switch (_productSeviyesi)
        {
            case 1:
                _upgradeAmount = 100;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 0;
                break;
            case 2:
                _upgradeAmount = 150;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 6;
                break;
            case 3:
                _upgradeAmount = 200;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 7;
                break;
            case 4:
                _upgradeAmount = 250;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 8;
                break;
            case 5:
                _upgradeAmount = 300;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 9;
                break;
            case 6:
                _upgradeAmount = 350;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 10;
                break;
            case 7:
                _upgradeAmount = 400;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 11;
                break;
            case 8:
                _upgradeAmount = 450;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 12;
                break;
            case 9:
                _upgradeAmount = 500;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 13;
                break;
            case 10:
                _upgradeAmount = 550;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 14;
                break;
            case 11:
                _upgradeAmount = 600;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 15;
                break;
            case 12:
                _upgradeAmount = 650;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 16;
                break;
            case 13:
                _upgradeAmount = 700;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 17;
                break;
            case 14:
                _upgradeAmount = 750;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 18;
                break;
            case 15:
                _upgradeAmount = 800;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 19;
                break;
            case 16:
                _upgradeAmount = 850;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 20;
                break;
            case 17:
                _upgradeAmount = 900;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 21;
                break;
            case 18:
                _upgradeAmount = 950;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 22;
                break;
            case 19:
                _upgradeAmount = 1000;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 23;
                break;
            case 20:
                _upgradeAmount = 1050;
                _purchaseAmountText.text = _upgradeAmount.ToString();
                _idleCoinAmount = 24;
                break;


        }

        IdleGelirGuncelle(_idleCoinAmount);

    }

    private void IdleGelirGuncelle(int _idleDeger)
    {
        PlayerPrefs.SetInt("ProductCost"+ _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, _upgradeAmount);
        PlayerPrefs.SetInt("GeneralIdleRevenue", PlayerPrefs.GetInt("GeneralIdleRevenue")- PlayerPrefs.GetInt("TempIdleDeger" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo));
        _idleRevenueText.text = _idleDeger.ToString()+"/min";

        PlayerPrefs.SetInt("ProductIdleRevenue" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, _idleDeger);
        PlayerPrefs.SetInt("TempIdleDeger" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo, _idleDeger);
        PlayerPrefs.SetInt("GeneralIdleRevenue", PlayerPrefs.GetInt("GeneralIdleRevenue") + PlayerPrefs.GetInt("ProductIdleRevenue" + _productMenusu._haritaNo + _productMenusu._panelNo + _productNo));
        GameObject.Find("UIKontrolcu").GetComponent<UIKontrolcu>().IdleCoinTextGuncelleme();
        _productMenusu.IdleCoinTextGuncelle();
        _productMenusu.BinaSliderGuncelle();
    }
}
