using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Flappingo flappingo;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    // public GameObject Bgmusic;
    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;
    public Text Developer;
    private int score;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        gold.SetActive(false);
        silver.SetActive(false);
        bronze.SetActive(false);
        gameOver.SetActive(false);

       

        Pause();
    }
    public void Play()
    {
        score=0;
        scoreText.text="Your Score: "+ score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        gold.SetActive(false);
        silver.SetActive(false);
        bronze.SetActive(false);
        FindObjectOfType<Bgmusic>().backgroundMusic.Play();

        Developer.enabled = false;
        // Developer.text = "";
        Time.timeScale= 1f;
        flappingo.enabled=true;

        Pipe[] pipe= FindObjectsOfType<Pipe>();

        for(int i=0; i<pipe.Length; i++){
            Destroy(pipe[i].gameObject);
        }
        // Bgmusic.Play();

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        flappingo.enabled= false;
        // Bgmusic.Pause();

    }
    public void Resume()
    {
        Time.timeScale = 1f;
        flappingo.enabled= true;
    }
   
   public void GameOver()
   {

    FindObjectOfType<Bgmusic>().backgroundMusic.Pause();
    gameOver.SetActive(true);
    playButton.SetActive(true);
    if( score>0 && score<=5)
    {
        bronze.SetActive(true);
    }
    else if (score >5 && score<=10 ){
          silver.SetActive(true);
    }
    else if(score>10) {
         gold.SetActive(true);
    }

 
    Developer.enabled = true; 
    //  Developer.text = "Your developer message here";
    Pause();
   }
   public void IncreaseScore()
   {
     score++;
     scoreText.text = "Your Score: " + score.ToString();
   }
}
