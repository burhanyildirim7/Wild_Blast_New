using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.UI;

namespace GameVanilla.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the popup for buying coins.
    /// </summary>
    public class BuyDiamondPopup : Popup
    {
#pragma warning disable 649
        [SerializeField]
        private GameObject iapItemsParent;

        [SerializeField]
        private GameObject iapRowPrefab;

        [SerializeField]
        private Text numDiamondsText;

        [SerializeField]
        private ParticleSystem coinsParticles;
#pragma warning restore 649

        private Popup loadingPopup;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            //Assert.IsNotNull(iapItemsParent);
            //Assert.IsNotNull(iapRowPrefab);
            //Assert.IsNotNull(numDiamondsText);
            //Assert.IsNotNull(coinsParticles);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            int diamondsMiktari = PlayerPrefs.GetInt("num_diamond");
            numDiamondsText.text = diamondsMiktari.ToString("n0");
            //PuzzleMatchManager.instance.coinsSystem.Subscribe(OnCoinsChanged);

          /*  foreach (var item in PuzzleMatchManager.instance.gameConfig.iapItems)
            {
                var row = Instantiate(iapRowPrefab);
                row.transform.SetParent(iapItemsParent.transform, false);
                row.GetComponent<IapRowDiamond>().Fill(item);
                row.GetComponent<IapRowDiamond>().buyDiamondPopup = this;
            }*/
        }

        /// <summary>
        /// Unity's OnDestroy method.
        /// </summary>
        private void OnDestroy()
        {
            //PuzzleMatchManager.instance.coinsSystem.Unsubscribe(OnCoinsChanged);
        }

        /// <summary>
        /// Called when the buy button is pressed.
        /// </summary>
        /// <param name="numDiamond">The number of coins to buy.</param>
        public void OnBuyButtonPressed(int numDiamond)
        {
            Debug.Log("Buy Diamınd fonk çalıştı");
            PuzzleMatchManager.instance.coinsSystem.BuyDiamond(numDiamond);
        }

        /// <summary>
        /// Called when the close button is pressed.
        /// </summary>
        public void OnCloseButtonPressed()
        {
            Close();
        }

        /// <summary>
        /// Called when the number of coins changes.
        /// </summary>
        /// <param name="numDiamond">The current number of coins.</param>
        public void OnDiamondChanged(int numDiamond)
        {
            Debug.Log("diamond guncellendi");
            numDiamondsText.text = numDiamond.ToString("n0");
            coinsParticles.Play();
            GetComponent<PlaySound>().Play("CoinsPopButton");
        }

        /// <summary>
        /// Opens a loading popup.
        /// </summary>
        public void OpenLoadingPopup()
        {
#if UNITY_IOS
            parentScene.OpenPopup<LoadingPopup>("Popups/LoadingPopup",
                popup =>
                {
                    loadingPopup = popup;
                }, false);
#endif
        }

        /// <summary>
        /// Closes the loading popup.
        /// </summary>
        public void CloseLoadingPopup()
        {
#if UNITY_IOS
            if (loadingPopup != null)
            {
                loadingPopup.Close();
            }
#endif
        }
    }
}
