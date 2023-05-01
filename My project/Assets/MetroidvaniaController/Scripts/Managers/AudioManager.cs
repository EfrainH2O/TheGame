using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer Sonido, Effects;
    public static AudioManager instance;

    [Range(-80,10)]
    public float masterVolumeMusic, masterVolumeEffects;
    public Slider MusicSlider, EffectsSlider;

    private void Awake(){
      
        if(instance==null){

            instance=this;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
      MusicSlider.value = masterVolumeMusic;
      EffectsSlider.value = masterVolumeEffects;

      MusicSlider.minValue = -80;
      MusicSlider.maxValue = 10;
      
      EffectsSlider.minValue = -80;
      EffectsSlider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
      MasterVolumeE();
      MasterVolumeM();
    }

    public void MasterVolumeM()
    {
    Sonido.SetFloat("masterVolumeM", MusicSlider.value);
   }

      public void MasterVolumeE()
    {
    Effects.SetFloat("masterVolumeE", EffectsSlider.value);
   }

}