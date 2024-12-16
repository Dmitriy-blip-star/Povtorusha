using System.Collections;
using UnityEngine;
public class MemoryCardController : MonoBehaviour
{
    private MemoryCard firstCard; // Первая перевернутая карточка
    private bool isFirstCard; // Флаг для отслеживания первой карточки
    private bool canFlip; // Флаг, позволяющий переворачивать карточки
    [SerializeField] private AudioSource audioSource; // Ссылка на компонент AudioSource
    [SerializeField] private AudioClip[] loseAudioClips; // Массив аудиоклипов для воспроизведения
    [SerializeField] private AudioClip[] winAudioClips; // Массив аудиоклипов для воспроизведения
    [SerializeField][Range(0, 1)] private float playProbability = 0.5f; // Вероятность воспроизведения (от 0 до 1)

    private void Awake()
    {
        canFlip = true; // Изначально можно переворачивать карточки
    }
    public void Click(MemoryCard card)
    {
        if (!canFlip || card.IsFlipped)
        {
            Debug.Log("Card already flipped or cannot flip now.");
            return; // Игнорировать, если карточка уже перевернута или нельзя переворачивать
        }
        card.Flip(); // Перевернуть карточку
        audioSource.PlayOneShot(card.AudioClip);

        if (!isFirstCard)
        {
            isFirstCard = true;
            firstCard = card; // Запомнить первую карточку

        }
        else
        {
            // Это вторая перевернутая карточка
            canFlip = false; // Запретить переворот новых карточек
            if (firstCard.CompareTo(card)) // Проверить на совпадение
            {
                Debug.Log("Match found!");
                // Здесь можно добавить логику для обработки совпадения
                canFlip = true; // Разрешить переворот карточек
                PlayRandomAudio(true);

                GameManager.instance.WinCheck();
            }
            else
            {
                Debug.Log("No match, flipping back...");
                PlayRandomAudio(false);

                StartCoroutine(FlipBack(firstCard, card)); // Перевернуть карточки обратно
            }
            // Сбросить состояние первой карточки
            isFirstCard = false;
            firstCard = null;
        }
    }

    // Метод, который можно вызывать для воспроизведения случайного аудио
    public void PlayRandomAudio(bool isWin)
    {
        // Выбираем массив в зависимости от результата
        AudioClip[] selectedClips = isWin ? winAudioClips : loseAudioClips;

        // Генерация случайного числа от 0 до 1
        float randomValue = Random.value;

        // Проверяем, должно ли аудио воспроизводиться на основе заданной вероятности
        if (randomValue <= playProbability)
        {
            // Выбираем случайный аудиоклип из выбранного массива
            int randomIndex = Random.Range(0, selectedClips.Length);
            audioSource.PlayOneShot(selectedClips[randomIndex]);
            Debug.Log("Воспроизведен звук: " + selectedClips[randomIndex].name);
        }
        else
        {
            Debug.Log("Звук не воспроизведен.");
        }
    }
    private IEnumerator FlipBack(MemoryCard card1, MemoryCard card2)
    {
        yield return new WaitForSeconds(0.5f); // Задержка перед переворотом обратно
        card1.Unflip(); // Перевернуть первую карточку обратно
        card2.Unflip(); // Перевернуть вторую карточку обратно
        canFlip = true; // Разрешить переворот карточек
    }
}
