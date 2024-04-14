using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ManageVolume : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private FloatObject volume;
    [SerializeField] private string audioMixerName;

    private void Awake()
    {
      volumeSlider.value = volume.value;
      audioMixer.SetFloat(audioMixerName, volume.value);
    }

    public void OnNotify()
    {
      volume.value = volumeSlider.value;
      audioMixer.SetFloat(audioMixerName, volumeSlider.value);
    }
}
