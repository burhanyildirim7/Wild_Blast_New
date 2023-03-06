using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.Popups;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// An in-app purchasable item in the shop popup.
    /// </summary>
    public class IapRowDiamond : MonoBehaviour
    {
        [HideInInspector]
        public BuyDiamondPopup buyDiamondPopup;

#pragma warning disable 649
        [SerializeField] GameObject _buyDiamondPopup;
        [SerializeField]
        private Text numCoinsText;
        [SerializeField]
        private Text priceText;
#pragma warning restore 649

        private void Awake()
        {

        }
        private void Start()
        {
            priceText.text = "$5,99";
        }
        public void OnDiamondPurchaseButtonPressed()
        {
            Debug.Log("diamond satın alındı");
            PlayerPrefs.SetInt("num_diamond", PlayerPrefs.GetInt("num_diamond") + int.Parse(numCoinsText.text));
            _buyDiamondPopup.GetComponent<BuyDiamondPopup>().OnDiamondChanged(PlayerPrefs.GetInt("num_diamond")) ;
            if (GameObject.Find("UIKontrolcu") != null)
            {
                GameObject.Find("UIKontrolcu").GetComponent<UIKontrolcu>().DiamondTextGuncelle(PlayerPrefs.GetInt("num_diamond"));
            }
            else
            {

            }

        }
    }
}
