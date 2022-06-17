using UnityEngine;

public class TimeSpeed : MonoBehaviour
{
    public float timeSpeed = 1f;
    void Update()
    {
        Time.timeScale = timeSpeed;
    }
}