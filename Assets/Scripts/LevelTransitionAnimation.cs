using System.Collections;
using UnityEngine;

public class LevelTransitionAnimation : MonoBehaviour
{
        [SerializeField] private Animator _animator;
        private float _transitionTime;

        public void LevelTransition(System.Action onTransitionEnd)
        {
                StartCoroutine(OnTransitionStart(onTransitionEnd));
        }

        private IEnumerator OnTransitionStart(System.Action onTransitionEnd)
        {
                _animator.SetTrigger("Start");
                yield return new WaitForSeconds(1f);
                onTransitionEnd?.Invoke();
        }
}
