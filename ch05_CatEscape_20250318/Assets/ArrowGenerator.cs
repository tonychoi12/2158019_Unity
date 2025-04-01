using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 화살 오브젝트를 1초에 한 개씩 생성하는 알고리즘
 * 업데이트 메서드는 프레임마다 실행되고 앞프레임과 현재 프레임 사이의 시간 차이는 Time.deltaTime에 대입
 * 프레임과 프레임 사이의 시간 차이를 대나무통(델타변수)에 모으고(합계) 1초 이상이 되면 대나무 통을 비움
 * 대나무 통을 비우는 시점인 1초에 한 번씩 화살이 생성됨
 * Instantiate 메서드
 *  게임을 실행하는 도중에 게임 오브젝트를 생성할 수 있음
 *  화살 프리팹을 이용하여 화살 인스턴스를 생성하는 메서드
 * Random.Range 메서드 : 랜덥 값을 쉽게 생성할 수 있는 방법
 *  랜덤 클래스는 흔히 요구되는 다양한 타임의 랜덤 값을 쉽게 생성할 수 있는 방법을 제공
 *  사용자가 제공한 최솟값과 최댓값 사이의 임의의 숫자를 제공함
 *      첫 번째 매개변수보다 크거나 같고, 두 번째 매개변수보다 작은 범위에서 무작위 수를 랜덤하게 반환
 */
public class ArrowGenerator : MonoBehaviour
{
    /*
     * 제너레이트 스크립트에 프리팹 전달 방법
     * arrowPrefab 변수에 프래팹 실체를 대입하기 위해서 public 접근 수식자
     * 멤버 변수 선언시 인스팩터 창에서 프리팹 설계도를 대입할 수 있도록 보임
     * 화살 대량 생산을 위해서 양산기계(제너레이트스크립트)에 넘겨줄 프리팹 설계도를 넘겨줘야함
     */
    public GameObject gArrowPrefab = null;   // 화살 프리팹을 넣을 빈오브젝트 상자
    GameObject gArrowInstance = null;       // 화살 인스턴스 저장 변수
    
    float fArrowCreateSpan = 1.0f;          // 화살 생성 변수 : 화살을 1초마다 생성 변수
    float fDeltaTime = 0.0f;                // 앞 프레임과 현재 프레임 사이의 시간 차이를 저장하는 변수
    
    int nArrowPositionRange = 0;            // 화살의 X좌표 Range 저장 변수
 
    void Update()
    {
        // 업데이트 메서드는 프레임마다 실행되고 앞 프레임과 현재 프레임 사이의 시간차이는 Time.deltaTime에 대입됨
        // Time.deltaTime은 한 프레임당 실행하는 시간을 뜰하는데 값을 float형태로 반환하고 단위는 초를 사용함
        // 프레임과 프레임 사이의 시간 차이를 fDeltaTime 변수에 누적
        fDeltaTime += Time.deltaTime;
        
        // 화살을 1초마다 한 개씩 생성
        // 프레임당 누적 시간이 1초가 넘으면 화살 생산
        if (fDeltaTime > fArrowCreateSpan)
        {
            fDeltaTime = 0.0f;  // 프레임과 프레임 사이의 시간 차이 누적 변수 초기화
            
            /*
             * 인스턴시에이트 메서드 : 화살 프리팹을 이용하여 화살 인스턴스를 생성하는 메서드
             * 게임을 사용하면 게임을 실행하는 도중에 게임오브젝트를 생성할 수 있음
             * RPG 게임이라면 수많은 아이템, 캐릭터, 배경 등 모든 것들을 어떻게 미리 만들어 놓을수 있을까?
             *      그러므로 게임 오브젝트의 복제본을 생성함
             * Instantiate(GameObject original, Vector3 position, Quaternion rotation)
             * GameObject original : 생성하고자 하는 게임 오브젝트명 현재 씬에 있는 오브젝트나 프리팹으로 선언된 객체를 의미함
             * Vector3 position : Vector3로 생성될 위치를 설정함
             * Quaternion rotation : 생성될 게임 오브젝트의 회전삾을 지정
             */
            gArrowInstance = Instantiate(gArrowPrefab);
            /*
             * 랜덤 클래스는 흔히 요구되는 다양한 타입의 랜덥 값을 쉡게 생성할 수 있는 방법을 제공
             * 랜덤 레인지 메서드 : 사용자가 제공한 최솟값과 최댓값 사이의 임의의 숫자를 제공함
             * 첫 번째 배개변수보다 크거나 같고, 두 번째 매개변수보다 작은 범위에서 무작위 수를 정수로 반환
             * 화살의 X좌표는 -9에서 9사이에 불규칙하게 위치된다. 
             */
            
            
            nArrowPositionRange = Random.Range(-9, 10);
            
            gArrowInstance.transform.position = new Vector3(nArrowPositionRange, 7, 0);
            
        }
    }
}
