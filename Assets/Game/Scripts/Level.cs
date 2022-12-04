using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private BombsGeneration bombsGenerator;
        [SerializeField] private CellsGeneration cellsGenerator;

        private void Start()
        {
            CreateLevel();
        }

        [ContextMenu("CreateLevel")]
        private void CreateLevel()
        {
            cellsGenerator.GenerateCells();
            bombsGenerator.GenerateFirstLineBombs(cellsGenerator.Cells);
        }
        [ContextMenu("DeleteArea")]
        private void DeleteArea()
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Cell")) DestroyImmediate(o);
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Ball")) DestroyImmediate(o);
        }
    }
}