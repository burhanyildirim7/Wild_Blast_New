using System.Collections;
using System.Collections.Generic;
using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.Popups;
using UnityEngine;
using UnityEngine.UI;

public class BinaSatinAlma : MonoBehaviour
{
	[SerializeField] private Text _priceText;
    [SerializeField] private int _buttonNo;
    [SerializeField] List<Sprite> _binaGorselleri=new List<Sprite>() ;
    [SerializeField] private GameObject _buildingContent;
    private GameObject _bosAlanObject;
    [SerializeField] private ParticleSystem coinParticles;
    int _starAmound;
	int _cost;
    BaseScene _baseScene;
    private void Start()
    {
        _baseScene = GameObject.FindObjectOfType<BaseScene>();
        if (PlayerPrefs.GetInt("ContentKullanildi"+_buttonNo)==1)
        {
            Destroy(gameObject);
        }
        else
        {

        }


    }
    public void SatinAlmaButton()
    {

        _cost = int.Parse(_priceText.text);
        _starAmound = PlayerPrefs.GetInt("HomeSceneToplamYildiz");
        if (_cost <= _starAmound)
        {
            _bosAlanObject = _buildingContent.transform.GetChild(PlayerPrefs.GetInt("SecilenBina")+1).gameObject;
            GameObject.Find("UIKontrolcu").GetComponent<UIKontrolcu>().YildizGuncelle(_cost);
            coinParticles.Play();
            SoundManager.instance.PlaySound("CoinsPopButton");
            PlayerPrefs.SetInt("Acildimi" + _bosAlanObject.GetComponent<BinaKurma>()._haritaNo + _bosAlanObject.GetComponent<BinaKurma>()._binaNo, 1);
            _bosAlanObject.transform.GetChild(0).gameObject.SetActive(false);
            _bosAlanObject.transform.GetChild(1).gameObject.SetActive(true);
            _bosAlanObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = _binaGorselleri[_buttonNo];
            PlayerPrefs.SetInt("BinaGorseli" + _bosAlanObject.GetComponent<BinaKurma>()._haritaNo + _bosAlanObject.GetComponent<BinaKurma>()._binaNo, _buttonNo);
            GameObject.Find("PanelKapatmaScript").GetComponent<PanelKapatma>().AnaEkrandaPanelKapatma();
            GameObject.Find("Building_Choice_Panel").transform.GetChild(0).gameObject.SetActive(false);
            PlayerPrefs.SetInt("ContentKullanildi" + _buttonNo, 1);
            Destroy(gameObject);

        }
        else
        {

            _baseScene.OpenPopup<SettingsPopup>("Popups/NotEnoughStarPopUp");
            Debug.Log("YETERLİ PARA YOK");
            Debug.Log("cost: "+_cost);
            Debug.Log("coins: "+_starAmound);
        }

    }
  
}
