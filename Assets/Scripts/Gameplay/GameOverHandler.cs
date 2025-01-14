using UnityEngine;
using UnityEngine.Events;

public class GameOverHandler : MonoBehaviour
{
    public static UnityAction GameOver;

    private void Start()
    {
        Time.timeScale = 1f;
        GameOver+= GameEnd;
    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
    }
}
