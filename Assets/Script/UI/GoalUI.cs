using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public Text goalText;

    private void Start()
    {
        if (goalText == null)
        {
            Debug.LogError("goalTextが設定されていません");
        }
    }
    public void DisplayGoalText(string message)
    {
        goalText.text = message;
        goalText.enabled = true;
    }

    public void HideGoalText()
    {
        goalText.enabled = false;
    }
}
