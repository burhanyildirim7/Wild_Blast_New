using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductMenusu : MonoBehaviour
{
    [SerializeField] MapScript _sehirHaritasi;
    [SerializeField] public int _panelNo,_haritaNo;
    [SerializeField] private Slider _binaLevelSlideri;
    [SerializeField] Text _sliderDurumText,_idleRevenueText,_openedProductAmountText;

    private int _tempIdleCoinAmount,_tempSliderValue;
    void Start()
    {
        _haritaNo = _sehirHaritasi._haritaNo;
        UpgradeOpenedProductAmount();
        IdleCoinTextGuncelle();
        BinaSliderGuncelle();
    }

    void Update()
    {
        
    }

    public void BinaSliderGuncelle()
    {
        _tempSliderValue = 0;
        for (int i = 0; i < 4; i++)
        {
            _tempSliderValue = _tempSliderValue + PlayerPrefs.GetInt("ProductSpendCoinForUpgrade" + 0 + 0 + i);
        }

        if (_tempSliderValue>=10000)
        {
            _binaLevelSlideri.value = 100;
            _sliderDurumText.text = _binaLevelSlideri.value + "/100";

        }
        else
        {
            _binaLevelSlideri.value = _tempSliderValue / 100;
            _sliderDurumText.text = _binaLevelSlideri.value + "/100";

        }
    }
    public void IdleCoinTextGuncelle()
    {
        _tempIdleCoinAmount = 0;
        for (int i = 0; i < 4; i++)
        {
            _tempIdleCoinAmount= _tempIdleCoinAmount+PlayerPrefs.GetInt("ProductIdleRevenue" + _haritaNo + _panelNo + i);
        }
        PlayerPrefs.SetInt("ProductPanelIdleRevenue" + _haritaNo + _panelNo, _tempIdleCoinAmount);
        _idleRevenueText.text="Revenue:"+ PlayerPrefs.GetInt("ProductPanelIdleRevenue" + _haritaNo + _panelNo, _tempIdleCoinAmount).ToString() + "/min";

    }
    public void UpgradeOpenedProductAmount()
    {

        _openedProductAmountText.text = PlayerPrefs.GetInt("ProductLevel" + _haritaNo + _panelNo).ToString()+"/4";
        
    }
}
