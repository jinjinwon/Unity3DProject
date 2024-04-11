using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float scroll;

    public Transform target;

    [SerializeField][Tooltip("ī�޶� ȸ�� ����")]                   private float fRotSensitive = 3f;
    [SerializeField][Tooltip("ī�޶� �� ȸ�� ����")]                private float fZoomSensitive = 0.5f;
    [SerializeField][Tooltip("ī�޶� ȸ������ �ּ�")]               private float fRotationMin = -10f;
    [SerializeField][Tooltip("ī�޶� ȸ������ �ִ�")]               private float fRotationMax = 80f;   
    [SerializeField][Tooltip("ī�޶� ȸ���ϴµ� �ɸ��� �ð�")]    private float fSmoothTime = 0.12f;

    [SerializeField][Tooltip("ī�޶�� �÷��̾� ������ �ִ� �Ÿ�")] private float fDisMax = 10f;
    [SerializeField][Tooltip("ī�޶�� �÷��̾� ������ �ּ� �Ÿ�")] private float fDisMin = 2f;

    [SerializeField][Tooltip("ī�޶� ���� ����")]                   private bool bRotationStatic = false;

    // ���� ����
    private Vector3 vec_TargetRotation;
    private Vector3 vec_CurrentVel;
    private float fCurrentDis = 3f;
    private float fStaticPostionY = 0;

    void LateUpdate()
    {
        #region Windows
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * fRotSensitive;                         // Y���� ȸ����Ų��
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * fRotSensitive;                         // X���� ȸ����Ų�� * Xaxis�� ���콺�� �Ʒ��� ������(�������� �Է� �޾�����) ���� �������� ī�޶� �Ʒ��� ȸ���Ѵ� 
        scroll = Input.GetAxis("Mouse ScrollWheel");                                      // ���� �� �ƿ�
        if (Input.GetKeyDown(KeyCode.Y) == true) bRotationStatic = !bRotationStatic;      // ���� ���� �� Ǯ��

        // ���� �� �ƿ�
        if (scroll < 0)
        {
            fCurrentDis = (fCurrentDis >= fDisMax) ? fDisMax : ++fCurrentDis;
        }
        else if (scroll > 0)
        {
            fCurrentDis = (fCurrentDis <= fDisMin) ? fDisMin : --fCurrentDis;
        }

        // X�� ȸ���� �Ѱ�ġ�� ���� �ʵ��� ����
        Xaxis = Mathf.Clamp(Xaxis, fRotationMin, fRotationMax);

        if (bRotationStatic == false)
        {
            // SmoothDamp�� ���� �ε巯�� ī�޶� ȸ��
            vec_TargetRotation = Vector3.SmoothDamp(vec_TargetRotation, new Vector3(Xaxis, Yaxis), ref vec_CurrentVel, fSmoothTime);
            this.transform.eulerAngles = vec_TargetRotation;
        }

        Vector3 targetPosition = target.position - transform.forward * fCurrentDis;

        // Xaxis�� 0���� �۰ų� ���� ��� ó��
        if (Xaxis <= 0)
        {
            // fStaticPositionY �ʱ�ȭ ������ �ʿ��� ��� ���⼭ ����
            if (fStaticPostionY == 0)
                fStaticPostionY = targetPosition.y;

            // ī�޶� ��ġ ������Ʈ - Y ��ġ�� fStaticPositionY�� ����
            transform.position = new Vector3(targetPosition.x, fStaticPostionY, targetPosition.z);
        }
        else
        {
            // Xaxis�� 0���� ū ���, fStaticPositionY�� targetPosition.y ���� �۰ų� ������ ����
            if (fStaticPostionY != 0 && targetPosition.y >= fStaticPostionY)
                fStaticPostionY = 0;

            // ī�޶� ��ġ ������Ʈ - fStaticPositionY�� ���µǾ��ٸ�, ��ü targetPosition ���
            transform.position = (fStaticPostionY == 0) ? targetPosition : new Vector3(targetPosition.x, fStaticPostionY, targetPosition.z);
        }
        #endregion
    }

    // UI ��ư�� ���� RotationStatic ���� ��� (����Ͽ� �ڵ�)
    public void ToggleRotationStatic()
    {
        bRotationStatic = !bRotationStatic;
    }
}

