using Key;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LevelCompleted => _numberOfKeysNow == _requiredNumberOfKeys;
    public float Delay => _delay;
    
    [SerializeField, Header("Нужное кол-во ключей для прохождения уровня"), Range(1, 2)]
    private int _requiredNumberOfKeys;
    [SerializeField, Range(0, 10), Header("Время ожидания прежде чем перейти в новую сцену")]
    private float _delay;
    private int _numberOfKeysNow = 0;

    private void OnEnable()
    {
        EventsKey.EventAddKey += AddKey;
    }

    private void OnDisable()
    {
        EventsKey.EventAddKey -= AddKey;
    }

    private void AddKey()
    {
        _numberOfKeysNow++;
    }
}