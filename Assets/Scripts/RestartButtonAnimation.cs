using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RestartButtonAnimation : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private float pulseDuration = 1f;
    [SerializeField] private float pulseScale = 1.2f;

    private Tween _pulseTween;

    private void Start()
    {
        StartPulseAnimation();
    }

    private void StartPulseAnimation()
    {
        StopPulseAnimation();

        _pulseTween = button.transform
            .DOScale(pulseScale, pulseDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void StopPulseAnimation()
    {
        if (_pulseTween != null && _pulseTween.IsActive())
        {
            _pulseTween.Kill();
        }
    }
}