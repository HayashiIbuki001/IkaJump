using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageCount = 0;
    public bool counter = false;
    public bool counted = false;

    // GoalUI �X�N���v�g�ւ̎Q��
    private GoalUI goalUI;

    void Start()
    {
        // �V�[������ GoalUI ��T��
        goalUI = FindFirstObjectByType<GoalUI>();
        if (goalUI == null)
        {
            Debug.LogError("GoalUI ���V�[�����Ɍ�����܂���");
        }
    }

    // Update �̓t���[�����ƂɌĂ΂��
    public void Update()
    {
        // �Q�[������ Goal �^�O���t�����I�u�W�F�N�g�����ׂď��������`�F�b�N
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)
        {
            counter = true;
            StageCounter();
        }

        if (GameObject.FindGameObjectsWithTag("Goal").Length == 1)
        {
            counter = false;
            counted = false;
        }
    }

    // �X�e�[�W�J�E���^�[�𑝂₷�֐�
    public void StageCounter()
    {
        if (counter)
        {
            if (!counted)
            {
                stageCount++;
                Debug.Log("�X�e�[�W�J�E���g: " + stageCount);
                counted = true;

                //�����ɒǉ�
                if (goalUI != null)
                {
                    goalUI.DisplayGoalText("Stage " + stageCount + "\nClear!");
                }
            }
        }
    }
}
