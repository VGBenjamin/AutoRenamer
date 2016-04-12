
// def file = args[0]  as File

args.getFiles { it.isVideo() }.each{ file ->
	println "File: " + file
	println "Info: " + getMediaInfo(file, template)
}

def seriesName = detectSeriesName(fs, true, false)