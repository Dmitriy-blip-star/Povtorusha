using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMod : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    
    [SerializeField] GameObject effect;
    private Dictionary<Image, Sprite> buttonSprites = new Dictionary<Image, Sprite>();

    [SerializeField] Image animalBut;
    [SerializeField] Image transportBut;
    [SerializeField] Image emotioinsBut;

    [SerializeField] Sprite animalChangeSprite;
    [SerializeField] Sprite transportChangeSprite;
    [SerializeField] Sprite emotionsChangeSprite;

    [SerializeField] Sprite exampleChangeSprite;
    [SerializeField] Image examplBut;

    Sprite startImageBut;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        buttonSprites.Add(animalBut, animalChangeSprite);
        buttonSprites.Add(transportBut, transportChangeSprite);
        buttonSprites.Add(emotioinsBut, emotionsChangeSprite);
        buttonSprites.Add(examplBut, exampleChangeSprite);
    }

    public void PointerEnter(Image button)
    {
        startImageBut = button.sprite;
        audioSource.PlayOneShot(clip);
        button.sprite = buttonSprites[button];
    }
    public void PointerExit(Image button)
    {
        button.sprite = startImageBut;
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
