Shader "Hidden/Fade"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_RuleTex ("RuleTex", 2D) = "white" {}
		_Scale ("Scale", Float) = 0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _RuleTex;
			float _Scale;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 rule = tex2D(_RuleTex, i.uv);
				fixed g = (rule.r + rule.g + rule.b) / 3;
				fixed4 col = tex2D(_MainTex, i.uv);
				g = clamp(g - (_Scale * 2.0 - 1.0), 0.0, 1.0);
				col = col * g;
				return col;
			}
			ENDCG
		}
	}
}
