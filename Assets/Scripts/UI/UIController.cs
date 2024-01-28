using Audio;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Slider _musicSlider;

        public void MusicVolume()
        {
            BetterAudioManager.instance.MusicVolume(_musicSlider.value);
        }
        
        public void SFXVolume()
        {
            BetterAudioManager.instance.SFXVolume(_musicSlider.value);
        }
    }
}
