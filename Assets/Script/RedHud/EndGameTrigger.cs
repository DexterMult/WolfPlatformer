using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class EndGameTrigger : MonoBehaviour
{
    public PausedGame PausedGame;
    private GameObject Heroe;
    private Transform RedHudTransform;
    public GameObject EndGamePanel;
    private EndGameCoins EbdGameCoins;
    private EndGameTime EndGameTime;
    private bool HiroeCollision;
    public Image noActiveStar1;
    public Image noActiveStar2;
    public Image noActiveStar3;
    public Image ActiveStar1;
    public Image ActiveStar2;
    public Image ActiveStar3;
    private Vector2 HeroePosition;
    private Vector2 RedHudPosition;
    public GameObject SoundListener;
    private Sounds soundSCR;
    public SavedSistem SavedSistem;
    private int finalStarsResult;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            soundSCR.PlaySound(soundSCR.sounds[5]);
            HiroeCollision = true;
            EndGameTime.TimeResult();
            EbdGameCoins.CoinsResult();
            GetStarsResult();
            StarsDemonstration();
            SavedSistem.SavedAllGame();
            PausedGame.PauseGame();
        }
    }
    private void GameIsFinished()
    {
        if (HiroeCollision)
        {
            EndGamePanel.SetActive(true);
            Heroe.SetActive(false);
        }
    }

    private void RedHudRotation()
    {
        if (Heroe != null)
        {
            HeroePosition = new Vector2(Heroe.transform.position.x, Heroe.transform.position.y);
            RedHudPosition = new Vector2(RedHudTransform.position.x, RedHudTransform.position.y);
            if (HeroePosition.x < RedHudPosition.x)
            {
                RedHudTransform.localScale = new Vector2(1, 1);
            }
            else if (HeroePosition.x > RedHudPosition.x)
            {
                RedHudTransform.localScale = new Vector2(-1, 1);
            }
        }
        else { return; }
    }

    private void GetStarsResult()
    {
        StarsController starsController = FindFirstObjectByType<StarsController>();
        starsController.StartStarsCalculation();
        finalStarsResult = starsController.finalStarsResult;
    }
    private void StarsDemonstration()
    {
        if (finalStarsResult == 0)
        {
            noActiveStar1.gameObject.SetActive(true);
            noActiveStar2.gameObject.SetActive(true);
            noActiveStar3.gameObject.SetActive(true);

            ActiveStar1.gameObject.SetActive(false);
            ActiveStar2.gameObject.SetActive(false);
            ActiveStar3.gameObject.SetActive(false);
        }

        else if (finalStarsResult == 1)
        {
            noActiveStar1.gameObject.SetActive(false);
            noActiveStar2.gameObject.SetActive(true);
            noActiveStar3.gameObject.SetActive(true);

            ActiveStar1.gameObject.SetActive(true);
            ActiveStar2.gameObject.SetActive(false);
            ActiveStar3.gameObject.SetActive(false);
        }

        else if (finalStarsResult == 2)
        {
            noActiveStar1.gameObject.SetActive(false);
            noActiveStar2.gameObject.SetActive(false);
            noActiveStar3.gameObject.SetActive(true);

            ActiveStar1.gameObject.SetActive(true);
            ActiveStar2.gameObject.SetActive(true);
            ActiveStar3.gameObject.SetActive(false);
        }
        else if (finalStarsResult == 3)
        {
            noActiveStar1.gameObject.SetActive(false);
            noActiveStar2.gameObject.SetActive(false);
            noActiveStar3.gameObject.SetActive(false);

            ActiveStar1.gameObject.SetActive(true);
            ActiveStar2.gameObject.SetActive(true);
            ActiveStar3.gameObject.SetActive(true);
        }
    }

    private void StarsOnStartNoActive()
    {
        noActiveStar1.gameObject.SetActive(false);
        noActiveStar2.gameObject.SetActive(false);
        noActiveStar3.gameObject.SetActive(false);

        ActiveStar1.gameObject.SetActive(false);
        ActiveStar2.gameObject.SetActive(false);
        ActiveStar3.gameObject.SetActive(false);
    }

    private void Start()
    {
        PausedGame.ResumeGame();
        soundSCR = SoundListener.GetComponent<Sounds>();
        EbdGameCoins = FindFirstObjectByType<EndGameCoins>();
        EndGameTime = FindFirstObjectByType<EndGameTime>();
        StarsOnStartNoActive();
        Heroe = GameObject.Find("Heroe");
        RedHudTransform = GetComponent<Transform>();
        RedHudTransform.localScale = new Vector2(1, 1);
        RedHudPosition = Heroe.transform.position;
        HiroeCollision = false;
    }
    private void Update()
    {
        GameIsFinished();
        RedHudRotation();
    }

}
