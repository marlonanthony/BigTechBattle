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
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;

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
                switch (randomIndex)
                {
                    // AmazonDrone
                    case 3:
                        {
                            spawnedMonster.transform.localScale = new Vector3(.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, 3f, 1f);
                            break;
                        }
                    // iPhone
                    case 4:
                        {
                            spawnedMonster.transform.localScale = new Vector3(.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, -2.5f, 1f);
                            break;
                        }
                    // TwitterBird
                    case 5:
                        {
                            spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, Random.Range(-3f, 3f), 1f);
                            break;
                        }
                    // TeslaCybertruck
                    case 7:
                        {
                            spawnedMonster.transform.localScale = new Vector3(-.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(leftPos.position.x, -2.9f, 1f);
                            break;
                        }
                    default:
                        {
                            spawnedMonster.transform.position = leftPos.position;
                            break;
                        }

                }
            }
            else
            {
                // right side
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                switch (randomIndex)
                {
                    // AmazonDrone
                    case 3:
                        {
                            spawnedMonster.transform.localScale = new Vector3(-.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(player.position.x + 10f, 3f, 1f);
                            break;
                        }
                    // iPhone
                    case 4:
                        {
                            spawnedMonster.transform.localScale = new Vector3(-.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(player.position.x + 10f, -2.5f, 1f);
                            break;
                        }
                    // TwitterBird
                    case 5:
                        {
                            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(player.position.x + 10f, Random.Range(-3f, 3f), 1f);
                            break;
                        }
                    // TeslaCybertruck
                    case 7:
                        {
                            spawnedMonster.transform.localScale = new Vector3(.5f, .5f, 1f);
                            spawnedMonster.transform.localPosition = new Vector3(player.position.x + 10f, -2.9f, 1f);
                            break;
                        }
                    default:
                        {
                            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                            // Spawn monsters from just outside the rightside of the camera instead of end of map. 
                            spawnedMonster.transform.localPosition = new Vector3(player.position.x + 10f, -2.9f, 1f);
                            break;
                        }
                }
            }
        }
    }
}
