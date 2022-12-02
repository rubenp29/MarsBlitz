using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public static VolumeControl Instance { get; private set; } = null;

    [SerializeField] private string volumeParameter = "MasterVolume";

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider slider;

    [SerializeField] private float multipler = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandlerSliderValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    private void HandlerSliderValueChanged(float musicVolume)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(musicVolume) * multipler);
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }
}