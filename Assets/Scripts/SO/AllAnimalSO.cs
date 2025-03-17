using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All animal data", menuName = "Animal/AllAnimal")]
public class AllAnimalSO : ScriptableObject
{
    public AnimalCardSO[] AnimalButtonsSO;
}
