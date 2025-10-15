using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] TextMeshPro goalText;
    public bool isGoal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGoal = true;
        }
    }
}
