using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO, fightSpot, heroSpot, monsterSpot;
    public TextMeshProUGUI hero_hp_TMP, monster_hp_TMP, winner_TMP, commentary_TMP;
    private int heroHitPoints = 10;
    private static int monsterHitPoints = 10;
    private int heroRoll, monsterRoll;
    private int turn = 0; // even is hero, odd is monster
    private string stringTurn;
    public static string lastFightOutcome = "";


    // Start is called before the first frame update
    void Start()
    {
        setHPText();
        winner_TMP.enabled = false;
        commentary_TMP.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        hero_GO.SetActive(true);
        monster_GO.SetActive(true);
        winner_TMP.enabled = false;

        if (heroHitPoints > 0 && monsterHitPoints > 0)
        {
            if (turn % 2 == 0)
            {
                stringTurn = "hero";

                commentary_TMP.text = "It's the hero's turn...";

                if (hero_GO.transform.position != fightSpot.transform.position)
                {
                    hero_GO.transform.position = Vector3.MoveTowards(hero_GO.transform.position, fightSpot.transform.position, 10f * Time.deltaTime);
                }
                else if (hero_GO.transform.position == fightSpot.transform.position)
                {
                    hit(stringTurn);
                    turn++;
                    hero_GO.transform.position = heroSpot.transform.position;
                    setHPText();
                }
            }

            if (turn % 2 == 1)
            {
                stringTurn = "monster";

                commentary_TMP.text = "It's the monster's turn...";

                if (monster_GO.transform.position != fightSpot.transform.position)
                {
                    monster_GO.transform.position = Vector3.MoveTowards(monster_GO.transform.position, fightSpot.transform.position, 10f * Time.deltaTime);
                }

                else
                {
                    hit(stringTurn);
                    turn++;
                    monster_GO.transform.position = monsterSpot.transform.position;
                    setHPText();
                }
            }

        }

        else if (heroHitPoints <= 0)
        {
            commentary_TMP.enabled = false;
            hero_GO.SetActive(false);
            winner_TMP.text = "The monster wins!";
            winner_TMP.enabled = true;
            lastFightOutcome = "monster";
            StartCoroutine(MyCoroutine());
        }

        else if (monsterHitPoints <= 0)
        {
            commentary_TMP.enabled = false;
            monster_GO.SetActive(false);
            winner_TMP.text = "The hero wins!";
            winner_TMP.enabled = true;
            lastFightOutcome = "hero";
            StartCoroutine(MyCoroutine());
        }
    }


    private void hit(string attackingPlayer)
    {
        heroRoll = Random.Range(1, 20);
        monsterRoll = Random.Range(1, 20);

        if (heroRoll > monsterRoll && attackingPlayer.Equals("hero"))
        {
            monsterHitPoints = monsterHitPoints - Random.Range(1, 6);
            commentary_TMP.text = "The hero hit the monster!";
        }

        else if (heroRoll < monsterRoll && attackingPlayer.Equals("monster"))
        {
            heroHitPoints = heroHitPoints - Random.Range(1, 6);
            commentary_TMP.text = "The monster hit the hero!";
        }
        else
        {
            commentary_TMP.text = "The hit misses!";
        }
    }

    private void setHPText()
    {
        hero_hp_TMP.text = "Hero Hit Points: " + heroHitPoints.ToString();
        monster_hp_TMP.text = "Monster Hit Points: " + monsterHitPoints.ToString();
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        if (heroHitPoints <= 0)
        {
            MySingleton.orbCount = 0;
            MySingleton.theDungeon = MySingleton.generateDungeon();
            EditorSceneManager.LoadScene("DungeonRoom");
        }

        heroHitPoints = 10;
        monsterHitPoints = 10;
        EditorSceneManager.LoadScene("DungeonRoom");
    }


}