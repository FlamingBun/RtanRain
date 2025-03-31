using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;
    public Text totalScoreTxt;
    public Text timeTxt;

    int totalScore;

    float totalTime = 10.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        // 함수를 반복적으로 실행시켜주는 함수
        // "함수명", 몇초 뒤에 호출?, 생성 주기
        InvokeRepeating("MakeRain", 0f, 1f);
        //MakeRain();
    }

    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
            // "N2": 소수점 둘 째자리까지
        }
        else
        {
            totalTime = 0;
            endPanel.SetActive(true);
            // 게임 시간이 멈추는 역할
            Time.timeScale = 0f;
        }
        timeTxt.text = totalTime.ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }
}
