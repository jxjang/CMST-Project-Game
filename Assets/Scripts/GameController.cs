using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public List<GameObject> enemyTypes;
    public float spawnTimer = 3f;
    private float TimeScore;
    private List<Vector3> initlocs= new List<Vector3>();

    private int ybound = 15;
    private int xbound = 10;
    private int ylow = 6;

    // UI
    private UIDocument gameUIDoc;
    private VisualElement root;
    private GroupBox groupGameUI;
    private Label scoreValue;

    // Game Over UI
    private GroupBox groupGameOver;
    private GroupBox groupScore;
    private Label finalScoreValue;
    private Button buttonPlayAgain;
    private Button buttonGameOverExit;

    private void Awake()
    {
        // Init game UIDocument and its pieces
        gameUIDoc = GetComponent<UIDocument>();
        root = gameUIDoc.rootVisualElement.Q<VisualElement>();
        groupGameUI = root.Q<GroupBox>("groupGameUI");
        scoreValue = groupGameUI.Q<Label>("scoreValue");
        groupGameUI.style.display = DisplayStyle.Flex;  // Make the game UI visible.

        groupGameOver = root.Q<GroupBox>("groupGameOver");
        groupScore = groupGameOver.Q<GroupBox>("groupScore");
        finalScoreValue = groupScore.Q<Label>("finalScoreValue");
        buttonPlayAgain = groupGameOver.Q<Button>("buttonPlayAgain");
        groupGameOver.style.display = DisplayStyle.None;  // Make the GameOver screen "invisible"
        buttonGameOverExit = groupGameOver.Q<Button>("buttonGameOverExit");

    }

    void Start()
    {
        // Subscribe to button events
        buttonPlayAgain.clicked += () => PlayAgainClicked();
        buttonGameOverExit.clicked += () => ExitGameOverClicked();

        TimeScore = 0;

        for (int i = -xbound; i <= xbound; i++)
        {
            initlocs.Add(new Vector3(i, ybound));
        }

        for (int j = ylow; j <= ybound; j++)
        {
            initlocs.Add(new Vector3(-xbound, j));
            initlocs.Add(new Vector3(xbound, j));
        }

        if (player == null) { Debug.LogError("Player gameobject has not been attached to the GameController!"); }

        StartCoroutine(SpawnRandomEnemy(spawnTimer));
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore += Time.deltaTime;
        if (player)
        {
            scoreValue.text = Mathf.Round(TimeScore).ToString();
            //scoreValue.text = TimeScore.ToString();
        }
        else
        {
            Time.timeScale = 0;  // Stops time. Remember to set back to 1 when ready to "unpause"
            finalScoreValue.text = scoreValue.text;

            // Swap Game UI with GameOver UI
            groupGameUI.style.display = DisplayStyle.None;
            groupGameOver.style.display = DisplayStyle.Flex;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnRandomEnemy(float timer)
    {
        while (player)
        {
            yield return new WaitForSeconds(timer);
            Instantiate(RandomEnemy(), RandomLoc(), Quaternion.identity);
        }
    }

    GameObject RandomEnemy()
    {
        return enemyTypes[Random.Range(0, enemyTypes.Count - 1)];
    }

    Vector3 RandomLoc()
    {
        return initlocs[Random.Range(0, initlocs.Count - 1)];
    }

    private void PlayAgainClicked()
    {
        //Debug.Log("Player clicked 'Play Again'!");
        Time.timeScale = 1;
        SceneManager.LoadScene("game");
    }

    private void ExitGameOverClicked()
    {
        Application.Quit();
    }
}
