Shader "Custom/StageTest" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_EmissiveColor("EmissiveColor",Color) = (1,1,1,1)
		_EmissiveTex("EmissiveTex",2D) = "white"{}
		_ElectColor("ElectColor",Color) = (1,1,1,1)
		_ElectTex("ElectTex",2D) = "white"{}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		sampler2D _MainTex;
		sampler2D _EmissiveTex;
		sampler2D _ElectTex;

		struct Input {
			float2 uv_MainTex;
			//float2 uv_ElectTex;
			float3 worldPos;
		};

		fixed4 _Color;
		half4 _EmissiveColor;
		half4 _ElectColor;

		float3 _LocalPos;
		float _Tester;

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//half4 Elect = tex2D(_ElectTex, IN.uv_ElectTex);
			float dist = distance(_LocalPos, IN.worldPos);
			float val = sin(dist * 3.0 - _Tester);
			//float t = ((2 * _SinTime.w * _CosTime.w) + 1) * 0.5;
			float t = 1.0f;
			float e = tex2D(_EmissiveTex, IN.uv_MainTex).a * t;

			float Ee = tex2D(_ElectTex, IN.uv_MainTex).a * t;

			if (val > 0.90f)
			{
				o.Albedo = c.rgb;
				o.Alpha = c.a;
				o.Emission = _EmissiveColor * e;
			}
			else if(val > 0.8f)
			{
				o.Albedo = c.rgb;
				o.Alpha = c.a;
				o.Emission = _ElectColor * Ee;
			}
			else
			{
				o.Albedo = c.rgb;
				o.Alpha = c.a;
				o.Emission = _ElectColor * 0;
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
