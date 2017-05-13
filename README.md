# Unity-Fade

## Discription
UnityでFadeIn/Outを使うAssets

## How to Use

1. `Fade.cs`をMainCameraにアタッチ  
1. 各スクリプトで以下のように使う
```cs
var fader = Camera.main.GetComponent<Fade>();
fader.FadeIn(0.5f, () => print("Finish FadeIn!"))
     .FadeOut(0.5f, () => print("Finish FadeOut!"));
```

## Method

### FadeClass
- `Fade FadeIn(float time, System.Action callback = null)`  
    time秒でフェードインした後callbackを実行
- `Fade FadeOut(float time, System.Action callback = null)`  
    time秒でフェードアウトした後callbackを実行