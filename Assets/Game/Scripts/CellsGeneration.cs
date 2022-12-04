using UnityEngine;

namespace Game.Scripts
{
    public class CellsGeneration : MonoBehaviour
    {
        [SerializeField] private Cell cell;
        [SerializeField] private int ySize, xSize;
        
        private float _offset = 1.1f;
        
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
                    float xOffset = _offset;
                    float yOffset = _offset;
                    Cell nextCell = Instantiate(cell, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), Quaternion.identity);
                    Cells[x,y] = nextCell;
                    nextCell.transform.parent = transform;
                }
            }

            return Cells;
        }
    }
}
