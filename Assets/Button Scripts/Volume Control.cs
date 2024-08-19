using UnityEngine;
using UnityEngine.UI;
public class Volumecontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Slider volumeSlider;
    [SerializeField] public Slider SFXSlider;
    [SerializeField] private Slider MusicSlider;
    public float Volume;
    public float SFX;
    public float Music;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Volume = volumeSlider.value / 100;
        SFX = Volume / (100 / SFXSlider.value);
        Music = Volume / (100 / MusicSlider.value);
    }
}
