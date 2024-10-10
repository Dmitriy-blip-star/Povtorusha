using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject selectLevelPanel;

    private void Awake()
    {
        CheckPanelStatus();
    }

    private void CheckPanelStatus()
    {
        menuPanel.SetActive(true);
        settingPanel.SetActive(false);
        selectLevelPanel.SetActive(false);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PointerEnter()
    {
        audioSource.PlayOneShot(clip);
    }

    public void GameScene(string gameName)
    {
        SceneManager.LoadScene(gameName);
    }

    public void MenuScene(string menuName)
    {

        SceneManager.LoadScene(menuName);
    }

    public void SelectModPanelOn(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void SettingPanelOn()
    {
        settingPanel.SetActive(true);
    }

    public void SaveSettings()
    {
        settingPanel.SetActive(false);
        Debug.Log("Дописать метод");
    }
}
