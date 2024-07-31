using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{

    public Text stageText;

    // Start is called before the first frame update
    void Start()
    {
        if (stageText == null)
        {
            Debug.LogError("stageText‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }

    public void StageText(int stageCount)
    {
        if (stageText != null)
        {
            stageText.text = "Stage " + (stageCount + 1);
        }
        else
        {
            Debug.LogError("stageText ‚ªİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }
}
