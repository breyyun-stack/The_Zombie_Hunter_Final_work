using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private float _startVolume = 0.2f;
    [SerializeField] private string _eventPath = "event:/BackGroundMusic/BackGroundMusic"; // путь к событию (скопируй из FMOD)
    
    private EventInstance musicInstanceBackground;

    private void Start()
    {
        musicInstanceBackground = RuntimeManager.CreateInstance(_eventPath);

        musicInstanceBackground.start();

        SetVolume(_startVolume);
    }

    private void OnDisable()
    {
        musicInstanceBackground.release();
    }

    /// <summary>
    /// Регулировка громкости
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {

        volume = Mathf.Clamp01(volume);

        var result = musicInstanceBackground.setVolume(volume);
        // FMOD использует dB: 0 dB = 100%, -80 dB = ~тишина
        // Преобразуем линейный volume (0..1) в dB
        //float dB = Mathf.Lerp(-80f, 0f, volume); // 0 → -80dB (тихо), 1 → 0dB (полная громкость)
        //musicInstanceBackground.setVolume(dB); // setVolume() принимает dB!
    }
}
