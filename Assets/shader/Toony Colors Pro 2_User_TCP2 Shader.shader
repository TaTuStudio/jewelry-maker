Shader "Toony Colors Pro 2/User/TCP2 Shader" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_MainTex ("Albedo", 2D) = "white" {}
		_PaintableTex ("Paintable", 2D) = "black" {}
		_DirtyTex ("Dirty", 2D) = "black" {}
		_DirtyOpaque ("Dirty Opaque", Range(0, 1)) = 1
		_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
		_Glossiness ("Smoothness", Range(0, 1)) = 0.5
		_GlossMapScale ("Smoothness Scale", Range(0, 1)) = 1
		[Gamma] _Metallic ("Metallic", Range(0, 1)) = 0
		_BumpScale ("Scale", Float) = 1
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_EmissionColor ("Color", Vector) = (0,0,0,1)
		_EmissionMap ("Emission", 2D) = "white" {}
		[HideInInspector] _Mode ("__mode", Float) = 0
		[HideInInspector] _SrcBlend ("__src", Float) = 1
		[HideInInspector] _DstBlend ("__dst", Float) = 0
		[HideInInspector] _ZWrite ("__zw", Float) = 1
		_HColor ("Highlight Color", Vector) = (0.785,0.785,0.785,1)
		_SColor ("Shadow Color", Vector) = (0.195,0.195,0.195,1)
		[Header(Ramp Shading)] _RampThreshold ("Threshold", Range(0, 1)) = 0.5
		_RampSmooth ("Main Light Smoothing", Range(0, 1)) = 0.2
		_RampSmoothAdd ("Other Lights Smoothing", Range(0, 1)) = 0.75
		[Header(HSV Controls)] _HSV_H ("Hue", Range(-360, 360)) = 0
		_HSV_S ("Saturation", Range(-1, 1)) = 0
		_HSV_V ("Value", Range(-1, 1)) = 0
		[Header(Stylized Fresnel)] [PowerSlider(3)] _RimStrength ("Strength", Range(0, 2)) = 0.5
		_RimMin ("Min", Range(0, 1)) = 0.6
		_RimMax ("Max", Range(0, 1)) = 0.85
		[HideInInspector] __dummy__ ("__unused__", Float) = 0
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
	Fallback "VertexLit"
	//CustomEditor "TCP2_MaterialInspector_SurfacePBS_SG"
}