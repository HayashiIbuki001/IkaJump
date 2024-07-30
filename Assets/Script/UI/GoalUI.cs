using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public Text goalText;

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
