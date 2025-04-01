using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowController : MonoBehaviour
{
    // 멤버 변수 선언
    GameObject gPlayer = null;  // 플레이어 오브젝트를 저장할 게임 오브젝트 변수, 게임 오브젝트 변수의 초기값은 null
    // 화살과 플레이어 충돌 판정
    Vector2 vArrowCirclePoint = Vector2.zero;   // 화살을 둘러싼 원의 중심 좌표
    Vector2 vPlayerCirclePoint = Vector2.zero;  // 플레이어를 둘러싼 원의 중심좌표
    Vector2 vArrowPlayerDir = Vector2.zero;     // 화살과 플레이어까지의 벡터값

    private float fArrowRadius = 0.5f;              // 화살의 반지름
    private float fPlayerRadius = 0.5f;             // 플레이어의 반지름
    private float fArrowPlayerDistance = 0.0f;      // 화살의 중심(vArrowCirclePoint)부터 플레이어를 둘러싼 원의 중심까지의 거리
    
    void Start()
    {
        gPlayer = GameObject.Find("player");
    }

    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);
        
        // 화면 밖으로 나가면 오브젝트를 소멸시킨다.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
        /*
         * 충돌판정 : 원의 중심 좌표와 반경을 사용한 충돌 판정 알고리즘
         * 화살의 중심으로부터 플레이어를 둘러싼 원의 중심까지의 거리를 피타고라스 정리를 이용하여 구한다.
         * fArrowRadius : 화살을 둘러싼 원의 반지름, fPlayerRadius : 플레이어를 둘러싼 원의 반지름
         * 두 원의 중심간의 거리 fArrowPlayerDistance > fPlayerRadius + fArrowRadius : 충돌하지 않음
         * 두 원의 중심간의 거리 fArrowPlayerDistance < fPlayerRadius + fArrowRadius : 충돌
         */
        vArrowCirclePoint = transform.position;
        vPlayerCirclePoint = gPlayer.transform.position;
        vArrowPlayerDir = vArrowCirclePoint - vPlayerCirclePoint;
        /*
         * 두 벡터간의 길이를 구하는 메서드 : magnitude
         *  - 메서드 정의 :  public float Magnitude(Vector vector);
         *  - 벡터는 크기와 방향을 갖기 때문에, 시작점(Initial Point)과 종점(Terminal Point)으로 구성되며 이 둘 사이의 거리가 곧 벡터의 크기가 된다.
         *  - 일반적으로 시작점을 벡터의 꼬리, 끝점을 벡터의 머리라고 부른다.
         *  - 벡터는 시작점과 종점의 위치에 관계 없이, 주 벡터의 크기와 방향이 같다면 서로 같은 벡터 취급한다.
         *  - 벡터는 점의 위치를 나타내는 위치 벡터를 이용해 표기한다.
         *  - 화살의 중심으로부터 플레이어를 둘러싼 원의 중심까지의 거리
         */
        fArrowPlayerDistance = vArrowPlayerDir.magnitude;
        /*
         * 플레이어가 화살에 맞았는지 감지, 즉 화살과 플레이어의 충돌 판정
         *  - 원의 중심 좌표와 반경을 사용해 충돌 판정
         *  - r1 : 화살을 둘러싼 원의 반지름, r2 : 플레이어를 둘러싼 원의 반지름, d : 화살원의 중심에서 플레이어 원의 중심까지의 거리
         *  - 충돌 : 두 원의 중김 산 거리 d가 (r1 + r2)보다 작으면 충돌(d<r1+r2)
         *  - 미충돌 : 두 원의 중김 산 거리 d가 (r1 + r2)보다 크면 충돌하지 않음(d>r1+r2)
         *  - 충돌((fArrowPlayerDistance < fPlayerRadius + fPlayerRadius)이면 화살 오브젝트 소멸
         */

        if (fArrowPlayerDistance < fPlayerRadius + fPlayerRadius)
        {
            Destroy(gameObject);
        }
    }
}
