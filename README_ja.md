# MIDI_Volume_Visualizer 
[Release Page](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/releases)

MIDIスライダーで，任意のソフトウェアの音量を変更することができます．
  
![01](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/b48a6a18-fc01-46f9-9bd6-39e91facbc03)

## 設定
タスクトレイ内の「MIDI_Volume_Visualizer」を右クリックし，「Settings」をクリック．  
![02](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/30fc1acc-4d75-4b5e-a9c7-de2bda8bb294)
  
任意のソフトウェアを選択でき，透明度も変更することができます．また，MIDIデバイスの変更もできます．  
![r3](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/1161658b-a2a7-4597-a6fd-0a4ccb0c5979)


## 動作確認済み商品
keebwerk Nano.Slider

## 前提条件
■MIDI Message  
__STATUS__ : B2  
__DATA1__ : 3F  
__DATA2__ : 0x00 - 0x7F (slider position)  
__CHANNEL__ : 3  
__EVENT__ : Control Change  
  
MIDI-OXでのモニター状況  
![04](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/36643b47-7538-430a-bc4e-752545efdc98)

## License
Copyright (c) 2024 S'(s1gnsgrfu)  

This software is released under the MIT License.  
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
