using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public Sprite[] pipeSprites;
    public float timer = 0f;
    public float spawnRate = 20f;
    public float pipeSpeed = 2f;





    void Start(){
        SpawnPipe();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate){
            SpawnPipe();
            timer = 0;
        }
    }

    public void SpawnPipe() {
        GameObject pipe = Instantiate(pipePrefab, new Vector2(2, Random.Range(-1f, 3f)), Quaternion.identity);
        Sprite selectedSprite = pipeSprites[Random.Range(0, pipeSprites.Length)];
        AssignSpriteToPipes(pipe, selectedSprite);
        pipe.GetComponent<Pipe>().SetSpeed(pipeSpeed);
    }

    void AssignSpriteToPipes(GameObject pipe, Sprite sprite){
        SpriteRenderer[] renderers = pipe.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers){
            renderer.sprite = sprite;
        }
    }
}
