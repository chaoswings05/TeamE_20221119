using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceMove : MonoBehaviour
{
    void OnMouseDrag()
    {

            Debug.Log("����ł�");
            //�}�E�X�̍��W���擾���ăX�N���[�����W���X�V
            Vector3 thisPosition = Input.mousePosition;
            //�X�N���[�����W�����[���h���W
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.z = 0f;

            this.transform.position = worldPosition;
        
    }
}


