using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI를 사용하므로 잊지 않고 추가하기
public class GameDirector : MonoBehaviour
{
    /* HP 게이지 이미지 오브젝트를 저장할 멤버 변수
     감독 스크립트를 사용해 HP게이지를 갱신하려면 감독 스크립트가 HP 게이지의 실체를 조작할 수 있어야 함
     그러기 위해서 오브젝트 변수를 선언해서 HP 게이지 이미지 오브젝트를 저장
    */
    GameObject hpGauge = null;

    void Start()
    {
        /*
         * HP게이지 오브젝트 찾기
         * 각 오브젝트 상자에 대응하는 오브젝트를 씬 안에서 찾아 넣어야 한다.
         * 씬 안에서 오브젝트를 찾는 메서드 : Find
         * Find 메서드는 오브젝트 이름을 인수에 전달하고
         * 인수 이름이 씬에 존재하면 해당 오브젝트를 반환
         */
        this.hpGauge = GameObject.Find("hpGauge");
        
    }

    public void f_DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
