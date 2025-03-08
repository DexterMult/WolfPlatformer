using UnityEngine;
using YG;

public class YandexGameReady : MonoBehaviour
{
    public YandexGame Yandex;
    private bool flagGameReady = false;
    private bool flagStartStop = false;
    public void GameReadyInitAPI() //Запускаем в первой сцене когда она загрузится (По сути включаем сам GameReady).
    //как правило это запускается в главном меню игры 1 раз, на каждой новой сцене этого делать не требуется.
    {
        if (flagGameReady == false)
        {
            Yandex._GameReadyAPI();
            flagGameReady = true;
            Debug.Log("Запуск GameReadyAPI");
        }
    }
    public void FirstStartGRAinUpdate() //Запускаем каждый раз когда игра стартует на новой сцене, обязательно после GameReadyInitAPI()
    {
        if (flagStartStop == false)
        {
            Yandex._GameplayStart();
            flagStartStop = true;
            Debug.Log("Первый старт GRA");
        }
    }
    public void StartGRA() //Запускаем, когда снимаем с паузы
    {
        Yandex._GameplayStart();
    }
    public void StopGRA() //Запускаем, когда ставим на паузу
    {
        Yandex._GameplayStop();
    }
    void Update()
    {
        GameReadyInitAPI();
        FirstStartGRAinUpdate();
    }
}