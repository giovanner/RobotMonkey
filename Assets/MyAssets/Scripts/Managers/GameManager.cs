using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
       
    public static GameManager instance = null;

    public bool testLevel = false;

    public GameObject player1;
    public GameObject player2;

    public EndCheck end1;
    public EndCheck end2;

    public GameObject start1;
    public GameObject start2;

    public CameraControl camera;

    public Text timeText;

    public bool gamePaused = false;

    public GameObject menuPosLevel;
    public GameObject menuPause;
    public GameObject loadingImage;

    public bool inLevel = false; //se o player esta jogando ou esta em menu (pre ou pos jogo)

    private GameObject player1_instance;
    private GameObject player2_instance;


    private float time;

    void Awake()
    {
        time = 0.0f;
      
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (testLevel)
            initLevel();
    }

    void initLevel()
    {
        time = 0.0f;

        end1 = GameObject.FindGameObjectWithTag("End1").GetComponent<EndCheck>() as EndCheck;
        end2 = GameObject.FindGameObjectWithTag("End2").GetComponent<EndCheck>() as EndCheck;
        start1 = GameObject.FindGameObjectWithTag("Start1") as GameObject;
        start2 = GameObject.FindGameObjectWithTag("Start2") as GameObject;
        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>() as Text;
        menuPosLevel = GameObject.FindGameObjectWithTag("MenuPosLevel") as GameObject;
        menuPause = GameObject.FindGameObjectWithTag("MenuPause") as GameObject;

        if (timeText)
            timeText.text = "Time: " + time; //have to insert by inspector

        if (end1 && end2 && start1 && start2)
        { 
           player1_instance = Instantiate(player1, start1.transform.position, Quaternion.identity) as GameObject;
           player2_instance = Instantiate(player2, start2.transform.position, Quaternion.identity) as GameObject;

            player1_instance.GetComponent<DemoScene>().enable = true;
            player2_instance.GetComponent<DemoScene>().enable = true;

            gamePaused = false;
            inLevel = true;
        }
        else
        {
            Debug.Log("Some start/end location Not Found");
            //volta para o menu principal
        }
    }

    void Update()
    {
        if(inLevel) // se esta em uma fase
        {

            if (Input.GetKeyDown("p"))
                pause();
            
            if (!gamePaused)
            {
                time = time + Time.deltaTime;
                timeText.text = "Time: " + (int)(time / 60) + ":" + (int)(time % 60);
            }
            
            if (completeLevel()) // se player alcançou o objetivo da fase
            {
                finishLevel();
            }
        }
    }

    void finishLevel()
    {
        Debug.Log("Finish Level");
        player1_instance.GetComponent<DemoScene>().enable = false;
        player2_instance.GetComponent<DemoScene>().enable = false;
        SaveManager.instance.saveGame();
        menuPosLevel.GetComponent<PosLevelMenu>().enable(time);
        inLevel = false;
    }

    public void finishByDeath(int iDeadPlayer) //exeção onde outra classe chama função do Manager, afim de melhorar performance
    {
        Debug.Log("Finish Level by death of Player: " + iDeadPlayer);
        player1_instance.GetComponent<DemoScene>().enable = false;
        player2_instance.GetComponent<DemoScene>().enable = false;
        SaveManager.instance.saveGame();
        //chama função para animação de death antes de aparecer o menu pos death/level 
        //--->
        menuPosLevel.GetComponent<PosLevelMenu>().enable(time, true);
        inLevel = false;
    }

    bool completeLevel()
    {
        if(end1.getCheck() && end2.getCheck())
            return true;

        return false;
    }

    public void exitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level > 1)
            initLevel();
    }

    public void LoadScene(int level = -1)
    {
        if(loadingImage)
            loadingImage.SetActive(true);

        if(level == -1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if(level == -2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene(level);
    }

    public void pause()
    {
        if(gamePaused)//se esta pausado
        {
            Debug.Log("Despause Game");
            player1_instance.GetComponent<DemoScene>().enable = true;
            player2_instance.GetComponent<DemoScene>().enable = true;
            menuPause.GetComponent<PauseMenu>().disable();
            gamePaused = false;
        }
        else//se não esta pausado
        {
            gamePaused = true;
            Debug.Log("Pause Game");
            menuPause.GetComponent<PauseMenu>().enable();
            player1_instance.GetComponent<DemoScene>().enable = false;
            player2_instance.GetComponent<DemoScene>().enable = false;
        }


    }

}
