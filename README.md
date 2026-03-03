## 開發環境
* **Unity Editor**：2022.3.60f1
* **硬體**：Quest 3
* **Package**：
    - Meta XR All-in-One SDK
    - Unity Sentis

## 技術細節與功能說明

### 核心功能：物體偵測 (Object Detection)
本專案的物體偵測功能參考了 Meta 官方範例庫，實作了多物體識別與追蹤。

* **參考來源**：
  - [Unity Inference Engine For On-Device ML/CV Models](https://developers.meta.com/horizon/documentation/unity/unity-pca-sentis/#recommendations-for-using-inference-engine-on-meta-quest-devices)
  - [Meta Oculus Samples - MultiObjectDetection](https://github.com/oculus-samples/Unity-PassthroughCameraApiSamples/tree/a2c0851db7395c473bc76dbc48b95c938854064d/Assets/PassthroughCameraApiSamples/MultiObjectDetection)
* **實作技術**：
    - 使用 **Passthrough API** 獲取即時混合實境影像。
    - 結合 Meta Quest 3 的空間感知能力進行多目標偵測與標籤覆蓋。

      
## 影片展示
[![觀看演示影片]](https://youtu.be/w-VfFGq2ASw?si=SJIgiIm7GClwviBh&t=2)

<div align="center">
  <a href="https://youtu.be/w-VfFGq2ASw?t=2">
    <img src="https://img.youtube.com/vi/w-VfFGq2ASw/maxresdefault.jpg" alt="專案演示影片" style="width:80%;">
  </a>
</div>
