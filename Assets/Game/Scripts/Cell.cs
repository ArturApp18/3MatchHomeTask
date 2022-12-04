using UnityEngine;

namespace Game.Scripts
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Bomb currentBomb;
        [SerializeField] private bool isOccupied;
        [SerializeField] private Cell underCell;
        private Vector2 _dirRay = Vector2.down;
        private bool _isunderCellNotNull;
        private bool _iscurrentBombNotNull;

        private void Start()
        {
            SetBomb(GetComponentInChildren<Bomb>());
            CheckUnderCell();
        }

        private void SetBomb(Bomb bomb)
        {
            currentBomb = bomb;
            if (currentBomb != null)
            {
                isOccupied = true;
            }
        }

        private void Update()
        {
            if (underCell != null)
            {
                if (isOccupied && underCell.isOccupied == false)
                {
                    Bomb cashCurrentBomb = currentBomb;
                    currentBomb = null;
                    underCell.currentBomb = cashCurrentBomb;
                    isOccupied = false;
                    underCell.isOccupied = true;
                }
            }
        }
        
        private void CheckUnderCell()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _dirRay);
            if (hit.collider != null)
            {
                underCell = hit.collider.GetComponent<Cell>();
            }
        }
        
    }
}