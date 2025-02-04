using Godot;
using System;
using System.IO;

using YoutubeDLSharp;
using System.Threading.Tasks;
using YoutubeDLSharp.Options;

using System.Reflection;//<---

public partial class YoutubeToWav : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var mp3 = YtToWav();
		GD.Print(mp3);
		
		//(Use this if you delete the Exes)_ = EnsureDependencies();
	}
	
	public async Task<AudioStreamMP3> YtToWav(string url = "https://www.youtube.com/watch?v=QUQsqBqxoR4")
	{
		var ytdl = new YoutubeDL();
		ytdl.YoutubeDLPath = ProjectSettings.GlobalizePath("res://assets/executables/yt-dlp.exe");
		ytdl.FFmpegPath = ProjectSettings.GlobalizePath("res://assets/executables/ffmpeg.exe");
		ytdl.OutputFolder = ProjectSettings.GlobalizePath("res://assets/media_formats/wav");
		
		//Download Audio
		var res = await ytdl.RunAudioDownload(
			url,
			AudioConversionFormat.Wav 
		);
		string path = res.Data;
		
		GD.Print(path);
		var mp3Stream = ResourceLoader.Load<AudioStreamMP3>(path);
		return mp3Stream;
	}
}
