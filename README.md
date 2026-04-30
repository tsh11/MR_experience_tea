## 研究摘要
本研究探討混合實境技術在茶文化傳承與學習中的應用，聚焦於如何透過創新設計吸引對茶文化缺乏興趣的使用者參與並激發其認同感與傳承意識。研究以方法目的鏈理論，設計了兩種不同的內容形式：其一為強調細節與操作的導向式設計，其二為營造沉浸氛圍的情境式設計。研究採初探性行動研究法，結果顯示：導向式設計透過清晰的任務結構與操作指引（如物件辨識、圖文說明），能讓使用者看見過去未曾留意的細節，並在提問與追究細部內容的過程中逐步發展興趣；而情境式設計（如虛擬場景與環境音效），引發使用者的驚訝感，進而有效導引其注意力。本研究認為，這二種設計模式分別產生不同的效果，以不同途徑引導使用者接觸、理解並重新看見本來覺得陌生或不感興趣的文化內容。

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
<div align="left">
  <a href="https://youtu.be/w-VfFGq2ASw?t=2">
    <img src="https://img.youtube.com/vi/w-VfFGq2ASw/maxresdefault.jpg" alt="專案演示影片" style="width:50%;">
  </a>
</div>
