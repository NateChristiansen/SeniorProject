// Upgrade NOTE: replaced 'PositionFog()' with multiply of UNITY_MATRIX_MVP by position
// Upgrade NOTE: replaced 'V2F_POS_FOG' with 'float4 pos : SV_POSITION'

//
// Shader: "FX/FractalProto"
// Version: v1.0
// Written by: Thomas Phillips
//
// Anyone is free to use this shader for non-commercial or commercial projects.
//
// Description:
// Prototype fractal effect.
// I was playing with the Mandelbrot set, but wasn't that happy
// because it is essentially a static structure.
// This was an attempt to breathe a litte life into the set.
// I don't see an immediate application for this shader,
// but I hope it will inspire.
//

Shader "FX/FractalProto" {

	Properties{
		_Color("Color Tint", Color) = (1,1,1,1)
	}

		SubShader{

		ZWrite Off
		Tags{ "Queue" = "Transparent" }
		Blend One One

		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_fog_exp2
#include "UnityCG.cginc"

		float4 _Color;
	float _Rate;

	struct v2f {
		float4 pos : SV_POSITION;
		float4 texcoord : TEXCOORD0;
	};

	v2f vert(appdata_base v)
	{
		v2f o;
		o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
		o.texcoord = v.texcoord - 0.5;
		return o;
	}

	half4 frag(v2f i) : COLOR
	{
		float3 color;
	float m;
	float2 c = i.texcoord.xy;
	float2 z = float2(_SinTime[1],_CosTime[1]);
	int j;
	for (j = 0; j< 7; j++) {
		z = float2((z.x * z.x - z.y * z.y), (z.x * z.y + z.x * z.y)) + c;
	} // for j
	m = tan(pow(1 / length(z)*.5, .8));

	color = float3(m*_Color.r, m*_Color.g, m*_Color.b);
	return half4(color, 1);
	}
		ENDCG

	}
	}
		Fallback "Transparent/Diffuse"
}
