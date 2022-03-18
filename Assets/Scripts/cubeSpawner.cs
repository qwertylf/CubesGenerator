using System;
using UnityEngine;
using UnityEngine.UI;

public class cubeSpawner : MonoBehaviour
{
    private bool gameIsOn;

    private float timer;
    private float cooldown = 1f;
    private int pastStartTime = 0;
    private int distance, speed, timeCubeRespawn = 0;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject distField, speedField, respawnTimeField;

    void Update()
    {
        if (String.IsNullOrEmpty(distField.GetComponent<Text>().text) || String.IsNullOrEmpty(speedField.GetComponent<Text>().text) || String.IsNullOrEmpty(respawnTimeField.GetComponent<Text>().text))
            gameIsOn = false;
        else
        {
            if (!gameIsOn)
            {
                gameIsOn = true;
                spawnCube();
            }
        }
        if (gameIsOn)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                pastStartTime++;
                if (pastStartTime == timeCubeRespawn)
                {
                    spawnCube();
                    pastStartTime = 0;
                }
                timer = cooldown;
            }
        }
    }
    private void spawnCube()
    {
        GameObject newCube = Instantiate(cubePrefab, new Vector3(0,1,0), Quaternion.identity);
        newCube.GetComponent<cubeController>().distance = distance;
        newCube.GetComponent<cubeController>().speed = speed;
    }
    public void distanceChange()
    {
        string newDist = distField.GetComponent<Text>().text;
        distance = Convert.ToInt32(newDist);
    }
    public void speedChange()
    {
        string newSpeed = speedField.GetComponent<Text>().text;
        speed = Convert.ToInt32(newSpeed);
    }
    public void respawnTimeChange()
    {
        string newRespawnTime = respawnTimeField.GetComponent<Text>().text;
        timeCubeRespawn = Convert.ToInt32(newRespawnTime);
        pastStartTime = 0;
    }
}