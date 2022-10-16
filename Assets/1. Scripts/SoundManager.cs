using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundSound;
    [field: SerializeField] public Slider _soundSlider { get; private set; }
    private float _soundVolume;

    private void Awake()
    {
        BackgroundSound.volume = Saver.Load(nameof(_soundVolume));
        _soundSlider.value = BackgroundSound.volume;
    }

    public void SetBackgroundVolume(float value)
    {
        BackgroundSound.volume = value;
        Saver.Save(nameof(_soundVolume), value);
    }
}
