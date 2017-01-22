using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaves : MonoBehaviour
{
	public Vector2 waveDir = new Vector2(1,0);

	public float waveAmplitude = 1.0f;
	public float waveSpaceFrequency = 0.5f;
	public float waveTimeFrequency = 0.8f;
	public float wavePhase = 0.0f;

	public MeshFilter waterMesh = null;
	public float waterMeshScale = 200.0f;


	void Update()
	{
		if(waterMesh == null)
		{
			return;
		}

		float waveAmp = waveDir.magnitude;
		Vector2 wDir = waveDir.normalized;

		float freq = waterMeshScale * waveSpaceFrequency;

		Mesh mesh = waterMesh.mesh;

		Vector3[] verts = mesh.vertices;

		float invScale = 1.0f / waterMeshScale;
		float timePhase = Time.time * waveTimeFrequency;

		for(int i = 0; i < verts.Length; ++i)
		{
			float x = verts[i].x * wDir.x;
			float z = verts[i].y * wDir.y;

			verts[i].y = Mathf.Sin((x + z) * freq + timePhase + wavePhase) * waveAmp * invScale;
		}

		mesh.vertices = verts;
		waterMesh.mesh = mesh;
	}
}
