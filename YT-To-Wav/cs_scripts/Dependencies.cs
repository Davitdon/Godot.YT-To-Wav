using Godot;
using System;
using System.IO;
using YoutubeDLSharp;
using YoutubeDLSharp.Options;
using System.Threading.Tasks;
using System.Reflection;

public partial class Dependencies : Node
{
	// This script summons the dependencies
	public override void _Ready()
	{
		_ = EnsureDependencies();
	}

	public static async Task EnsureDependencies() 
	{
		//In root folder Terminal: 
		//dotnet add package YoutubeDLSharp --version 1.1.1
		
		string dirPath = ProjectSettings.GlobalizePath("res://assets/executables");

		// Check if the executables exist
		string ffmpegPath = Path.Combine(dirPath, "ffmpeg.exe");
		string ytDlpPath = Path.Combine(dirPath, "yt-dlp.exe");
		if (!File.Exists(ffmpegPath))
		{
			GD.Print("Downloading YtDlp.exe");
			await YoutubeDLSharp.Utils.DownloadYtDlp(dirPath);
			GD.Print("YtDlp.exe downloaded");
		}
		if(!File.Exists(ffmpegPath))
		{
			GD.Print("Downloading ffmpeg.exe");
			await YoutubeDLSharp.Utils.DownloadFFmpeg(dirPath);
			GD.Print("ffmpeg.exe downloaded");
		}

	}
	
	public void check_paramaters(string paramater) //Not important right now
	{
		// Get the MethodInfo for DownloadYtDlp
		MethodInfo methodInfo = typeof(Utils).GetMethod(paramater);

		if (methodInfo != null)
		{
			// Get the parameters of the method
			ParameterInfo[] parameters = methodInfo.GetParameters();

			GD.Print($"Method: {methodInfo.Name}");

			// Loop through the parameters and print their names and types
			foreach (var param in parameters)
			{
				GD.Print($"Parameter: {param.Name}, Type: {param.ParameterType}");
			}
		}
		else
		{
			GD.Print("Method not found!");
		}
	}
}
