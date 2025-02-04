using Godot;
using System;
using System.Diagnostics;
using System.IO; //Path.GetFileName()


public partial class TrimWavFile : Node
{
	//Didn't test this yet
	public void TrimAudio(string inputFile, string fileName = "", string startTime = "00:00:0.0", string duration = "00:00:10.0")
	{
		string ffmpegPath = ProjectSettings.GlobalizePath("res://assets/executables/ffmpeg.exe");
		string inputPath = ProjectSettings.GlobalizePath(inputFile);
		if (fileName == "")
		{
			fileName = Path.GetFileName(inputPath);
		}
		
		string outputPath = ProjectSettings.GlobalizePath("res://assets/media_formats/wav_trim/" +fileName);

		ProcessStartInfo psi = new ProcessStartInfo
		{
			FileName = ffmpegPath,
			Arguments = $"-ss {startTime} -t {duration} -i \"{inputPath}\" -acodec copy \"{outputPath}\"",
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		Process process = new Process { StartInfo = psi };
		process.Start();

		string output = process.StandardOutput.ReadToEnd();
		string error = process.StandardError.ReadToEnd();

		process.WaitForExit();

		GD.Print("FFmpeg Output: " + output);
		GD.Print("FFmpeg Error: " + error);
	}

}
