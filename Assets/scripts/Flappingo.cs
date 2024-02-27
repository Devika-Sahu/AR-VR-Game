using UnityEngine;
// using System Collections;
// using System Collections Generic; 


public class Flappingo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity= -9.8f;
    public float strength=5f;

    // public GameObject Bgmusic;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;  

    private int playState = 0;
   
    private void Awake(){
        spriteRenderer= GetComponent<SpriteRenderer>();
        
    }
    private void Start(){
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction=Vector3.up * strength;
            //  FindObjectOfType<Sound>().PlaySound(jumpSound);
            // Sound.instance.PlaySound(jumpSound);
        }
        direction.y += gravity* Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // logic for P key press
        // if(Input.GetKeyDown(KeyCode.P)){
        //     if(Time.timeScale > 0) {
        //         FindObjectOfType<GameManager>().Pause();
        //     } 
        //     if(Time.timeScale == 0) {
        //         FindObjectOfType<GameManager>().Resume();
        //     }
        // }
    }

    //  private void Stop()
    // {
    //     if()
    // }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex>=sprites.Length){
            spriteIndex=0;
        }
        spriteRenderer.sprite=sprites[spriteIndex];

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<Sound>().PlaySound(gameOverSound);
            // GameManager.instance.GameOver();
            // Sound.instance.PlaySound(gameOverSound);
        }
        else if(other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
            FindObjectOfType<Sound>().PlaySound(scoreSound);
            // GameManager.instance.IncreaseScore();
            // Sound.instance.PlaySound(scoreSound);
        }
    }
}
