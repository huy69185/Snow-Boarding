﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public ParticleSystem particles;
    public PlayerMovement player;
    public AudioSource checkpointSound;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) // Kiểm tra xem collider có tag "Player" không
        {
            if (player.respawnPoint != this.transform)
            {
                checkpointSound.Play();
                particles.Play();
                player.respawnPoint = this.transform;
            }
        }
    }
}
