using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Cell cell;

        public float fallingSpeed;
        private void Start()
        {
            cell = GetComponentInParent<Cell>();
        }
        public void ChangeBombPosition(Transform target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, fallingSpeed * Time.deltaTime);
        }
    }
}