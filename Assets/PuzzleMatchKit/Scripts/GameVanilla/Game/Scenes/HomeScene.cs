using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

using GameVanilla.Core;
using GameVanilla.Game.Popups;

namespace GameVanilla.Game.Scenes
{
    /// <summary>
    /// This class contains the logic associated to the home scene.
    /// </summary>
    public class HomeScene : BaseScene
    {
#pragma warning disable 649
        [SerializeField]
        private AnimatedButton soundButton;

        [SerializeField]
        private AnimatedButton musicButton;
        [SerializeField] private Text _playButtonText;
#pragma warning restore 649

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(soundButton);
            Assert.IsNotNull(musicButton);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            if (PlayerPrefs.GetInt("IlkAcilis") == 0)
            {
                PlayerPrefs.SetInt("MevcutLevel", 1);
                _playButtonText.text = "LEVEL " + PlayerPrefs.GetInt("MevcutLevel");
                PlayerPrefs.SetInt("IlkAcilis", 1);
            }
            else
            {
                _playButtonText.text = "LEVEL " + PlayerPrefs.GetInt("MevcutLevel");
            }

            UpdateButtons();
        }

        /// <summary>
        /// Called when the settings button is pressed.
        /// </summary>
        public void OnSettingsButtonPressed()
        {
            OpenPopup<SettingsPopup>("Popups/SettingsPopup");
        }

        /// <summary>
        /// Called when the sound button is pressed.
        /// </summary>
        public void OnSoundButtonPressed()
        {
            SoundManager.instance.ToggleSound();
        }

        /// <summary>
        /// Called when the music button is pressed.
        /// </summary>
        public void OnMusicButtonPressed()
        {
            SoundManager.instance.ToggleMusic();
        }

        /// <summary>
        /// Updates the state of the UI buttons according to the values stored in PlayerPrefs.
        /// </summary>
        public void UpdateButtons()
        {
            var sound = PlayerPrefs.GetInt("sound_enabled");
            soundButton.transform.GetChild(1).GetComponent<SpriteSwapper>().SetEnabled(sound == 1);
            var music = PlayerPrefs.GetInt("music_enabled");
            musicButton.transform.GetChild(1).GetComponent<SpriteSwapper>().SetEnabled(music == 1);
        }
    }
}
