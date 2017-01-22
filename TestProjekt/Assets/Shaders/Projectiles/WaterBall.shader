Shader "Unlit/WaterBall"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_MaskTex ("Mask", 2D) = "grey" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			fixed4 _Color;
			sampler2D _MainTex;
			sampler2D _MaskTex;
			float4 _MainTex_ST;
			float4 _MaskTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv1 = TRANSFORM_TEX(v.uv1, _MaskTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 off1 = float2(_SinTime.x, _CosTime.x);
				float2 off2 = float2(_Time.x, -_Time.x);
				
				// sample the texture
				fixed4 outer = tex2D(_MainTex, i.uv + off1);
				fixed4 inner = tex2D(_MainTex, i.uv + off2);

				fixed4 mask = tex2D(_MaskTex, i.uv1 - off1 * 2.0f);

				return lerp(outer, inner, mask.aaaa) * _Color;
			}
			ENDCG
		}
	}
}
