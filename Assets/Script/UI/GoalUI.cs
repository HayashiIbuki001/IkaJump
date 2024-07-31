using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public Text goalText;



    private void Start()
    {
        if (goalText == null)
        {
            Debug.LogError("goalTextÇ™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
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
