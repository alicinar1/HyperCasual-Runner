using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Runner.Energy
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] private Ease animEase;
        [SerializeField] private TweenCallback callback;

        private Sequence _aliveLoopSequence;
        private Sequence _disableLoopSequence;

        private void Awake()
        {
            SetAliveSequence();
            SetDisableSequence();
        }
        private void OnTriggerEnter(Collider other)
        {
            _aliveLoopSequence.Pause();
            TakeAnimation();
        }

        private void OnEnable()
        {
            ScaleLoopAnimation();
        }

        private void OnDisable()
        {
            DOTween.PauseAll();
        }

        private void SetAliveSequence()
        {
            _aliveLoopSequence = DOTween.Sequence();
            _aliveLoopSequence.Append(transform.DOScale(1.5f, 1f).SetEase(animEase)).Append(transform.DOScale(1, 1f).SetEase(animEase)).SetLoops(-1);
            _aliveLoopSequence.Pause();
        }
        private void SetDisableSequence()
        {
            _disableLoopSequence = DOTween.Sequence();
            _disableLoopSequence.Append(transform.DOScale(1.8f, 0.5f)).Append(transform.DOScale(0.1f, 0.3f)).SetLoops(-1);
            _disableLoopSequence.Pause();
        }
               
        private void ScaleLoopAnimation()
        {
            _aliveLoopSequence.Play();
        }

        private void TakeAnimation()
        {
            _disableLoopSequence.Play();
            Invoke("SetInactieve", 0.8f);

        }

        private void SetInactieve()
        {
            _disableLoopSequence.Pause();
            gameObject.SetActive(false);
        }
    }
}
