using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Game.Scripts
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Cell underCell;
        [SerializeField] private BombsGeneration bombsGenerator;

        public Bomb currentBomb;
        public bool isOccupied;
        
        private Vector2 _dirRayDown = Vector2.down;

        private void Start()
        {
            SetBomb(GetComponentInChildren<Bomb>());
            CheckUnderCell();
        }

        public void SetBomb(Bomb bomb)
        {
            currentBomb = bomb;

            if (currentBomb != null)
            {
                currentBomb.transform.SetParent(transform);
                isOccupied = true;
            }
        }

        private void DeleteBomb()
        {
            Destroy(currentBomb.gameObject);
            isOccupied = false;
        }
        private void OnMouseDown()
        {
            DeleteBomb();
        }
        private void Update()
        {
            if (underCell == null || currentBomb == null)
                return;

            if (isOccupied && !underCell.isOccupied)
            {
                underCell.isOccupied = true;
                Transform targetPosition = underCell.transform;
                currentBomb.ChangeBombPosition(targetPosition, OnBombFinishMove);
            }
        }

        private void OnBombFinishMove(Bomb bomb)
        {
            underCell.SetBomb(bomb);
            currentBomb = null;

            isOccupied = false;
        }

        private void CheckUnderCell()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _dirRayDown);
            if (hit.collider != null)
            {
                underCell = hit.collider.GetComponent<Cell>();
            }
        }
    }
}