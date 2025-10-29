using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private TimeUI timeUI;
    [SerializeField] private float speed;

    private void Awake()
    {
        timeUI = GameObject.FindAnyObjectByType<TimeUI>();
    }

    private void Update()
    {
        if (timeUI.Time >= 10f)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
