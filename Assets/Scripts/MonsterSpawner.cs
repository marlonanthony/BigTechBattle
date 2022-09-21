using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;
    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                // left side
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                if (randomIndex == 3 || randomIndex == 4) spawnedMonster.transform.localScale = new Vector3(.5f, .5f, 1f);
                if (randomIndex == 3) spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, 3f, 1f);
                else if (randomIndex == 5) spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, Random.Range(-3f, 3f), 1f);
                else spawnedMonster.transform.position = leftPos.position;
            }
            else
            {
                // right side
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                if (randomIndex == 3 || randomIndex == 4) spawnedMonster.transform.localScale = new Vector3(-.5f, .5f, 1f);
                else spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                if (randomIndex == 3) spawnedMonster.transform.localPosition = new Vector3(rightPos.position.x, 3f, 1f);
                else if (randomIndex == 5) spawnedMonster.transform.localPosition = new Vector3(rightPos.position.x, Random.Range(-3f, 3f), 1f);
                else spawnedMonster.transform.position = rightPos.position;
            }
        }
    }
}
