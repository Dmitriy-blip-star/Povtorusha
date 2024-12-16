using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StandartButtonsLogic : MonoBehaviour
    {
        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void CloseSelectModPanel(GameObject selectModPanel)
        {
            selectModPanel.SetActive(false);    
        }
    }
}