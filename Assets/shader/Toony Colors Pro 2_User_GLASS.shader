Shader "Toony Colors Pro 2/User/GLASS" {
	Properties {
		[TCP2HeaderHelp(BASE, Base Properties)] _Color ("Color", Vector) = (1,1,1,1)
		_HColor ("Highlight Color", Vector) = (0.785,0.785,0.785,1)
		_SColor ("Shadow Color", Vector) = (0.195,0.195,0.195,1)
		_MainTex ("Main Texture", 2D) = "white" {}
		[TCP2Separator] [TCP2Header(RAMP SETTINGS)] _RampThreshold ("Ramp Threshold", Range(0, 1)) = 0.5
		_RampSmooth ("Ramp Smoothing", Range(0.001, 1)) = 0.1
		[TCP2Separator] [TCP2HeaderHelp(SUBSURFACE SCATTERING, Subsurface Scattering)] _SSDistortion ("Distortion", Range(0, 2)) = 0.2
		_SSPower ("Power", Range(0.1, 16)) = 3
		_SSScale ("Scale", Float) = 1
		_SSColor ("Color (RGB)", Vector) = (0.5,0.5,0.5,1)
		[TCP2Separator] [TCP2HeaderHelp(SPECULAR, Specular)] _SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_Smoothness ("Size", Float) = 0.2
		_SpecSmooth ("Smoothness", Range(0, 1)) = 0.05
		[TCP2Separator] [TCP2HeaderHelp(REFLECTION, Reflection)] [NoScaleOffset] _Cube ("Cubemap", Cube) = "_Skybox" {}
		_ReflectColor ("Color (RGB) Strength (Alpha)", Vector) = (1,1,1,0.5)
		_ReflectRoughness ("Roughness", Range(0, 9)) = 0
		[TCP2Separator] [TCP2HeaderHelp(RIM, Rim)] _RimColor ("Rim Color", Vector) = (0.8,0.8,0.8,0.6)
		_RimMin ("Rim Min", Range(0, 2)) = 0.5
		_RimMax ("Rim Max", Range(0, 2)) = 1
		_RimDir ("Rim Direction", Vector) = (0,0,1,0)
		_RimColorTex ("Rim Color Texture", 2D) = "white" {}
		[TCP2Separator] [HideInInspector] __dummy__ ("unused", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "TCP2_MaterialInspector_SG"
}