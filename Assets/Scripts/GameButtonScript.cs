using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonScript : MonoBehaviour
{

    public GameObject SettingsMenu;

    private void Start()
    {
        SettingsMenu = GameObject.Find("SettingsPanel");
        SettingsMenu.SetActive(false);
    }

    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            EnableCursor();
            SettingsMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
    public void PlaySFX(string name)
    {
        AudioManager.Instance.PlaySFX(name);
    }

    public void PlayMusicOnLoad(string name)
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlayMusic(name);
    }

}
