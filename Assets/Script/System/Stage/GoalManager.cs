using System.Collections;
using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goalText;
    public bool isGoal = false;

    private void GoalCollected()
    {
        isGoal = true;
        goalText.text = "Stage Clear!";

        StartCoroutine(AfterDelay());
    }

    private IEnumerator AfterDelay()
    {
        yield return new WaitForSeconds(3f);
        goalText.text = "";
        isGoal = false;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoalCollected();
        }
    }
}
