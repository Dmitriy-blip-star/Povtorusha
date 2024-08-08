using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Assets
{
    public class Transport : MonoBehaviour
    {
        [SerializeField] private AudioClip[] transportAudios;
        [SerializeField] private AudioSource audioSource;
        private AudioClip currentAudio;
        private int currentAudioIndex;

        bool isChoose = false;
        [SerializeField] AudioClip winAudio;

        [SerializeField] GameObject[] examples;

        [SerializeField] TextMeshProUGUI textMeshProUGUI;
        [SerializeField] AudioClip failAudio;
        [SerializeField] Transform[] buttonsPositions;

        public static Transport Initial;

        private void Start()
        {
            NewCards();
            Initial = this;
        }

        public void RestartLvl()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void StartGameMenu(string nameOfScene)
        {
            SceneManager.LoadScene(nameOfScene);
        }

        public void TransportButtons(GameObject butt)
        {
            switch(currentAudioIndex)
            {
                case 0:
                    
                    if (butt.tag == "Example")
                    {
                        isChoose = true;
                    }
                    else
                    {
                        isChoose = false;
                    }
                    IsChoose();
                    break;
                    case 1:
                    {
                        
                        if (butt.tag == "Example1")
                        {
                            isChoose = true;
                        }
                        else
                        {
                            isChoose= false;
                        }
                        IsChoose();
                        break;
                    }
                case 2:
                    {
                        if (butt.tag == "Example2")
                        {
                            isChoose = true;
                            
                        }
                        else
                        {
                            isChoose = false;
                        }
                        IsChoose();
                        break;
                    }
                case 3:
                    {
                        IsChoose();
                        if (butt.tag == "Example3")
                        {
                            isChoose = true;
                        }
                        else
                        {
                            isChoose = false;
                        }
                        break;
                    }
            }
        }

        private void IsChoose()
        {
            if (isChoose)
            {
                audioSource.PlayOneShot(winAudio);
                textMeshProUGUI.text = "Win!";
                NewCards();
            }
            else
            {
                textMeshProUGUI.text = "Fail!";
                audioSource.PlayOneShot(failAudio);
            }
        }

        private void NewCards()
        {
            currentAudioIndex = Random.Range(0, transportAudios.Length);
            currentAudio = transportAudios[currentAudioIndex];
            for (int i = 0; i < 4; i++)
            {
                
                Instantiate(examples[Random.Range(0, examples.Length)], buttonsPositions[i]);
            }
        }
    }
}