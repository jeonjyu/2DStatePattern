using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    //애니메이션을 위한 스프라이트들
    public Sprite[] _frames;
    public float _frameRate = 0.1f;

    //스프라이드 변경해줄 랜더
    private SpriteRenderer _spriteRender;
    private int currentFrame = 0;

    //사용할 코루틴
    private Coroutine _animationCoroutine;
    private WaitForSeconds _delay;

    // 컴포넌트 연결 및 딜레이 설정
    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        if( _spriteRender == null )
        {
            Debug.LogError("SpriteRender가 없음");
        }

        _delay = new WaitForSeconds(_frameRate);
    }

    //객체가 켜질 때 애니메이션 스타트
    private void OnEnable()
    {
        StartAnimation();
    }

    //꺼질 때 종료
    private void OnDisable()
    {
        StopAnimation();
    }

    //애니메이션 코루틴 실행 함수
    private void StartAnimation()
    {
        if (_animationCoroutine != null)
            StopCoroutine(_animationCoroutine);

        _animationCoroutine = StartCoroutine(PlayAnimation());
    }
    //종료함수
    private void StopAnimation()
    {
        if(_animationCoroutine != null)
            StopCoroutine( _animationCoroutine);
    }
    //코루틴을 통해 스프라이트 교체하는 함수
    private IEnumerator PlayAnimation()
    {
        while(true)
        {
            if (_frames.Length > 0)
            {
                _spriteRender.sprite = _frames[currentFrame];
                currentFrame = (currentFrame + 1) % _frames.Length; //반복
            }
            yield return _delay;
        }
    }
}
