using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlace : MonoBehaviour
{
    // �z�u����I�u�W�F�N�g���w��iSerializeField��ǉ��j
    [SerializeField]
    private GameObject groundObject;

    // �S�[���ɂȂ�I�u�W�F�N�g���w��iSerializeField��ǉ��j
    [SerializeField]
    private GameObject goalObject;

    // �I�u�W�F�N�g�̔z�u��
    [SerializeField, Tooltip("�I�u�W�F�N�g�̔z�u��")]
    private int numberOfObjects = 10;

    // y���̊Ԋu
    [SerializeField, Tooltip("y���̊Ԋu")]
    private float ySpacing = 9.1f;

    [SerializeField] private Transform background;
    [SerializeField, Tooltip("�w�i��1��ŐL�΂�����")] private float addHeight = 20f;
    private SpriteRenderer backGroundSr;
    

    void Start()
    {
        backGroundSr = background.GetComponent<SpriteRenderer>();

        // �G���[�`�F�b�N
        ErrorCheck();

        // �I�u�W�F�N�g��z�u
        PlaceObjects();
    }

    void ErrorCheck()
    {
        if (groundObject == null)
        {
            Debug.LogError("GroundObject���A�^�b�`����Ă��܂���");
        }

        if (goalObject == null)
        {
            Debug.LogError("GoalObject���A�^�b�`����Ă��܂���");
        }
    }

    void PlaceObjects()
    {
        // ��ԍ���y���̈ʒu���L�^���邽�߂̕ϐ�
        float maxYPosition = 0f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            // y���̈ʒu��ySpacing������
            float yPosition = ySpacing * (i + 1);

            // x���̃����_���Ȉʒu���擾�i�͈͂� -16 ~ 0 �ɐݒ�j
            float randomX = Random.Range(-16f, 0f);

            // �I�u�W�F�N�g�̐V�����ʒu��ݒ�
            Vector3 newPosition = new Vector3(randomX, yPosition, 0f);

            // �I�u�W�F�N�g���w�肳�ꂽ�ʒu�ɃC���X�^���X��
            Instantiate(groundObject, newPosition, Quaternion.identity);

            // ��ԍ���y���̈ʒu���X�V
            if (yPosition > maxYPosition)
            {
                maxYPosition = yPosition;
            }
                
        }

        // �S�[���I�u�W�F�N�g�̔z�u
        if (goalObject != null)
        {
            float goalYPosition = maxYPosition + ySpacing;
            // �S�[���I�u�W�F�N�g��x���ʒu�� -10 �ɌŒ�
            goalObject.transform.position = new Vector3(-8f, goalYPosition, 0f);

            // �w�i��L�΂�
            if (background != null)
            {
                

                background.position += new Vector3(0, addHeight / 2f, 0);
            }
        }
    }

    public void Reload()
    {
        numberOfObjects += 3;
        PlaceObjects();
    }
}