using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Slider _musicSlider, _sfxSlider;

        public void MusicVolume()
        {
            BetterAudioManager.Instance.MusicVolume(_musicSlider.value);
        }
        
        public void SFXVolume()
        {
            BetterAudioManager.Instance.SFXVolume(_sfxSlider.value);
        }
    }
}
