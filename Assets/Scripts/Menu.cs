using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject menuPanel;

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
        menuPanel.SetActive(false);
    }
}
