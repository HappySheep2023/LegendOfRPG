using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;      // 캐릭터 움직임 스피드
    [SerializeField] private float height; // 이동 위치 저장
    [SerializeField] private GameObject player; // 캐릭터
    [SerializeField] private Vector3 movePoint; // 이동 위치 저장
    [SerializeField] private Camera mainCamera; // 메인 카메라
    [SerializeField] private GameObject point; // 포인트
    private bool isMove = true;
    
    void Update()
    {
    
        // 좌클릭 이벤트가 들어왔다면
        if (Input.GetMouseButtonDown(1))
        {
            // 카메라에서 레이저를 쏜다.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);
    
            // 레이저가 뭔가에 맞았다면
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                // 맞은 위치를 목적지로 저장
                movePoint = raycastHit.point;
                point.transform.position = movePoint;
                isMove = true;
            }
        }
    
        // 이동
        Move();
        
    }
    
    void Move()
    { 
        if (isMove)
        {
            if (Vector3.Distance(movePoint, player.transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
            var dir = movePoint - player.transform.position;
            player.transform.position += dir.normalized * Time.deltaTime * speed;
            var pos = player.transform.position;
            player.transform.position = new Vector3(pos.x, height, pos.z);
        }
    }
}
