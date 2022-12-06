using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Cell cell;
        [SerializeField] private float threshold;

        public float fallingSpeed;

        public void ChangeBombPosition(Transform target, Action<Bomb> callback)
        {
            StartCoroutine(ChangeBombPositionRoutine(target, callback));
        }

        private void Start()
        {
            cell = GetComponentInParent<Cell>();
        }

        private IEnumerator ChangeBombPositionRoutine(Transform target, Action<Bomb> callback)
        {
            while (true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, fallingSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target.position) <= threshold)
                {
                    transform.position = target.position;
                    callback?.Invoke(this);
                    break;
                }

                yield return null;
            }
        }
    }
}