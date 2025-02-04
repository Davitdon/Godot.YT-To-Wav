extends Node
@onready var getYoutubePlaylist: Node = $cs/GetYoutubePlaylist
@onready var youtubeToWav: Node = $cs/YoutubeToWav
@onready var trimWavFile: Node = $cs/TrimWavFile

@onready var file_dialog: FileDialog = $FileDialog 

var current_wav_from_file :AudioStreamWAV


##get_youtube_playlist.gYtP() 				//Returns a list of urls:String
##scrape_youtube.sYt(url) 					//Read hhtml code, look for videos
##youtube_to_wav.YtToWav(url) 				//Return AudioStreamWav From url

##mp_4_to_mp_3(Removed..?) 					//Should Returns I wanted to convert from mp4 to mp3 in memory... Much efficiency

func _ready() -> void:
	print("Add Godot Whisper to yourself")
	print("The node that has a c# Script:", youtubeToWav)
	print("For some reason method is :", youtubeToWav.has_method("YoutubeToWav")) # Should print true
	##Should but isn't working  ##var mp3 = await YoutubeToMp3.YtToMp3() 
	
	##Has a defualt thing it loads from internet



func _on_file_dialog_confirmed() -> void:
	return
	##should be used to convert mp3 to mp4
	#current_wav_from_file = mp4_to_wav()

func get_data_from_mp4(path : String) -> PackedByteArray:
	var file = FileAccess.open(path, FileAccess.READ)
	var mp4 :PackedByteArray= file.get_buffer(file.get_length())
	file.close()
	return mp4
	
