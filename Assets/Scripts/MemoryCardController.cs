using System.Collections;
using UnityEngine;

public class MemoryCardController : MonoBehaviour
{
    private MemoryCard firstCard; // Первая перевернутая карточка
    private bool canFlip = true; // Флаг, позволяющий переворачивать карточки
    [SerializeField] private AudioSource _audioSource; // Ссылка на компонент AudioSource
    [SerializeField] private AudioClip[] loseAudioClips; // Массив аудиоклипов для воспроизведения
    [SerializeField] private AudioClip[] winAudioClips; // Массив аудиоклипов для воспроизведения
    [SerializeField][Range(0, 1)] private float playProbability = 0.5f; // Вероятность воспроизведения (от 0 до 1)

    private void Awake()
    {
        canFlip = true; // Изначально можно переворачивать карточки
    }

    // Метод для обработки клика на карточку
    public void Click(MemoryCard card)
    {
        // Если карточка уже перевернута или нельзя переворачивать, игнорируем клик
        if (!canFlip || card.IsFlipped)
        {
            return;
        }

        card.Flip(); // Перевернуть карточку
        PlayAudio(card.Card.Audio); // Воспроизвести звук карты

        // Если это первая карточка
        if (firstCard == null)
        {
            firstCard = card;
            return;
        }

        // Это вторая перевернутая карточка
        canFlip = false; // Запрещаем переворачивать новые карты
        StartCoroutine(HandleCardMatch(firstCard, card)); // Обработать матч
    }
    private void PlayAudio(AudioClip currentAnimalAudio)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.PlayOneShot(currentAnimalAudio);
    }
    // Обработчик совпадения карт
    private IEnumerator HandleCardMatch(MemoryCard card1, MemoryCard card2)
    {
        if (card1.CompareTo(card2)) // Если карты совпадают
        {
            PlayRandomAudio(true); // Воспроизвести победный звук
            GameManager.instance.WinCheck(); // Проверка на победу (или завершение игры)
        }
        else // Если карты не совпадают
        {
            PlayRandomAudio(false); // Воспроизвести проигрышный звук
            yield return new WaitForSeconds(0.5f); // Задержка перед переворотом обратно
            card1.Unflip(); // Перевернуть обратно первую карточку
            card2.Unflip(); // Перевернуть обратно вторую карточку
        }

        // Сброс состояния после проверки
        firstCard = null;
        canFlip = true; // Разрешить переворот новых карточек
    }

    // Метод для воспроизведения случайного аудио
    public void PlayRandomAudio(bool isWin)
    {
        // Выбор массива аудио в зависимости от результата
        AudioClip[] selectedClips = isWin ? winAudioClips : loseAudioClips;

        // Проверка, нужно ли воспроизвести аудио (в зависимости от вероятности)
        if (Random.value <= playProbability)
        {
            int randomIndex = Random.Range(0, selectedClips.Length);
            _audioSource.PlayOneShot(selectedClips[randomIndex]); // Воспроизвести случайный аудиоклип
        }
    }
}
