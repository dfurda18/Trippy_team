using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

namespace UI
{
    public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _defaultSprite, _pressedSprite;
        [SerializeField] private AudioClip _compressedAudioClip, _uncompressedAudioClip;
        [SerializeField] private AudioSource _audioSource;

        public void OnPointerDown(PointerEventData eventData)
        {
            _image.sprite = _pressedSprite;
            _audioSource.PlayOneShot(_compressedAudioClip);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _image.sprite = _defaultSprite;
            _audioSource.PlayOneShot(_uncompressedAudioClip);
        }
    }
}