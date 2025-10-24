using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;

public class StageUI : MonoBehaviour
{
    private TextMeshProUGUI stageText;

    private int stageCounter;

    private void Awake()
    {
        if (stageText == null)
        {
            stageText = FindFirstObjectByType<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        stageCounter = 1;

        stageText.text = $"STAGE\n{stageCounter}";
    }

    private void UpdateText()
    {
        stageText.text = $"STAGE\n{stageCounter}";
    }

    public void UpdateStageCount()
    {
        stageCounter++;
        UpdateText();
    }
}
