using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    int musicOn;
    public Slider _musicSlider, _sfxSlider, _difficultySlider;
    public Toggle musicToggle;

    public void ToggleMusic() 
    {
        AudioManager.Instance.ToggleMusic();
    }

    /*
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
    */

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject DifficultyMenu;
    public GameObject AudioMenu;
    public GameObject InstructMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        _difficultySlider.value = PlayerPrefs.GetFloat("difficulty");

        musicOn = PlayerPrefs.GetInt("musicToggle");
        if(musicOn == 0)
        {
            musicToggle.isOn = false;
            AudioManager.Instance.musicSource.mute = true;

        }
        else
        {
            musicToggle.isOn = true;
            AudioManager.Instance.musicSource.mute = false;
        }

            OptionsMenu = GameObject.Find("Options menu");
        OptionsMenu.SetActive(false);

        MainMenu = GameObject.Find("Main menu");

        DifficultyMenu = GameObject.Find("Difficulty menu");
        DifficultyMenu.SetActive(false);

        AudioMenu = GameObject.Find("Audio menu");
        AudioMenu.SetActive(false);

        InstructMenu = GameObject.Find("Instructions");
        InstructMenu.SetActive(false);

        _musicSlider.value = AudioManager.Instance.musicSource.volume;
        _sfxSlider.value = AudioManager.Instance.sfxSource.volume;

        if (AudioManager.Instance.musicSource.mute)
        {
            musicToggle.isOn = false;
        }
    }

    

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayMusicOnLoad(string name)
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic(name);
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlaySFX(string name)
    {
        AudioManager.Instance.PlaySFX(name);
    }

    // Update is called once per frame
    void Update()
    {
        if(musicToggle.isOn)
        {
            musicOn = 1;
        }
        else
        {
            musicOn = 0;
        }
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", _sfxSlider.value);
        PlayerPrefs.SetFloat("difficulty", _difficultySlider.value);
        PlayerPrefs.SetInt("musicToggle", musicOn);
    }
}
