using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class EnemyTrigger : MonoBehaviour {
	ParticleSystem ps;

	List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

	void OnEnable()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void OnParticleTrigger()
	{
		enter = new List<ParticleSystem.Particle>();
		int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
		for (int i = 0; i < numEnter; i++)
		{
			ParticleSystem.Particle p = enter[i];
			p.startColor = new Color32(255, 0, 0, 255);
			enter[i] = p;
		}

		foreach (ParticleSystem.Particle p in enter) {
			Debug.Log (p.GetCurrentColor(ps));
		}
		ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
	}
}