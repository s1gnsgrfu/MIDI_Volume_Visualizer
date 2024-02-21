# MIDI_Volume_Visualizer 
[日本語版 READMEはこちら](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/README_ja.md)  

[Release Page](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/releases)
  
The MIDI slider allows you to change the volume of any software.  
  
![01](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/b48a6a18-fc01-46f9-9bd6-39e91facbc03)

## Settings
Right-click on MIDI_Volume_Visualizer in the task tray and click on Settings.  
![02](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/30fc1acc-4d75-4b5e-a9c7-de2bda8bb294)
  
You can select the desired software and change the transparency.  
![010413](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/20597f57-9707-449f-a920-0d7d1f540c64)

## Products that have been confirmed to work
keebwerk Nano.Slider

## Prerequisites
■MIDI Message  
__STATUS__ : B2  
__DATA1__ : 3F  
__DATA2__ : 0x00 - 0x7F (slider position)  
__CHANNEL__ : 3  
__EVENT__ : Control Change  
  
Monitoring status at MIDI-OX.  
![04](https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/assets/52664734/36643b47-7538-430a-bc4e-752545efdc98)

## License
Copyright (c) 2024 S'(s1gnsgrfu)  

This software is released under the MIT License.  
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
