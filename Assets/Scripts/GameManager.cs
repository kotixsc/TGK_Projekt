using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject UI;
    [SerializeField] private Text coinsField;
    public GameObject backgroundFolder;
    private PlayerController playerController;
    public GameObject playerObject {  get; private set; }
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (playerController)
        {
            coinsField.text = "Coins: " + playerController.gold;
        }        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        UI.SetActive(true);
        playerObject = Instantiate(playerPrefab);
        GetComponent<CameraController>().target = playerObject;
        DontDestroyOnLoad(playerObject);
        playerController = playerObject.GetComponent<PlayerController>();
    }

    public void ClearMap()
    {
        GetComponent<BackgroundController>().renderCells = false;
        GetComponent<BackgroundController>().spawnedCells.Clear();
        foreach (Transform child in backgroundFolder.transform)
        {
            Destroy(child.gameObject);
        }
        GetComponent<BackgroundController>().renderCells = true;
    }

    public void LoadWorld2()
    {
        SceneManager.LoadScene("World2");
        StartCoroutine(co());
        IEnumerator co()
        {
            yield return new WaitForEndOfFrame();
            ClearMap();
        }
    }

}
