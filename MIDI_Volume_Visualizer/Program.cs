/*
Program.cs

Copyright (c) 2024 S'(s1gnsgrfu)

This software is released under the MIT License.
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
*/

using System.Diagnostics;

namespace MIDI_Volume_Visualizer
{

    internal class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            display form2 = new();

            Application.Run(form2);
        }
    }
}