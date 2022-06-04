using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class Finish_restart : MonoBehaviour
{
    public GameObject redscoreui,bluescoreui, tut1, tut2;
    public bool is_started;
    public GameObject player1, player2;
    public GameObject start, restart;
    Vector2 initpos;
    Color winnercolor;
    public SpriteRenderer wonball;
    int rstreak, bstreak, bscore, rscore;
    public GameObject streak;
    public Text redscore, bluescore;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }
    void Awake()
    {
        initpos = player1.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player 2")
        {
            bscore++;
            bstreak++;
            rstreak = 0;
            winnercolor = player1.GetComponent<SpriteRenderer>().color;
            if (bstreak >= 2)
            {
                streak.SetActive(true);
                streak.GetComponent<Text>().text = bstreak + "x streaks!";     
            }
        }
        else if (col.gameObject.name == "Player 1")
        {
            rscore++;
            rstreak++;
            bstreak = 0;
            winnercolor = player2.GetComponent<SpriteRenderer>().color;
            if (rstreak >= 2)
            {
                streak.SetActive(true);
                streak.GetComponent<Text>().text = rstreak + "x streaks!";
            }
        }
        if (rstreak < 2 && bstreak < 2)
        {
            streak.SetActive(false);
        }
        bluescoreui.SetActive(true);
        redscoreui.SetActive(true);
        player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        redscore.text = rscore.ToString();
        bluescore.text = bscore.ToString();
        wonball.color = winnercolor;
        col.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.7f);
        restart.SetActive(true);
        is_started = false;
        Time.timeScale = 0;
    }
    public void starting()
    {
        // go to balls script and get the value booleen from zone script to set the ball velocity to vector zero
        tut1.SetActive(false);
        tut2.SetActive(false);
        start.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        Time.timeScale = 1;
        is_started = true;
    }
    public void restarting()
    {
        tut1.SetActive(false);
        tut2.SetActive(false);
        restart.SetActive(false);
        player1.SetActive(true);
        player2.SetActive(true);
        streak.SetActive(false);
        is_started = true;
        player1.transform.position = initpos;
        player2.transform.position = -initpos;
        
        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        Time.timeScale = 1;
    }
}
