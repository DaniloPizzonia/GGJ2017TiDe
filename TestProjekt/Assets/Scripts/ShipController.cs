using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

		public Vector2 userForces = new Vector2( 10.0f , 8.0f );
		public float otherWaveMultiplier = 2.0f;

		public float waveFrequency = 0.1f;

		private List<OceanWavePeak> waves = new List<OceanWavePeak>();

		public float waveRollSpeed = 2.0f;

		//        public MeshFilter waveBarFilter = null;
		public Transform waterPlane = null;

		[Range( 1 , 16 )]
		public int divisions = 4;
		public float waveCameraSway = 1.5f;

		private Texture2D tex = null;
		private Color[] pixels = null;
		public Color waveColor = new Color( 0.18f , 0.5f , 1.0f , 1.0f );
		public RawImage waveDisplayer = null;

		void Start()
		{
			ExtendWaveStream();

			tex = new Texture2D( 100 , 16 , TextureFormat.RGBA32 , false , true );
			tex.filterMode = FilterMode.Point;
			tex.wrapMode = TextureWrapMode.Clamp;
			pixels = new Color[ tex.width * tex.height ];
			for ( int i = 0 ; i < pixels.Length ; ++i )
			{
				pixels[ i ] = waveColor;
			}
		}

		private void ExtendWaveStream()
		{
			float streamLength = 0.0f;

			if ( waves.Count > 1 )
			{
				streamLength = waves[ Mathf.Max( waves.Count - 1 , 0 ) ].position;
			}

			bool isElevation = false;
			while ( streamLength < 100 )
			{
				OceanWavePeak peak = new OceanWavePeak();
				float amplitude = isElevation ? Random.Range( 0.3f , 3.0f ) : Random.Range( -3.0f , -0.3f );
				isElevation = !isElevation;

				peak.amplitude = amplitude;
				streamLength += Mathf.Abs( amplitude ) * 3.0f;
				peak.position = streamLength;

				waves.Add( peak );
			}
		}

		private void UpdateWaveVisualizer()
		{
			if ( waveDisplayer == null )
				return;

			float inv32 = 1.0f / 32.0f;
			int current = 0;

			OceanWavePeak peakA = new OceanWavePeak { position = -100.0f };
			OceanWavePeak peakB = new OceanWavePeak { position = -90.0f };

			for ( int x = 0 ; x < 100 ; ++x )
			{
				if ( (float)x > peakB.position )
				{
					current++;
					peakA = waves[ Mathf.Min( current , waves.Count - 1 ) ];
					peakB = waves[ Mathf.Min( current + 1 , waves.Count - 1 ) ];
				}


				float dist = ( (float)x - peakA.position ) / ( peakB.position - peakA.position );

				float level = Mathf.SmoothStep( peakA.amplitude , peakB.amplitude , dist );
				int fill = Mathf.RoundToInt( 8 + level * 2 );

				for ( int y = 0 ; y < 16 ; ++y )
				{
					float a = 0;
					if ( y < fill )
						a = 1;
					//else if ( y < fill + 1 )
					//	a = 0.5f;

					pixels[ y * 100 + x ].a = a;
				}
			}

			tex.SetPixels( pixels );
			tex.Apply();

			waveDisplayer.texture = tex;
		}

		/*
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
		*/

		private float UpdateWaveStream()
		{
			bool isFirst = true;
			bool killFirst = false;

			for ( int i = 0 ; i < waves.Count ; ++i )
			{
				OceanWavePeak peak = waves[ i ];
				peak.position -= Time.deltaTime * waveRollSpeed;

				waves[ i ] = peak;

				if ( !isFirst && peak.position < 0.0f )
				{
					killFirst = true;
				}

				isFirst = false;
			}

			if ( killFirst )
			{
				waves.RemoveAt( 0 );
				ExtendWaveStream();
			}

			UpdateWaveVisualizer();

			OceanWavePeak cur = waves[ 0 ];
			OceanWavePeak nxt = waves[ 1 ];

			float distance = nxt.position - cur.position;
			float passed = Mathf.Abs( cur.position );

			float passedFactor = passed / distance;

			return Mathf.SmoothStep( cur.amplitude , nxt.amplitude , passedFactor );
		}

		private void ApplyWaveTilt( Transform trans , float strength , float waveState )
		{
			Vector3 eulerAngles = trans.eulerAngles;

			float angZ = eulerAngles.z;
			float targetAng = waveState * strength;

			angZ = targetAng;
			trans.eulerAngles = new Vector3( eulerAngles.x , eulerAngles.y , angZ );
		}

		void FixedUpdate()
		{
			x = Input.GetAxisRaw( "Horizontal" );
			y = Input.GetAxisRaw( "Vertical" );

			Vector2 input = new Vector2( x * userForces.x , y * userForces.y );

			float curWave = UpdateWaveStream();

			Vector3 physForce = new Vector3( input.x + curWave * otherWaveMultiplier , 0.0f , input.y );

			foreach ( Tower tower in Root.I.Get<TowerManager>().All )
			{
				tower.GetComponent<Rigidbody>().AddForce( physForce );
			}

			if ( waterPlane != null )
			{
				ApplyWaveTilt( Camera.main.transform , waveCameraSway , curWave );
				ApplyWaveTilt( waterPlane , waveCameraSway , curWave );
			}
		}
	}

}
