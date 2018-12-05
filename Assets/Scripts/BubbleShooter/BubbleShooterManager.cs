using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BubbleShooterManager : MonoBehaviour {

    public static BubbleShooterManager instance;
    public RectTransform canvasTransform;
    public GameObject[] leafPrefabs;
    public GameObject[][] leafs;
    public Vector2 gridStart;
    public float horizontalDistanceBetweenLeafs;
    public float verticalDistanceBetweenLeafs;
    public int rows;
    public int columns;
    public int defaultShotsLeft = 4;
    public int shotsLeft = 4;
    public int rowsOnStart = 3;
    public Image[] shotsLeftUI;
    public Sprite shotsLeftUIOn;
    public Sprite shotsLeftUIOff;
    public MonologueContent gameOverMonologue;
    public GameEvent gameOverEvent;
    public MonologueContent winMonologue;
    public GameEvent winEvent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        leafs = new GameObject[rows][];
        for(int i = 0; i < rows; i++)
        {
            leafs[i] = new GameObject[columns];
        }
    }

    private void Start()
    {
        for(int i=0;i<rowsOnStart;i++)
            PopulateRow(0, false);

        //GetComponent<BallTouchInput>().enabled = true;
    }

    /// <summary>
    /// Populates a given Row with Random Leafes.
    /// Starting with 0 at the top increasing downwards.
    /// When given true as second Parameter the field will travel one row down before population, otherwise it will override the row.
    /// </summary>
    /// <param name="rowNumber">Row Number to populate</param>
    /// <param name="overrideRow">Override the existing Row?</param>

    public void PopulateRow(int rowNumber, bool overrideRow)
    {
        if (!overrideRow)
        {
            bool lastRow = false;
            for (int i = 0; i < columns; i++)
            {
                if (leafs[rows - 1][i] != null)
                {
                    lastRow = true;
                }
            }
            if (lastRow)
            {
                GameOver();
                return;
            }
            else
            {
                for (int i = rows - 1; i >= rowNumber+1; i--)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (leafs[i - 1][j] != null)
                        {
                            leafs[i][j] = leafs[i - 1][j];
                            RectTransform trans = leafs[i][j].GetComponent<RectTransform>();
                            trans.position = new Vector2(trans.position.x, trans.position.y - (verticalDistanceBetweenLeafs * canvasTransform.localScale.y));
                        }
                        else
                        {
                            leafs[i][j] = null;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < columns; i++)
        {
            int number = Random.Range(0, leafPrefabs.Length + 1);
            if (number < leafPrefabs.Length)
            {
                GameObject leafToSpawn = leafPrefabs[number];
                leafs[rowNumber][i] = Instantiate(leafToSpawn, new Vector2(0, 0), Quaternion.identity, transform);
                leafs[rowNumber][i].GetComponent<RectTransform>().position = new Vector3((gridStart.x + (horizontalDistanceBetweenLeafs * i)) * canvasTransform.localScale.x, (gridStart.y + (verticalDistanceBetweenLeafs * rowNumber)) * canvasTransform.localScale.y, 0);
            }
            else
            {
                leafs[rowNumber][i] = null;
            }
        }
    }

    public void GameOver()
    {
        if (gameOverMonologue != null && gameOverEvent != null)
            LevelManager.instance.StartMonologue(gameOverMonologue, gameOverEvent);
        Debug.Log("Game Over!");
    }

    public bool[] GetRemainingColors()
    {
        bool[] colors = new bool[4];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if (leafs[i][j] != null)
                {
                    switch (leafs[i][j].GetComponent<Leaf>().color)
                    {
                        case Leaf.Color.Brown:
                            colors[0] = true;
                            break;
                        case Leaf.Color.Green:
                            colors[1] = true;
                            break;
                        case Leaf.Color.Orange:
                            colors[2] = true;
                            break;
                        case Leaf.Color.Yellow:
                            colors[3] = true;
                            break;
                        default: break;
                    }
                }
            }
        }
        return colors;
    }

    public void Win()
    {
        if (winMonologue != null && winEvent != null)
            LevelManager.instance.StartMonologue(winMonologue, winEvent);
        Debug.Log("Win!");
    }

    public void DecreaseShots()
    {
        shotsLeft--;
        if (shotsLeft == 0)
        {
            shotsLeft = defaultShotsLeft;
            PopulateRow(0, false);
        }
        if (shotsLeft > 0)
            shotsLeftUI[0].sprite = shotsLeftUIOn;
        else
            shotsLeftUI[0].sprite = shotsLeftUIOff;
        if (shotsLeft > 1)
            shotsLeftUI[1].sprite = shotsLeftUIOn;
        else
            shotsLeftUI[1].sprite = shotsLeftUIOff;
        if (shotsLeft > 2)
            shotsLeftUI[2].sprite = shotsLeftUIOn;
        else
            shotsLeftUI[2].sprite = shotsLeftUIOff;
        if (shotsLeft > 3)
            shotsLeftUI[3].sprite = shotsLeftUIOn;
        else
            shotsLeftUI[3].sprite = shotsLeftUIOff;
    }

    public void Restart()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if(leafs[i][j] != null)
                {
                    Destroy(leafs[i][j]);
                    leafs[i][j] = null;
                }
            }
        }
        for (int i = 0; i < rowsOnStart; i++)
            PopulateRow(0, false);
        shotsLeft = defaultShotsLeft;
        for(int i = 0; i < shotsLeftUI.Length; i++)
        {
            shotsLeftUI[i].sprite = shotsLeftUIOn;
        }
    }
}
