using UnityEngine;

[CreateAssetMenu(fileName = "New Animal Data", menuName = "Animal/AnimalData")]
public class AnimalCardSO : ScriptableObject
{
    public AudioClip Audio;
    public Sprite Sprite;
    public Sprite BackSprite;
    // ”бираем флаг IsFlipped здесь, чтобы он не был общим дл€ всех экземпл€ров
}
