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
        [SerializeField] private Text numDiamondsText;

        // Start is called before the first frame update
        private void Start()
        {
            var numCoins = PlayerPrefs.GetInt("num_coins");

            int numDiamonds = PlayerPrefs.GetInt("num_diamond");

            numCoinsText.text = numCoins.ToString();
            numDiamondsText.text = numDiamonds.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnDestroy()
        {

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
