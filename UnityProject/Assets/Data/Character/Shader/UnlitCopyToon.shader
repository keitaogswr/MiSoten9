Shader "Custom/UnlitCopyToon" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_RampColor("RampColor",Color) = (1,1,1,1)
		_RampTex("Ramp", 2D) = "white"{}
		_EdgeSize("Edge Size",  Float) = 1          // Edge Size
		_EdgeColor("Edge Color", Color) = (1, 1, 1, 1)
		_ToonShade("ToonShader Cubemap(RGB)", CUBE) = "" { }
		
	}
	SubShader {
		Tags {"RenderType" = "Opaque"}

		UsePass "Custom/ToonRamp/FORWARD"
		UsePass "Custom/UnlitShaderCopy/FRONT"
		UsePass "Custom/UnlitShaderCopy/OUTLINE"
		
	}
	FallBack "Diffuse"
}
