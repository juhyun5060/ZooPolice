using System.Collections;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    Enemy_Info info;
    Enemy_shoot gun;

    public GameObject bullet;
    public GameObject enemy;

    private float currentHp;

    private bool spawning;
    private bool shooting;

    private Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        info = GameObject.Find("Boss").GetComponent<Enemy_Info>();
        spawning = false;
        shooting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHp = info.hp;
        if (currentHp <= 20)
        {
            onHp20();
        }
        if(shooting == false)
        {
            shooting = true;
            StopCoroutine(nameof(RandomShot));
            StartCoroutine(nameof(RandomShot));
            Debug.Log("Start Coroutine");
        }
    }
    void onHp20()
    {
        if(spawning == false)
        {
            spawning = true;
            StopCoroutine(nameof(EnemySpawn));
            StartCoroutine(nameof(EnemySpawn));            
        }
    }
    IEnumerator EnemySpawn()
    {
        
        int count = 0;
        while(count < 3)
        {
            int spawnX = Random.Range(-6, 6);
            int spawnY = Random.Range(-4, 4);
            Instantiate(enemy, new Vector3(spawnX, spawnY, 1), Quaternion.identity);
            Debug.Log(count);
            count++;
        }
        yield return new WaitForSeconds(20f);
        spawning = false;
    }
    IEnumerator RandomShot()
    {
        int count = 0;
        yield return new WaitForSeconds(1f);

        for(int x=-1; x<2; x++)
        {
            for(int y=-1; y<2; y++)
            {
                direction = new Vector3(x, y, 1);

                GameObject bulletClone = Instantiate(bullet, new Vector2(0.038f, 0.028f), Quaternion.identity);

                bulletClone.name = "Bullet";
                bulletClone.tag = "Enemy";
                bulletClone.layer = 7; //Enemy·¹ÀÌ¾î

                bulletClone.GetComponent<Movement2D>().Setup(direction / 2);
            }
        }

        yield return new WaitForSeconds(7f);
        shooting = false;
    }
}
