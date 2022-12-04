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
                isOccupied = true;
            }
        }

        private void Update()
        {
            if (underCell != null)
            {
                Transform position = underCell.transform;
                if (isOccupied && underCell.isOccupied == false)
                {
                    Bomb cashCurrentBomb = currentBomb;
                    currentBomb = null;
                    underCell.currentBomb = cashCurrentBomb;
                    isOccupied = false;
                    underCell.isOccupied = true;
                    underCell.currentBomb.transform.parent = underCell.transform;
                }

                if (underCell.currentBomb != null)
                {
                    underCell.currentBomb.ChangeBombPosition(position);
                }
            }
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