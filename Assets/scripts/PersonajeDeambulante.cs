using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PersonajeDeambulante : MonoBehaviour
{
    public float rangoDeambular = 10f;
    public float tiempoEntreDestinos = 3f;
    public Animator animador;

    private NavMeshAgent agente;
    private float tiempoProximoMovimiento = 0f;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        ElegirNuevoDestino();
    }

    void Update()
    {
        // Actualizar animación de caminar
        if (animador != null)
        {
            animador.SetBool("caminando", agente.velocity.magnitude > 0.1f);
        }

        // Si llegó al destino o se detuvo, espera para moverse otra vez
        if (!agente.pathPending && agente.remainingDistance < 0.5f && Time.time >= tiempoProximoMovimiento)
        {
            ElegirNuevoDestino();
        }
    }

    void ElegirNuevoDestino()
    {
        Vector3 destinoAleatorio = Random.insideUnitSphere * rangoDeambular;
        destinoAleatorio += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(destinoAleatorio, out hit, rangoDeambular, NavMesh.AllAreas))
        {
            agente.SetDestination(hit.position);
        }

        tiempoProximoMovimiento = Time.time + tiempoEntreDestinos;
    }
}
