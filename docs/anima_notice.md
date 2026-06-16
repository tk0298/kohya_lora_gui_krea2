# Animaに関するヒントなど
## 重要事項
事前学習モデルに拡散モデル(`anima-base-v1.0.safetensors`)、詳細設定->パスにてVAE(`qwen_image_vae.safetensors`)およびQwen3(`qwen_3_06b_base.safetensors`)のパスを指定してください。

bf16対応GPUでは詳細設定->パフォーマンスにある混合精度を`bf16`に設定してください。

非対応環境はfp16にしてください。

保存精度はfp16でも問題ないようです。

## Anima関連の仕様
ComfyUIで出力した拡散モデルはComfyUI独自形式のためか読み込めずエラー落ちします。

これはsd-scriptsだけでなくdiffusion-pipeも同様です。

大量の`Missing keys in state dict`で落ちる場合は、おそらくComfyUIで作成されたものです。

この問題はほとんどのマージモデルで見られます。 **これは仕様です。解決策はありません。**
