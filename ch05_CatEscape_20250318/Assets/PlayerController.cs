using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 멤버 변수 선언
    private float fMaxPositionX = 10.0f;    // 플레이어가 좌우 이동시 게임창을 벗어나지 않도록 하는 Vector 최댓값 설정 변수
    private float fMinPositionX = -10.0f;   // 플레이어가 좌우 이동시 게임창을 벗어나지 않도록 하는 Vector 최솟값 설정 변수
    float fPositionX = 0.0f;                // 플레이어가 좌우 이동할 수 있는 X좌표 저장 변수


    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LButtonDown()
    {
        transform.Translate(-1, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(1, 0, 0);
    }
    
    void Update()
    {
        //왼쪽 화살표를 누르는 중에
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            // 왼쪽으로 0.3 움직인다.
            transform.Translate(-0.3f, 0, 0);
        }

        //오른쪽 화살표를 누르는 중에
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        {
            // 오른쪽으로 0.3 움직인다.
            transform.Translate(0.3f, 0, 0);
        }
        /*
          Mathf.Clamp(value, min, max) 메서드
           특정 값을 어떠한 범위에 제한시키고자 할 때 사용하는 메서드
           value 값의 범위 : min <= value <= max
           최소/최대값을 설정하여 지정한 범위 이외에 값이 되지 않도록 할 때 사용
           플레이어가 움직일 수 있는 최소(fMaxPositionX)/최대(fMaxPositionX) 범위값을 사용하여 그 범위를 벗어나지 않도록 한다. 
         */
        fPositionX = Mathf.Clamp(transform.position.x, fMinPositionX, fMaxPositionX);
        transform.position = new Vector3(fPositionX, transform.position.y, transform.position.z);
    }
}
