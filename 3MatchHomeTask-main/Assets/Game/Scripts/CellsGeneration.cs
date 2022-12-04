using UnityEngine;

namespace Game.Scripts
{
    public class CellsGeneration : MonoBehaviour
    {
        [SerializeField] private Cell cell;
        [SerializeField] private int ySize, xSize;

        private const float Offset = 1.1f;

        public Cell[,] Cells;
        
        
        public Cell[,] GenerateCells()
        {
            Cells = new Cell[ySize,xSize];
            float startX = transform.position.x;
            float startY = transform.position.y;
            
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    float xOffset = Offset;
                    float yOffset = Offset;
                    Cell nextCell = Instantiate(cell, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), Quaternion.identity);
                    Cells[x,y] = nextCell;
                    nextCell.transform.parent = transform;
                }
            }
            return Cells;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Cell"))
            {
                Debug.Log(col.gameObject.tag);
            }
        }
    }
}
