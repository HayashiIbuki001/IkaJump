using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageCount = 0;

    // Update �̓t���[�����ƂɌĂ΂��
    public void Update()
    {
        // �Q�[������ Goal �^�O���t�����I�u�W�F�N�g�����ׂď��������`�F�b�N
        if (GameObject.FindGameObjectsWithTag("Goal").Length == 0)
        {
            // �X�e�[�W�J�E���^�[�𑝂₷
            StageCounter();
        }
    }

    // �X�e�[�W�J�E���^�[�𑝂₷�֐�
    public void StageCounter()
    {
        stageCount++;
        Debug.Log("�X�e�[�W�J�E���g: " + stageCount);
    }
}
