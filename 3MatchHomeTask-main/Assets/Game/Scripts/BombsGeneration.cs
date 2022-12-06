using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts
{
    public class BombsGeneration : MonoBehaviour
    {
        [SerializeField] private int bombsAmount;
        [SerializeField] private Bomb[] bombPrefabs;
        public Cell[] firstLineCells;

        private Bomb[] _createdBombs;
        private Vector3 _ballPosition;
        private Vector2 _dirRayRight = Vector2.right;
        private int _color;

        public void GenerateFirstLineBombs(Cell[,] createdCell)
        {
            _createdBombs = new Bomb[bombsAmount];
            firstLineCells = new Cell[bombsAmount];

            for (int i = 0; i < _createdBombs.Length; i++)
            {
                float offsetX = 1.1f;
                Vector2 position = transform.position;
                _color = Random.Range(0, bombPrefabs.Length);
                Bomb nextBomb = Instantiate(bombPrefabs[_color], new Vector2(position.x + (offsetX * i), position.y),
                    Quaternion.identity);
                _createdBombs[i] = nextBomb;
                _createdBombs[i].transform.SetParent(createdCell[i, (int)position.y].transform);
                firstLineCells[i] = createdCell[i, (int)position.y];
            }
            
        }

        private void Update()
        {
            Respawn();
        }

        private void Respawn()
        {
            foreach (Cell cell in firstLineCells)
            {
                if (!cell.isOccupied)
                {
                    _color = Random.Range(0, bombsAmount);
                    cell.SetBomb(Instantiate(bombPrefabs[_color], cell.transform.position, Quaternion.identity));
                }
            }
        }
    }
}