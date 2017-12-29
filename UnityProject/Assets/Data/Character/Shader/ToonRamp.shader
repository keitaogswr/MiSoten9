Shader "Custom/ToonRamp" {
	Properties{
		_RampColor("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_RampTex("Ramp", 2D) = "white"{}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf ToonRamp
#pragma target 3.0
#pragma lighting ToonRamp exclude_path:prepass
	sampler2D _MainTex;
	sampler2D _RampTex;

	struct Input {
		float2 uv_MainTex;
	};

	fixed4 _RampColor;

inline half4 LightingToonRamp(SurfaceOutput s, half3 lightDir, half atten)
	{
#ifdef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
#endif
		half d = dot(s.Normal, lightDir)*0.5 + 0.5;
		half3 ramp = tex2D(_RampTex, fixed2(d, d)).rgb;
		half4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
		c.a = 0;
		return c;
	}

	void surf(Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _RampColor;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}