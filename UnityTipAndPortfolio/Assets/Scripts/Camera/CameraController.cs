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

    [SerializeField][Tooltip("카메라 회전 감도")]                   private float fRotSensitive = 3f;
    [SerializeField][Tooltip("카메라 줌 회전 감도")]                private float fZoomSensitive = 0.5f;
    [SerializeField][Tooltip("카메라 회전각도 최소")]               private float fRotationMin = -10f;
    [SerializeField][Tooltip("카메라 회전각도 최대")]               private float fRotationMax = 80f;   
    [SerializeField][Tooltip("카메라가 회전하는데 걸리는 시간")]    private float fSmoothTime = 0.12f;

    [SerializeField][Tooltip("카메라와 플레이어 사이의 최대 거리")] private float fDisMax = 10f;
    [SerializeField][Tooltip("카메라와 플레이어 사이의 최소 거리")] private float fDisMin = 2f;

    [SerializeField][Tooltip("카메라 시점 고정")]                   private bool bRotationStatic = false;

    // 저장 변수
    private Vector3 vec_TargetRotation;
    private Vector3 vec_CurrentVel;
    private float fCurrentDis = 3f;
    private float fStaticPostionY = 0;

    void LateUpdate()
    {
        #region Windows
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * fRotSensitive;                         // Y축을 회전시킨다
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * fRotSensitive;                         // X축을 회전시킨다 * Xaxis는 마우스를 아래로 했을때(음수값이 입력 받아질때) 값이 더해져야 카메라가 아래로 회전한다 
        scroll = Input.GetAxis("Mouse ScrollWheel");                                      // 줌인 줌 아웃
        if (Input.GetKeyDown(KeyCode.Y) == true) bRotationStatic = !bRotationStatic;      // 시점 고정 및 풀기

        // 줌인 줌 아웃
        if (scroll < 0)
        {
            fCurrentDis = (fCurrentDis >= fDisMax) ? fDisMax : ++fCurrentDis;
        }
        else if (scroll > 0)
        {
            fCurrentDis = (fCurrentDis <= fDisMin) ? fDisMin : --fCurrentDis;
        }

        // X축 회전이 한계치를 넘지 않도록 제한
        Xaxis = Mathf.Clamp(Xaxis, fRotationMin, fRotationMax);

        if (bRotationStatic == false)
        {
            // SmoothDamp를 통해 부드러운 카메라 회전
            vec_TargetRotation = Vector3.SmoothDamp(vec_TargetRotation, new Vector3(Xaxis, Yaxis), ref vec_CurrentVel, fSmoothTime);
            this.transform.eulerAngles = vec_TargetRotation;
        }

        Vector3 targetPosition = target.position - transform.forward * fCurrentDis;

        // Xaxis가 0보다 작거나 같은 경우 처리
        if (Xaxis <= 0)
        {
            // fStaticPositionY 초기화 로직이 필요한 경우 여기서 수행
            if (fStaticPostionY == 0)
                fStaticPostionY = targetPosition.y;

            // 카메라 위치 업데이트 - Y 위치는 fStaticPositionY로 고정
            transform.position = new Vector3(targetPosition.x, fStaticPostionY, targetPosition.z);
        }
        else
        {
            // Xaxis가 0보다 큰 경우, fStaticPositionY가 targetPosition.y 보다 작거나 같으면 리셋
            if (fStaticPostionY != 0 && targetPosition.y >= fStaticPostionY)
                fStaticPostionY = 0;

            // 카메라 위치 업데이트 - fStaticPositionY가 리셋되었다면, 전체 targetPosition 사용
            transform.position = (fStaticPostionY == 0) ? targetPosition : new Vector3(targetPosition.x, fStaticPostionY, targetPosition.z);
        }
        #endregion
    }

    // UI 버튼을 통해 RotationStatic 변수 토글 (모바일용 코드)
    public void ToggleRotationStatic()
    {
        bRotationStatic = !bRotationStatic;
    }
}

