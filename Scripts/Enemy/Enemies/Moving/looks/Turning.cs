using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        Transform myTransform = this.transform;

        // ���[�J�����W��ŁA���݂̉�]�ʂ։��Z����
        myTransform.Rotate(0, 0, rotateSpeed / 10);
    }
}
