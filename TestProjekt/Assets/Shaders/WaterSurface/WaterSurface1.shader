Shader "Custom/WaterSurface1" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_FoamColor ("Foam Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_FoamTex ("Foam Caps (RGB)", 2D) = "black" {}
		_Normal ("Normal Map (bump)", 2D) = "bump" {}
		_Glossiness("Smoothness", Range(0,1.5)) = 0.2
		_Metallic("Metallic", Range(0,1)) = 0.6
		_BaseHeight("Wave min. height", float) = 0.0
		_MaxHeight ("Wave height mult.", float) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _FoamTex;
		sampler2D _Normal;
		
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			INTERNAL_DATA
			float3 worldRefl;
		};

		half _Glossiness;
		half _Metallic;
		float _BaseHeight;
		float _MaxHeight;
		fixed4 _Color;
		fixed4 _FoamColor;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float2 uvScroll1 = float2(0.03f, 0.07f) * _Time;
			float2 uvScroll2 = float2(0.04f, 0.06f) * _Time;
			
			float2 uv1 = IN.uv_MainTex + uvScroll1;
			float2 uv2 = IN.uv_MainTex - uvScroll2;
			
			// Albedo comes from a texture tinted by color
			fixed4 mc = tex2D (_MainTex, uv1) * _Color;
			fixed4 fc = tex2D (_FoamTex, uv1) * _FoamColor;

			float3 topDir = float3(0, 1, 0);
			float topReflMod = dot(IN.worldRefl, topDir);

			float y = IN.worldPos.y - _BaseHeight;
			float alpha = fc.a;
			float foamFac = clamp(y * alpha * _MaxHeight, 0.0f, 1.0f);

			o.Albedo = lerp(mc.rgb, fc.rgb, foamFac);//*foamFac
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic + (half)topReflMod;
			o.Smoothness = _Glossiness + (half)topReflMod;
			o.Alpha = mc.a;

			fixed4 norm1 = tex2D(_Normal, uv1 * 0.5f);
			fixed4 norm2 = tex2D(_Normal, uv2 * 0.5f);
			
			o.Normal = UnpackNormal(lerp(norm1, norm2, 0.75f + 0.25f * sin(0.33f *  _Time)) * 0.3f);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
