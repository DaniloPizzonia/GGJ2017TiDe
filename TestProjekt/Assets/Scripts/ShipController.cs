using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    struct OceanWavePeak
    {
        public float position;
        public float amplitude;
    }

    public class ShipController : MonoBehaviour
    {
        private float x = 0.0f;
        private float y = 0.0f;

        public Vector2 userForces = new Vector2(10.0f, 8.0f);
        public float otherWaveMultiplier = 2.0f;

        public float waveFrequency = 0.1f;

        private List<Rigidbody> towers = new List<Rigidbody>();
        private List<OceanWavePeak> waves = new List<OceanWavePeak>();

        public float waveRollSpeed = 2.0f;
        public float waveStreamLength = 100.0f;

        public MeshFilter waveBarFilter = null;
        public Transform waterPlane = null;

        [Range(1, 16)]
        public int divisions = 4;


        void Start()
        {
            towers.AddRange(GameObject.FindObjectsOfType<Rigidbody>());

            ExtendWaveStream();
        }

        private void ExtendWaveStream()
        {
            float streamLength = 0.0f;

            if (waves.Count > 1)
            {
                streamLength = waves[Mathf.Max(waves.Count - 1, 0)].position;
            }

            bool isElevation = false;
            while (streamLength < waveStreamLength)
            {
                OceanWavePeak peak = new OceanWavePeak();
                float amplitude = isElevation ? Random.Range(0.3f, 3.0f) : Random.Range(-3.0f, -0.3f);
                isElevation = !isElevation;

                peak.amplitude = amplitude;
                streamLength += Mathf.Abs(amplitude) * 3.0f;
                peak.position = streamLength;

                waves.Add(peak);
            }
        }

        private void UpdateWaveVisualizer()
        {
            if (waveBarFilter == null)
            {
                return;
            }

            int peakCount = waves.Count;
            float scale = 0.01f;

            int stepCount = peakCount * divisions;

            Vector3[] verts = new Vector3[stepCount * 2];
            int[] tris = new int[(2 * stepCount - 2) * 3];

            int triIndex = 0;

            for (int i = 0; i < stepCount; ++i)
            {
                int peakIndex = i / divisions;
                if (peakIndex >= waves.Count - 1)
                {
                    break;
                }

                OceanWavePeak peakA = waves[peakIndex];
                OceanWavePeak peakB = waves[peakIndex + 1];

                float distFactor = (float)(peakIndex * divisions - i) / (float)divisions;

                float pos = Mathf.SmoothStep(peakA.position, peakB.position, distFactor);
                float amp = peakA.amplitude;//Mathf.SmoothStep(peakA.amplitude, peakB.amplitude, distFactor);

                int vA = 2 * i;
                int vB = 2 * i + 1;

                verts[vA] = new Vector3(pos, 0.0f, 0) * scale;
                verts[vB] = new Vector3(pos, Mathf.Abs(3.0f + amp), 0) * scale;

                if (i < stepCount - 1)
                {
                    tris[triIndex++] = vA;
                    tris[triIndex++] = vA + 2;
                    tris[triIndex++] = vB;
                    tris[triIndex++] = vA + 2;
                    tris[triIndex++] = vB + 2;
                    tris[triIndex++] = vB;
                }
            }

            Mesh mesh = new Mesh();
            mesh.vertices = verts;
            mesh.triangles = tris;

            waveBarFilter.mesh = mesh;
        }

        private float UpdateWaveStream()
        {
            bool isFirst = true;
            bool killFirst = false;
            float height = 0.0f;

            for (int i = 0; i < waves.Count; ++i)
            {
                OceanWavePeak peak = waves[i];
                peak.position -= Time.deltaTime * waveRollSpeed;

                waves[i] = peak;

                if (!isFirst && peak.position < 0.0f)
                {
                    killFirst = true;
                }

                isFirst = false;
            }

            if (killFirst)
            {
                waves.RemoveAt(0);
                ExtendWaveStream();
            }

            UpdateWaveVisualizer();

            OceanWavePeak cur = waves[0];
            OceanWavePeak nxt = waves[1];

            float distance = nxt.position - cur.position;
            float passed = Mathf.Abs(cur.position);

            float passedFactor = passed / distance;

            return Mathf.SmoothStep(cur.amplitude, nxt.amplitude, passedFactor);
        }

        private void ApplyWaveTilt(Transform trans, float strength, float waveState)
        {
            Vector3 eulerAngles = trans.eulerAngles;

            float angZ = eulerAngles.z;
            float targetAng = waveState * strength;
  //          targetAng += Mathf.Sign(targetAng) * 360 * (Mathf.Abs(targetAng) > 180.0f ? 1.0f : 0.0f);

            angZ = targetAng;
  //          angZ = Mathf.Slerp(angZ, targetAng, Time.deltaTime * 2.0f);
            trans.eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, angZ);
        }

        void FixedUpdate()
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            Vector2 input = new Vector2(x * userForces.x, y * userForces.y);

            float curWave = UpdateWaveStream();

            if (towers != null)
            {
                Vector3 physForce = new Vector3(input.x + curWave * otherWaveMultiplier, 0.0f, input.y);

                foreach (Rigidbody rig in towers)
                {
                    rig.AddForce(physForce);
                }
            }

            if(waterPlane != null)
            {
                ApplyWaveTilt(Camera.main.transform, 1.0f, curWave);
                ApplyWaveTilt(waterPlane, -0.7f, curWave);
            }
        }
    }

}
