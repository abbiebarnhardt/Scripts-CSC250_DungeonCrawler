
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class fightController : MonoBehaviour
{
    private bool isFightOver = false;
    public GameObject hero_GO, monster_GO;
    public TextMeshProUGUI hero_hp_TMP, monster_hp_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;
    public TextMeshProUGUI fightCommentaryTMP;


    // Start is called before the first frame update
    void Start()
    {
        this.fightCommentaryTMP.text = "";
        this.theMonster = new Monster("Pink Ghost");
        this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

        int num = Random.Range(0, 2); //coin flip, will produce 0 and 1 (since 2 is not included)
        if (num == 0)
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }

        StartCoroutine(fight());
    }

    private void tryAttack(Inhabitant attacker, Inhabitant defender)
    {
        StartCoroutine(MoveAndReturn());
        this.fightCommentaryTMP.text = "";
        //have attacker try to attack the defender
        int attackRoll = Random.Range(0, 20) + 1;
        if (attackRoll >= defender.getAC())
        {
            //attacker will hit the defender, lets see how hard!!!!
            int damageRoll = Random.Range(0, 4) + 2; //damage between 2 and 5
            this.fightCommentaryTMP.color = Color.red;
            this.fightCommentaryTMP.text = "Attack hits for " + damageRoll;
            defender.takeDamage(damageRoll);
        }
        else
        {
            this.fightCommentaryTMP.color = Color.blue;
            this.fightCommentaryTMP.text = "Attack Misses!!!";
        }
    }

    IEnumerator MoveAndReturn()
    {
        float moveDistance = 2.0f;
        float delay = 0.3f;
        Vector3 originalPosition = this.currentAttacker.transform.position;

        if (this.currentAttacker == this.monster_GO)
        {
            moveDistance *= -1;
        }
        // Move the GameObject to the left by 2 units
        this.currentAttacker.transform.position = new Vector3(this.currentAttacker.transform.position.x - moveDistance, this.currentAttacker.transform.position.y, this.currentAttacker.transform.position.z);

        // Wait for 0.2 seconds
        yield return new WaitForSeconds(delay);

        // Move the GameObject back to its original position
        this.currentAttacker.transform.position = originalPosition;

        if (this.currentAttacker == this.monster_GO)
        {
            this.currentAttacker = this.hero_GO;
        }
        else
        {
            this.currentAttacker = this.monster_GO;
        }
    }

    IEnumerator fight()
    {
        if (this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            //this.theCurrentAnimator.SetTrigger("attack");
            //this.hero_GO.transform.Translate(new Vector3(10, 0, 0));
            if (this.currentAttacker == this.hero_GO)
            {
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.monster_hp_TMP.text = "Monster Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (this.theMonster.getHP() <= 0)
                {
                    this.monster_GO.transform.Rotate(-90, 0, 0);
                    this.fightCommentaryTMP.text = "Hero Wins!!!";
                    MySingleton.currentPellets++;
                    this.isFightOver = true;

                    this.shouldAttack = false;
                }
                else
                {
                    yield return new WaitForSeconds(0.75f);
                    StartCoroutine(fight());
                }

            }
            else
            {
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.hero_hp_TMP.text = "Hero Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();

                //now the defender may have fewer hp...check if their are dead?
                if (MySingleton.thePlayer.getHP() <= 0)
                {
                    this.hero_GO.transform.Rotate(-90, 0, 0);
                    this.fightCommentaryTMP.text = "Monster Wins!!!!!";
                    this.isFightOver = true;
                    this.shouldAttack = false;
                }
                else
                {
                    yield return new WaitForSeconds(0.75f);
                    StartCoroutine(fight());
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isFightOver && Input.GetKeyUp(KeyCode.Space)) //when the fight is finally over
        {
            //we want to go back to the dungeon scene
            MySingleton.thePlayer.resetStats(); //give the player their hp back
            MySingleton.currentDirection = "?";
            EditorSceneManager.LoadScene("DungeonRoom");
        }

    }
}
