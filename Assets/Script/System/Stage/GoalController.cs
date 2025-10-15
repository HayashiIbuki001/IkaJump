using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // StageManager �X�N���v�g�ւ̎Q��
    private StageManager stageManager;

    void Start()
    {
        // �V�[������ StageManager ��T��
        stageManager = FindFirstObjectByType<StageManager>();
    }

    void OnDestroy()
    {
        // Goal �I�u�W�F�N�g���j�󂳂ꂽ�Ƃ��� StageManager �� Update ���\�b�h���Ă�
        stageManager.Update();
    }
}