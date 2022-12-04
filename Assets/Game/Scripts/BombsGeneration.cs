using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class BombsGeneration : MonoBehaviour
    {
        [SerializeField] private int bombsAmount;
        [SerializeField] private Bomb[] bombPrefabs;
        [SerializeField] private Cell cell;
        private Bomb[] _createdBombs;
        private Vector3 _ballPosition;
        
        public void GenerateFirstLineBombs(Cell[,] createdCell)
        {
            _createdBombs = new Bomb[bombsAmount];
            for (int i = 0; i < bombsAmount; i++)
            {
                int color = Random.Range(0, bombPrefabs.Length);
                float offsetX = 1.1f;
                Vector2 position = transform.position;
                Bomb nextBomb = Instantiate(bombPrefabs[color], new Vector2(position.x + (offsetX * i), position.y), Quaternion.identity);
                _createdBombs[i] = nextBomb;
                _createdBombs[i].transform.SetParent(createdCell[i,(int)position.y].transform);
            }
        }
    }
}