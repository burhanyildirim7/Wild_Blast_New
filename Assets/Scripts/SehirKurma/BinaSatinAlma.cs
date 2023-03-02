using System.Collections;
using System.Collections.Generic;
using GameVanilla.Core;
using GameVanilla.Game.Common;
using UnityEngine;
using UnityEngine.UI;

public class BinaSatinAlma : MonoBehaviour
{
	[SerializeField] private Text _priceText;
    [SerializeField] private GameObject _bosAlanObject;
    [SerializeField] private ParticleSystem coinParticles;
    int coins;
	int _cost;
    public void SatinAlmaButton()
    {
		_cost = int.Parse(_priceText.text);
        coins = PlayerPrefs.GetInt("num_coins");
        if (_cost <= coins)
        {
            PuzzleMatchManager.instance.coinsSystem.SpendCoins(_cost);
            coinParticles.Play();
            SoundManager.instance.PlaySound("CoinsPopButton");
            PlayerPrefs.SetInt("Acildimi" + _bosAlanObject.GetComponent<BinaKurma>()._haritaNo + _bosAlanObject.GetComponent<BinaKurma>()._binaNo, 1);
            _bosAlanObject.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("YETERLİ PARA YOK");
            Debug.Log("cost: "+_cost);
            Debug.Log("coins: "+coins);
        }

    }
  
}
