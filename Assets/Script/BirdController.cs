using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower;

    public AudioClip flyClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;
    private Animator anim;
    GameObject obj;
    public GameObject gameController;
    //internal static readonly object instance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdController start");
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Input.GetMouseButton(0)
       if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
            {
                audioSource.Play();
            }

            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
            anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("object collider: " + other.gameObject.name);
        EndGame();
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();

    }
    void EndGame()
    {
        anim.SetBool("isDead", true);
        Debug.Log("EndGame");
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
