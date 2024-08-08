using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMod : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] Image animalBut;
    [SerializeField] GameObject effect;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PointerEnter(Sprite sprite)
    {
        audioSource.PlayOneShot(clip);
        animalBut.sprite = sprite;
    }
    public void PointerExit(Sprite sprite)
    {
        animalBut.sprite = sprite;
    }

    public void SelectLevel(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        effect.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneName);
    }
}
