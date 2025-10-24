using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI goalText;
    public bool IsGoal {  get; private set; } = false;

    private void GoalCollected()
    {
        IsGoal = true;
        this.transform.position = new Vector3(1000f, transform.position.y, transform.position.z);
        goalText.text = "Stage Clear!";

        StartCoroutine(AfterDelay());
    }

    private IEnumerator AfterDelay()
    {
        yield return new WaitForSeconds(3f);
        goalText.text = "";
        IsGoal = false;

        FindFirstObjectByType<TimeUI>().ResetTime(); // 経過時間リセット
        FindFirstObjectByType<StageUI>().UpdateStageCount();


        // 再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoalCollected();
        }
    }
}
