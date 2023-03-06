using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.Popups;
using GameVanilla.Game.UI;


namespace GameVanilla.Game.Scenes
{

    public class SatinAlmaScript : BaseScene
    {

        [SerializeField]
        private Text numCoinsText;
        [SerializeField]
        private Text numDiamondsText;

        // Start is called before the first frame update
        private void Start()
        {
            var numCoins = PlayerPrefs.GetInt("num_coins");
            //var numDiamonds = PlayerPrefs.GetInt("num_diamond");
            var numDiamonds = 0;
            PlayerPrefs.SetInt("num_diamond",0);
            //Debug.Log("SAHIP OLDUGUM PARA:"+numCoins);
            if (numCoins >= 1000)
            {
                numCoinsText.text = (numCoins / 1000f).ToString("F1") + "K";
            }
            else if (numCoins >= 1000000)
            {
                numCoinsText.text = (numCoins / 1000000f).ToString("F1") + "M";
            }
            else if (numCoins >= 1000000000)
            {
                numCoinsText.text = (numCoins / 1000000000f).ToString("F1") + "B";
            }
            else
            {
                numCoinsText.text = numCoins.ToString();
            }
            
            if (numDiamonds >= 1000)
            {
                numDiamondsText.text = (numDiamonds / 1000f).ToString("F1") + "K";
            }
            else if (numDiamonds >= 1000000)
            {
                numDiamondsText.text = (numDiamonds / 1000000f).ToString("F1") + "M";
            }
            else if (numDiamonds >= 1000000000)
            {
                numDiamondsText.text = (numDiamonds / 1000000000f).ToString("F1") + "B";
            }
            else
            {
                numDiamondsText.text = numDiamonds.ToString();
            }
            PuzzleMatchManager.instance.coinsSystem.Subscribe(OnCoinsChanged);
            PuzzleMatchManager.instance.coinsSystem.Subscribe(OnDiamondsChanged);

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnDestroy()
        {
            PuzzleMatchManager.instance.coinsSystem.Unsubscribe(OnCoinsChanged);
            PuzzleMatchManager.instance.coinsSystem.Unsubscribe(OnDiamondsChanged);

        }

        /* public void OnSpinWheelButtonPressed()
         {
             OpenPopup<SpinWheelPopup>("Popups/SpinWheelPopup", popup =>
             {
                 var gameConfig = PuzzleMatchManager.instance.gameConfig;
                 popup.SetInfo(gameConfig.spinWheelItems, gameConfig.spinWheelCost);
             });
         }*/
        public void OnBuyCoinButtonPressed()
        {
            OpenPopup<BuyCoinsPopup>("Popups/BuyCoinsPopup");
        }
        public void OnBuyDiamondsButtonPressed()
        {
            OpenPopup<BuyCoinsPopup>("Popups/BuyDiamondsPopup");
        }

        /// <summary>
        /// Called when the number of coins changes.
        /// </summary>
        /// <param name="numCoins">The current number of coins.</param>
        private void OnCoinsChanged(int numCoins)
        {
            if (numCoins >= 1000)
            {
                numCoinsText.text = (numCoins / 1000f).ToString("F1") + "K";
            }
            else if (numCoins >= 1000000)
            {
                numCoinsText.text = (numCoins / 1000000f).ToString("F1") + "M";
            }
            else if (numCoins >= 1000000000)
            {
                numCoinsText.text = (numCoins / 1000000000f).ToString("F1") + "B";
            }
            else
            {
                numCoinsText.text = numCoins.ToString("F1");
            }
            Debug.Log("SAHIP OLDUGUM PARA:" + numCoins);

        }
        private void OnDiamondsChanged(int numDiamonds)
        {
            if (numDiamonds >= 1000)
            {
                numDiamondsText.text = (numDiamonds / 1000f).ToString("F1") + "K";
            }
            else if (numDiamonds >= 1000000)
            {
                numDiamondsText.text = (numDiamonds / 1000000f).ToString("F1") + "M";
            }
            else if (numDiamonds >= 1000000000)
            {
                numDiamondsText.text = (numDiamonds / 1000000000f).ToString("F1") + "B";
            }
            else
            {
                numDiamondsText.text = numDiamonds.ToString("F1");
            }
            Debug.Log("SAHIP OLDUGUM DIAMONDS:" + numDiamonds);

        }

        public void OnBuyLivesButtonPressed()
        {
            var numLives = PlayerPrefs.GetInt("num_lives");
            var maxLives = PuzzleMatchManager.instance.gameConfig.maxLives;
            if (numLives < maxLives)
            {
                OpenPopup<BuyLivesPopup>("Popups/BuyLivesPopup");
            }
        }

    }

}
