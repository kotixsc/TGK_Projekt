using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgroundTemplates;
    private float tileWidth = 10.24f;
    private float tileHeight = 7.68f;

    public bool renderCells = true;

    public int renderDistance; //minecraft referencja xd

    private Transform player;
    private Transform backgroundFolder;
    public HashSet<Vector2Int> spawnedCells = new HashSet<Vector2Int>();

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || !renderCells)
        {
            print("return");
            return;
        }
        if (renderDistance <= 0)
        {
            renderDistance = 2;
        }
        if (!player || !backgroundFolder)
        {
            player = GameManager.instance.playerObject.transform;
            backgroundFolder = GameManager.instance.backgroundFolder.transform;
            return;
        }
        Vector2Int currentCell = new Vector2Int(
            Mathf.FloorToInt(player.position.x / tileWidth),
            Mathf.FloorToInt(player.position.y / tileHeight)
        );

        for (int dx = -renderDistance; dx <= renderDistance; dx++)
        {
            for (int dy = -renderDistance; dy <= renderDistance; dy++)
            {
                Vector2Int cell = new Vector2Int(currentCell.x + dx, currentCell.y + dy);
                if (!spawnedCells.Contains(cell))
                {
                    Vector3 spawnPos = new Vector3(
                        cell.x * tileWidth,
                        cell.y * tileHeight,
                        0f
                    );
                    if (SceneManager.GetActiveScene().name == "MainScene")
                    {
                        Instantiate(backgroundTemplates[0], spawnPos, Quaternion.identity, backgroundFolder);
                    }
                    else if (SceneManager.GetActiveScene().name == "World2")
                    {
                        Instantiate(backgroundTemplates[1], spawnPos, Quaternion.identity, backgroundFolder);
                    }
                    spawnedCells.Add(cell);
                }
            }
        }
    }
}
