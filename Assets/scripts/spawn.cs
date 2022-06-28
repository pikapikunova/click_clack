using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters;
    [SerializeField] private GameObject[] boosters;

    public float periodOfTime = 3f;
    private float speedOfSpawn = 0;
    private int numOfGameOver = 10;
    public int addExtraTaps = 0;
    public float addExtraSpeed = 0;


    void Start()
    {
        for (int i = 0; i < 2; i++)
            Instantiate(monsters[0], new Vector3(Random.Range(-4f, 4f), 1, Random.Range(-4f, 4f)), Quaternion.Euler(0, 180, 0));
        Instantiate(monsters[1], new Vector3(Random.Range(-4f, 4f), 1, Random.Range(-4f, 4f)), Quaternion.Euler(0, 180, 0));
        StartCoroutine("timer");

    }

    void Update()
    {
        if (FindObjectsOfType<monster>().Length >= numOfGameOver)
        {
            StopCoroutine("timer");
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(periodOfTime);
        addMonster();
        boostGenerator();
        speedOfSpawn += 0.07f;
        addExtraSpeed+= 0.04f;

    }

    public void addMonster()
    {
        int numOfMon = Random.Range(0, 2);
        Instantiate(monsters[numOfMon], new Vector3(Random.Range(-4f, 4f), 1, Random.Range(-4f, 4f)), Quaternion.Euler(0, 180, 0));
        
        periodOfTime = Random.Range(2f - speedOfSpawn, 3f - speedOfSpawn);

        StartCoroutine("timer");
    }

    public void addTaps(int taps)
    {
        addExtraTaps = taps;

        monster[] mons = FindObjectsOfType<monster>();
        for (int i = 0; i < mons.Length; i++)
            mons[i].increaseClickCount(addExtraTaps);
    }

    public void boostGenerator()
    {
        int numOfBoost = Random.Range(0, 4);
        int chan = Random.Range(0, 101);

        booster b = new booster(Resources.Load<boosterInfo>(boosters[numOfBoost].name).Chance);

        if (chan <= b.chance)
            Instantiate(boosters[numOfBoost], new Vector3(Random.Range(-4f, 4f), 1.5f, Random.Range(-4f, 4f)), Quaternion.identity);
    }
}
